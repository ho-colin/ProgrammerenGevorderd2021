namespace Decorator.Models
{
    public class ParkingSensors : OptionDecorator
    {
        Vehicle _vehicle;

        public ParkingSensors(Vehicle vehicle)
        {
            _vehicle = vehicle;
            optionName = "Parking Sensors";
            description = vehicle.GetDescription() + ", " + optionName;
        }

        public override int Price()
        {
            return 350 + _vehicle.Price();
        }
    }
}