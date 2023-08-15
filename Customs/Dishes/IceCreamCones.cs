using IceCreamParlour.Customs.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Dishes
{
    public class IceCreamCones : CustomDish
    {
        public override string UniqueNameID => "iceCreamCones";
        public override DishType Type => DishType.Dessert;
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(1378842682),  // Flour
            (Item)GDOUtils.GetExistingGDO(-849164789),  // Sugar
            (Item)GDOUtils.GetExistingGDO(1755299639),  // Egg
            (Item)GDOUtils.GetExistingGDO(329108931),   // Milk
            (Item)GDOUtils.GetExistingGDO(1626110274),  // Mixing Bowl - Empty
            (Item)GDOUtils.GetExistingGDO(1570518340),  // Ice Cream - Vanilla
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>()
        {
            (Process)GDOUtils.GetExistingGDO(-523839730),   // Knead
            (Process)GDOUtils.GetExistingGDO(1972879238)    // Cook
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>()
        {
            new Dish.MenuItem()
            {
                Item = GDOUtils.GetCastedGDO<Item, IceCreamConeVV>(),
                Phase = MenuPhase.Dessert,
                Weight = 1f
            },
            new Dish.MenuItem()
            {
                Item = GDOUtils.GetCastedGDO<Item, IceCreamConeCC>(),
                Phase = MenuPhase.Dessert,
                Weight = 1f
            },
            new Dish.MenuItem()
            {
                Item = GDOUtils.GetCastedGDO<Item, IceCreamConeSS>(),
                Phase = MenuPhase.Dessert,
                Weight = 1f
            },
            new Dish.MenuItem()
            {
                Item = GDOUtils.GetCastedGDO<Item, IceCreamConeVC>(),
                Phase = MenuPhase.Dessert,
                Weight = 1f
            },
            new Dish.MenuItem()
            {
                Item = GDOUtils.GetCastedGDO<Item, IceCreamConeVS>(),
                Phase = MenuPhase.Dessert,
                Weight = 1f
            },
            new Dish.MenuItem()
            {
                Item = GDOUtils.GetCastedGDO<Item, IceCreamConeCS>(),
                Phase = MenuPhase.Dessert,
                Weight = 1f
            }
        };
        public override GameObject IconPrefab => ((Item)GDOUtils.GetExistingGDO(ItemReferences.IceCreamServing))?.Prefab;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override bool IsUnlockable => true;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override List<Unlock> HardcodedRequirements => new List<Unlock>()
        {
            (Dish)GDOUtils.GetExistingGDO(373996608)    // Ice Cream
        };
        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>()
        {
            (Locale.English, LocalisationUtils.CreateUnlockInfo("Ice Cream - Cones", "Adds ice cream cones as a dessert", "Are cone hats named after cones? Or are cones named after cone hats?"))
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>()
        {
            { Locale.English, "Make cake batter and add milk. Put mixture into a pan and cook. Portion and roll to make a cone. Add ice cream before serving." }
        };

        public override void OnRegister(Dish gameDataObject)
        {
            base.OnRegister(gameDataObject);
            gameDataObject.Difficulty = 2;
            gameDataObject.AlsoAddRecipes = new List<Dish>()
            {
                (Dish)GDOUtils.GetExistingGDO(-1115351824)  // Cake Batter (Recipe Only)
            };
        }
    }
}
