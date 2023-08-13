using IceCreamParlour.Customs.Processes;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public class IceCreamStrawberry : CustomItem
    {
        public override string UniqueNameID => "iceCreamStrawberry";
        public override GameObject Prefab => PrefabManager.GetUnfrozenIceCreamInstance<IceCreamStrawberry>(iceCreamMaterial: MaterialUtils.GetExistingMaterial("Strawberry"));
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(1626110274);   // Mixing Bowl - Empty
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess{
                Duration = 12f,
                IsBad = false,
                Process = GDOUtils.GetCastedGDO<Process, Freeze>(),
                Result = GDOUtils.GetCastedGDO<Item, IceCreamStrawberryFrozen>()
            },
            new Item.ItemProcess{
                Duration = 2f,
                IsBad = false,
                Process = GDOUtils.GetCastedGDO<Process, FastFreeze>(),
                Result = GDOUtils.GetCastedGDO<Item, IceCreamStrawberryFrozen>()
            }
        };
    }
}
