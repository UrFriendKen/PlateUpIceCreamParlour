using IceCreamParlour.Customs.Processes;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public class IceCreamVanilla : CustomItem
    {
        public override string UniqueNameID => "iceCreamVanilla";
        public override GameObject Prefab => PrefabManager.GetUnfrozenIceCreamInstance<IceCreamVanilla>(iceCreamMaterial: MaterialUtils.GetExistingMaterial("Vanilla"));
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(1626110274);   // Mixing Bowl - Empty
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess{
                Duration = 12f,
                IsBad = false,
                Process = GDOUtils.GetCastedGDO<Process, Freeze>(),
                Result = GDOUtils.GetCastedGDO<Item, IceCreamVanillaFrozen>()
            },
            new Item.ItemProcess{
                Duration = 2f,
                IsBad = false,
                Process = GDOUtils.GetCastedGDO<Process, FastFreeze>(),
                Result = GDOUtils.GetCastedGDO<Item, IceCreamVanillaFrozen>()
            }
        };
    }
}
