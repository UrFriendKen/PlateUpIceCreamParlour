using IceCreamParlour.Customs.Appliances;
using IceCreamParlour.Customs.Dishes;
using IceCreamParlour.Customs.Items;
using IceCreamParlour.Customs.Processes;
using Kitchen;
using KitchenData;
using KitchenLib;
using KitchenLib.Event;
using KitchenMods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

// Namespace should have "Kitchen" in the beginning
namespace IceCreamParlour
{
    public class Main : BaseMod, IModSystem
    {
        public const string MOD_GUID = "IcedMilo.PlateUp.IceCreamParlour";
        public const string MOD_NAME = "Ice Cream Parlour";
        public const string MOD_VERSION = "0.1.2";
        public const string MOD_AUTHOR = "IcedMilo";
        public const string MOD_GAMEVERSION = ">=1.1.5";

        public static AssetBundle Bundle;

        public Main() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        internal static IceCreamStation IceCreamStationAppliance = null;
        private Freeze FreezeProcess = null;
        private FastFreeze FastFreezeProcess = null;
        internal static HandmadeIceCream HandmadeIceCreamUnlock = null;

        protected override void OnInitialise()
        {
            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
        }

        private void AddGameData()
        {
            LogInfo("Attempting to register game data...");

            IceCreamStationAppliance = AddGameDataObject<IceCreamStation>();

            AddGameDataObject<UnmixedIceCreamBase>();

            AddGameDataObject<IceCreamVanilla>();
            AddGameDataObject<IceCreamVanillaFrozen>();
            AddGameDataObject<IceCreamVanillaRefill>();

            AddGameDataObject<IceCreamChocolateUnmixed>();
            AddGameDataObject<IceCreamChocolate>();
            AddGameDataObject<IceCreamChocolateFrozen>();
            AddGameDataObject<IceCreamChocolateRefill>();

            AddGameDataObject<IceCreamStrawberryUnmixed>();
            AddGameDataObject<IceCreamStrawberry>();
            AddGameDataObject<IceCreamStrawberryFrozen>();
            AddGameDataObject<IceCreamStrawberryRefill>();

            FreezeProcess = AddGameDataObject<Freeze>();
            FastFreezeProcess = AddGameDataObject<FastFreeze>();

            HandmadeIceCreamUnlock = AddGameDataObject<HandmadeIceCream>();



            AddGameDataObject<PanBatterUncooked>();
            AddGameDataObject<PanBatterCooked>();

            AddGameDataObject<ConeUnrolled>();
            AddGameDataObject<ConeRolled>();

            AddGameDataObject<IceCreamConeVV>();
            AddGameDataObject<IceCreamConeCC>();
            AddGameDataObject<IceCreamConeSS>();
            AddGameDataObject<IceCreamConeVC>();
            AddGameDataObject<IceCreamConeVS>();
            AddGameDataObject<IceCreamConeCS>();

            AddGameDataObject<IceCreamCones>();

            LogInfo("Done loading game data.");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            // TODO: Uncomment the following if you have an asset bundle.
            // TODO: Also, make sure to set EnableAssetBundleDeploy to 'true' in your ModName.csproj

            LogInfo("Attempting to load asset bundle...");
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();
            LogInfo("Done loading asset bundle.");

            // Register custom GDOs
            AddGameData();

            // Perform actions when game data is built
            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args)
            {
                if (args.gamedata.TryGet(-1857890774, out Appliance freezer))
                {
                    if (!freezer.Processes.Select(x => x.GetType()).Contains(typeof(Freeze)))
                    {
                        freezer.Processes.Add(new Appliance.ApplianceProcesses()
                        {
                            Process = FreezeProcess?.GameDataObject,
                            IsAutomatic = true,
                            Speed = 1f,
                            Validity = ProcessValidity.Generic
                        });
                    }
                }

                foreach (Appliance appliance in args.gamedata.Get<Appliance>())
                {
                    if (appliance.ID == (freezer?.ID ?? 0))
                        continue;

                    IEnumerable<Type> propertyTypes = appliance.Properties.Select(x => x.GetType());
                    IEnumerable<Type> processTypes = appliance.Processes.Select(x => x.GetType());
                    if (propertyTypes.Contains(typeof(CItemHolder)) && !processTypes.Contains(typeof(FastFreeze)))
                    {
                        appliance.Processes.Add(new Appliance.ApplianceProcesses()
                        {
                            Process = FastFreezeProcess?.GameDataObject,
                            IsAutomatic = false,
                            Speed = 0.00001f,
                            Validity = ProcessValidity.Generic
                        });
                    }
                }

                if (args.gamedata.TryGet(-241697184, out Item fireExtinguisher))
                {
                    if (!fireExtinguisher.Properties.Select(x => x.GetType()).Contains(typeof(CProcessTool)))
                    {
                        fireExtinguisher.Properties.Add(new CProcessTool()
                        {
                            Process = FastFreezeProcess?.GameDataObject.ID ?? 0,
                            Factor = 100000f
                        });
                    }
                }
            };
        }
        #region Logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }
        #endregion
    }
}
