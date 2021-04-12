using Microsoft.AspNetCore.Mvc;
using Decorator.Models.HomeViewModels;
using Decorator.Models;

namespace Decorator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Car Configurator";

            var model = new IndexViewModel();
            return View(model);
        }

[HttpPost]
public IActionResult Index(IndexViewModel model)
{
    ViewData["Message"] = "Car Configurator";

    var selectedOptions = this.Request.Form["SelectedOptions"];

    foreach (var option in selectedOptions)
    {
        switch (option)
        {
            case "Leather Seats":
                model.Selected = new LeatherSeats(model.Selected);
                break;
            case "Parking Sensors":
                model.Selected = new ParkingSensors(model.Selected);
                break;

            case "Adaptive CruiseControl":
                model.Selected = new AdaptiveCruiseControl(model.Selected);
                break;
        }
    }

    return View(model);
}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
