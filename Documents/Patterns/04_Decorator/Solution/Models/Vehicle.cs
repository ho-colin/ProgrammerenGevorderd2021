using System;

namespace Decorator.Models
{
    public abstract class Vehicle
    {
        protected string description = "Undefined";

        public string GetDescription()
        {
            return description;
        }

        public abstract int Price();
    }

    public class AlfaRomeo : Vehicle
    {
        public AlfaRomeo()
        {
            description = "Alfa Romeo Giulia";
        }

        public override int Price()
        {
            return 40000;
        }
    }
}