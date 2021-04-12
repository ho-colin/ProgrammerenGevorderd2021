namespace Decorator.Models
{
    public abstract class OptionDecorator : Vehicle
    {
        protected string optionName;

        public string OptionName => optionName;
    }
}