# System.Object

**Alle** klassen C# zijn afstammelingen van de `System.Object` klasse. Indien je een klasse schrijft zonder een expliciete parent dan zal deze steeds System.Object als rechtstreekse parent hebben. Ook afgeleide klassen stammen dus af van System.Object. Concreet wil dit zeggen dat alle klassen System.Object-klassen zijn en dus ook de bijhorende functionaliteit ervan hebben.

> Because every class descends from `Object`, every object "is an" `Object`.

Indien je de System namespace in je project gebruikt door bovenaan `using System;` te schrijven dan moet je dus niet altijd `System.Object` schrijven maar mag je ook **`Object`** schrijven.

# Hoe ziet System.Object er uit?

Wanneer je een lege klasse maakt dan zal je zien dat instanties van deze klasse reeds 4 methoden ingebouwd hebben, dit zijn uiteraard de methoden die in de `System.Object` klasse staan gedefinieerd:

| Methode         | Beschrijving                                                 |
| --------------- | ------------------------------------------------------------ |
| `Equals()`      | Gebruikt om te ontdekken of twee instanties gelijk zijn.     |
| `GetHashCode()` | Geeft een unieke code (hash) terug van het object; nuttig om o.a. te sorteren. |
| `GetType()`     | Geeft het type (of klasse) van het object terug.             |
| `ToString()`    | Geeft een string terug die het object voorstel.              |

## GetType()

Stel dat je een klasse Student hebt gemaakt in je project. Je kan dan op een object van deze klasse de GetType() -methode aanroepen om te weten wat het type van dit object is:

```csharp
Student stud1= new Student();
Console.WriteLine(stud1.GetType());
```

Dit zal als uitvoer de namespace gevolgd door het type op het scherm geven. Als je project bijvoorbeeld "StudentManager" heet (en je namespace dus ook) dan zal er op het scherm verschijnen: `StudentManager.Student`.

Wil je enkel het type zonder namespace dan is het nuttig te beseffen dat GetType() een object teruggeeft van het type `Type` met meerdere eigenschappen, waaronder `Name`. Volgende code zal dus enkel `Student` op het scherm tonen:

```csharp
Student stud1= new Student();
Console.WriteLine(stud1.GetType().Name);
```

## ToString()

Deze is de nuttigste waar je al direct leuke dingen mee kan doen. Wanneer je schrijft:

```csharp
Console.WriteLine(stud1);
```

Wordt je code eigenlijk herschreven naar:

```csharp
Console.WriteLine(stud1.ToString());
```

Op het scherm verschijnt dan `StudentManager.Student`. Waarom? Wel, de methode ToString() wordt in System.Object() ongeveer als volgt beschreven:

```csharp
public virtual string ToString()
 { return GetType(); }
```

Merk twee zaken op:

1. GetType wordt aangeroepen en die output krijg je terug.

2. De methode is **virtual** gedefinieerd. **Alle 4 methoden in System.Object zijn `virtual` , en je kan deze dus `override`'n!**

   ### ToString() overriden

   Het zou natuurlijk fijner zijn dat de ToString() van onze student nuttigere info teruggeeft, zoals bv de interne Naam (string autoprop) en Leeftijd (int autoprop). We kunnen dat eenvoudig krijgen door gewoon ToString to overriden:

   ```csharp
   class Student
   {
   public int Leeftijd {get;set;}
   public string Naam {get;set;}
   
   public override string ToString()
   {
      return $"Student genaamd {Naam} (Leeftijd:{Leeftijd})";
   }
   }
   ```

   Wanneer je nu `Console.WriteLine(stud1);` (gelet dat hij een Naam en Leeftijd heeft) zou schrijven dan wordt je output: `Student Tim Dams (Leeftijd:35)`.

## Equals()

Ook deze methode kan je dus overriden om twee objecten met elkaar te testen. Op het [einde van deze cursus](https://timdams.gitbooks.io/csharpfromantwerp/content/18_IsAs/6_equals.html) zal dieper in `Equals` ingaan worden om objecten te vergelijken, maar we tonen hier reeds een voorbeeld:

```csharp
if(stud1.Equals(stud2))
   //...
```

De `Equals` methode heeft dus als signatuur: `public virtual bool Equals(Object o)` Twee objecten zijn gelijk voor .NET als aan volgende afspraken wordt voldaan:

- Het moet `false` teruggeven indien het argument o `null` is

- Het moet `true` teruggeven indien je het object met zichzelf vergelijkt (bv `stud1.Equals(stud1)`)

- Het mag enkel

   

  ```
  true
  ```

   

  teruggeven als volgende statements beide waar zijn:

  ```csharp
  stud1.Equals(stud2);
  stud2.Equals(stud1);
  ```

- Indien `stud1.Equals(stud2)` true teruggeeft en `stud1.Equals(stud3)` ook true is, dan moet `stud2.Equals(stud3)` ook true zijn.

### Equals overriden

Stel dat we vinden dat een student gelijk is aan een andere student indien z'n Naam en Leeftijd dezelfde is, we kunnen dan de Equals-methode overriden als volgt:

```csharp
//In de Student class
public override bool Equals(Object o)
{
     bool gelijk;
     if(GetType() != o.GetType()) 
         gelijk=false;
     else
     {
         Student temp= (Student)o; //Zie opmerking na code!
         if(Leeftijd== temp.Leeftijd && Naam== temp.Naam)
            gelijk=true;
         else gelijk=false;
      }
       return gelijk;
}
```

De lijn `Student temp = (Student)o;` zal het `object o` casten naar een `Student`. Doe je dit niet dan kan je niet aan de interne Student-variabelen van het `object o`.

Dit concept heet polymorfisme en wordt later uitgelegd.

## GetHashcode

Indien je Equals override dan moet je eigenlijk ook GetHashCode overriden, daar er wordt verondersteld dat twee gelijke objecten ook dezelfde unieke hashcode teruggeven. Wil je dit dus implementeren dan zal je dus een (bestaand) algoritme moeten schrijven dat een uniek nummer genereert voor ieder niet-gelijke object.

Bekijk volgende [StackOverflow post](https://stackoverflow.com/questions/9827911/how-to-implement-override-of-gethashcode-with-logic-of-overriden-equals) indien je dit wenst toe te passen.

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

Maak een applicatie waarin je de werking van deze klassen aantoont

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

Maak de klassen van het volgende schema: ![Klassenschema enclave](./pg006.png)

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
