using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public class PanBatterUncooked : CustomItemGroup
    {
        public override string UniqueNameID => "panBatterUncooked";
        public override GameObject Prefab => PrefabManager.GetPanBatterInstance<PanBatterUncooked>();
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(-622622812);   // Cookie Tin, to be replaced with custom pan
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess{
                Duration = 2f,
                IsBad = false,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
                Result = GDOUtils.GetCastedGDO<Item, PanBatterCooked>()
            }
        };
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 3,
                Min = 3,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetExistingGDO(-622622812),  // Cookie Tin, to be replaced with custom pan
                    (Item)GDOUtils.GetExistingGDO(329108931),   // Milk
                    (Item)GDOUtils.GetExistingGDO(906595973)    // Mixing Bowl - Mixed
                },
                IsMandatory = true
            }
        };
        //public override string ColourBlindTag => "C";
    }
}
