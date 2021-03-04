# Culture

## Inleiding

De tijd dat je software ontwikkelde om die alleen maar op een paar locale computers te laten draaien, ligt echt wel achter ons. Dankzij globalisatie en het internet in het bijzonder, wordt software tegenwoordig vrijwel over op de wereld gebruikt op een brede variëteit aan apparaten. Dit betekent dat je code een heleboel cultuurspecifieke zaken zaken moet aankunnen, zoals het omgaan met getallen en data in andere formaten dan je zou verwachten. Wist je bijvoorbeeld dat in sommige landen bij bepaalde getallen (bv. 1,24) geen komma wordt gebruikt maar een punt (bv 1.24)? En wist je dat data in landen op diverse manieren worden weergeven? In Nederland is dat dd/mm/jjjj .

Het kan een heel gedoe zijn om hiermee uit de voeten te kunnen, maar gelukkig voor ons heeft .NET diverse classes die van dienst kunnen zijn in dit soort gevallen.De meest algemeen gebruikte is de CultureInfo class, die we in het volgende artikel gaan bespreken. Maar .Net heeft ook classes voor het werken in regio's en zelfs specifieke kalenders (niet overal in de wereld wordt dezelfde soort kalender gebruikt!)

Deze kwestie is vooral belangrijk als je aan een applicatie werkt die meerdere talen moet kunnen ondersteunen. Maar zelfs al is dat niet zo, dan nog moet je een oplossing vinden voor het feit dat hij kan worden gebruikt op een apparaat dat niet dezelfde notaties gebruikt voor bv. data en getallen. Om te laten zien hoe belangrijk dit is, is hier het volgende voorbeeld:

```c#
string inputNumber = "1.425";
double usNumber = double.Parse(inputNumber, CultureInfo.GetCultureInfo("en-US"));
double germanNumber = double.Parse(inputNumber, CultureInfo.GetCultureInfo("de-DE"));
Console.WriteLine(usNumber.ToString() + " is not the same as " + germanNumber);
```

Denk aan de *inputNumber* variabele als iets dat je zojuist ontving van de gebruiker van de applicatie, bv. iets dat werd ingetoetst in een tekstveld of op een web formulier. We gebruiken de double.Parse() method om er een float van te maken, maar we voeren een tweede parameter in van het CultureInfo type. Als we dat niet zouden doen, zouden de systeeminstellingen worden gebruikt, die dan bv. Engels zouden kunnen zijn, of Duits of welke andere taal dan ook maar. Let nu op de output:

```c#
1,425 is not the same as 1425
```

Helemaal waar! Onze 'getal' waarde is zojuist duizend keer groter geworden omdat in bv. Nederland een komma wordt gebruikt als decimaal scheider, en een punt (.) als duizendtallen scheider. Dit zou voor de meeste applicaties een probleem kunnen zijn, maar er is een oplossing. Je moet altijd weten hoe je input binnenkrijgt en er dan op de juiste manier mee omgaan. Je ziet dat dankzij de CultureInfo class .Net in staat is tot het 'parsen' van een getal ( en ook data!) in elke gewenst format, zolang als je die class maar laat weten wat hij kan verwachten.

## Culture en UICulture

In het vorige artikel bespraken we dat het rekening houden met cultuur erg belangrijk is, vooral als je met data (datums) en getallen werkt. Om die reden moet jouw applicatie altijd een exemplaar van de CultureInfo class hebben, gedefinieerd als "CurrentCulture", een terugval exemplaar voor al die situaties waarbij je niet hebt aangegeven welke cultuur moet worden gebruikt, bv. voor het afdrukken van een getal. Tenzij je deze property in de CultureInfo class verandert, zal de output gelijk zijn aan de cultuur van jouw besturingssysteem. Zie hier een simpele manier om dat te controleren:

```output
Console.WriteLine("Current culture: " + CultureInfo.CurrentCulture.Name);
```

Het voorbeeld zal de cultuur 'outputten' die door jouw applicatie wordt gebruikt, bv. "en-US" voor een computer met de Engelse taal in de Verenigde Staten. In Nederland is dat "nl-NL" als je computer de Nederlandse taal gebruikt. Met ander woorden, de eerste twee letters geven de taal aan, en de laatste twee letters geven het land aan.

Het kan zijn dat je controle wilt hebben met betrekking tot welke cultuur door jouw applicatie wordt gebruikt. Als jouw applicatie bv overal de Engelse taal gebruikt, heeft het dan zin om getallen in Duits of Zweeds formaat af te drukken omdat de computer van de gebruiker dat specificeert? Misschien doet die dat, maar zo niet dan kun je heel gemakkelijk een nieuwe 'cultuur' specificeren, waarbij je opnieuw de CurrentCulture 'property' gebruikt:

```c#
CultureInfo.CurrentCulture = new CultureInfo("en-US");
Console.WriteLine("Current culture: " + CultureInfo.CurrentCulture.Name);

float largeNumber = 12345.67f;
Console.WriteLine("Number format (Current culture): " + largeNumber.ToString());

CultureInfo germanCulture = new CultureInfo("de-DE");
Console.WriteLine("Number format (German): " + largeNumber.ToString(germanCulture));
```

We starten meteen met het 'overrulen' van de CurrentCulture property door er een en-US cultuur van te maken. Dan drukken we het af, met een groot floating point getal. Je ziet dan dat het resultaat een getal is dat geformatteerd is in het Engels (US). In de laatste paar regels laten we zien hoe je die cultuur kunt 'overrulen' door een ander CultureInfo exemplaar aan de ToString() methode toe te voegen. En in dat geval wordt het getal ook in het Nederlands format afgedrukt. De output van dit voorbeeld ziet er ongeveer zo uit:

```output
Current culture: en-US
Number format (Current culture): 12345.67
Number format (German): 12345,67
```

## CurrentCulture vs. CurrentUICulture

Misschien heb je gezien dat de CultureInfo een property heeft met de naam **CurrentUICulture**. Deze property is alleen maar relevant als je hulpbestanden gebruikt om een user interface te localiseren. In dat geval weet jouw applicatie welke versies van de hulpbestanden moeten worden geladen, gebaseerd op de CurrentCulture property. Voor elk ander doel, inclusief het formatten van getallen, data, enzovoorts, moet je de **CurrentCulture** property gebruiken.

## CurrentCulture en Threads

We hebben nog niet echt gepraat over threads, maar ze zijn eigenlijk een concept waardoor jouw applicatie aan een aantal dingen tegelijk kan werken. Als een .Net applicatie wordt opgestart, wordt er één enkele thread gemaakt en wordt alleen deze thread gebruikt, tenzij je een nieuwe maakt met behulp van de vele multi-threading strategieën van het framework. Ik noem dat hier, omdat het ook erg relevant is als het aankomt op de 'terugval' cultuur van jouw applicatie. In feite is *CultureInfo.CurrentCulture* eigenlijk een sluipweg naar de **Thread.CurrentThread.CurrentCulture** property, hetgeen betekent dat wanneer ook maar je de CurrentCulture definieert, die alleen maar geldig is voor de huidige thread.

Vóór de verschijning van .Net framework versie 4.5, moest je zelf de cultuur van elke nieuwe thread specificeren. Maar in .Net 4.5 werd de **CultureInfo.DefaultThreadCurrentCulture** property geïntroduceerd. Als je die gebruikt, zal elke nieuwe thread eveneens deze cultuur gebruiken, en het is net zo gemakkelijk te gebruiken als de CurrentCulture property:

```c#
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
```

aar hoe zit het dan met de bestaande thread? Welnu, als je nog niet een andere cultuur hebt gedefinieerd voor de *CurrentCulture* property, dan kan het instellen van de *DefaultThreadCurrentCulture* ook kunnen worden toegepast op de *CurrentCulture* property. Met andere woorden, het is zinnig om de *DefaultThreadCurrentCulture* te gebruiken in plaats van *CurrentCulture* als je multiple threads wil gaan gebruiken in je applicatie, dat houdt namelijk rekening met alle scenario's.

## CultureInfo

In de vorige reeks artikelen hebben we gesproken over hoe nuttig de CultureInfo class is als je de volledige controle moet hebben over hoe getallen en datums in jouw applicatie worden weergegeven. We hebben ook gesproken over hoe je kunt verifiëren en wijzigen welke cultuur jouw applicatie moet gebruiken als 'terugval' cultuur. Dit allemaal gezegd hebbende, is het nu tijd om dieper in te gaan op de CultureInfo class om te zien hoe we er het volle profijt van kunnen hebben.

Nog even snel iets in herinnering brengen voordat we beginnen: De CultureInfo class is een onderdeel van de *System.Globalization* benamingsruimte (namespace), dus wees er zeker van om dat te importeren (using) wanneer je de voorbeelden gaat proberen:

```c#
using System.Globalization;
```

## Neutrale en specifieke culturen

In de voorgaande voorbeelden in dit hoofdstuk hebben we alleen maar specifieke culturen gebruikt, waarmee we bedoelen, een cultuur die zowel een taal als een land specificeert. Een voorbeeld hiervan is de **en-US** cultuur, die duidelijk aangeeft dat de gewenste taal Engels moet zijn en het land de VS. Een alternatief hierop is de **en-GB** cultuur, die eveneens dezelfde taal heeft, maar met als land Groot Brittannië.

Soms zijn deze verschillen belangrijk voor jou, in welk geval je deze regio-specifieke versies van de CultureInfo class moet gebruiken. Anderzijds zijn er situaties waarbij Engels slechts een taal is en je deze taal niet wilt verbinden aan een specifiek land. Om hieraan tegemoet te komen, definieert het .NET framework zogenaamde neutrale culturen, die alleen maar een taal specificeren. In feite 'erven'(inherit) zowel en-US en en-GB van zo'n neutrale cultuur (wat logisch is omdat ze dezelfde taal hebben!) en je kunt die inschakelen via de **Parent** property. Laat ik het illustreren met een voorbeeld:

```c#
CultureInfo enGb = new CultureInfo("en-GB");
CultureInfo enUs = new CultureInfo("en-US");
Console.WriteLine(enGb.DisplayName);
Console.WriteLine(enUs.DisplayName);
Console.WriteLine(enGb.Parent.DisplayName);
Console.WriteLine(enUs.Parent.DisplayName);
```

Niet een ontzettend nuttig voorbeeld, maar het geeft wel een beter idee van de interne structuur van de CultureInfo class. De output wordt aldus:

```output
English (United Kingdom)
English (United States)
English
English
```

## De juiste CultureInfo krijgen

Uit onze vorige voorbeelden kon je zien dat we de gewenste CultureInfo class kunnen ophalen door de taal-land identifier toe te voegen aan de constructor van de class. Maar als je naar een neutrale cultuur op zoek bent, is het voldoende om slechts een taal identifier toe te voegen:

```c#
CultureInfo en = new CultureInfo("en");
```

In de meeste situaties echter is het veel gemakkelijker om de eerder gedemonstreerde taal-land/regio specifier te gebruiken.

## Een lijst van beschikbare Culturen krijgen

We kunnen nu een specifieke cultuur krijgen en die voor allerlei doeleinden gebruiken, maar misschien heb je een lijst van de beschikbare culturen nodig, omdat je bv. de gebruiker zelf een taal en/of land/regio wilt laten kiezen. Ook hier voorziet het .NET framework in om het ons gemakkelijk te maken. Een voorbeeld:

```c#
CultureInfo[] specificCultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
foreach (CultureInfo ci in specificCultures)
    Console.WriteLine(ci.DisplayName);
Console.WriteLine("Total: " + specificCultures.Length);
```

Door dit te doen, zie je ook dat er lang niet zoveel neutrale culturen zijn in vergelijking met specifieke culturen. Op mijn computer/.Net framework is het resultaat een totaal van 280 neutrale culturen.

## Belangrijke properties & methods van CultureInfo

Wanneer je eenmaal een exemplaar hebt van de CultureInfo class, krijg je onmiddellijk toegang tot een hele reeks bruikbare properties en methods. Deze 'members' kunnen je helpen bij het doen van nuttige dingen met betrekking tot cultuur. Laten we eens naar een paar van die dingen kijken!

### DateTimeFormat

Met de DateTimeFormat property krijg je toegang tot informatie over hoe datums en tijd geformat moeten worden, evenals een boel nuttige informatie over de kalender van een gegeven cultuur. Een aardig voorbeeld hiervan zijn de **FirstDayOfWeek** and **CalendarWeekRule** properties. Die kunnen je zeggen op welke dag de week begint (meestal zondag of maandag) en hoe de eerste kalenderweek van het jaar wordt weergegeven (bv. alleen maar de eerste dag van de eerste volle week):

```
CultureInfo enUs = new CultureInfo("en-US");
Console.WriteLine("First day of the: " + enUs.DateTimeFormat.FirstDayOfWeek.ToString());
Console.WriteLine("First calendar week starts with: " + enUs.DateTimeFormat.CalendarWeekRule.ToString());
```

Probeer het CultureInfo exemplaar te veranderen naar je eigen cultuur of naar een andere culktuur die je kent. Dan zie je hoe deze properties variëren!

Een ander mooi ding is dat je informatie kan krijgen over de namen van de maanden en de dagen van die specifieke cultuur door gebruik te maken van properties als **MonthNames** and methods like **GetMonthName()**. Hier is een vlug voorbeeld:

```c#
CultureInfo enUs = new CultureInfo("en-US");

foreach (string monthName in enUs.DateTimeFormat.MonthNames)
    Console.WriteLine(monthName);
Console.WriteLine("Current month: " + enUs.DateTimeFormat.GetMonthName(DateTime.Now.Month));
```

En precies hetzelfde kan gedaan worden voor dagen, door gebruik van de **DayNames** property en de **GetDayName()** method:

```c#
CultureInfo enUs = new CultureInfo("en-US");

foreach (string dayName in enUs.DateTimeFormat.DayNames)
    Console.WriteLine(dayName);
Console.WriteLine("Today is: " + enUs.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek));
```

Er zijn veel meer nuttige properties en methods bij de DateTimeFormat property, bv. *DateSeparator*, *YearMonthPattern* enzovoorts. Kijk zelf maar eens; misschien is hier wel een oplossing verborgen voor jouw datum/tijd probleem: [DateTimeFormatInfo documentation](https://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo(v=vs.110).aspx).

### Formatten van getallen

Precies zoals DateTimeFormat informatie heeft over datums, zo kun je ook informatie krijgen over hoe een specifieke cultuur omgaat met getallen via de **NumberFormat** property. Deze informatie wordt elke keer gebruikt als je naar een visuele representatie vraagt van een getal, bv. als je dat converteert naar een string en het naar de console schrijft. Maar je kunt ook zelf toegang krijgen tot de informatie door gebruik te maken van de properties en methods van de NumberFormat property. Hier is een voorbeeld:

```c#
CultureInfo enUs = new CultureInfo("en-US");  
Console.WriteLine(enUs.DisplayName + ":");  
Console.WriteLine("NumberGroupSeparator: " + enUs.NumberFormat.NumberGroupSeparator);  
Console.WriteLine("NumberDecimalSeparator: " + enUs.NumberFormat.NumberDecimalSeparator);  

CultureInfo deDe = new CultureInfo("de-DE");  
Console.WriteLine(deDe.DisplayName + ":");  
Console.WriteLine("NumberGroupSeparator: " + deDe.NumberFormat.NumberGroupSeparator);  
Console.WriteLine("NumberDecimalSeparator: " + deDe.NumberFormat.NumberDecimalSeparator);
```

We gebruiken de **NumberGroupSeparator** en de **NumberDecimalSeparator** properties om informatie te krijgen over hoe een getal wordt getoond (bv. 1,000.00 of 1.000,00) voor de Engelse en Nederlandse culturen. Als je even kijkt, vind je ook overeenkomstige properties voor valuta (**CurrencyGroupSeparator** en **CurrencyDecimalSeparator**) en voor percentages (**PercentGroupSeparator** and **PercentDecimalSeparator**).

Over valuta gesproken, de NumberFormat property kan ook aangeven welk symbool een bepaalde cultuur gebruikt om een monetaire hoeveelheid weer te geven. Gebruik daarvoor simpelweg de **CurrencySymbol** property:

```c#
CultureInfo enUs = new CultureInfo("en-US");
Console.WriteLine(enUs.DisplayName + " - currency symbol: " + enUs.NumberFormat.CurrencySymbol);
CultureInfo deDe = new CultureInfo("de-DE");
Console.WriteLine(deDe.DisplayName + " - currency symbol: " + deDe.NumberFormat.CurrencySymbol);
CultureInfo ruRu = new CultureInfo("ru-RU");
Console.WriteLine(ruRu.DisplayName + " - currency symbol: " + ruRu.NumberFormat.CurrencySymbol);
```

Het is leuk om al deze properties te kennen, , maar in de meeste gevallen hoef je er niets aan te doen omdat C# in stilte de informatie om getallen, percentages en valuta te formatten voor jou gebruikt, zolang als jij maar de juiste format string specificeert wanneer je het getal naar een string converteert.

### Namen & identifiers

Laten we tot slot kijken naar de properties die het CultureInfo exemplaar representeert. We hebben er al een paar van gebruikt, bv. **Name** en **DisplayName**, maar hoe werken die nu eigenlijk? Om te beginnen, hier is een lijst van beschikbare properties die gebruikt worden om een CultureInfo exemplaar te identificeren:

- **Name** identificeert een CultureInfo in de taalcode-landcode-format, bv. "en-US" voor Engels in de VS, en "nl-NL" in nederland enzovoorts. Als er geen land/regio wordt gespecificeerd, wordt alleen het eerste deel geretourneerd, bv. "en" voor Engels of "nl" voor Nederlands.
- **TwoLetterISOLanguageName** doet vrijwel hetzelfde als Name, maar retourneert alleen de taalcode, ongeacht of een land/regio is gespecificeerd of niet. Bijvoorbeeld, "en" wordt zowel voor "en-US" en "en-GB" geretourneerd. (Net zo wordt "nl" geretourneerd voor zowel "nl-NL"en "nl-BE") . De geretourneerde letters worden gespecificeerd in de [ISO 639-1 standard](https://en.wikipedia.org/wiki/ISO_639-1).
- **ThreeLetterISOLanguageName** werkt vrijwel hetzelfde als TwoLetterISOLanguageName, maar retourneert drie letters in plaats van twee, zoals gespecificeerd in de [ISO 639-2 standard](https://en.wikipedia.org/wiki/ISO_639-2).
- **EnglishName** retourneert de naam van de taal (in het Engels). Als een land/regio is gespecificeerd wordt dit tussen haakjes () toegevoegd aan het resultaat.
- Make correction

- **NativeName** retourneert de naam van de taal (in de taal die is gespecificeerd in het CultureInfo exemplaar). Als een land/regio is gespecificeerd wordt dit tussen haakjes () toegevoegd aan het resultaat.

## Samenvatting

Zoals je aan de lengte van dit artikel kunt zien, is het omgaan met cultuur geen geringe kwestie. Gelukkig voor ons maakt het .NET framework het veel gemakkelijker met de CultureInfo class. Deze wordt stilzwijgend in jouw applicatie gebruikt bij het formatten van datums en getallen. Het is echter goed om te weten hoe het werkt zodat je zo nodig het gedrag kunt veranderen. Ik hoop dat dit artikel je het meeste geleerd heeft van wat er te weten valt over de CultureInfo class.

# De RegionInfo class

We kunnen eigenlijk veel meer regio-gebaseerde dingen doen met één van de andere classes in de *System.Globalization* namespace: De **RegionInfo** class. Die bevat een boel nuttige informatie over een specifieke regio (meestal een land), bv. de naam en het symbool van hun valuta, en verder of ze het metrieke stelsel gebruiken of niet, enzovoorts.

## Verkrijgen van een RegionInfo exemplaar

Om toegang te krijgen tot de regionale info, heb je een exemplaar van de RegionInfo class nodig. Die heeft een contructor die een [ISO 3166 code](https://en.wikipedia.org/wiki/ISO_3166) kan nemen of de 'taalcode/regio-land code' (languagecode/region-country code) van de regio (bv. "nl-NL" of "en-US"). Hier is een voorbeeld.

```c#
RegionInfo regionInfo = new RegionInfo("en-US");
Console.WriteLine(regionInfo.EnglishName);
```

Dit betekent dat als je al een referentie hebt naar een CultureInfo class, je deze goed kunt gebruiken om er zeker van te zijn dat je de overeenkomstige RegionInfo krijgt. Zoal we geleerd hebben in een eerder artikel, heeft je applicatie altijd een terugval CultureInfo exemplaar waaraan je kunt refereren:

```c#
RegionInfo regionInfo = new RegionInfo(CultureInfo.CurrentCulture.Name);
Console.WriteLine(regionInfo.EnglishName);
```

Dit gezegd hebbende, kijken we nu naar een paar nuttige kenmerken van de RegionInfo class.

## Belangrijke properties van de RegionInfo class

We hebben de EnglishName property al bekeken - hij retourneert de naam van de regio in het Engels. Maar natuurlijk is er nog meer goeds te vinden - bijvoorbeeld diverse properties die met valuta te maken hebben:

```c#
RegionInfo regionInfo = new RegionInfo("sv-SE");
Console.WriteLine(regionInfo.CurrencySymbol);
Console.WriteLine(regionInfo.ISOCurrencySymbol);
Console.WriteLine(regionInfo.CurrencyEnglishName);
Console.WriteLine(regionInfo.CurrencyNativeName);
```

Als we **CurrencySymbol**, **ISOCurrencySymbol**, **CurrencyEnglishName** en/of **CurrencyNativeName** gebruiken, krijgen we de info die we nodig hebben om valuta gerelateerde output te kunnen realiseren. Het resultaat ziet er zo uit (in dit geval voor Zweeds/Zweden):

```output
kr
SEK
Swedish Krona
Svensk krona
```

Je kunt ook zien of de gegeven regio het metrieke stelsel gebruikt met de **IsMetric** property:

```c#
RegionInfo regionInfo = new RegionInfo(CultureInfo.CurrentCulture.Name);
Console.WriteLine("Is the metric system used in " + regionInfo.EnglishName + "? " + (regionInfo.IsMetric ? "Yes" : "No"));
```

Daarmee hebben we nu alle identiteit gerelateerde properties:

- **Name** brengt je de ISO 3166 code die taal en land/regio identificeert, bv. "nl-NL" voor Nederlands/Nederland.
- **DisplayName** brengt je de volledige naam van land.regio in de lokale .NET framework versie.
- **EnglishName** brengt je de volledige naam van land/regio in het Engels.
- **NativeName** brengt je de volledige naam van land/regio in de gevraagde taal, bv. "Nederland" bij *nl-NL* of "Deutschland" for *de-DE*.
- **TwoLetterISORegionName** brengt je de twee-letter ISO 3166 code voor land/regio, bv "NL" voor Nederland of "DE" for Duitsland.
- **ThreeLetterISORegionName** brengt je de drie-letter ISO 3166 code voor land/regio, bv. "NED" voor Nederland of "DEU" voor Duitland.

Vanzelfsprekend kunnen deze properties handig zijn als je informatie moet tonen over een land/regio, zoals we zullen zien in ons volgende voorbeeld.

## Een lijst van landen krijgen met RegionInfo

In een vorig artikel liet ik zien hoe je een lijst van al de gedefinieerde culturen in het .NET framework kunt krijgen. Dat brengt ons een lijst van taal-land/regio combinaties. We kunnen dit gebruiken in combinatie met de RegioInfo class om een lijst van landen/regio's te krijgen:

```c#
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RegionInfoCountries
{
    class Program
    {
    static void Main(string[] args)
    {
        CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        List<RegionInfo> countries = new List<RegionInfo>();
        foreach (CultureInfo ci in cultures)
        {
        RegionInfo regionInfo = new RegionInfo(ci.Name);
        if (countries.Count(x => x.EnglishName == regionInfo.EnglishName) <= 0)
            countries.Add(regionInfo);
        }
        foreach (RegionInfo regionInfo in countries.OrderBy(x => x.EnglishName))
        Console.WriteLine(regionInfo.EnglishName);
    }
    }
}
```

Dit voorbeeld is wat langer dan de ander voorbeelden in dit artikel, maar laat ik het voor jou in kleinere stukken opdelen. We beginnen met een lijst van alle beschikbare, specifieke culturen. In het vorige artikel hebben we geleerd dat specifieke culturen die culturen zijn, welke een taal ÉN een regio/land definiëren. We maken een 'loop' door deze lijst en bij elke iteratie gebruiken we het CultureInfo exemplaar om een corresponderend RegionInfo exemplaar te creëren. We checken of een land met die naam al eerder is toegevoegd aan onze lijst, en zo niet, dan doen we dat alsnog. Als de 'doorloop' klaar is, hebben we nu een complete lijst van de landen die gedefinieerd zijn door het .NET framework. Deze kunnen we doorlopen en naar de console zenden, of gewoon van alles doen wat we nuttig zouden kunnen vinden.

Dit is een prachtig voorbeeld van wat je kunt bereiken met de combinatie van CultureInfo en RegionInfo. Maar laat ik benadrukken dat dit geen complete en accurate lijst van landen is. In plaats daarvan is het een lijst van landen zoals die gedefinieerd is in de versie van het .NET framework die je gebruikt. Dat betekent dat sommige landen er niet in voorkomen of hun naam hebben veranderd sinds de publicatie van de versie. Dus als je een lijst van landen nodig hebt die 100% accuraat en bijgewerkt is, zul je die waarschijnlijk zelf moeten maken en bijhouden.

## Samenvatting

De RegionInfo class is in feite een extensie van de CultureInfo class met nog meer nuttige info over een specifiek land of regio. Je kunt er meer door te weten komen over de identiteit en valuta van een specifieke regio, en je kunt erdoor aan een lijst van landen/regio's komen.