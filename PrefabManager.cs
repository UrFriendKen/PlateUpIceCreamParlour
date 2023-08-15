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

        private static Dictionary<Type, GameObject> PanBatterPrefabs = new Dictionary<Type, GameObject>();

        private static Dictionary<string, GameObject> IceCreamConePrefabs = new Dictionary<string, GameObject>();

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

        public static GameObject GetUnfrozenIceCreamInstance<T>(string name = null, Material iceCreamMaterial = null)
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

        public static GameObject GetFrozenIceCreamInstance<T>(string name = null, Material iceCreamMaterial = null)
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

        public static GameObject GetIceCreamRefillInstance<T>(string name = null, Material iceCreamMaterial = null)
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

        public static GameObject GetPanBatterInstance<T>(string name = null, Material batterMaterial = null)
        {
            if (!PanBatterPrefabs.TryGetValue(typeof(T), out GameObject gO))
            {
                gO = GameObject.Instantiate(Main.Bundle.LoadAsset<GameObject>("Pan - Batter"));
                gO.name = name ?? "Pan - Batter";
                gO.transform.SetParent(GetHider());
                if (batterMaterial == null)
                    batterMaterial = MaterialUtils.GetExistingMaterial("Flour");
                MaterialUtils.ApplyMaterial(gO, "MixingBowl", new Material[] { MaterialUtils.GetExistingMaterial("Metal Dark") });
                MaterialUtils.ApplyMaterial(gO, "FlourBowl/Cylinder", new Material[] { batterMaterial });

                PanBatterPrefabs.Add(typeof(T), gO);
            }
            return gO;
        }

        public static GameObject GetIceCreamConeInstance(string name = null, Material material1 = null, Material material2 = null)
        {
            if (!IceCreamConePrefabs.TryGetValue(name, out GameObject gO))
            {
                gO = GameObject.Instantiate(Main.Bundle.LoadAsset<GameObject>("Ice Cream Cone"));
                gO.name = name ?? "Ice Cream Cone";
                gO.transform.SetParent(GetHider());
                if (material1 == null)
                    material1 = MaterialUtils.GetExistingMaterial("Vanilla");
                if (material2 == null)
                    material2 = MaterialUtils.GetExistingMaterial("Vanilla");
                MaterialUtils.ApplyMaterial(gO, "Cone/Cone", new Material[] { MaterialUtils.GetExistingMaterial("Cake") });
                MaterialUtils.ApplyMaterial(gO, "Flavour", new Material[] { material1 });
                MaterialUtils.ApplyMaterial(gO, "Flavour (1)", new Material[] { material2 });

                IceCreamConePrefabs.Add(name, gO);
            }
            return gO;
        }
        public static GameObject GetIceCreamConeInstance<T>(Material material1 = null, Material material2 = null)
        {
            return GetIceCreamConeInstance(typeof(T).AssemblyQualifiedName, material1, material2);
        }
    }
}
