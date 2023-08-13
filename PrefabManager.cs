using Kitchen;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace IceCreamParlour
{
    public static class PrefabManager
    {
        private static Transform Hider = null;

        private static Dictionary<Type, GameObject> UnfrozenIceCreamPrefabs = new Dictionary<Type, GameObject>();

        private static Dictionary<Type, GameObject> FrozenIceCreamPrefabs = new Dictionary<Type, GameObject>();

        private static Transform GetHider()
        {
            if (Hider == null)
            {
                GameObject hiderGO = new GameObject("IceCreamParlour - Hider");
                hiderGO.SetActive(false);
                Hider = hiderGO.transform;
            }
            return Hider;
        }

        public static GameObject GetUnfrozenIceCreamInstance<T>(string name = null, Material iceCreamMaterial = null) where T : CustomItem
        {
            if (!UnfrozenIceCreamPrefabs.TryGetValue(typeof(T), out GameObject gO))
            {
                gO = GameObject.Instantiate(Main.Bundle.LoadAsset<GameObject>("Mixing Bowl - Ice Cream Unfrozen"));
                gO.name = name ?? "Mixing Bowl - Ice Cream Unfrozen";
                gO.transform.SetParent(GetHider());
                if (iceCreamMaterial == null)
                    iceCreamMaterial = MaterialUtils.GetExistingMaterial("Vanilla");
                MaterialUtils.ApplyMaterial(gO, "MixingBowl", new Material[] { MaterialUtils.GetExistingMaterial("Metal - Copper") });
                MaterialUtils.ApplyMaterial(gO, "FlourBowl/Cylinder", new Material[] { iceCreamMaterial });

                UnfrozenIceCreamPrefabs.Add(typeof(T), gO);
            }
            return gO;
        }

        public static GameObject GetFrozenIceCreamInstance<T>(string name = null, Material iceCreamMaterial = null) where T : CustomItem
        {
            if (!FrozenIceCreamPrefabs.TryGetValue(typeof(T), out GameObject gO))
            {
                gO = GameObject.Instantiate(Main.Bundle.LoadAsset<GameObject>("Mixing Bowl - Ice Cream Frozen"));
                gO.name = name ?? "Mixing Bowl - Ice Cream Frozen";
                gO.transform.SetParent(GetHider());
                if (iceCreamMaterial == null)
                    iceCreamMaterial = MaterialUtils.GetExistingMaterial("Vanilla");
                MaterialUtils.ApplyMaterial(gO, "MixingBowl", new Material[] { MaterialUtils.GetExistingMaterial("Metal - Copper") });
                MaterialUtils.ApplyMaterial(gO, "FlourBowl/Cylinder", new Material[] { iceCreamMaterial });

                FrozenIceCreamPrefabs.Add(typeof(T), gO);
            }
            return gO;
        }

        public static GameObject GetIceCreamRefillInstance<T>(string name = null, Material iceCreamMaterial = null) where T : CustomItem
        {
            if (!FrozenIceCreamPrefabs.TryGetValue(typeof(T), out GameObject gO))
            {
                gO = GameObject.Instantiate(Main.Bundle.LoadAsset<GameObject>("Ice Cream Refill"));
                gO.name = name ?? "Ice Cream Refill";
                gO.transform.SetParent(GetHider());
                if (iceCreamMaterial == null)
                    iceCreamMaterial = MaterialUtils.GetExistingMaterial("Vanilla");
                MaterialUtils.ApplyMaterial(gO, "MixingBowl", new Material[] { MaterialUtils.GetExistingMaterial("Metal Dark") });
                MaterialUtils.ApplyMaterial(gO, "FlourBowl/Cylinder", new Material[] { iceCreamMaterial });

                FrozenIceCreamPrefabs.Add(typeof(T), gO);
            }
            return gO;
        }
    }
}
