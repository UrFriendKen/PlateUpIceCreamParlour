using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public class ConeUnrolled : CustomItem
    {
        public override string UniqueNameID => "coneUnrolled";
        public override GameObject Prefab => TestCubes.TestCubeManager.GetPrefab<ConeUnrolled>(0.45f, 0.03f, 0.45f, MaterialUtils.GetExistingMaterial("Cake"), false);
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>()
        {
            new Item.ItemProcess()
            {
                Process = (Process)GDOUtils.GetExistingGDO(-523839730), // Knead
                Duration = 1f,
                IsBad = false,
                Result = GDOUtils.GetCastedGDO<Item, ConeRolled>()
            }
        };
    }
}
