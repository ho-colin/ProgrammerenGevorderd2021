# Polymorfisme

**Polymorfisme** oftewel "meerdere vormen" is een programmeertechniek waarbij je code schrijft die door objecten van verschillende klasse, kan gebruikt worden. Hierdoor kan je dus compactere code schrijven en hoef je niet voor iedere klasse apart (deel)code te schrijven. Samen met **encapsulatie** en overerving is polymorfisme een derde belangrijke eigenschap van object georiënteerd programmeren.

We tonen het nut van polymorfisme aan de hand van drie voorbeelden:

## Polymorfisme in de praktijk: Dieren

Een voorbeeld maakt veel duidelijk. Stel dat we een een aantal Dier-gerelateerde klassen hebben die allemaal op hun eigen manier een geluid voortbrengen. We hanteren de klasse dier uit een eerder hoofdstuk ([abstracte klassen in overerving](https://timdams.gitbooks.io/csharpfromantwerp/content/13_advancedovererving/5_abstract.html)):

```csharp
abstract class  Dier
{
   public abstract string MaakGeluid();
}
```

Twee child-klassen:

```csharp
class Paard: Dier
{
  public override string MaakGeluid()
  { 
      return "Hinnikhinnik";
  }
}

class Varken: Dier
{
  public override string MaakGeluid()
  { 
      return "Oinkoink";
  }
}
```

Dankzij polymorfisme kunnen we nu elders objecten van Paard en Varken in een `Dier` bewaren, maar toch hun eigen geluid laten reproduceren:

```csharp
Dier someAnimal = new Varken();
Dier anotherAnimal = new Paard();
Console.WriteLine(someAnimal.MaakGeluid()); //Oinkoink
Console.WriteLine(anotherAnimal.MaakGeluid()); //Hinnikhinnik
```

Het is belangrijk te beseffen dat `someAnimal` en `anotherAnimal` van het type `Dier` zijn en dus enkel die dingen kunnen die in `Dier` beschreven staan. Enkel zaken die `override` zijn in de child-klasse zullen met de specialisatie-code werken.

### Arrays en polymorfisme

Arrays en lijsten laten heel krachtige code toe. Je kan een lijst van de basis-klasse maken en deze vullen met allerlei objecten van de basis-klasse **én de child-klassen**.

Een voorbeeld:

```csharp
List<Dier> zoo = new List<Dier>();
zoo.Add(new Varken());
zoo.Add(new Paard());
foreach(var dier in zoo)
{
  Console.WriteLine(dier.MaakGeluid());
}
```

# Why should I care?

![img](./pg012.jfif)

Polymorfisme is een heel krachtig concept. Door objecten te bewaren in hun basistype en , wanneer nodig, ze als 'zichzelf' te gebruiken wordt je code een pak eenvoudiger. Vaak weet je niet op voorhand wat voor elementen je in je lijst wilt plaatsen. Via polymorfisme lossen we dit op. Stel bijvoorbeeld dat je een lijst van Personen hebt (`List<Person>`) waar echter elementen van subklassen in terecht kunnen komen (`Bakker`, `Student`, etc) , dan laat polymorfisme dit gewoon toe om ook deze elementen in die lijst te plaatsen.

## Polymorfisme in de praktijk: Presidenten

![Gezocht: wie weet waar deze still vandaan komt? Ik heb geen flauw benul. We zien Robert Redford en Bush Senior, uit een film ofzo?](./pg013.jfif)

Beeld je in dat je een klasse President hebt met een methode "RunTheCountry" (voorbeeld van [StackOverflow](https://stackoverflow.com/questions/1031273/what-is-polymorphism-what-is-it-for-and-how-is-it-used)). De President heeft toegang tot tal van adviseurs die hem kunnen helpen (inzake militair, binnenlands beleid, economie). Zonder de voordelen van polymorfisme zou de klasse President er zo kunnen uitzien (**slechte manier**):

```csharp
public class President
{
    MilitaryMinister Petraeus = new MilitaryMinister();
    ForeignSecretary Condi = new ForeignSecretary();
    HealthOfficial MrX = new HealthOfficial();

    public void RunTheCountry()
    {
        // people walk into the Presidents office and he tells them what to do
        // depending on who they are.

        // Fallujah Advice - Mr Prez tells his military exactly what to do.
        Petraeus.IncreaseTroopNumbers();
        Petraeus.ImproveSecurity();
        Petraeus.PayContractors();

        // Condi diplomacy advice - Prez tells Condi how to negotiate

        Condi.StallNegotiations();
        Condi.LowBallFigure();
        Condi.FireDemocraticallyElectedIraqiLeaderBecauseIDontLikeHim();

        // Health care mr X

        MrX.IncreasePremiums();
        MrX.AddPreexistingConditions();
    }
}
```

De MilitaryMinister zou er zo kunnen uitzien:

```csharp
class MilitaryMinister
{
  public void IncreaseTroopNumbers()
  {
    //..
  }
  public void ImproveSecurity()
  {
    //..
  }
  etc
}
```

De HealthOfficial-klasse heeft dan weer heel andere publieke methoden. En die Foreignminister ook weer totaal andere.

Je merkt dat de President (of de programmeur van deze klasse) aardig wat specifieke kennis moet hebben van de vele verschillende departementen van het land. Uiteraard is dat onmogelijk (een fictief voorbeeld: stel je Trump voor...Denk je echt dat die zo veel weet?) . Bovenstaande code is dus zeer slecht. Telkens er zaken binnen een specifiek landsonderdeel wijzigen moet dit ook in de klasse President aangepast worden.

Dankzij polymorfisme kunnen we dit alles veel mooier oplossen:

1. We verplichten alle adviseurs dat ze overerven van de abstracte klasse `Advisor` die maar 1 abstracte methode heeft `Advise`:

```csharp
abstract class Advisor
{
  abstract public void Advise();
}

class MilitaryMinister:Advisor
{
  public override void Advise()
  {
       increaseTroopNumbers();
       improveSecurity();
       payContractors();
  }
  private void increaseTroopNumbers(){ ... }
  private void improveSecurity(){ ... }
  private void payContractors(){ ... }
  }
}

class ForeignSecretary:Advisor
{
  //...
}
class HealthOfficial:Advisor
{
  //...
}
```

2° Het leven van de President wordt plots véél makkelijker:

```csharp
public class MisterPresident
{
    public void RunTheCountry()
    {
        Advisor Petraeus = new MilitaryAdvisor();
        Advisor Condi = new ForeignSecretary();
        Advisor mrX= new HealthOfficial();
        Petraeus.Advise(); // # Petraeus says send 100,000 troops to Fallujah
        Condi.Advise(); // # she says negotiate trade deal with Iran
        mrX.Advise(); // # they say we need to spend $50 billion on ObamaCare
    }
}
```

3° En we kunnen hem nog helpen door met een array of `List<Advisor>` te werken zodat hij ook niet steeds de "namen" van z'n adviseurs moet kennen:

```csharp
public class MisterPresident
{
    public void RunTheCountry()
    {   
        List<Advisor> allMinisters= new List<Advisor>();
        allMinisters.Add(new MilitaryAdvisor());
        allMinisters.Add(new ForeignSecretary());
        allMinisters.Add(new HealthOfficial());

        //Ask advise from each:
        foreach (Advisor minister in allMinisters)
        {
            minister.Advise();
        }
    }
}
```

En wie zei dat het presidentschap moeilijk was?!

## Nog voorbeelden van polymorfisme nodig?

Volgende tekst heeft een leuke insteek om polymorfisme uit te leggen... aan de hand van...wait for it... Zeemeerminnen! :) [Lezen maar!](http://www.techoschool.com/Technology/Dotnet/Csharp-for-Beginners_Csharp-Polymorphism)

Volgende voorbeeld is iets praktischer: [Arena with a mage in C# .NET (inheritance and polymorphism)](https://www.ict.social/csharp/oop/arena-with-mage-in-csharp-net-inheritance-and-polymorphism)

# Is en As

We introduceren twee nieuwe C# keywords: `is` en `as`.

## Is keyword

Het `is` keyword is een operator die je kan gebruiken om te weten te komen of:

- Een object van een bepaalde type is
- Een object een bepaalde interface bevat

`is` geeft een bool terug.

### Is voorbeeld 1

Stel dat we volgende drie klassen hebben:

```csharp
class Vehicle {}

class Car: Vehicle{}

class Person {}
```

Een Car **is** een Vehicle. Een Person **is geen** Vehicle.

Stel dat we enkele variabelen hebben als volgt:

```csharp
Car myCar = new Car();
Person rambo = new Person();
```

We kunnen nu de objecten met `is` bevragen of ze van een bepaalde type zijn:

```csharp
if(myCar is Vehicle)
{
    Console.WriteLine("The first object is a Vehicle");
}
if(rambo is Vehicle)
{
    Console.WriteLine("The second object is a Vehicle");
}
```

De uitvoer zal worden:`The first object is a Vehicle`.

## As keyword met voorbeeld

Wanneer we objecten van het ene naar het andere type willen omzetten dan doen we dit vaak met behulp van [casting](https://timdams.gitbooks.io/csharpfromantwerp/content/3_data/4_converteren_casting.html):

```csharp
Student fritz= new Student();
Mens jos = (Mens)fritz;
```

Het probleem bij casting is dat dit niet altijd lukt. Indien de conversie niet mogelijk is zal een Exception gegenereerd worden en je programma zal crashen als je niet aan [Exception handling doet](https://codevan1001nacht.wordpress.com/2013/11/06/exception-handling/).

Het `as` keyword lost dit op. Het keyword zegt aan de compiler 'probeer dit object te converteren. Als het niet lukt, zet het dan op `null` in plaats van een Exception te werpen.

De code van daarnet herschrijven we dan naar:

```csharp
Student fritz = new Student();
Mens jos = fritz as Mens;
```

Indien nu de casting niet lukt (omdat ´´Student´´ misschien geen child klasse van ´´Mens´´ blijkt te zijn) dan zal `jos` de waarde `null` hebben gekregen.

We kunnen dan vervolgens bijvoorbeeld schrijven:

```csharp
Student fritz= new Student();
Mens jos =fritz as Mens;
if(jos!=null)
{
    //Doe Mens-zaken   
}
```

# Why should I care?

![img](./pg012.jfif)

De `is` en `as` keywords laten toe om meer dynamische code te schrijven. Mogelijk weet je niet op voorhand wat voor datatype je code zal moeten verwerken en wordt polymorfisme je oplossing. Maar dan? Dan komen `is` en `as` to the rescue!

Je , dank zij polymorfisme, gevuld lijst van objecten van allerhande typen wordt nu beheersbaarder. Je kan nu , met `is` een element bevragen of hij van een bepaald type is. Vervolgens kan je met `as` het element even 'omzetten' naar z'n effectieve type (en dus meer doen dan wat hij kan in de vermomming van z'n eigen basistype).

In dit hoofdstuk gaan we dieper in hoe we objecten kunnen vergelijken op gelijkheid met behulp van de `Equals` methode die in `System.Object` gedefinieerd wordt. We hebben dit reeds behandeld in het hoofdstuk over [System.Object](https://timdams.gitbooks.io/csharpfromantwerp/content/13_advancedovererving/4_System_Object.html). We hebben nu echter voldoende bagage dankzij de voorgaande hoofdstukken om een complete oplossing te vinden.

We zullen stap voor stap opbouwen en motiveren waarom dit de enige correcte manier is.

Als leuk zij-effect krijgen we het feit dat deze uitleg aardig wat reeds opgedane kennis vereist: we kunnen deze zaken dus ineens herhalen en toelichten in de context van de `Equals` methode.

## Heap en stack

C# programma’s gebruiken twee soorten geheugens:

- De stack
- De heap

De volledige werking van deze geheugens gaan we niet terug herhalen. Voor ons belangrijk is te weten dat variabelen van built-in .NET types (int , char, etc.) in de stack worden bewaard. Objecten daarentegen worden in de heap bewaard. Indien je een object aanmaakt met de new operator en deze bewaard in een lokale variabele zoals hier:

```csharp
Point punt1 = new Point();
```

dan zal in de heap een `Point` object worden aangemaakt. Vervolgens krijgt een kleine variabele genaamd `punt1` in de stack het adres naar dat aangemaakt object. `punt1` zelf bevat dus niet meer dan een geheugenadres én dus niet het eigenlijke punt. We zullen dit verder op nodig hebben.

# Objecten vergelijken

## Value types en de == operator

Wanneer we twee variabele van een van de ingebouwde .NET types (behalve string) met elkaar vergelijken (int, char, etc.) dan kunnen we schrijven:

```csharp
int getal1 = 4;
int getal2= 5;
if(getal1 == getal2)
{
    Console.WriteLine("Getallen zijn gelijk"):
}
```

Dit werkt omdat de variabelen `getal1` en `getal2` in het geheugen de effectieve waarden 4 en 5 bezitten. **Maar wat gebeurt er indien we twee objecten met elkaar op deze manier vergelijken?**

## Objecten en de == operator

Stel dat we een klasse Point hebben dat we gebruiken om een 2-dimensionaal punt voor te stellen:

```csharp
class Point
{
    public int X {get;set;}
    public int Y {get;set;}
}
```

We zouden nu kunnen denken dat volgende code `Punten zijn gelijk` op het scherm zal tonen:

```csharp
Point punt1= new Point();
punt1.X=3;
punt1.Y=5;

Point punt2= new Point();
punt2.X=3;
punt2.Y=5;

if(punt1==punt2)
{
    Console.WriteLine("Punten zijn gelijk");
}
```

Echter, objecten worden we weten dat objecten "by reference" in het geheugen worden bewaard. Wat dit wil zeggen is dat de variabelen `punt1` en `punt2` in het geheugen niet het volledig object bevatten. Ze bevatten enkel een geheugenadres (pointer, referentie) naar een andere plaats (in de heap) waar het volledige object zich bevindt.

Wanneer we dus de expressie `punt1==punt2` schrijven dan zal de inhoud van die 2 variabelen worden vergeleken, zijnde de 2 adressen. Daar beide variabelen naar een ander adres wijzen zal deze test dus fout teruggeven. Als we 1 extra lijn voor de if toevoegen:

```csharp
punt1 = punt2;

if(punt1==punt2)
{
    Console.WriteLine("Punten zijn gelijk");
}
```

Dan zal de test wel `true` teruggeven: we hebben vlak voor de test gezegd dat er in de variabele `punt1` het geheugenadres moet komen dat ook in `punt2` staat. Met andere woorden: zowel `punt1`, als `punt2` bevatten nu hetzelfde adres, namelijk dat van het object met waarden `X=3` en `Y=6`. Het object met `Y=5` zijn we kwijt door de garbage collector: die heeft gezien dat er geen enkele variabele meer wijst naar dat object en heeft het dus verwijderd. De variabelen `punt1` en `punt2` zijn nu dus wel gelijk: ze hebben dezelfde inhoud, namelijk hetzelfde adres naar hetzelfde object.

## Objecten vergelijken zonder overerving

Hoe kunnen we dan wel 2 objecten vergelijken? Hiervoor dienen we, manueel, alle properties en private fields te vergelijken met elkaar van beide objecten. Althans, jij als programmeur moet beslissen wanneer 2 objecten gelijk zijn. Mogelijk vind je dat 2 punten gelijk zijn als ze beide dezelfde X-waarde hebben ongeacht de Y-waarde. Maar wij prefereren natuurlijk dat zowel de X als de Y-waarde dezelfde is en kunnen dus schrijven:

```csharp
if(punt1.X== punt2.X && punt1.Y== punt2.Y)
```

We zouden dit dan in een handige [static methode](https://timdams.gitbooks.io/csharpfromantwerp/content/10_advancedklassen/5_static.html) kunnen plaatsen :

```csharp
static bool VergelijkPunten(Point p1, Point p2)
{
    if(punt1.X== punt2.X && punt1.Y== punt2.Y)
    {
        return true;
    }
    else{return false; }
}
```

Nog leuker zou natuurlijk zijn als we de vergelijking **in** het object zelf kunnen doen. We zouden dan aan een object kunnen vragen "beste punt1, is het volgende punt dat ik als parameter meegeef gelijk aan jou of niet?". Hiermee leggen we de verantwoordelijkheid bij het object en zorgen we dat alles mooi geëncapsuleerd en samen blijft. Onze uitgebreide Point-klasse wordt dan:

```csharp
class Point
{
    public int X {get;set;}
    public int Y {get;set;}

    public bool IsDitPuntGelijk(Point anderePunt)
    {
        if(X== anderePunt.X && Y== anderePunt.Y)
        {
            return true;
        }
        else{return false;}
    }
}
```

Ieder object van het type Point bevat dus nu een methode `IsDitPuntGelijk` waarbij we een ander punt meegeven als parameter. Daar de test in het punt zelf wordt gedaan hebben we onmiddellijke toegang tot alle, al dan niet, private variabelen van het punt in kwestie.

Elders kunnen we dus schrijven:

```csharp
if(punt1.IsDitPuntGelijk(punt2))
```

In de wereld waar we overerving nog niet kennen zou dit een mooi einde zijn van de oefening…maar we kennen overerving en gaan dus een stapje verder.

# System.Object: De grondlegger van alles

Uit een vorige hoofdstuk weten we dat alle klassen overerven van `System.Object` en dat deze een methode Equals bevat. Deze werd speciaal toegevoegd om objecten op gelijkheid te testen. We moeten echter de implementatie zelf schrijven, daar .NET niet kan voorspellen hoe jij vindt dat objecten dezelfde zijn.

Wat we vorige keer niet zagen is dat er twee versies van de `Equals` methode beschikbaar zijn in `System.Object`:

- Een static versie
- Een gewone object-methode versie

```csharp
object object1 = new object();
object object2 = new object();

//object methode versie
if(object1.Equals(object2))
    Console.WriteLine("gelijk!");

//static versie
if(Object.Equals(object1, object2))
    Console.WriteLine("gelijk!");
```

## Equals als virtual methode

Wij gaan ons nu concentreren op de eerste, niet-statische, `Equals` methode. Bekijken we de signature van de Equals methode in System.Object dan zien we:

```csharp
public virtual bool Equals(Object obj)
```

Met andere woorden, deze methode is `virtual` gemaakt zodat andere klasse deze methode kunnen override`'n. Laten we dit eerst eens **niet** doen. Daar Point van `System.Object` overerft kunnen we schrijven:

```csharp
Point punt1 = new Point();
punt1.X = 3;
punt1.Y = 5;

Point punt2= new Point();
punt2.X = 3;
punt2.Y = 5;

if(punt1.Equals(punt2))
{
    Console.WriteLine("Punten zijn gelijk");
}
```

Standaard zal de `Equals` methode van `System.Object` simpelweg kijken of beide objecten naar hetzelfde geheugenadres wijzen (zoals eerder reeds aangehaald). Dit is hier niet het geval. Volgende code uitvoeren zal wél ``Punten zijn gelijk´´ op het scherm tonen:

```csharp
punt1 = punt2;
if(punt1.Equals(punt2))
{
    Console.WriteLine("Punten zijn gelijk");
}
```

`System.Object` weet natuurlijk niet welke andere klassen allemaal de originele Equals methode zal gebruiken en kan dus ook moeilijk voor al die andere klassen de nodige code voorzien. We zullen dus in onze `Point` klasse de `Equals` methode moeten herschrijven waarbij we ze zullen laten werken zoals we willen: *punten zijn gelijk indien zowel hun X als hun Y waarde dezelfde is.*

Wanneer we een bestaande methode willen overriden dan moeten we **EXACT DEZELFDE SIGNATURE** overnemen van de originele methode. De signature van de originele methode is `virtual bool Equals(object obj)`.

We zijn dus verplicht om deze methode zo over te nemen in onze Point klasse, waarbij we het virtual keyword natuurlijk vervangen door `override`:

```csharp
class Point: System.Object
{
    public int X {get;set;}
    public int Y {get;set;}

    public override bool Equals (object obj)
    {
        return true;
    }
}
```

Daar we steevast `true` teruggeven hierboven zal onderstaande code altijd in de if gaan. Alle Point objecten zouden gelijk zijn, ongeacht of dat nu is of niet:

```csharp
if(punt1.Equals(punt2))
```

Merk op dat dit dezelfde code is als voor we de `Equals` methode override’n. Echter, aangezien we de Equals methode *wel* override'n zullen we dus de implementatie uitvoeren die in de Point klasse staat, en niet die van `System.Object`.

# Polymorfisme duikt op

Maar nu komt het nieuwe element om de hoek kijken: *hoe kunnen we nu binnen onze nieuwe Equals methode de punten vergelijken?* We krijgen binnen de Equals methode een parameter van het type `Object` binnen...

Als we het volgende schrijven dan begint Visual Studio te huilen:

```csharp
public override bool Equals (object obj)
{
    if(X==obj.X && Y== obj.Y) //BAAAAD CODE
        return true;
    return false
}
```

Inderdaad. De `obj` parameter is van de `Object` klasse, en deze klasse heeft geen `X` en `Y` properties. We zullen dus die obj parameter naar een punt moeten transformeren. Dit kan op twee manieren:

- Via casting: `Point t= (Point)obj;`
- Via `as`: `Point t= obj as Point;`

Laten we even veronderstellen dat we de Equals methode in onze Point klasse altijd gebruiken om 2 Points te vergelijken niets anders: we weten dan dat de obj parameter ook kan aanschouwd worden als een Point. En we kunnen dus de obj parameter casten naar een (tijdelijk) Point:

```csharp
public override bool Equals (object obj)
{
    Point tijdelijk= (Point)obj;
    if(X==tijdelijk.X && Y== tijdelijk.Y) 
        {return true; }
    else {return false; }
}
```

We maken dus een tijdelijke variabele aan en zetten daarin het adres van de binnenkomende obj object. Als we namelijk naar `obj` zouden gaan zien in het geheugen (de heap) dan zouden we daar effectief een object van het type System.Object zien staan, maar vlak erachter staan de X en de Y-waarden. We zeggen dus eigenlijk: *"beste variabele `tijdelijk`, jij verwijst naar het geheugenadres van de obj parameter, maar ik weet dat die obj-parameter van het type Point is...Kijk dus maar verder in het geheugen en beschouw de obj parameter als een `Point`*.

We kunnen dus nu obj vergelijken met het punt zelf. Wanneer we dus schrijven: `if(punt1.Equals(punt2))`.

Dan zal de `Equals` methode *op het `punt1`* uitgevoerd worden. `X` en `Y` bevatten met andere woorden de waarden van `punt1`. `Punt2` in dit geval zal als object `obj` de methode binnenkomen.

# Verbetering: is to the rescue

Het is natuurlijk gevaarlijk om te veronderstellen dat we de `Equals` methode op de ``Point´´ klasse altijd correct gaan gebruiken. Stel dat we zouden schrijven:

```csharp
if(punt1.Equals("mijn locatie is hier"))
```

dan gaan we dus proberen om een Point te vergelijken met een `string`. *We vergelijken appelen met peren.*

Het is dus aan te raden om een controle(s) in te bouwen in de `Equals` methode: voor we `obj` gaan casten naar een `Point` gaan we eerst controleren of deze wel kan gecast worden.

**Met andere woorden: we gaan vragen wat het echte type van obj is.**

```csharp
public override bool Equals (object obj)
{
    if(obj is Point)
    {
        Point tijdelijk= (Point)obj;
        if(X==tijdelijk.X && Y== tijdelijk.Y) 
            return true;
    }
    else {return false; }
}
```

Enkel indien het type van `obj` dezelfde is als het type van het object waarbinnen we de ``Equals´´ methode aanroepen zullen we verder werken. Als we deze controle niet zouden doen dan zou deze lijn:

```csharp
Point tijdelijk = (Point)obj;
```

proberen om `"mijn locatie is hier"` om te zetten (casten) naar een Point, wat zou resulteren in een `InvalidCastException`.

# Checken op null

Als finale check moeten we ook controleren of we geen null-object als parameter aan de methode meegeven. Mogelijk probeer je een bestaand object te vergelijken met een nog niet geïnstantieerd object en dan krijgen we een `NullReferenceException`.

Onze finale `Equals` methode wordt:

```csharp
public override bool Equals (object obj)
{
    if(obj != null)
    {
        if(obj is Point)
        {
            Point tijdelijk = (Point)obj;
            if(X == tijdelijk.X && Y == tijdelijk.Y) 
                return true;
        }
    }
    else { return false; }
}
```



