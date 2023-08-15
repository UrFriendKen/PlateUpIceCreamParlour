using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public class ConeRolled : CustomItem
    {
        public override string UniqueNameID => "coneRolled";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Cone");

        public override void SetupPrefab(GameObject prefab)
        {
            MaterialUtils.ApplyMaterial(prefab, "Cone", new Material[] { MaterialUtils.GetExistingMaterial("Cake") });
        }
    }
}
