﻿using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public class IceCreamVanillaFrozen : CustomItem
    {
        public override string UniqueNameID => "iceCreamVanillaFrozen";
        public override GameObject Prefab => PrefabManager.GetFrozenIceCreamInstance<IceCreamVanillaFrozen>(iceCreamMaterial: MaterialUtils.GetExistingMaterial("Vanilla"));
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(1626110274);   // Mixing Bowl - Empty
        public override int SplitCount => 1;
        public override float SplitSpeed => 1f;
        public override Item SplitSubItem => GDOUtils.GetCastedGDO<Item, IceCreamVanillaRefill>();
        public override List<Item> SplitDepletedItems => new List<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(1626110274)   // Mixing Bowl - Empty
        };
    }
}
