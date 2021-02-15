# Abstracte klassen

Abstracte klassen worden gemarkeerd met het keyword *abstract* in hun definitie. Ze worden meestal gebruikt om een basisklasse te definiëren binnen de hiërarchie. Wat speciaal is aan een abstracte klasse is dat je er geen instanties van kan maken, als je dit probeert zal je zien dat je een compilatiefout krijgt. Wat je dus moet doen is er een subklasse van maken zoals we gezien hebben in het hoofdstuk over overerving en dan een instantie maken van deze subklasse. Het gebruik van abstracte klassen hangt af van het gewenst doel.

Om eerlijk te zijn kan je al een heel eind ver raken zonder ooit een abstracte klasse nodig te hebben. Maar voor bepaalde zaken zijn ze zeer nuttig, zoals bijvoorbeeld framework. Binnen het .NET framework zal je dan ook een hele resem aan abstracte klassen terugvinden. Een goeie vuistregel is dat de naam abstract klasse eigenlijk moet kloppen. Abstracte klassen worden bijna altijd gebruikt om iets abstract te omschrijven, iets dat meer een concept is dan een echt ding.

In dit voorbeeld maken we een basis abstracte klasse for dieren met 4 poten en dan maken we een Dog klasse die daarvan overerft:

```c#
namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Console.WriteLine(dog.Describe());
            Console.ReadKey();
        }
    }

    abstract class FourLeggedAnimal
    {
        public virtual string Describe()
        {
            return "Not much is known about this four legged animal!";
        }
    }

    class Dog : FourLeggedAnimal
    {

    }
}
```

Als je dit nu vergelijkt met de voorbeelden in het hoofdstuk over overerving zal je weinig verschil zien. In feite is het keyword abstract in de definitie van de klasse FourLeggedAnimal het grootste verschil. Zoals je ziet maken we een instantie van onze Dog klasse en roepen we dan de overgeërfde methode Describe() aan uit de FourLeggedAnimal klasse. Probeer nu even een instantie te maken van de klasse FourLeggedAnimal zelf:

```csharp
FourLeggedAnimal someAnimal = new FourLeggedAnimal();
```

Je krijgt nu de volgende compilatiefout:

```c#
Cannot create an instance of the abstract class or interface 'AbstractClasses.FourLeggedAnimal'
```

We erven de methode Describe() over uit de klasse FourLeggedAnimal, maar in z'n huidige vorm is deze niet erg nuttig voor onze Dog klasse. Laat ons de methode Describe() overriden:

```c#
class Dog : FourLeggedAnimal
{
    public override string Describe()
    {
        return "This four legged animal is a Dog!";
    }
}
```

In dit geval doen we een volledige override, maar in sommige gevallen zal je het gedrag van de basisklasse willen overnemen en er extra functionaliteit aan toevoegen. Dit kan je doen met het base keyword die verwijst naar de klasse waarvan we overerven.

```c#
abstract class FourLeggedAnimal
{
    public virtual string Describe()
    {
        return "This animal has four legs.";
    }
}


class Dog : FourLeggedAnimal
{
    public override string Describe()
    {
        string result = base.Describe();
        result += " In fact, it's a dog!";
        return result;
    }
}
```

Je kan natuurlijk nog meer subklassen maken van de FourLeggedAnimal klasse. Misschien een kat of een leeuw? In het volgende hoofdstukken tonen we een aantal complexere voorbeelden en introduceren we ook abstracte methoden.

Abstracte methoden kan je enkel definiëren binnen abstracte klassen. Hun definitie mag er dan uitzien zoals een gewone methode, maar er zit geen code binnen een abstracte methode.

```C#
abstract class FourLeggedAnimal
{
    public abstract string Describe();
}
```

Waarom zou je nu een lege methode willen definiëren die niets doet? Omdat een abstracte methode methode een verplichting is als je die specifieke methode wil implementeren in alle subklassen. Dit wordt tijdens de compilatie gecontroleerd om zeker te zijn dat je subklassen deze methode gedefinieerd hebben. Dit is opnieuw een goeie manier om een basisklasse voor iets te creëren en toch enige controle te hebben over wat de subklasse zou moeten kunnen doen. Met dit in gedachten kan je een subklasse altijd op dezelfde manier behandelen als de basisklasse als je een als abstract gedefinieerde methode uit de basisklasse wil gebruiken. Bekijk even volgend voorbeeld:

```c#
namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.ArrayList animalList = new System.Collections.ArrayList();
            animalList.Add(new Dog());
            animalList.Add(new Cat());
            foreach(FourLeggedAnimal animal in animalList)
                Console.WriteLine(animal.Describe());
            Console.ReadKey();
        }
    }

    abstract class FourLeggedAnimal
    {
        public abstract string Describe();
    }


    class Dog : FourLeggedAnimal
    {

        public override string Describe()
        {
            return "I'm a dog!";
        }
    }

    class Cat : FourLeggedAnimal
    {
        public override string Describe()
        {
            return "I'm a cat!";
        }
    }
}
```

We maken een Arraylist om onze dieren in te bewaren. Dan maken we een nieuwe instantie van Dog en Cat en voegen deze toe aan onze lijst. Ze worden geïnstantieerd als respectievelijk Cat en Dog maar zijn ook van het type FourLeggedAnimal. En aangezien de compiler weet welke subklassen van de klasse FourLeggedAnimal allemaal de Describe() methode bevatten kan je die methode aanroepen zonder het exacte type van het dier te kennen. Door FourLeggedAnimal te typecasten (wat we doen in de foreach lus) krijgen we toegang tot de leden van de subklassen. Dit kan zeer handig zijn!

# Abstract

## Abstracte klassen

Soms maken we een parent-klasse waar op zich geen instanties van kunnen gemaakt worden: denk aan de parent-klasse `Dier`. Subklassen van Dier kunnen `Paard`, `Wolf`, etc zijn. Van Paard en Wolf is het logisch dat je instanties kan maken (echte paardjes en wolfjes) maar van 'een dier'? Hoe zou dat er uit zien.

Met behulp van het **`abstract`** kunnen we aangeven dat een klasse abstract is: je kan overerven van deze klasse, maar je kan er geen instanties van aanmaken.

We plaatsen `abstract` voor de klasse om dit aan te duiden.

Een voorbeeld:

```csharp
abstract class Dier
{
  public int Name {get;set;}
}
```

Volgende lijn zal een error geven: `Dier hetDier = new Dier();`

We mogen echter wel klassen overerven van deze klasse en instanties van aanmaken:

```csharp
class Paard: Dier
{
//...
}

class Wolf: Dier
{
 //..
}
```

En dan zal dit wel werken: `Wolf wolfje= new Wolf();`

En als we polymorfisme gebruiken, dan mag dit ook: `Dier paardje= new Paard();`

## Abstracte methoden

Het is logisch dat we mogelijk ook bepaalde zaken in de abstracte klasse als abstract kunnen aanduiden. Beeld je in dat je een Methode "MaakGeluid" hebt in je klasse Dier. Wat voor een geluid maakt 'een dier'? We kunnen dus ook geen implementatie (code) geven in de abstracte parent klasse.

Via abstracte methoden geven we dit aan: we hoeven enkel de methode signature te geven, met ervoor `abstract`:

```csharp
abstract class  Dier
{
   public abstract string MaakGeluid();
}
```

Merk op dat er geen accolades na de signature komen.

Child-klassen **zijn verplicht deze abstracte methoden te overriden**.

De Paard-klasse wordt dan:

```csharp
class Paard: Dier
{
  public override string MaakGeluid()
  { 
      return "Hinnikhinnik";
  }
}
```

(en idem voor de wolf-klasse uiteraard)

### Abstracte methoden enkel in abstracte klassen

Van zodra een klasse een abstracte methode of property heeft dan ben je, logischerwijs, verplicht om de klasse ook abstract te maken.

## Abstracte properties

Properties kunnen virtual gemaakt, en dus ook `abstract`. Volgende voorbeeld toont hoe dit werkt:

```csharp
    abstract class Dier
    {
        abstract public int MaxLeeftijd { get;}
    }

    class Olifant : Dier
    {
        public override int MaxLeeftijd {
            get { return 100; }
        }
    }
```

# Book (*)

## Deel 1

Maak een klasse `Book` en gebruik auto-properties voor de velden:

- ISBN (int)
- Title (string)
- Author (string)

Maak voorts een full property voor Price (double)

Maak een child-klasse die van Book overerft genaamd ‘TextBook. Een textbook heeft één extra property:

- GradeLevel (int)

Maak een child-klasse die van Book overerft genaamd ‘CoffeeTableBook’. Deze klasse heeft geen extra velden.

Voorts kunnen boeken "opgeteld" worden om als omnibus uitgebracht te worden. De titel wordt dan "Omnibus van [X]". waarbij X de Authors bevat, gescheiden met een komma. De prijs van een Omnibus is steeds de som van beide boeken gedeeld door 2. **Schrijf een `static` methode `TelOp` die twee `Book` objecten als parameter aanvaardt en als returntype een nieuw `Book` teruggeeft.**

In beide child-klassen, override de Price-setter zodat: a) Bij Textbook de prijs enkel tussen 20 en 80 kan liggen b) Bij CoffeeTableBooks de prijs enkel tussen 35 en 100 kan liggen

## Deel 2

- Zorg ervoor dat boeken de ToString overriden zodat je boekobjecten eenvoudig via Console.WriteLine(myBoek) hun info op het scherm tonen. Ze tonen deze info als volgt: "Title - Auteur (ISBN) *Price" (bv The Shining - Stephen King (05848152)* 50)
- (PRO) Zorg ervoor dat de equals methode werkt op alle boeken. Boeken zijn gelijk indien ze hetzelfde ISBN nummer hebben.

**Toon de werking aan van je 3 klassen:** Maak boeken aan van de 3 klassen, toon dat de prijs niet altijd zomaar ingesteld kan worden en (PRO) toon aan dat je Equals –methode werkt (ook wanneer je bijvoorbeeld een Book en TextBook wil vergelijken).

# Money, money, money (*)

Maak enkele klassen die een bank kan gebruiken.

1. Abstracte klasse `Rekening`: deze bevat een methode `VoegGeldToe` en `HaalGeldAf`. Het saldo van de rekening wordt in een private variabele bijgehouden (en via de voorgaande methoden aangepast) die enkel via een read-only property kan uitgelezen worden. Voorts is er een abstracte methode `BerekenRente` de rente als double teruggeeft.
2. Een klasse `BankRekening` die een Rekening is. De rente van een BankRekening is 5% wanneer het saldo hoger is dan 100 euro, zoniet is deze 0%.
3. Een klasse `SpaarRekening` die een Rekening is. De rente van een SpaarRekening bedraagt steeds 2%.
4. Een klasse `ProRekening` die een SpaarRekening is. De ProRekening hanteert de Rente-berekening van een SpaarRekening (`base.BerekenRente`) maar zal per 1000 euro saldo nog eens 10 euro verhogen.

Schrijf deze klassen en toon de werking ervan in je main.

# Geometric figures (*)

Maak een abstracte klasse `GeometricFigure`. Iedere figuur heeft een hoogte, breedte en oppervlakte. Maak autoproperties voor van `Hoogte` en `Breedte`. De oppervlakte is een read-only property want deze wordt berekend gebaseerd op de hoogte en breedte.

Voorzie een abstracte methode `BerekenOppervlakte` die een int teruggeeft.

Maak 3 klassen:

- Rechthoek: erft over van GeometricFigure. Oppervlakte is gedefinieerd als `breedte * hoogte`.
- Vierkant: erft over van Rechthoek. Voorzie een constructor die lengte en breedte als parameter aanvaard: deze moeten gelijk zijn, indien niet zet je deze tijdens de constructie gelijk. Voorzie een 2e constructor die één parameter aanvaardt dat dan geldt als zowel de lengte als breedte. Deze klasse gebruikt de methode BerekenOppervlakte van de Rechthoek-klasse.
- Driehoek: erft over van GeometricFigure. Oppervlakte is gedefinieerd als `breedte*hoogte/2`.

Maak een applicatie waarin je de werking van deze klassen aantoont.

<!--

# Dierentuin

Maak een console-applicatie waarin je een zelfverzonnen abstract klasse Dier in een List kunt plaatsen. Ieder dier heeft een gewicht en een methode `Zegt` (die abstract is) die het geluid van het dier in kwestie op het scherm zal tonen. Maak enkele childklassen die overerven van Dier en uiteraard de `Zegt` methode overriden.

Vervolgens vraag je aan de gebruiker wat voor dieren er in deze lijst moeten toegevoegd worden. Wanneer de gebruiker 'q' kiest stopt het programma met vragen welke dieren moeten toegevoegd worden en komt er een nieuw keuze menu. Het keuze menu heeft volgende opties:

a. Dier verwijderen , gevolgd door de gebruiker die invoert het hoeveelste dier weg moet uit de List.

b. Diergewicht gemiddelde: het gemiddelde van alle dieren hun gewicht wordt getoond

c. Dier praten: alle dieren hun Zegt() methode wordt aangeroepen en via WriteLine getoond

d. Opnieuw beginnen: de List wordt leeggemaakt en het programma zal terug van voor af aan beginnen.

Probeer zo modulair mogelijk te werken.

De enclave die je moet uitbouwen zal bestaan uit enkele essentiële gebouwen. We willen alle gebouwen volgens een zelfde concept uitwerken zodat onze stad zo modulair mogelijk wordt.

# Abstracte klasse Gebouw

Deze klasse is ... je raadt het nooit. Abstract.

De klasse heeft 3 auto properties:

- Ieder gebouw heeft een X en Y locatie (via int property) waar het gebouw zal verschijnen op de kaart.
- Ieder gebouw heeft een Naam (`string`)

De klasse heeft een abstracte methode `PrintGebouw`. Deze methode geeft niets terug en heeft geen parameters nodig.

De klasse override `ToString` en zal de volgende tekst teruggeven (veronderstel dat het gebouw als Naam `Hospitaal` heeft op locatie (3,4 )):

```text
Hospitaal (locatie: 3, 4)
```

De klasse heeft géén default constructor. Enkel een overloaded constructor die Naam, X en Y als parameters aanvaardt.

# Basis gebouwen klaarmaken

Maak de klassen van het volgende schema: ![Klassenschema enclave](C:/Users/u2389/source/repos/ProgrammerenGevorderd2021/Documents/pg006.png)

Iedere groene klasse heeft:

- Een overloaded constructor die X en Y coördinaat vraagt

- Override ToString en zal extra informatie over het gebouw geven (verzin zelf wat tekst per klasse). Merk op dat de ToString implementatie van de parent-klasse(n) nog steeds moet uitgevoerd worden.

- Implementeert de

   

  ```
  PrintGebouw
  ```

   

  methode. Voorlopig is de code in al deze klasse quasi dezelfde. De aanroep van deze methode zal resulteren in één karakter dat op het scherm verschijnt op de coördinaten X en Y.

  - Bij een woonst is dit karakter een `w`
  - Bij een flat is dit karakter een `W`
  - Bij een Hospitaal is dit karakter een `H`
  - Bij een Generator is dit karakter een `g`
  - Bij een Waterkrachtcentrale is dit karakter een `G`

# Maak een enclave

Test of je enclave werkt door volgende code in je main te steken:

```csharp
List<Gebouw> enclave=new List<Gebouw>();
enclave.Add(new Hospitaal("Sint Vincentius",4, 5));
enclave.Add(new Woonst("Tims shack",1, 1));
enclave.Add(new Generator("batteryshed 1",1, 2));

foreach(var gebouw in enclave)
{
    gebouw.PrintGebouw();
}
```

Dit zou volgende uitvoer moeten geven:

```
wg


   H
```

# Extra 1

Voeg kleur toe. Zorg ervoor dat ieder type gebouw in een andere kleur op het scherm komt. Dus de woonst geeft bijvoorbeeld een blauwe w. Een hospitaal een rode H.

# Bonuspoints:

Maak ook een Straat-klasse en voorzie wat straten in je enclave.

Mail je coolste stad naar mij met straten en gebouw. Mail me:

- Een screenshot
- Je code in zip

-->