using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public class IceCreamChocolateFrozen : CustomItem
    {
        public override string UniqueNameID => "iceCreamChocolateFrozen";
        public override GameObject Prefab => PrefabManager.GetFrozenIceCreamInstance<IceCreamChocolateFrozen>(iceCreamMaterial: MaterialUtils.GetExistingMaterial("Chocolate"));
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(1626110274);   // Mixing Bowl - Empty
        public override int SplitCount => 1;
        public override float SplitSpeed => 1f;
        public override Item SplitSubItem => GDOUtils.GetCastedGDO<Item, IceCreamChocolateRefill>();
        public override List<Item> SplitDepletedItems => new List<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(1626110274)   // Mixing Bowl - Empty
        };
    }
}
