using KitchenData;
using KitchenMods;
using System.Data.OleDb;
using Unity.Entities;

namespace IceCreamParlour.Components
{
    public struct CLimitedVariableProvider : IApplianceProperty, IAttachableProperty, IComponentData, IModComponent
    {
        public int Current;

        public int Total;

        public int Remaining1;
        public int Remaining2;
        public int Remaining3;

        public int Remaining
        {
            get
            {
                switch (Current)
                {
                    case 0:
                        return Remaining1;
                    case 1:
                        return Remaining2;
                    case 2:
                        return Remaining3;
                    default:
                        return Remaining1;
                }
            }
        }

        public void SetRemaining(int count)
        {
            switch (Current)
            {
                case 0:
                    Remaining1 = count;
                    break;
                case 1:
                    Remaining2 = count;
                    break;
                case 2:
                    Remaining3 = count;
                    break;
                default:
                    Remaining1 = count;
                    break;
            }
        }
    }
}
