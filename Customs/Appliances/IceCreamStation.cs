using IceCreamParlour.Components;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace IceCreamParlour.Customs.Appliances
{
    public class IceCreamStation : CustomAppliance
    {
        public override string UniqueNameID => "iceCreamStation";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Ice Cream Station");
        public override GameObject HeldAppliancePrefab => Main.Bundle.LoadAsset<GameObject>("Ice Cream Station");
        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>()
        {
            KitchenPropertiesUtils.GetCItemProvider(ItemReferences.IceCreamVanilla, 0, 15, false, false, true, false, false, false, true),
            new CVariableProvider()
            {
                Current = 0,
                Provide1 = 1570518340,  // Ice Cream - Vanilla
                Provide2 = 502129042, // Ice Cream - Chocolate
                Provide3 = 186895094    // Ice Cream - Stawberry
            },
            new CLimitedVariableProvider()
            {
                Current = 0,
                Total = 15,
                Remaining1 = 0,
                Remaining2 = 0,
                Remaining3 = 0
            },
            new CDynamicItemProvider(),
            new CPreservesContentsOvernight(),
            new CRequiresSpecificRefresher()
        };
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>()
        {
            (Locale.English, new ApplianceInfo()
            {
                Name = "Ice Cream Station",
                Description = "Provides ice cream. Refill with handmade ice cream."
            })
        };

        public override void SetupPrefab(GameObject prefab)
        {
            VariableProviderView variableProviderView = prefab.AddComponent<VariableProviderView>();
            variableProviderView.Animator = prefab.GetComponent<Animator>();

            HoldPointContainer holdPointContainer = prefab.AddComponent<HoldPointContainer>();
            holdPointContainer.HoldPoint = prefab.transform.Find("HoldPoint");

            Transform iceCreamTransform = prefab.transform.Find("IceCream");
            if (iceCreamTransform != null)
            {
                LimitedVariableProviderView limitedVariableProviderView = iceCreamTransform.gameObject.AddComponent<LimitedVariableProviderView>();
                limitedVariableProviderView.MaxPosition1 = 0.1f;
                limitedVariableProviderView.MaxPosition2 = 0.1f;
                limitedVariableProviderView.MaxPosition3 = 0.1f;
                limitedVariableProviderView.Item1 = iceCreamTransform.Find("Offset1");
                limitedVariableProviderView.Item2 = iceCreamTransform.Find("Offset2");
                limitedVariableProviderView.Item3 = iceCreamTransform.Find("Offset3");

                Material woodDefault = MaterialUtils.GetExistingMaterial("Wood - Default");
                Material wood4Painted = MaterialUtils.GetExistingMaterial("Wood 4 - Painted");
                MaterialUtils.ApplyMaterial(prefab, "IceCream/Base_L_Counter.blend", new Material[] { woodDefault, wood4Painted, wood4Painted });

                Material knob = MaterialUtils.GetExistingMaterial("Knob");
                MaterialUtils.ApplyMaterial(prefab, "IceCream/Base_L_Counter.blend/Handle_L_Counter.blend", new Material[] { knob });

                Material metal = MaterialUtils.GetExistingMaterial("Metal");
                MaterialUtils.ApplyMaterial(prefab, "IceCream/Cube", new Material[] { metal });

                Material vanilla = MaterialUtils.GetExistingMaterial("Vanilla");
                MaterialUtils.ApplyMaterial(prefab, "IceCream/Offset1/Icecream 1", new Material[] { vanilla });

                Material chocolate = MaterialUtils.GetExistingMaterial("Chocolate");
                MaterialUtils.ApplyMaterial(prefab, "IceCream/Offset2/Icecream 2", new Material[] { chocolate });

                Material strawberry = MaterialUtils.GetExistingMaterial("Strawberry");
                MaterialUtils.ApplyMaterial(prefab, "IceCream/Offset3/Icecream 3", new Material[] { strawberry });

                Material metalDark = MaterialUtils.GetExistingMaterial("Metal Dark");
                Material doorGlass = MaterialUtils.GetExistingMaterial("Door Glass");
                MaterialUtils.ApplyMaterial(prefab, "IceCream/Lid 1", new Material[] { metalDark, doorGlass });
                MaterialUtils.ApplyMaterial(prefab, "IceCream/Lid 2", new Material[] { doorGlass, metalDark });
                MaterialUtils.ApplyMaterial(prefab, "IceCream/Lid 3", new Material[] { doorGlass, metalDark });

                MaterialUtils.ApplyMaterial(prefab, "IceCream/Top_L_Counter.blend", new Material[] { woodDefault });
            }

            GameObject titlePrefab = ((Appliance)GDOUtils.GetExistingGDO(-1533430406))?.Prefab?.transform?.Find("Colour Blind")?.Find("Title")?.gameObject;
            if (titlePrefab != null)
            {
                List<(string path, string text)> colorblindLabelRoots = new List<(string, string)>()
                {
                    ("Colour Blind", "V"),
                    ("Colour Blind (1)", "C"),
                    ("Colour Blind (2)", "S")
                };

                foreach (var item in colorblindLabelRoots)
                {
                    Transform colorblindRoot = prefab.transform.Find(item.path);
                    if (colorblindRoot != null)
                    {
                        colorblindRoot.gameObject.AddComponent<FixedWorldRotation>();
                        ColourBlindMode colorblindMode = colorblindRoot.gameObject.AddComponent<ColourBlindMode>();
                        GameObject title = GameObject.Instantiate(titlePrefab);
                        title.transform.SetParent(colorblindRoot);
                        title.transform.Reset();
                        title.transform.localRotation = Quaternion.Euler(60f, 0f, 0f);
                        TextMeshPro textMeshPro = title.GetComponent<TextMeshPro>();
                        if (textMeshPro != null)
                        {
                            textMeshPro.text = item.text;
                        }
                        title.name = "Title";
                        colorblindMode.Element = title;
                        colorblindMode.ShowInColourblindMode = true;
                        colorblindMode.ShowInNonColourblindMode = false;
                    }
                }
            }
        }
    }
}
