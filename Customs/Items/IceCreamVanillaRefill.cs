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
    public class IceCreamVanillaRefill : CustomItem
    {
        public override string UniqueNameID => "iceCreamVanillaRefill";
        public override GameObject Prefab => PrefabManager.GetIceCreamRefillInstance<IceCreamVanillaRefill>(iceCreamMaterial: MaterialUtils.GetExistingMaterial("Vanilla"));
        public override List<IItemProperty> Properties => new List<IItemProperty>()
        {
            new CRefreshesSpecificProvider()
            {
                Item = 1570518340   // Ice Cream - Vanilla
            },
            new CRefreshesProviderQuantity()
        };
    }
}
