using IceCreamParlour.Components;
using Kitchen;
using KitchenMods;
using MessagePack;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace IceCreamParlour
{
    public class LimitedVariableProviderView : UpdatableObjectView<LimitedVariableProviderView.ViewData>
    {
        public class UpdateView : IncrementalViewSystemBase<ViewData>, IModSystem
        {
            EntityQuery Views;
            protected override void Initialise()
            {
                base.Initialise();
                Views = GetEntityQuery(typeof(CLimitedVariableProvider), typeof(CLinkedView));
            }

            protected override void OnUpdate()
            {
                using NativeArray<CLimitedVariableProvider> limitedVariableProviders = Views.ToComponentDataArray<CLimitedVariableProvider>(Allocator.Temp);
                using NativeArray<CLinkedView> views = Views.ToComponentDataArray<CLinkedView>(Allocator.Temp);

                for (int i = 0; i < views.Length; i++)
                {
                    CLinkedView view = views[i];
                    CLimitedVariableProvider limitedVariableProvider = limitedVariableProviders[i];

                    SendUpdate(view, new ViewData()
                    {
                        Remaining1 = limitedVariableProvider.Remaining1,
                        Remaining2 = limitedVariableProvider.Remaining2,
                        Remaining3 = limitedVariableProvider.Remaining3,
                        Total = limitedVariableProvider.Total
                    }, MessageType.SpecificViewUpdate);
                }
            }
        }

        [MessagePackObject(false)]
        public class ViewData : ISpecificViewData, IViewData.ICheckForChanges<ViewData>
        {
            [Key(0)] public int Remaining1;
            [Key(1)] public int Remaining2;
            [Key(2)] public int Remaining3;
            [Key(3)] public int Total;

            public IUpdatableObject GetRelevantSubview(IObjectView view) => view.GetSubView<LimitedVariableProviderView>();

            public bool IsChangedFrom(ViewData check)
            {
                return Remaining1 != check.Remaining1 ||
                    Remaining2 != check.Remaining2 ||
                    Remaining3 != check.Remaining3 || 
                    Total != check.Total;
            }
        }

        public Transform Item1;
        public float MaxPosition1 = 0f;

        public Transform Item2;
        public float MaxPosition2 = 0f;

        public Transform Item3;
        public float MaxPosition3 = 0f;

        protected override void UpdateData(ViewData data)
        {
            int total = data.Total > 0 ? data.Total : 1;
            if (Item1 != null)
            {
                Item1.localPosition = new Vector3(0f, Mathf.Clamp01(((float)data.Remaining1) / total) * MaxPosition1, 0f);
            }
            if (Item2 != null)
            {
                Item2.localPosition = new Vector3(0f, Mathf.Clamp01(((float)data.Remaining2) / total) * MaxPosition2, 0f);
            }
            if (Item3 != null)
            {
                Item3.localPosition = new Vector3(0f, Mathf.Clamp01(((float)data.Remaining3) / total) * MaxPosition3, 0f);
            }
        }
    }
}
