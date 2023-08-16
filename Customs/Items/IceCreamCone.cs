using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace IceCreamParlour.Customs.Items
{
    public abstract class IceCreamConeBase : CustomItemGroup
    {
        protected const int ICE_CREAM_VANILLA = 1570518340;
        protected const int ICE_CREAM_CHOCOLATE = 502129042;
        protected const int ICE_CREAM_STRAWBERRY = 186895094;

        public override sealed string UniqueNameID => GetType().Name;

        private readonly int _flavour1;
        private readonly int _flavour2;

        const string DEFAULT_MATERIAL_NAME = "Vanilla";

        public override GameObject Prefab => PrefabManager.GetIceCreamConeInstance(GetType().AssemblyQualifiedName, GetMaterial(_flavour2), GetMaterial(_flavour1));

        static Dictionary<int, string> _materialMap = new Dictionary<int, string>()
        {
            { ICE_CREAM_VANILLA, "Vanilla" },
            { ICE_CREAM_CHOCOLATE, "Chocolate" },
            { ICE_CREAM_STRAWBERRY, "Strawberry" }
        };

        public IceCreamConeBase(int flavourID1, int flavourID2)
        {
            _flavour1 = flavourID1;
            _flavour2 = flavourID2;
        }

        private Material GetMaterial(int itemID)
        {
            if (!_materialMap.TryGetValue(itemID, out string materialName))
                materialName = DEFAULT_MATERIAL_NAME;
            return MaterialUtils.GetExistingMaterial(materialName);
        }

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Items = new List<Item>()
                {
                    GDOUtils.GetCastedGDO<Item, ConeRolled>()
                },
                Min = 1,
                Max = 1,
                IsMandatory = true
            },
            new ItemGroup.ItemSet()
            {
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetExistingGDO(_flavour1),
                    (Item)GDOUtils.GetExistingGDO(_flavour2)
                },
                Min = 2,
                Max = 2
            }
        };

        public override void OnRegister(ItemGroup itemGroup)
        {
            ItemGroupView view = itemGroup.Prefab.GetComponent<ItemGroupView>();

            if (_flavour1 == _flavour2)
            {
                view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
                {
                    new ItemGroupView.ComponentGroup
                    {
                        Item = GDOUtils.GetCastedGDO<Item, ConeRolled>(),
                        GameObject = GameObjectUtils.GetChildObject(itemGroup.Prefab, "Cone"),
                        DrawAll = true
                    },
                    new ItemGroupView.ComponentGroup
                    {
                        Item = (Item)GDOUtils.GetExistingGDO(_flavour1),
                        Objects = new List<GameObject>()
                        {
                            GameObjectUtils.GetChildObject(itemGroup.Prefab, "Flavour"),
                            GameObjectUtils.GetChildObject(itemGroup.Prefab, "Flavour (1)")
                        },
                        DrawAll = false
                    }
                };
            }
            else
            {
                view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
                {
                    new ItemGroupView.ComponentGroup
                    {
                        Item = GDOUtils.GetCastedGDO<Item, ConeRolled>(),
                        GameObject = GameObjectUtils.GetChildObject(itemGroup.Prefab, "Cone"),
                        DrawAll = true
                    },
                    new ItemGroupView.ComponentGroup
                    {
                        Item = (Item)GDOUtils.GetExistingGDO(_flavour2),
                        Objects = new List<GameObject>()
                        {
                            GameObjectUtils.GetChildObject(itemGroup.Prefab, "Flavour")
                        },
                        DrawAll = true
                    },
                    new ItemGroupView.ComponentGroup
                    {
                        Item = (Item)GDOUtils.GetExistingGDO(_flavour1),
                        Objects = new List<GameObject>()
                        {
                            GameObjectUtils.GetChildObject(itemGroup.Prefab, "Flavour (1)")
                        },
                        DrawAll = true
                    }
                };
            }
            
        }
    }

    public class IceCreamConeVV : IceCreamConeBase
    {
        public IceCreamConeVV() : base(ICE_CREAM_VANILLA, ICE_CREAM_VANILLA)
        {
        }
    }

    public class IceCreamConeCC : IceCreamConeBase
    {
        public IceCreamConeCC() : base(ICE_CREAM_CHOCOLATE, ICE_CREAM_CHOCOLATE)
        {
        }
    }

    public class IceCreamConeSS : IceCreamConeBase
    {
        public IceCreamConeSS() : base(ICE_CREAM_STRAWBERRY, ICE_CREAM_STRAWBERRY)
        {
        }
    }

    public class IceCreamConeVC : IceCreamConeBase
    {
        public IceCreamConeVC() : base(ICE_CREAM_VANILLA, ICE_CREAM_CHOCOLATE)
        {
        }
    }

    public class IceCreamConeVS : IceCreamConeBase
    {
        public IceCreamConeVS() : base(ICE_CREAM_VANILLA, ICE_CREAM_STRAWBERRY)
        {
        }
    }

    public class IceCreamConeCS : IceCreamConeBase
    {
        public IceCreamConeCS() : base(ICE_CREAM_CHOCOLATE, ICE_CREAM_STRAWBERRY)
        {
        }
    }
}
