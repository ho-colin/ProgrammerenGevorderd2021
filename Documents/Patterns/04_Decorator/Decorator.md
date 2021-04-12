# Decorator

Het Decorator Design Pattern is een 'Structural' pattern. Dat wil zeggen dat het een *best practice* is voor het creeeren van structuur binnen je applicatie,
structuur door hergebruik van componenten.

In deze workshop maken we een **car configurator** (hoe kon het ook anders, sorry :P ) met behulp van het 'Decorator Pattern'.

*1:* Maak op een locatie naar keuze een folder aan en noem deze 'Decorator'. Vanuit deze folder beginnen we het 'project'.
nb: De folder mag geen spaties bevatten, dit vanwege een fout/bug in de .NET Core.  

*6:* Maak in de folder Models het bestand 'Vehicle.cs' aan (New File -> Class -> 'Vehicle.cs')

*7:* Vehicle is de abstracte Component class binnen het Decorator Pattern. Dit wil zeggen dat alle andere klassen hiervan overerven.

*8:* Schrijf een *protected* property van het type string met de naam '_description'. De default waarde van de string is 'Undefined'.

*9:* Maak een *public* function 'GetDescription()' welke niets anders doet dan de eerder gemaakte 'Description' string retourneren.

*10:* Afsluitend voor de Vehicle class maken we een *abstract* 'Price()' definitie aan. Deze retourneert de prijs als geheel getal (int) maar dient geschreven te worden in overervende classes.

Je code in de Vehicle.cs class zou er ongeveer zo uit moeten zien:

```C
    public abstract class Vehicle
    {
        protected string _description = "Undefined";

        public string GetDescription()
        {
            return _description;
        }

        public abstract int Price();
    }
```

*11:* Nu schrijven we de concrete implementatie van de 'Vehicle' class. Maak de *public* class 'AlfaRomeo' aan welke overerft van de 'Vehicle' class.

*12:* In de constructor van 'AlfaRomeo' definieer je de waarde van de 'description' met de tekst: 'Alfa Romeo Giulia'.

(PRO-TIP: in Visual Studio type je in een class de tekst *'ctor'* gevolgd door een tab om automagisch een constructor aan te maken) 

*13:* Omdat we overerven van de 'Vehicle' class zijn we verplicht om de Price() funtie te definiëren. 'Override' de abstract Price() functie en laat deze de standaard prijs van '40000' retourneren.

De 'AlfaRomeo' class code zou er als volgt moeten uit zien:

```C
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
```

Tijd voor de Decorator. We willen namelijk niet een kale auto kopen ... we willen opties! De Decorator is een abstracte klasse welke de Component aanvullende opties kan geven.

*14:* Maak in de 'Models' folder een nieuw bestand aan en noem deze 'OptionDecorator.cs'

*15:* In het bestand maken we een abstracte definitie van de OptionDecorator class aan.

De Decorator erft over van het Component dat men wenst te 'decoraten'. In dit geval erft de 'OptionDecorator' dus over van 'Vehicle'. Echter omdat het een abstracte class betreft hoeven we de functies niet te implementeren. Dat doen we pas in de concrete uitwerking van de Decorator class.

*16:* In de OptionDecorator class creeeren we een *protected* string optionName en een public string OptionName welke de protected variant retourneert (get);

De 'OptionDecorator' class code zou er als volgt moeten uit zien:

```C
    public abstract class OptionDecorator : Vehicle
    {
        protected string optionName;

        public string OptionName => optionName;
    }
```

De opties zijn losse classes welke de OptionDecorator implementeren.

*17:* Eveneens in de Models folder van het project maak je een nieuw bestand genaamd 'LeatherSeats.cs'.

*18:* In dit bestand maken we de 'LeatherSeats' class aan welke de OptionDecorator implementeert.

 ```C
namespace Decorator.Models
{
    public class LeatherSeats : OptionDecorator
    {
    }
}
```

*19:* De constructor (ctor + tab) ontvangt een 'Vehicle' object met de naam 'vehicle'. Deze schrijven we direct weg naar het locale '_vehicle' object. (dez emoet je dus zelf even schrijven)

 ```C
    public class LeatherSeats : OptionDecorator
    {
        Vehicle _vehicle;

        public LeatherSeats(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }
    }
```

*20:* In dezelfde constructor schrijven we de optionName weg als 'Leather Seats'.

*21:* De 'description' **decoraten** we door op het lokale Vehicle object de functie GetDescription() aan te roepen en deze aan te vullen met een komma plus spatie (anders ziet het er zo slordig uit) en de 'optionName' van het object zelf.

 ```C
    public LeatherSeats(Vehicle vehicle)
    {
        _vehicle = vehicle;
        optionName = "Leather Seats";
        description = _vehicle.GetDescription() + ", " + optionName;
    }
```

*22:* Om de optie geheel volgens specificaties te laten voldoen aan de OptionDecorator moeten we alleen de 'Price()' functie (welke in de Vehicle class als abstract gemarkeerd staat) nog implementeren.
    Dit doen we door de Price() functie te 'overriden' en vervolgens een prijs (1200) plus de lokale '_vehicle.Price()' te retourneren.

```C
    public override int Price()
    {
      return 1200 + _vehicle.Price();
    }
```  

De 'LeatherSeats' class zou er uiteindelijk als volgt moeten uitzien:

```C
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
```  

*23:* We willen nog een tweetal opties die we voor het gemak kopieren op basis van de 'LeatherSeats' class. Kopieer dus het gehele 'LeaterSeats.cs' tweemaal en noem er eentje 'ParkingSensors.cs' en de ander 'AdaptiveCruiseControl.cs'.

*24:* Pas in 'ParkingSensors.cs' de klasse naam aan naar 'ParkingSensors', wijzig eveneens de initiele waarde van 'optionName' in de constructor naar 'Parking Sensors'.

*25:* Wijzig in 'ParkingSensors.cs' in de 'Price()' functie de waarde *1200* naar **350.**

*26:* Pas in 'AdaptiveCruiseControl.cs' de klasse naam aan naar 'AdaptiveCruiseControl', wijzig eveneens de initiele waarde van 'optionName' in de constructor naar 'Adaptive CruiseControl'.

*27:* Wijzig in 'AdaptiveCruiseControl.cs' in de 'Price()' functie de waarde *1200* naar **550.**

Resulterende ParkingSensors.cs:

```C
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

```  

Resulterende AdaptiveCruiseControl.cs:

```C
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
```  

## Tijd voor het echte werk

*28:* Voeg de folder 'HomeViewModels' toe aan de 'Models' folder.

*29:* Maak in de 'HomeViewModels' folder de 'IndexViewModel' class aan.

*30:* Schrijf de 'IndexViewModel class een public Getter van het type 'Vehicle' en noem deze Car. In verband met het SOLID Open-Closed principle laten we de setter weg. Deze property zetten we alleen in de constructor.

```C
namespace Decorator.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public Vehicle Car { get; }
    }
}
```  

*31:* Onder de Car property maak je een IList property aan van het type OptionDecorator. Noem deze 'Options'. Ook hier laten we de Setter weg.

```C
using System.Collections.Generic;
namespace Decorator.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public Vehicle Car { get; }

        public IList<OptionDecorator> Options { get; }
    }
}
```

*nb: Om de IList<> interface te kunnen gebruiken in deze klasse dien je een referentie (using) naar 'System.Collections.Generic' te leggen.*


*32:* Later in het proces gaan we dit ViewModel binden aan de View. Om de properties een betere naamgeving op het display te geven voeg je onderstaande **using** toe:
```C
using System.ComponentModel.DataAnnotations;
```

*33:* Vervolgens schrijven we boven de Options property een Display **attribute**. Hierin zetten we de property 'Name' met de tekst 'Available options'.

```C
[Display(Name = "Available options")]
public IList<OptionDecorator> Options { get; }
```

*34:* Omdat we ook willen weten wat de gebruiker geselecteerd heeft schrijven we nu een public property van het type Vehicle welke zowel een 'get' als een 'set' heeft en deze noemen we 'Selected'.

*35:* Ook boven deze property schrijven we een attribute van het type Display waarbij we de Name property vullen met de tekst 'Your selection'.  

```C
[Display(Name = "Your selection")]
public Vehicle Selected { get; set; }
}
```

*36:* We sluiten het IndexViewModel af met een constructor (ctor).

*37:* In de constructor zetten we de waarde van de property 'Car' met een 'new AlfaRomeo()';

*38:* Schrijf de waarde van 'Car' vervolgens ook naar de 'Selected' property.

*39:* Vul nu de 'Options' met een 'new List<OptionDecorator> { }'

*40:* In de 'constructor' van de lijst schrijf je achtereenvolgens:
      - een 'new LeatherSeats' met als waarde voor 'Vehicle' de 'Car' property.
      - 'new ParkingSensors' met als waarde voor 'Vehicle' eveneens 'Car'.
      - en een 'new AdaptiveCruiseControl(Car)'. 

Het bestand 'IndexViewModel.cs' zou er nu zo uit moeten zien.

```C
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
```

Hiermee kunnen we het IndexViewModel.cs bestand sluiten.

*41:* In de Controllers folder zit het bestand HomeController. Open dit bestand.

*42:* Standaard retourneert de Index() functie alleen de View(). Maak een nieuw IndexViewModel aan en retourneer deze in de View(). Hiervoor zal je een referentie moeten leggen naar ~.Models.HomeViewModels.

*43:* Schrijf naar de ViewData de text "Car Configurator" in het "Message" object: ViewData['Message'] = "Car Configurator".

De HomeController.cs zou er ongeveer zo uit moeten zien waarbij de About(), Contact() en Error() standaard gegenereerd zijn: 
```C
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
```

*44:* Alvorens we het nieuwe ViewModel kunnen gebruiken in de View dienen we een referentie te leggen in het _ViewImports document.
Op hiertoe het '_ViewImports.cshtml' bestand uit de 'Views' folder en voeg onderstaande regel toe:

```cshtml
@using Decorator.Models.HomeViewModels
```

*45:* Open het bestand 'Index.cshtml' in de folder 'Views/Home' en verwijder alle opsmuk (alles in de gehele div tag) met uitzondering van het eerst razor statement.

```C
@{
    ViewData["Title"] = "Home Page";
}
```

*46:* In de HomeController hebben we in de Index() functie een tekst weggeschreven naar de `ViewData[Message]` property. Deze tekst willen we weergeven op de pagina als een Heading 3.

Dit doen we op de pagina als volgt:
```html
<h3>@ViewData["Message"]</h3>
```

*47:* Voeg nu een referentie toe naar het ViewModel* door boven in het document de volgende regel te schrijven:
```C
@model  Decorator.Models.HomeViewModels.IndexViewModel
```
<sup>**Vanwege het feit dat er meerdere 'IndexViewModels' in het project zijn dien je op de webpagina de referentie te leggen inclusief de gehele namespace.*</sup>


*48:* Onder de heading schrijven we een form welke verwijst naar de HomeController en de Index functie als Action. Logischerwijs willen we de waarden van het formulier Posten.
```html
<form asp-controller="Home" asp-action="Index" method="post" class="form-horizontal" role="form">

</form>
```


*49:* Binnen de `<form>` tags schrijven we een `<div class="form-group">` en maken we een checklist van de Options die we in het ViewModel hebben gedefinieerd. Van elke 'option' gebruiken we de property *OptionName* als 'value' en als tekstuele weergave. De geselecteerde waarden kennen we toe aan 'SelectedOptions':

<sub> Let op: Onderstaand voorbeeld laat ter illustratie de form tags <u>nogmaals</u> zien. Als je dit hele blok copy+paste binnen de bestaande form tags dan gaat het dus niet werken ;) Pak alleen de tekst binnen de div.</sub>
```html
<form asp-controller="Home" asp-action="Index" method="post" class="form-horizontal" role="form">
    <div class="form-group">
        <h3><label asp-for="Options"></label></h3>    
        <ul>
            @foreach (var option in Model.Options)
            {
                <li><input type="checkbox" name="SelectedOptions" value="@option.OptionName">@option.OptionName</li>
            }
        </ul>
    </div>
</form>
```

*50:* Om een formulier te posten hebben we alleen nog een Submit button nodig plaats deze op de pagina in een aparte `<div>` onder de vorige `<div>` maar nog tussen de `<form>` tags.
   Zoiets als dit zou prima moeten werken:
```html
    <div class="form-group">
        <input type="submit" value="Drive!" class="btn btn-default" />
    </div>
``` 

*51:* Nadat we het formulier gepost hebben, willen we ook de resultaten zien. Schrijf een laatste lege `<div`> binnen de pagina en voeg hier een `<h3>` heading toe die een label bevat voor de 'Selected' property op het ViewModel.
```html
    <div>
      <h3><label asp-for="Selected"></label></h3>    
    </div>
```


*52:* Vervolgens kunnen we de waarden van de 'Selected' property als volgt weergeven:
```html
    <p><b>Description:</b>    @Model.Selected.GetDescription()</p>
    <p><b>Total Price:</b>    @Model.Selected.Price()</p>
```

Het uiteindelijke 'index.cshtml' bestand zou er nu, ongeveer, zo uit moeten zien:

```html
@model  Decorator.Models.HomeViewModels.IndexViewModel
@{
    ViewData["Title"] = "Home Page";
}

<h3>@ViewData["Message"]</h3>


<form asp-controller="Home" asp-action="Index" method="post" class="form-horizontal" role="form">
    <div class="form-group">
        <h3><label asp-for="Options"></label></h3>    
        <ul>
            @foreach (var option in Model.Options)
            {
                <li><input type="checkbox" name="SelectedOptions" value="@option.OptionName">@option.OptionName</li>
            }
        </ul>
    </div>
    <div class="form-group">
        <input type="submit" value="Drive!" class="btn btn-default" />
    </div>
</form>
<div>
    <h3><label asp-for="Selected"></label></h3>    
    
    <p><b>Description:</b>    @Model.Selected.GetDescription()</p>
    <p><b>Total Price:</b>    @Model.Selected.Price()</p>

</div>
```

*53:* De laatste stappen dienen we te doen in de HomeController. We hebben namelijk aangegeven dat we een formulier willen posten. Deze logica moeten we nog wel afvangen.
Dit doen we door in de HomeController class een nieuwe Index() functie te schrijven, onder de bestaande Index(), die een IndexViewModel property met de naam 'model' ontvangt. Dit model retourneren we vervolgens weer naar de View.


```c
public IActionResult Index(IndexViewModel model)
{    
  return View(model);
}
```

*54:* Om aan te geven dat het hier om een POST actie gaat schrijven we het `[HttpPost]` attribuut boven de nieuwe Index functie.

*55:* We schrijven wederom de standaard header, "Car Configurator" weg in de `ViewData[Message]`.

*56:* De checkboxen die we in het formulier onder de naam 'SelectedOptions' hebben gemaakt lezen we hier uit en schrijven we wel naar het ViewModel in de 'Selected' property.

De nieuwe Index functie: 

```c
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
```

Wat er in de `foreach` gebeurd is belangrijk. Dit is namelijk de essentie van het **Decorator Pattern**. Je zet een bepaald object en voegt hier niet simpel een waarde aan toe maar vouwt er als het ware een object om heen.
Initieel is je 'model.Selected' de kale auto. Bij elke optie update je de 'model.Selected' met een nieuwe waarde maar geef je de voorgaande waarde mee als 'basis'.
Hierdoor 'decorate' je het object met de gewenste toevoegingen. 

ALS VOORBEELD: Stel dat we een enkele optie selecteren, bijvoorbeeld, 'Leather Seats' en we bekijken wat de `Price()` functie doet. Dan zien we dat deze de prijs van 'Leater Seats' opteld bij de prijs van het bestaande object. In dit geval is dat dus de prijs van de kale auto.

Als we nu een tweede optie aanvinken, bijvoorbeeld 'Parking Sensors', dan zien we dat eerst de 'Alfa Romeo Giulia' gewrapt wordt in de 'LeaterSeats' optie. (okee dat klinkt wat vreemd maar nee we krijgen geen auto met een lederen wrap)
Vervolgens wordt de prijs van de 'Leather Seats' bij de 'Alfa Romeo Giulia' opgeteld. Dit gehele object slaan we op in de `model.Selected` en we beginnen de volgend stap in de iteratie. Nu komen we de 'Parking Sensors' tegen. Die pakt het `model.Selected` object weer op en vult deze aan met zijn eigen waarde. De uiteindelijke `Price()` zal dus eerste de `Price()` van de auto aanroepen, dan de `Price()` van de 'Leather Seats' en tot slot de `Price()` van de 'Parking Sensors'.

### Run nu de code via Visual Studio met F5 of via de console met `dotnet run`.
