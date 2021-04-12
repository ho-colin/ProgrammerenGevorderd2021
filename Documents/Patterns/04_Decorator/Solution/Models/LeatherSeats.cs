namespace Decorator.Models
{
    public class LeatherSeats : OptionDecorator
    {
        Vehicle _vehicle;

        public LeatherSeats(Vehicle vehicle)
        {
            _vehicle = vehicle;
            optionName = "Leather Seats";
            description = _vehicle.GetDescription() + ", " + optionName;
        }

        public override int Price()
        {
            return 1200 + _vehicle.Price();
        }
    }
}