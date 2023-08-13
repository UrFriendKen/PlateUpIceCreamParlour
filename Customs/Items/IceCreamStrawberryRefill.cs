using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

namespace IceCreamParlour.Customs.Items
{
    public class IceCreamStrawberryRefill : CustomItem
    {
        public override string UniqueNameID => "iceCreamStrawberryRefill";
        public override GameObject Prefab => PrefabManager.GetIceCreamRefillInstance<IceCreamStrawberryRefill>(iceCreamMaterial: MaterialUtils.GetExistingMaterial("Strawberry"));
        public override List<IItemProperty> Properties => new List<IItemProperty>()
        {
            new CRefreshesSpecificProvider()
            {
                Item = 186895094    // Ice Cream - Strawberry
            },
            new CRefreshesProviderQuantity()
        };
    }
}
