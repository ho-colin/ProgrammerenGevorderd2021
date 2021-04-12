namespace Decorator.Models
{
    public class AdaptiveCruiseControl : OptionDecorator
    {
        Vehicle _vehicle;

        public AdaptiveCruiseControl(Vehicle vehicle)
        {
            _vehicle = vehicle;
            optionName = "Adaptive CruiseControl";
            description = vehicle.GetDescription() + ", " + optionName;
        }

        public override int Price()
        {
            return 550 + _vehicle.Price();
        }
    }
}