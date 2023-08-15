using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public class UnmixedIceCreamBase : CustomItemGroup
    {
        public override string UniqueNameID => "unmixedIceCreamBase";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Mixing Bowl - Ice Cream Base Unmixed");
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(1626110274);   // Mixing Bowl - Empty
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess{
                Duration = 2.5f,
                IsBad = false,
                Process = (Process)GDOUtils.GetExistingGDO(-523839730), // Knead
                Result = GDOUtils.GetCastedGDO<Item, IceCreamVanilla>()
            }
        };
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetExistingGDO(1626110274)   // Mixing Bowl - Empty
                },
                IsMandatory = true
            },
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetExistingGDO(329108931),   // Milk
                    (Item)GDOUtils.GetExistingGDO(-849164789)   // Sugar
                }
            }
        };
        public override string ColourBlindTag => "MS";

        public override void OnRegister(ItemGroup itemGroup)
        {
            ItemGroupView view = itemGroup.Prefab.GetComponent<ItemGroupView>();

            view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
            {
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(329108931),
                    GameObject = GameObjectUtils.GetChildObject(itemGroup.Prefab, "Milk"),
                    DrawAll = true
                },

                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(-849164789),
                    GameObject = GameObjectUtils.GetChildObject(itemGroup.Prefab, "Sugar"),
                    DrawAll = true
                }
            };
        }

        public override void SetupPrefab(GameObject prefab)
        {
            MaterialUtils.ApplyMaterial(prefab, "MixingBowl", new Material[] { MaterialUtils.GetExistingMaterial("Metal - Copper") });
            MaterialUtils.ApplyMaterial(prefab, "Sugar/Sugar/Cube", new Material[] { MaterialUtils.GetExistingMaterial("Metal - Brass") });
            MaterialUtils.ApplyMaterial(prefab, "Sugar/Sugar/Cube.001", new Material[] { MaterialUtils.GetExistingMaterial("Sugar") });
            MaterialUtils.ApplyMaterial(prefab, "Milk/Milk", new Material[] { MaterialUtils.GetExistingMaterial("Milk Glass"),
                                                                                MaterialUtils.GetExistingMaterial("Milk"),
                                                                                MaterialUtils.GetExistingMaterial("Plastic - Shiny Red") });

        }
    }
}
