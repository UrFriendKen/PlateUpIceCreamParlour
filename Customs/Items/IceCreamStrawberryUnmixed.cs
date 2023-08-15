using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public class IceCreamStrawberryUnmixed : CustomItemGroup
    {
        public override string UniqueNameID => "iceCreamStrawberryUnmixed";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Mixing Bowl - Ice Cream Base");
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(1626110274);   // Mixing Bowl - Empty
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess{
                Duration = 2f,
                IsBad = false,
                Process = (Process)GDOUtils.GetExistingGDO(-523839730), // Knead
                Result = GDOUtils.GetCastedGDO<Item, IceCreamStrawberry>()
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
                    GDOUtils.GetCastedGDO<Item, IceCreamVanilla>()
                },
                IsMandatory = true
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    GDOUtils.GetCastedGDO<Item, ChoppedStrawberry>()
                }
            }
        };
        public override string ColourBlindTag => "C";

        public override void OnRegister(ItemGroup itemGroup)
        {
            ItemGroupView view = itemGroup.Prefab.GetComponent<ItemGroupView>();

            view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
            {
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(-1004033684),
                    GameObject = GameObjectUtils.GetChildObject(itemGroup.Prefab, "Flavours/Chocolate"),
                    DrawAll = false
                },
                new ItemGroupView.ComponentGroup
                {
                    Item = GDOUtils.GetCastedGDO<Item, ChoppedStrawberry>(),
                    GameObject = GameObjectUtils.GetChildObject(itemGroup.Prefab, "Flavours/Strawberry"),
                    DrawAll = false
                }
            };
        }

        public override void SetupPrefab(GameObject prefab)
        {
            MaterialUtils.ApplyMaterial(prefab, "MixingBowl", new Material[] { MaterialUtils.GetExistingMaterial("Metal - Copper") });
            MaterialUtils.ApplyMaterial(prefab, "FlourBowl/Cylinder", new Material[] { MaterialUtils.GetExistingMaterial("Vanilla") });
            MaterialUtils.ApplyMaterial(prefab, "Flavours/Chocolate/Chocolate/Cookie", new Material[] { MaterialUtils.GetExistingMaterial("Lit") });
            MaterialUtils.ApplyMaterial(prefab, "Flavours/Chocolate/Chocolate/Plane", new Material[] { MaterialUtils.GetExistingMaterial("Chocolate") });
            MaterialUtils.ApplyMaterial(prefab, "Flavours/Chocolate/Flour/FlourBowl/Cylinder", new Material[] { MaterialUtils.GetExistingMaterial("Chocolate") });

            MaterialUtils.ApplyMaterialToChildren(prefab.GetChild("Flavours/Strawberry/Chopped Strawberry"), "Strawberry", "Strawberry", "Strawberry Inside");
        }
    }
}
