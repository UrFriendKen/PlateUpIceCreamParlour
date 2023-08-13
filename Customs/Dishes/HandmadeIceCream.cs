using IceCreamParlour.Customs.Processes;
using IngredientLib.Ingredient.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Dishes
{
    public class HandmadeIceCream : CustomDish
    {
        public override string UniqueNameID => "handmadeIceCream";
        public override DishType Type => DishType.Extra;
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(1069000119),  // Chocolate
            (Item)GDOUtils.GetExistingGDO(-849164789),  // Sugar
            (Item)GDOUtils.GetExistingGDO(329108931),   // Milk
            (Item)GDOUtils.GetExistingGDO(1626110274),  // Mixing Bowl - Empty
            (Item)GDOUtils.GetExistingGDO(1570518340),  // Ice Cream - Vanilla
            GDOUtils.GetCastedGDO<Item, Strawberry>()
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>()
        {
            (Process)GDOUtils.GetExistingGDO(-523839730),   // Knead
            (Process)GDOUtils.GetExistingGDO(1972879238),   // Cook
            (Process)GDOUtils.GetExistingGDO(2087693779),   // Chop
            GDOUtils.GetCastedGDO<Process, Freeze>(),
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
            (Locale.English, LocalisationUtils.CreateUnlockInfo("Handmade Ice Cream", "Make your own Ice Cream instead of using premade", "I'd like it fresh, please!"))
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>()
        {
            { Locale.English, "Mix milk and sugar in a mixing bowl. Add chocolate or strawberry, if required, and mix. Freeze in freezer, or with fire extinguisher. Portion to get ice cream refill. Put ice cream refill into Ice Cream Station for 15 ice cream portions." }
        };

        public override void OnRegister(Dish gameDataObject)
        {
            base.OnRegister(gameDataObject);
            gameDataObject.Difficulty = 2;
        }
    }
}
