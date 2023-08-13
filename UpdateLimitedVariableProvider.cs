using IceCreamParlour.Components;
using Kitchen;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace IceCreamParlour
{
    public class UpdateLimitedVariableProvider : GenericSystemBase, IModSystem
    {
        EntityQuery Providers;

        protected override void Initialise()
        {
            base.Initialise();
            Providers = GetEntityQuery(typeof(CLimitedVariableProvider), typeof(CVariableProvider), typeof(CItemProvider));
        }
        protected override void OnUpdate()
        {
            using NativeArray<Entity> entities = Providers.ToEntityArray(Allocator.Temp);
            using NativeArray<CItemProvider> providers = Providers.ToComponentDataArray<CItemProvider>(Allocator.Temp);
            using NativeArray<CVariableProvider> variables = Providers.ToComponentDataArray<CVariableProvider>(Allocator.Temp);
            using NativeArray<CLimitedVariableProvider> limitedVariables = Providers.ToComponentDataArray<CLimitedVariableProvider>(Allocator.Temp);

            for (int i = 0; i < entities.Length; i++)
            {
                CVariableProvider variable = variables[i];
                CLimitedVariableProvider limitedVariable = limitedVariables[i];
                Entity entity = entities[i];
                CItemProvider provider = providers[i];

                if (limitedVariable.Current == variable.Current)
                {
                    limitedVariable.Total = provider.Maximum;
                    limitedVariable.SetRemaining(provider.Available);
                    Set(entity, limitedVariable);
                    continue;
                }

                limitedVariable.Total = provider.Maximum;
                limitedVariable.SetRemaining(Mathf.Clamp(provider.Available, 0, provider.Maximum));
                limitedVariable.Current = variable.Current;
                Set(entity, limitedVariable);

                provider.Available = Mathf.Clamp(limitedVariable.Remaining, 0, provider.Maximum);
                Set(entity, provider);
            }
        }
    }
}
