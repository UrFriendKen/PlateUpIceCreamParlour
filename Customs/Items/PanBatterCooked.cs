using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public class PanBatterCooked : CustomItem
    {
        public override string UniqueNameID => "panBatterCooked";
        public override GameObject Prefab => PrefabManager.GetPanBatterInstance<PanBatterCooked>(batterMaterial: MaterialUtils.GetExistingMaterial("Cake"));
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(-622622812);   // Cookie Tin, to be replaced with custom pan
        public override int SplitCount => 3;
        public override float SplitSpeed => 1f;
        public override Item SplitSubItem => GDOUtils.GetCastedGDO<Item, ConeUnrolled>();
        public override List<Item> SplitDepletedItems => new List<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(-622622812)   // Cookie Tin, to be replaced with custom pan
        };
    }
}
