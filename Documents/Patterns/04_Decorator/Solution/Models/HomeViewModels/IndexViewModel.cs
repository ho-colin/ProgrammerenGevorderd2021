using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Decorator.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public Vehicle Car { get; }

        [Display(Name = "Available options")]
        public IList<OptionDecorator> Options { get; }

        [Display(Name = "Your selection")]
        public Vehicle Selected { get; set; }

        public IndexViewModel()
        {
            Car = new AlfaRomeo();

            Selected = Car;

            Options = new List<OptionDecorator>
            {
                new LeatherSeats(Car),
                new ParkingSensors(Car),
                new AdaptiveCruiseControl(Car),
            };
        }
    }
}