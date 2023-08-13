using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public class IceCreamChocolateRefill : CustomItem
    {
        public override string UniqueNameID => "iceCreamChocolateRefill";
        public override GameObject Prefab => PrefabManager.GetIceCreamRefillInstance<IceCreamChocolateRefill>(iceCreamMaterial: MaterialUtils.GetExistingMaterial("Chocolate"));
        public override List<IItemProperty> Properties => new List<IItemProperty>()
        {
            new CRefreshesSpecificProvider()
            {
                Item = 502129042    // Ice Cream - Chocolate
            },
            new CRefreshesProviderQuantity()
        };
    }
}
