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

# Oefeningen

## Het dierenrijk

![img](./animals.png)

Maak bovenstaande klassenhierarchie na. *Animal* is de parentklasse , mammal en reptile zijn childklassen van *Animal* en zo voort.

Verzin voor iedere klasse een property die de parent klasse niet heeft. (bv Animal heeft "BeweegVoort", *Reptile* heeft "AantalSchubben", etc).

Voorzie in de klasse *Animal* een virtual methode `ToonInfo` die alle properties van de klasse op het scherm zet. De overgeërfde klassen overriden deze methode door de extra properties ook te tonen (maar gebruik base.ToonInfo om zeker de parentklasse werking te bewaren).

Maak nu van iedere klasse een object en roep de ToonInfo methode van ieder object aan.

Plaats deze dieren nu in een `List<Animal>` en kijk wat er gebeurt als je deze met een foreach aanroept om alle ToonInfo-methoden van ieder dier te gebruiken.

## Ziekenhuis (*)

### Deel 1

Maak een basisklasse `Patient` die een programma kan gebruiken om de doktersrekening te berekenen. Een patiënt heeft:

- een naam
- het aantal uur dat hij in het ziekenhuis heeft gelegen

Een `virtual` methode `BerekenKost` zal de totaalkost berekenen. Deze bestaat uit 50 euro + 20 euro per uur dat de patiënt in het ziekenhuis lag.

Maak een methode `ToonInfo` die steeds de naam van de patiënt toont gevolgd door het aantal uur en z'n kosten.

### Deel 2

Maak een specialisatieklasse `VerzekerdePatient`. Deze klasse heeft alles dat een gewone `Patient` heeft, echter de berekening van de kosten zal steeds gevolgd worden door een 10% reductie.

Toon de werking aan van deze klasse.

## Balspel met overerving (*)

Volgende code toont hoe we een bestaande klasse `Ball` kunnen overerven om een bestuurbare bal te maken

### Basisklasse Ball

We maken een klasse `Ball` die via `Update` en `Draw` zichzelf over het consolescherm beweegt. Enkele opmerkingen:

- We maken sommige variabelen `protected` zodat later de overgeërfde klasse er aan kunnen
- Een `static` methode `CheckHit` laat ons toe te ontdekken of twee `Ball`objecten mekaar raken

```csharp
class Ball
{
   public int X { get { return x; } }
   public int Y { get { return y; } }
   private int x = 0;
   private int y = 0;
   protected int vx = 0;
   protected int vy = 0;
   protected char drawChar = 'O';
   protected ConsoleColor drawColor = ConsoleColor.Red;

   public Ball(int xin, int yin, int vxin, int vyin)
   {
      x = xin;
      y = yin;
      vx = vxin;
      vy = vyin;
   }

   public void Update()
   {
      x += vx;
      y += vy;
      if (x >= Console.WindowWidth || x < 0)
      {
            vx *= -1;
            x += vx;
      }
      if (y >= Console.WindowHeight || y < 0)
      {
            vy *= -1;
            y += vy;
      }
   }
   public void Draw()
   {
      Console.SetCursorPosition(x, y);
      Console.ForegroundColor = drawColor;
      Console.Write(drawChar);
      Console.ResetColor();

   }

   static public bool CheckHit(Ball ball1, Ball ball2)
   {

      if (ball1.X == ball2.X && ball1.Y == ball2.Y)
            return true;

      return false;
   }
}
```

### Specialisatie klasse PlayerBall

De overgeërfde klasse `PlayerBall` is een `Ball` maar zal z'n `vx` en `vy` updaten gebaseerd op input via de `ChangeVelocity` methode:

```csharp
class PlayerBall : Ball
{
   public PlayerBall(int xin, int yin, int vxin, int vyin) : base(xin, yin, vxin, vyin)
   {
      drawChar = 'X';
      drawColor = ConsoleColor.Green;
   }

   public void ChangeVelocity(ConsoleKeyInfo richting)
   {
      switch (richting.Key)
      {
            case ConsoleKey.UpArrow:
               vy--;
               break;
            case ConsoleKey.DownArrow:
               vy++;
               break;
            case ConsoleKey.LeftArrow:
               vx--;
               break;
            case ConsoleKey.RightArrow:
               vx++;
               break;
            default:
               break;
      }
   }
}
```

### Eenvoudig spel

We maken nu een rudimentair spel waarin de gebruiker een bal moet proberen te raken.

```csharp
static void Main(string[] args)
{
   Console.CursorVisible = false;
   Console.WindowHeight = 20;
   Console.WindowWidth = 30;
   Ball b1 = new Ball(4, 4, 1, 0);
   PlayerBall player = new PlayerBall(10, 10, 0, 0);
   while (true)
   {

         Console.Clear();

         //Ball
         b1.Update();
         b1.Draw();

         //SpelerBall
         if (Console.KeyAvailable)
         {
            var key = Console.ReadKey();
            player.ChangeVelocity(key);
         }

         player.Update();
         player.Draw();

         //Check collisions
         if (Ball.CheckHit(b1, player))
         {
            Console.Clear();
            Console.WriteLine("Gewonnen!");
            Console.ReadLine();
         }
         System.Threading.Thread.Sleep(100);
   }
}
```

Kan je dit uitbreiden met?

- Ballen met andere eigenschappen
- Meerdere ballen die over het scherm vliegen (benodigdheden: array)
- Meerdere levels
- Score gebaseerd op tijd die gebruiker nodig had om bal te raken (benodigdheden: teller die optelt na iedere `Sleep`)
- PRO: collision detection tussen de ballen

## Virus

We maken een applicatie waarmee we vaccins, virussen en vaccinatiecentra gaan simuleren. In deze wereld heeft ieder virus een "killcode", een verborgen code. Indien een vaccin de juiste killcode heeft dan kan deze gebruikt worden om een virus uit te schakelen.

### Maak een Vaccin klasse

Deze klasse heeft:

- Een Naam (`string`) als autoproperty met private setter.

- Enkel een overloaded constructor, waarbij je de naam van het vaccin kunt instellen

- Een methode TryKillCode die geen parameters aanvaardt en steeds een random getal tussen 1 en 100 teruggeeft

  - Indien Oplossing een andere waarde dan -1 heeft zal deze methode géén random getal teruggeven maar wel de waarde van Oplossing.

- Een autoproperty `Oplossing` van het type `int` deze staat standaard op -1.

- Een methode `ToonInfo` die de naam van het vaccin en de huidige Oplossing op het scherm zet.

### Maak een Virus klasse

Deze klasse heeft:

- Een Naam als autopoperty met private setter

- Een DoomCountdown (int) full property met private setter:

  - Indien doomcountdown 0 of lager wordt gezet zal er "Game over [Naam virus]" op het scherm verschijnen. Dit gebeurt in de setter van de property.
  
- Een private `int killcode`

- Enkel een default constructor die:

  - `DoomCountdown` op een getal tussen 10 en 20 instelt.
  - killcode op een getallen tussen 0 en 99 instelt
  - Naam wordt willekeurig als volgt: deze bestaat uit 3 willekeurige letters na mekaar, gevolgd door een getal tussen 1 en 99 (bv ABC34).

- Een methode

   

  ```
  TryVaccin
  ```

   

  die:

  - Eén parameter van het type `Vaccin` aanvaardt
  - Een bool teruggeeft. Deze zal true zijn indien het meegegeven Vaccin werkt:
    - De methode zal de `TryKillcode` aanroepen op het meegegeven Vaccin. Indien het resultaat van TryKillcode overeenkomt met de killcode van het Virus zal er een true teruggestuurd worden. Ook zal vervolgens de property Oplossing van het Vaccin op de geteste én werkende killcode ingesteld worden in het meegegeven Vaccin.
    - Indien de kill code verkeerd is wordt er false terugestuurd , maar niet voordat eerst de doomcountdown met 1 werd verlaagd.

### Fase 1 - zoeken vaccin

We gaan nu op zoek naar het juiste vaccin.

*Maak een virus aan.*

Maak een programma waarin je 5 vaccins aanmaakt en in een lijst plaatst. Vervolgens ga je deze vaccins blijven testen op een aangemaakt virus en toon je aan de gebruiker welke vaccins werkten. Van zodra je een werkend vaccin vindt stopt de test en moet je onthouden welk vaccin in de lijst werkt.

Indien de countdown van het virus op 0 komt te staan ben je gameover en heb je geen vaccin gevonden. De gebruiker zal het programma dus opnieuw moeten opstarten en hopen dat er deze keer wel een vaccin kan worden gevonden.

Indien je tijdig een vaccin gevonden hebt ga je naar fase 2.

### Fase 2 - Vaccinatiecentra

#### klasse vaccincatiecentrum

Maak een klasse `VaccinatieCentrum` aan.

Deze klasse heeft een `static` methode `BewaarVaccin`. Aan deze methode kan je een int als parameter meegeven. Deze parameter wordt in een `static` autoproperty genaamd `Oplossing` bewaard en bevat de killcode voor het virus die je uit het Vaccin kunt halen via de Oplossing-property dat je aan de methode meegeeft. Standaard staat deze code op -1.

Zorg ervoor dat de Vaccin klasse een extra constructor heeft die toelaat dat je ook een int kunt meegeven die zal gebruikt worden als de oplossing die het vaccin moet maken (en dus reeds vanuit de Oplossing kan uitgelezen worden). De constructor zal dus de property `Oplossing` reeds op de juiste waarde zetten. De aanroep van`TryKillCode` zal dus ook reeds de juiste killcode geven (wat normaal reeds in orde was gebrakt toen je de methode maakte in de eerste plaats).

Maak in de VaccinatieCentrum een methode `GeefVaccin` aan die geen parameters aanvaardt en een Vaccin als return type geeft. Deze methode zal null teruggeven in indien `Killcode` nog op -1 staat. Indien de killcode een andere waarde heeft dan zal deze methode een nieuw Vaccin teruggeven waarbij de killcode al juist werd gezet.

#### Centra verspreiden (*)

We gaan nu VaccinatieCentra over de hele wereld verspreiden. Stel eerst via `BewaarVaccin` eenmalig in welk vaccin alle centra moeten gebruiken (i.e. het vaccin dat gevonden werd in fase 1)

Plaats nu 5 nieuwe centra aan in je lijst en roep op ieder centra 7x `GeefVaccin` aan die een vaccin teruggeeft. Plaats ieder vaccin in een grote lijst.

Overloop finaal de hele lijst (die normaal 35 vaccins moet bevatten) en roep van ieder vaccin de tooninfo op.Je zou nu 35x dezelfde oplossing op het scherm moeten zien. Controleer via een breakpoint of deze oplossing/killcode overeen komt de killcode in je virus dat aan de start van fase 1 werd gemaakt.

### Nieuwe vaccins en virussen

1. Zorg ervoor dat de methode `TryKillCode` virtual wordt gemaakt in de Vaccin klasse.

2. Maak een klasse SlimVaccin dat overerft van Vaccin. Deze klasse implementeert TryKillCode op een andere manier via

    

   ```
   override
   ```

   :

   1. Het Vaccin zal eerst alle veelvouden van 10 (0,10, 20, etc.) testen. Vervolgens 11,21,31,...en dan 12,22, etc.

### Nieuw virus

1. Zorg ervoor dat de methode `TryVaccin` virtual wordt gemaakt in de Vaccin klasse.
2. Maak een klasse DomVirus dat overerft van Virus. Deze klasse voert nog steeds TryVaccin uit zonder aanpassingen. Echter, 50% van de tijd zal de aanroep van TryVaccin resulteren in het verhogen (ipv verlagen) van de `DoomCountdown` teller.

### Test vaccin en nieuwe virus

Voer terug Fase 1 uit maar deze keer doe je dit op het nieuwe DomVirus en gebruik je SlimVaccins.

Kan je nu sneller het vaccin vinden?

### Vaccinatiecentra verspreiden

#### Dictionary

We gaan de centra over de 7 continenten verspreiden. Maar we gaan `Dictionary` gebruiken, dit is hetzelfde als een `List` maar in plaats van een index heeft ieder element een key van een type dat je zelf bepaalt. 

Maak de Dictionary als volgt:

```csharp
Dictionary<string,VaccinatieCentrum> centraDB = new Dictionary<string,VaccinatieCentrum>
```

`string` geeft hier aan dat we als key een string gebruiken, en dat de elementen in de dictionary allemaal Vaccinatiecentra zijn.

Voeg centra aan de dicht als volgt toe.Dit centrum geven we als key frankrijk:

```csharp
centraDB.Add("frankrijk", new VaccinatieCentrum());
```

Volgende code toont bijvoorbeeld hoe je een vaccin nu aan het centrum met key frankrijk verkrijgt

```csharp
Vaccin vac= centraDB["frankrijk"].GeefVaccin();
```

#### Uitvoeren

Maak een programma dat aan de "operator" vraagt in welke landen een centrum moet geplaatst worden. Zoek op hoe je in een dictionary kan controleren of er reeds een element met die key bestaat (want anders overschrijf je bestaande centrum). Toon aan gebruiker dat bouw van nieuw centrum gelukt is, of waarschuw hem als dit land reeds centrum heeft.

De operator kan uit het menu ook kiezen om een overzicht van alle centra te krijgen. Volgende code toont hoe dit kan:

```csharp
Console.WriteLine("Centra in volgende landen:")
foreach (VaccinatieCentrum item in centraDV)
{
    Console.WriteLine(item.Key);
}
```

Kan je hier een programma rond bouwen waarbij de operator ook kan kiezen welk land/centrum Vaccins moet genereren?
