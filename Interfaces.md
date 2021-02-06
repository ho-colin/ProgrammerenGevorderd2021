# Interfaces

In de vorige hoofdstukken hadden we het over abstracte klassen. Interfaces lijken in vele opzichten op abstracte klassen en van beiden kunnen er geen instanties gecreëerd worden. Interfaces zijn echter nog conceptueler dan abstracte klassen, aangezien er binnen een interface geen methoden met code toegelaten zijn. Een interface is dus een soort abstracte klasse die niets anders bevat dan abstracte methoden. Gezien dat er geen methoden zijn met code is er ook geen nood aan velden. Eigenschappen zijn echter wel toegelaten, evenals indexers en evenementen. Je kan een interface aanzien als een soort contract - een klasse die een interface implementeert wordt verplicht alle methoden en eigenschappen van de interface te implementeren. Het belangrijkste verschil is echter dat C# de implementatie van meerdere interfaces wel toestaat, terwijl meervoudige overerving (waarbij één klasse overerft van meerdere basisklassen) niet is toegestaan.

Hoe ziet dit alles er nu uit in onze code? Hieronder volgt een goed voorbeeld. Probeer het misschien zelf even uit en lees dan de volledige uitleg:

```c#
using System;
using System.Collections.Generic;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dog> dogs = new List<Dog>();
            dogs.Add(new Dog("Fido"));
            dogs.Add(new Dog("Bob"));
            dogs.Add(new Dog("Adam"));
            dogs.Sort();
            foreach(Dog dog in dogs)
                Console.WriteLine(dog.Describe());
            Console.ReadKey();
        }
    }

    interface IAnimal
    {
        string Describe();

        string Name
        {
            get;
            set;
        }
    }

    class Dog : IAnimal, IComparable
    {
        private string name;

        public Dog(string name)
        {
            this.Name = name;
        }

        public string Describe()
        {
            return "Hello, I'm a dog and my name is " + this.Name;
        }

        public int CompareTo(object obj)
        {
            if(obj is IAnimal)
                return this.Name.CompareTo((obj as IAnimal).Name);
            return 0;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
```

Laat ons beginnen in het midden, waar onze interface gedeclareerd wordt. Zoals je ziet is het enige verschil in de declaratie het gebruikte keyword (interface in plaats van class). Ook merk je dat de naam van de interface wordt voorafgegaan door de letter I (van Interface) - dit is niet verplicht maar het is een codeerafspraak en het zorgt er ook voor dat je een interface overal in je code direct herkent. Aangezien het gebruik van klassen en interface dicht bij elkaar aanleunt is het een goed idee om op basis van de naamgeving het verschil duidelijk te maken.

Vervolgens declaren we de Describe() methode en ook de Name eigenschap. De Name eigenschap heeft zowel een get als een set keyword, wat ervoor zorgt dat Name gelezen en overschreven kan worden. Je zal ook zien dat de zichtbaarheid (public, private, protected, …) ontbreekt, deze zijn niet toegelaten binnen een interface. Alles binnen een interface wordt standaard ingesteld als public.

Vervolgens komt onze Dog klasse. Dit ziet er net uit alsof deze overerft van een andere klasse, met de dubbelpunt tussen de naam van de klasse en de klasse/interface die wordt overgeërfd/geïmplementeerd. In ons voorbeeld worden 2 interfaces geïmplementeerd in dezelfde klasse, gescheiden door een komma. Je kan zoveel interfaces implementeren als je maar wilt. In ons voorbeeld implementeren we twee interfaces - onze eigen iAnimal interface en de .NET IComparable interface (dit is een gedeelde interface voor klassen die gesorteerd kunnen worden). Zoals je ziet hebben we zowel de Describe() methode als de eigenschap Name geïmplementeerd vanuit de IAnimal interface alsook de CompareTo methode uit de IComparable interface.

Nu denk je waarschijnlijk: "is dit het wel allemaal waard, als we hele methoden en eigenschappen moeten implementeren". Wel, een goed voorbeeld daarvan zie je bovenaan in de code. Daar voegen we een aantal Dog objecten toe aan onze lijst, die we dan sorteren. Hoe weet de lijst hoe hij honden moeten sorteren? Omdat onze Dog klasse een CompareTo methode heeft die kan zeggen hoe twee honden te vergelijken. Hoe weet onze lijst dat een Dog object dat kan en welke methode er moet aangeroepen worden om de honden te vergelijken? Omdat wij dat meegegeven hebben in onze code, door een interface te implementeren die een CompareTo methode belooft! Dat is de echte schoonheid van interfaces!