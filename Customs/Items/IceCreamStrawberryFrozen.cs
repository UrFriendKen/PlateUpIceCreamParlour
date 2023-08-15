using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public class IceCreamStrawberryFrozen : CustomItem
    {
        public override string UniqueNameID => "iceCreamStrawberryFrozen";
        public override GameObject Prefab => PrefabManager.GetFrozenIceCreamInstance<IceCreamStrawberryFrozen>(iceCreamMaterial: MaterialUtils.GetExistingMaterial("Strawberry"));
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(1626110274);   // Mixing Bowl - Empty
        public override int SplitCount => 1;
        public override float SplitSpeed => 1f;
        public override Item SplitSubItem => GDOUtils.GetCastedGDO<Item, IceCreamStrawberryRefill>();
        public override List<Item> SplitDepletedItems => new List<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(1626110274)   // Mixing Bowl - Empty
        };
    }
}
