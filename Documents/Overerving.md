# Overerving

Een van de sleutelaspecten binnen object-georiënteerd programmeren (OOP) is overerving, en C# is volledig op het concept van OOP gebouwd. Overerving geeft ons de mogelijkheid om klassen te creëren die bepaalde aspecten overerven van bovenliggende klassen (parent classes). Het volledig .NET framework is op dit concept gebouwd, wat als gevolg heeft dat alles aangezien wordt als een object. Zelfs een simpel getal is een instantie van een klasse die overerft van de **System.Object** klasse. Het framework helpt ons hierbij wel een beetje, zodat we een **nummer** direct kunnen toewijzen en niet telkens met keyword *new* een **instantie** van bijvoorbeeld de integer klasse moeten aanmaken.

**POD** type: Plain Old Data type. Voorbeelden: int, float, double, long, string, ... . 

vererving (**inheritance**) laat ons toe om klassen te specialiseren vanuit een reeds bestaande basisklasse. Wanneer we een klasse van een andere klasse overerven dan zeggen we dat deze nieuwe klasse een child-klasse of sub-klasse is van de bestaande parent-klasse of super-klasse.

De child-klasse kan alles wat de parent-klasse kan, maar de nieuwe klasse kan nu ook extra specialisatie code krijgen.

## Is-een relatie

Wanneer twee klassen met behulp van een "x is een y"-relatie kunnen beschreven worden dan weet je dat overerving mogelijk.

- Een paard **is een** dier (paard = child-klasse, dier= parent-klasse)
- Een tulp **is een** plant

(Opgelet: wanneer we "x heeft een y" zeggen gaat het **niet** over overerving, maar over compositie)

## Inheritance in CS

Overving duid je aan met behulp van het dubbele punt(:) bij de klassedefinitie:

Een voorbeeld:

```csharp
class Paard: Dier
{
   public bool KanHinnikken{get;set;}
}

class Dier
{
   public void Eet()
   {
    //...
   }
}
```

Objecten van het type Dier kunnen enkel de Eet-methode aanroepen. Objecten van het type Paard kunnen de Eet-methode aanroepen én ze hebben ook een property KanHinnikken:

```csharp
Dier aDier = new Dier();
Paard bPaard = new Paard();
aDier.Eet();
bPaard.Eet();
bPaard.KanHinnikken = false;
aDier.KanHinnikken = false; //!!! zal niet werken!
```

## Multiple inheritance

In C# is het niet mogelijk om een klasse van meer dan een parent-klasse te laten overerven (zogenaamde multiple inheritance), wat wel mogelijk is in sommige andere object georiënteerde talen.

## Transitive

Overerving in C# is transitief, dit wil zeggen dat de child-klasse ALLES overerft van de parent-klasse: methoden, properties, etc.

## Protected

Ook al is overerving transitief, hou er rekening mee dat private variabelen en methoden van de parent-klasse NIET rechtsreeks aanroepbaar zijn in de child-klasse. **Private** geeft aan dat het element enkel in de klasse zichtbaar is:

```csharp
class Paard: Dier
{
   public void MaakOuder()
   {
      leeftijd++; //  !!! dit zal error geven!
   }
}

class Dier
{
   private int leeftijd;
}
```

Je kan dit oplossen door de **protected** access modifier ipv private te gebruiken. Met protected geef je aan dat het element enkel zichtbaar is binnen de klasse **en** binnen child-klassen:

```csharp
class Paard: Dier
{
   public void MaakOuder()
   {
      leeftijd++; //  werkt nu wel
   }
}

class Dier
{
   protected int leeftijd;
}
```

## Sealed

Soms wil je niet dat van een klasse nog nieuwe klasse kunnen overgeërfd worden. Je lost dit op door het keyword `sealed` voor de klasse te zetten:

```csharp
sealed class DoNotInheritMe
{
   //...
}
```

Als je later dan dit probeert:

```csharp
class ChildClass:DoNotInheritMe
{
   //...
}
```

zal dit resulteren in een foutboodschap, namelijk `cannot derive from sealed type 'DoNotInheritMe'`.

# Constructors bij overerving

Wanneer je een object instantiëert van een child klasse dan gebeuren er meerdere zaken na elkaar, in volgende volgorde:

- Eerst wordt de constructor aangeroepen van de basis-klasse: dus steeds eerst die van `System.Object`
- Gevolgd door de constructors van alle parent-klassen
- Finaal de constructor van de klasse zelf.

Volgende voorbeeld toont dit in actie:

```csharp
class Soldier
{
   public Soldier() {Console.WriteLine("Soldier reporting in");}
}

class Medic:Soldier
{
   public Medic(){Console.WriteLine("Who needs healing?");}
}
```

Indien je vervolgens een object aanmaakt van het type Medic:

```csharp
Medic RexGregor= new Medic();
```

Dan zal zien we de volgorde van constructor-aanroep op het scherm:

```text
Soldier reporting in
Who needs healing?
```

Er wordt dus verondersteld in dit geval dat er een default constructor in de basis-klasse aanwezig is.

## Overloaded constructors

Indien je klasse Soldier een overloaded constructor heeft, dan geeft deze niet automatisch een default constructor. Volgende code zou dus een probleem geven indien je een Medic wilt aanmaken via `new Medic()`:

```csharp
class Soldier
{
   public Soldier(bool canShoot) {//...Do stuff  }
}

class Medic:Soldier
{
   public Medic(){Console.WriteLine("Who needs healing?");}
}
```

Wat je namelijk niet ziet bij child-klassen en hun constructors is dat er eigenlijk een impliciete call naar de basis-constructor wordt gedaan. Bij alle constructors staat eigenlijk `:base()` wat je ook zelf kunt schrijven:

```csharp
class Medic:Soldier
{
   public Medic(): base()
   {Console.WriteLine("Who needs healing?");}
}
```

`base()` achter de constructor zegt dus eigenlijk 'roep de constructor van de parent-klasse aan. Je mag hier echter ook parameters meegeven en de compiler zal dan zoeken naar een constructor in de basis-klasse die deze volgorde van parameters kan accepteren.

We zien hier dus hoe we ervoor moeten zorgen dat we terug Medics via `new Medic()` kunnen aanroepen zonder dat we de constructor(s) van Soldier moeten aanpassen:

```csharp
class Soldier
{
   public Soldier(bool canShoot) {//...Do stuff  }
}

class Medic:Soldier
{
   public Medic():base(true)
    {Console.WriteLine("Who needs healing?");}
}
```

De medics zullen de canShoot dus steeds op true zetten. Uiteraard wil je misschien dit kunnen meegeven bij het aanmaken van een object zoals `new Medic(false)`, dit vereist dat je dus een overloaded constructor in Medic aanmaakt, die op zijn beurt de overloaded constructor van Soldier aanroept. Je schrijft dan een overloaded constructor in Medic bij:

```csharp
class Soldier
{
   public Soldier(bool canShoot) {//...Do stuff  }
}

class Medic:Soldier
{
   public Medic(bool canSh): base(canSh)
   {} 

   public Medic():base(true)  //Default
    {Console.WriteLine("Who needs healing?");}
}
```

Uiteraard mag je ook de default constructor aanroepen vanuit de child-constructor, alle combinaties zijn mogelijk (zolang de constructor in kwestie maar bestaat in de parent-klasse).

# Virtual en Override

Soms willen we aangeven dat de implementatie (code) van een property of methode in een parent-klasse door child-klassen mag aangepast worden. Dit geven we aan met het **virtual** keyword:

```csharp
class Vliegtuig
{
   public virtual void Vlieg()
   {
      Console.WriteLine("Het vliegtuig vliegt rustig door de wolken.");
   }
}

class Raket: Vliegtuig
{
}
```

Stel dat we 2 objecten aanmaken en laten vliegen:

```csharp
Vliegtuig f1 = new Vliegtuig();
Raket spaceX1 = new Raket();
f1.Vlieg();
spaceX1.Vlieg();
```

De uitvoer zal dan zijn:

```
Het vliegtuig vliegt rustig door de wolken.
Het vliegtuig vliegt rustig door de wolken.
```

Een raket is een vliegtuig, toch vliegt het anders. We willen dus de methode Vlieg anders uitvoeren voor een raket. Daar hebben we **override** voor nodig. Door override voor een methode in de child-klasse te plaatsen zeggen we "gebruik deze implementatie en niet die van de parent klasse." **Je kan enkel overriden indien de respectievelijke methode of property in de parent-klasse als virtual werd aangeduid**

```csharp
class Raket:Vliegtuig
{
   public override void Vlieg()
   {
      Console.WriteLine("De raket verdwijnt in de ruimte.");
   }     
}
```

De uitvoer van volgende code zal nu anders zijn:

```csharp
Vliegtuig f1 = new Vliegtuig();
Raket spaceX1 = new Raket();
f1.Vlieg();
spaceX1.Vlieg();
```

Uitvoer:

```
Het vliegtuig vliegt rustig door de wolken.
De raket verdwijnt in de ruimte.
```

# Properties overriden

Ook properties kan je virtual instellen en override'n.

**Opgelet**: Visual Studio gebruikt Expression Body Member syntax (herkenbaar aan de `=>`) om properties te overriden. Deze syntax kennen we niet. **Je schrijft dus best manueel de override van properties**

Stel dat je volgende klasse hebt:

```csharp
    class Auto
    {
        virtual public int Fuel { get; set; }
    }
```

We maken nu een meer luxueuze auto die een lichtje heeft dat aangaat wanneer de benzine-tank vol genoeg is, dit kan via override.

```csharp
class LuxeAuto : Auto
{
   public bool HeeftVolleTank { get; set; }

   public override int Fuel
   {
      get { return base.Fuel; }
      set
      {
            if (value > 100)
            {
               HeeftVolleTank = true;
            }
            base.Fuel = value;
      }
   }
}
```

# Base keyword

Het **base** keyword laat ons toe om bij een overriden methode of property in de child-klasse toch te verplichten om de parent-implementatie toe te passen.

Stel dat we volgende 2 klassen hebben:

```csharp
class Restaurant
{
     protected int kosten=0;
     public virtual void PoetsAlles()
     {
           kosten += 1000;
     }
}

class Frituur:Restaurant
{
     public override void PoetsAlles()
     {
           koste n+= (1000 + 500);
     }

}
```

Het poetsen van een Frituur is duurder (1000 basis + 500 voor ontsmetting) dan een gewoon restaurant. Als we echter later beslissen dat de basisprijs (in Restaurant) moet veranderen dan moet je ook in alle child-klassen doen. Base lost dit voor ons. De Frituur-klasse herschrijven we naar:

```csharp
class Frituur:Restaurant
{
     public override void PoetsAlles()
     {
           base.PoetsAlles(); //eerste basiskost wordt opgeteld
           kosten += 500;  //kosten eigen aan frituur worden bijgeteld.
     }

}
```

# Non-polymorphism: new keyword

* **virtual** en **override** gaan samen: polymorfisme
* zonder keyword virtual: de method wordt toegepast zoals deze gedefinieerd is op niveau van het class type. Je kan dit expliciet aangeven door gebruik te maken van het keyword **new**. Dit is echter ook zonder new het geval ... .
* het is mogelijk om via een zogenaamde "**cast**" de method van je keuze op te roepen

```C#
class A 
{
    public string Foo() 
    {
        return "A";
    }

    public virtual string Test()
    {
        return "base test";
    }
}

class B: A
{
    public new string Foo() 
    {
        return "B";
    }
}

class C: B 
{
    public string Foo() 
    {
        return "C";
    }

    public override string Test() {
        return "derived test";
    }
}
```

```C#
A AClass = new B();
Console.WriteLine(AClass.Foo());
B BClass = new B();
Console.WriteLine(BClass.Foo());
B BClassWithC = new C();
Console.WriteLine(BClassWithC.Foo());

Console.WriteLine(AClass.Test());
Console.WriteLine(BClassWithC.Test());
```

```
A
B
B
base test
derived test
```



