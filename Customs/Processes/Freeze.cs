using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamParlour.Customs.Processes
{
    public class Freeze : CustomProcess
    {
        public override string UniqueNameID => "freeze";
        public override GameDataObject BasicEnablingAppliance => GDOUtils.GetExistingGDO(-1857890774);  // Freezer
        public override int EnablingApplianceCount => 2;
        public override Process IsPseudoprocessFor => null;
        public override bool CanObfuscateProgress => true;
        public override List<(Locale, ProcessInfo)> InfoList => new List<(Locale, ProcessInfo)>()
        {
            (Locale.English, new ProcessInfo()
            {
                Name = "Freeze",
                Icon = "<sprite name=\"snow\">"
            })
        };
    }
}
