# OOP

<!--

## RapportModule (*)

Ontwerp een klasse Resultaat die je zal tonen wat je graad is gegeven een bepaald behaald percentage. Het enige dat je aan een Resultaat-object moet kunnen geven is het behaalde percentage. Enkel het totaal behaalde % wordt bijgehouden via een auto-property. Via een methode PrintGraad kan de behaalde graad weergegeven worden. Dit zijn de mogelijkheden:

- < 50: niet geslaagd;
- tussen 50 en 68: voldoende;
- tussen 68 en 75: onderscheiding;
- tussen 75 en 85: grote onderscheiding;
- \> 85: grootste onderscheiding.

Test je klasse door enkele objecten in je main aan te maken en de verschillende properties waarden te geven en methoden aan te roepen. Deze code zou moeten werken:

```csharp
Resultaat mijnpunten= new Resultaat();
mijnpunten.Percentage=65;
mijnpunten.PrintGraad();
```

## Nummers (*)

Maak een klasse Nummers. Deze klasse bevat 2 getallen (type int) die via een autoproperty kunnen aangepast worden. Er zijn 4 methoden:

- `Som`: geeft de som van beide getallen terug
- `Verschil`: geeft het verschil van beide getallen terug
- `Product`: geeft het product van beide getallen terug
- `Quotient`: geeft de deling van beide getallen terug. Toon "Error" indien je zou moeten delen door 0.

Toon in je main aan dat je code werkt.

Volgende code zou bijvoorbeeld onderstaande output moeten geven:

```csharp
    Nummers paar1 = new Nummers();
    paar1.Getal1 = 12;
    paar1.Getal2 = 34;

    Console.WriteLine("Paar:" + paar1.Getal1 + ", " + paar1.Getal2);
    Console.WriteLine("Som = " + paar1.Som());
    Console.WriteLine("Verschil = " + paar1.Verschil());
    Console.WriteLine("Product = " + paar1.Product());
    Console.WriteLine("Quotient = " + paar1.Quotient());
```

Output:

```text
Paar: 12, 34
Som = 46
Verschil = -22
Product = 408
Quotient = 0,352941176470588
```

-->

## Studentklasse (*)

Maak een nieuwe klasse `Student`.

Deze klasse heeft 6 autoproperties:

- Naam (string)
- Leeftijd (int)
- Klas (maak dit van een `enum`)
- PuntenCommunicatie (int)
- PuntenProgrammingPrinciples (int)
- PuntenWebTech (int)

Voeg aan de klasse een methode `BerekenTotaalCijfer` toe. Wanneer deze methode wordt aangeroepen dan wordt het gemiddelde van de 3 punten teruggegeven als double zodat dit op het scherm kan getoond worden.

Voeg aan de klasse ook de methode `GeefOverzicht` toe. Deze methode zal een volledig "Rapport" van de student tonen (inclusief het gemiddelde m.b.v. de BerekenTotaalCijfer-methode).

Test je programma door enkele studenten aan te maken en in te stellen. Volgende main zou dan de bijhorende output moeten krijgen:

```csharp
    Student student1= new Student();
    student1.Klas = Klassen.EA2;
    student1.Leeftijd = 21;
    student1.Naam = "Joske Vermeulen";
    student1.PuntenCommunicatie = 12;
    student1.PuntenProgrammingPrinciples = 15;
    student1.PuntenWebTech = 13;

    student1.GeefOverzicht();
```

Output:

```text
Joske Vermeulen, 21 jaar
Klas: EA2

Cijferrapport:
**********
Communicatie:             12
Programming Principles:   15
Web Technology:           13
Gemiddelde:               13.3
```

<!--

## PizzaTime (*)

Maak een klasse Pizza. Deze klasse heeft een aantal private fields:

- toppings (string): bevat beschrijving van wat er op ligt, bv. ananas, pepperoni, etc.
- diameter (integer): doorsnede van de pizza in cm.
- price (double): prijs van de pizza in euro.

Zorg ervoor dat je met behulp van full properties deze 3 velden kan uitlezen en aanpassen. Bouw controle in zodat de fields geen foute waarden kunnen gegeven worden (denk maar aan negatieve prijs en diameter, pizza zonder topping, etc.). Maak in je main een aantal pizza-instanties aan en toon de werking van de properties aan.

## Figuren

Maak een eenvoudige klasse Rechthoek aan die een lengte en breedte als private datafields heeft. Deze kunnen enkel via full properties ingesteld worden en nooit onder 1 gaan.

Maak ook een klasse Driehoek die een basis en hoogte als fields heeft.

Beide klassen hebben een methode `ToonOppervlakte` die de oppervlakte van de figuur in kwestie op het scherm toont.

Toon de werking van het project aan door een aantal instanties van Driehoek en Rechthoek te maken, met verschillende groottes. Roep van iedere figuur de ToonOppervlakte-methode aan.

## Sports

### Sportspeler

Kies je favoriete sport of game. Maak een klasse aan die een speler uit deze sport kan voorstellen. Verzin een 4-tal private datavelden die deze spelers hebben, alsook 2 methoden die de speler moet kunnen uitvoeren.

Voorzie een methode `StelIn` die je toelaat om de private datafields in te stellen:

Voorzie ook minstens 1 "Naam" (string) dataveld.

Voorzie per data field ook telkens een full property. Waar nodig zorg je er voor dat er geen illegale waarden kunnen ingesteld worden (bv mutsnummer bij waterpolo gaat maar van 1 tot 13).

Bijvoorbeeld:

- klasse Waterpolospeler
- datavelden:
  - spelerNaam(string)
  - mutsnummer (int)
  - isDoelman (bool)
  - isReserve(bool)
  - reeks (string, bv "Cadet")

Methoden: GooiBal, Watertrappen, StelIn

De methode `StelIn` zou dan zou kunnen aangeroepen worden:

```csharp
speler1.StelIn("Tim", 5, false, true, "tweedeklas");
```

Wanneer de methoden worden aangeroepen zal er een tekst (mbv Console.WriteLine in de methode) op het scherm verschijnen die bv zegt `Ik (Jos) gooi de bal`. Waarbij de naam van de speler in kwestie uit het Naam dataveld wordt gebruikt om mee getoond te worden.

Maak vervolgens een console-applicatie aan waarin je de werking van de klasse aantoont. Maar in de applicatie een aantal speler-objecten aan, vervolgens stel je hun properties in. Vervolgens roep je enkele methoden van de spelers aan en toon je via (Console.WriteLine) ook de properties van de individuele spelerobjecten.

Toon maw aan dat je:

- Een klasse kunt maken (in een aparte file!)
- Instanties (objecten) van deze klasse kunt maken
- Kunt werken met deze instanties (properties instellen én uitlezen, aanroepen van methoden)

### enums

Kan je in voorgaand voorbeeld het dataveld `reeks` vervangen door een dataveld reeks dat een enum als datatype heeft?

## BankManager

Ontwerp een klasse Account die minstens een Naamveld, bedrag en rekeningnummer bevat. Voorzie 3 methoden:

1. WithdrawFunds: bepaald bedrag wordt van rekening verwijderd
2. PayInFunds: bepaald bedrag (als parameter) wordt op de rekening gezet
3. GetBalance: het totale bedrag op de rekening wordt teruggegeven

Pas de WithdrawFunds methode aan zodat als returntype het bedrag (int) wordt teruggegeven. Indien het gevraagde bedrag meer dan de balance is dan geef je al het geld terug dat nog op de rekening staat en toon je in de console dat niet al het geld kon worden gegeven.

Maak 2 instanties van het type Account aan en toon aan dat je geld van de ene account aan de andere kunt geven, als volgt:

```csharp
BankAccount rekening1 = new BankAccount();
BankAccount rekening2 = new BankAccount();
```

Voeg aan de Account-klasse een private field toe zijnde van het type accountState dat een enumeratie bevat. De account kan in volgende states zijn "Geldig", "Geblokkeerd"). Maak een bijhorende publieke Methode waarmee je de account van state kunt veranderen. Deze methode (noem ze ChangeState) vereist één parameter van het type accountState natuurlijk.

Indien een persoon geld van of naar een Geblokkeerde rekening wil sturen dan zal er een error op het scherm verschijnen.

Test je klasse.

1. Nieuwe klant aanmaken (max 10)
2. Status van bestaande klant tonen
3. Geld op een bepaald account zetten
4. Geld van een bepaald account afhalen
5. Geld tussen 2 accounts overschrijven

Voorzie extra functionaliteit naar keuze.

-->

# Overerving

## Het dierenrijk

![img](C:/Users/u2389/source/repos/ProgrammerenGevorderd2021/Documents/animals.png)

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

#### Centra verspreiden

We gaan nu VaccinatieCentra over de hele wereld verspreiden. Stel eerst via `BewaarVaccin` eenmalig in welk vaccin alle centra moeten gebruiken (i.e. het vaccin dat gevonden werd in fase 1)

Plaats nu 5 nieuwe centra aan in je lijst en roep op ieder centra 7x `GeefVaccin` aan die een vaccin teruggeeft. Plaats ieder vaccin in een grote lijst.

Overloop finaal de hele lijst (die normaal 35 vaccins moet bevatten) en roep van ieder vaccin de tooninfo op.Je zou nu 35x dezelfde oplossing op het scherm moeten zien. Controleer via een breakpoint of deze oplossing/killcode overeen komt de killcode in je virus dat aan de start van fase 1 werd gemaakt.

<!--

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

-->

# Abstracte klassen

## Book (*)

### Deel 1

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

### Deel 2

- Zorg ervoor dat boeken de ToString overriden zodat je boekobjecten eenvoudig via Console.WriteLine(myBoek) hun info op het scherm tonen. Ze tonen deze info als volgt: "Title - Auteur (ISBN) *Price" (bv The Shining - Stephen King (05848152)* 50)
- (PRO) Zorg ervoor dat de equals methode werkt op alle boeken. Boeken zijn gelijk indien ze hetzelfde ISBN nummer hebben.

**Toon de werking aan van je 3 klassen:** Maak boeken aan van de 3 klassen, toon dat de prijs niet altijd zomaar ingesteld kan worden en (PRO) toon aan dat je Equals –methode werkt (ook wanneer je bijvoorbeeld een Book en TextBook wil vergelijken).

## Money, money, money (*)

Maak enkele klassen die een bank kan gebruiken.

1. Abstracte klasse `Rekening`: deze bevat een methode `VoegGeldToe` en `HaalGeldAf`. Het saldo van de rekening wordt in een private variabele bijgehouden (en via de voorgaande methoden aangepast) die enkel via een read-only property kan uitgelezen worden. Voorts is er een abstracte methode `BerekenRente` de rente als double teruggeeft.
2. Een klasse `BankRekening` die een Rekening is. De rente van een BankRekening is 5% wanneer het saldo hoger is dan 100 euro, zoniet is deze 0%.
3. Een klasse `SpaarRekening` die een Rekening is. De rente van een SpaarRekening bedraagt steeds 2%.
4. Een klasse `ProRekening` die een SpaarRekening is. De ProRekening hanteert de Rente-berekening van een SpaarRekening (`base.BerekenRente`) maar zal per 1000 euro saldo nog eens 10 euro verhogen.

Schrijf deze klassen en toon de werking ervan in je main.

## Geometric figures (*)

Maak een abstracte klasse `GeometricFigure`. Iedere figuur heeft een hoogte, breedte en oppervlakte. Maak autoproperties voor van `Hoogte` en `Breedte`. De oppervlakte is een read-only property want deze wordt berekend gebaseerd op de hoogte en breedte.

Voorzie een abstracte methode `BerekenOppervlakte` die een int teruggeeft.

Maak 3 klassen:

- Rechthoek: erft over van GeometricFigure. Oppervlakte is gedefinieerd als `breedte * hoogte`.
- Vierkant: erft over van Rechthoek. Voorzie een constructor die lengte en breedte als parameter aanvaard: deze moeten gelijk zijn, indien niet zet je deze tijdens de constructie gelijk. Voorzie een 2e constructor die één parameter aanvaardt dat dan geldt als zowel de lengte als breedte. Deze klasse gebruikt de methode BerekenOppervlakte van de Rechthoek-klasse.
- Driehoek: erft over van GeometricFigure. Oppervlakte is gedefinieerd als `breedte*hoogte/2`.

Maak een applicatie waarin je de werking van deze klassen aantoont.

<!--

## Dierentuin

Maak een console-applicatie waarin je een zelfverzonnen abstract klasse Dier in een List kunt plaatsen. Ieder dier heeft een gewicht en een methode `Zegt` (die abstract is) die het geluid van het dier in kwestie op het scherm zal tonen. Maak enkele childklassen die overerven van Dier en uiteraard de `Zegt` methode overriden.

Vervolgens vraag je aan de gebruiker wat voor dieren er in deze lijst moeten toegevoegd worden. Wanneer de gebruiker 'q' kiest stopt het programma met vragen welke dieren moeten toegevoegd worden en komt er een nieuw keuze menu. Het keuze menu heeft volgende opties:

a. Dier verwijderen , gevolgd door de gebruiker die invoert het hoeveelste dier weg moet uit de List.

b. Diergewicht gemiddelde: het gemiddelde van alle dieren hun gewicht wordt getoond

c. Dier praten: alle dieren hun Zegt() methode wordt aangeroepen en via WriteLine getoond

d. Opnieuw beginnen: de List wordt leeggemaakt en het programma zal terug van voor af aan beginnen.

Probeer zo modulair mogelijk te werken.

De enclave die je moet uitbouwen zal bestaan uit enkele essentiële gebouwen. We willen alle gebouwen volgens een zelfde concept uitwerken zodat onze stad zo modulair mogelijk wordt.

## Abstracte klasse Gebouw

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

### Basis gebouwen klaarmaken

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

### Maak een enclave

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

### Extra 1

Voeg kleur toe. Zorg ervoor dat ieder type gebouw in een andere kleur op het scherm komt. Dus de woonst geeft bijvoorbeeld een blauwe w. Een hospitaal een rode H.

### Bonuspoints:

Maak ook een Straat-klasse en voorzie wat straten in je enclave.

Mail je coolste stad naar mij met straten en gebouw. Mail me:

- Een screenshot
- Je code in zip

-->

# Null Reference

## Meetlat (*)

Maak een klasse "Meetlat". Via een write-only property BeginLengte kan de gebruiker de lengte van een voorwerp instellen (in meter). Via een reeks read-only properties (die transformeren) kan de gebruiker deze lengte in verschillende eenheden uitlezen namelijk:

- LengteInM
- LengteInCm
- LengteInKm
- LengteInVoet (1m= 3.2808ft)

**Opgelet het `readonly` keyword heb je niét nodig om readonly properties te maken. Zoek op hoe je dit wel doet.**

Voorbeeld gebruik van klasse:

```csharp
Meetlat mijnLat = new Meetlat();
mijnLat.BeginLengte = 2;
Console.WriteLine($"{mijnLat.LengteInM} meter is {mijnLat.LengteInVoet} voet.");
```

# Exception handling

## Deling

Ontwerp een consoletoepassing waarmee je het quotiënt berekent van een ingegeven deeltal en deler. Bij een deling mag de deler niet gelijk zijn aan nul. Maak eerst een console toepassing zonder hiermee rekening te houden. Welke foutmelding krijg je in C#?

Pas de consoletoepassing aan. Indien de gebruiker als deler 0 ingeeft, verschijnt de tekst: “Wie deelt door nul is een snul!”.