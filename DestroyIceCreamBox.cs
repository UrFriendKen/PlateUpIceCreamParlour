using Kitchen;
using KitchenMods;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace IceCreamParlour
{
    public class DestroyIceCreamBox : GenericSystemBase, IModSystem
    {
        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct SInit : IComponentData, IModComponent { }

        EntityQuery Unlocks;
        EntityQuery Appliances;

        protected override void Initialise()
        {
            base.Initialise();
            Unlocks = GetEntityQuery(typeof(CProgressionUnlock));
            Appliances = GetEntityQuery(typeof(CAppliance));
        }

        protected override void OnUpdate()
        {
            bool hasCard = false;
            using NativeArray<CProgressionUnlock> unlocks = Unlocks.ToComponentDataArray<CProgressionUnlock>(Allocator.Temp);
            for (int i = 0; i < unlocks.Length; i++)
            {
                CProgressionUnlock unlock = unlocks[i];
                if (unlock.ID == (Main.HandmadeIceCreamUnlock?.ID ?? 0))
                {
                    hasCard = true;
                    break;
                }
            }

            if (!hasCard)
                return;

            bool hasIceCreamStation = false;
            int iceCreamStationID = Main.IceCreamStationAppliance?.ID ?? 0;

            using NativeArray<Entity> applianceEntities = Appliances.ToEntityArray(Allocator.Temp);
            using NativeArray<CAppliance> appliances = Appliances.ToComponentDataArray<CAppliance>(Allocator.Temp);

            for (int j = applianceEntities.Length - 1; j > -1; j--)
            {
                Entity applianceEntity = applianceEntities[j];
                CAppliance appliance = appliances[j];

                if (appliance.ID == -1533430406)    // Source - Ice Cream
                {
                    EntityManager.DestroyEntity(applianceEntity);
                    continue;
                }
                if (appliance.ID == iceCreamStationID)
                {
                    hasIceCreamStation = true;
                }
            }

            if (!hasIceCreamStation && Main.IceCreamStationAppliance != null)
            {
                int offset = 0;
                List<Vector3> postTiles = GetPostTiles();
                PostHelpers.CreateApplianceParcel(EntityManager, GetParcelTile(postTiles, ref offset), iceCreamStationID);
            }
        }

        private Vector3 GetParcelTile(List<Vector3> tiles, ref int offset)
        {
            Vector3 vector = Vector3.zero;
            bool flag = false;
            while (!flag && offset < tiles.Count)
            {
                vector = tiles[offset++];
                if (GetOccupant(vector) == default(Entity) && !GetTile(vector).HasFeature)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                return vector;
            }
            return GetFallbackTile();
        }
    }
}
