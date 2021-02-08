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