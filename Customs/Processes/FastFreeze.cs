using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;

namespace IceCreamParlour.Customs.Processes
{
    public class FastFreeze : CustomProcess
    {
        public override string UniqueNameID => "fastFreeze";
        public override GameDataObject BasicEnablingAppliance => GDOUtils.GetExistingGDO(1286554202);  // Fire Extinguisher Holder
        public override int EnablingApplianceCount => 1;
        public override Process IsPseudoprocessFor => GDOUtils.GetCastedGDO<Process, Freeze>();
        public override bool CanObfuscateProgress => true;
        public override List<(Locale, ProcessInfo)> InfoList => new List<(Locale, ProcessInfo)>()
        {
            (Locale.English, new ProcessInfo()
            {
                Name = "Fast Freeze",
                Icon = "<sprite name=\"extinguish\">"
            })
        };
    }
}
