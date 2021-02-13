# Objecten als argumenten

Klassen zijn "gewoon" nieuwe types. Alle regels die we dus al kenden in verband met het doorgeven van variabelen als parameters in een methoden blijven gelden. Het enige verschil is dat we objecten **by reference** meegeven aan een methode. Aanpassingen aan het object in de methode zal dus betekenen dat je het originele object aanpast dat aan de methode werd meegegeven. Hier moet je dus zeker rekening mee houden.

Een voorbeeld. Stel dat we volgende klasse hebben waarin we metingen willen opslaan, alsook wie de meting heeft gedaan:

```csharp
class Meting
{
    public int Temperatuur { get; set; }
    public string OpgemetenDoor { get; set; }
}
```

In ons hoofdprogramma schrijven we een methode `ToonMetingInKleur` die ons toelaat om deze meting op het scherm te tonen in een bepaalde kleur. Het gebruik en de methode zelf zouden er zo kunnen uitzien:

```csharp
static void Main(string[] args)
{
    Meting m1 = new Meting();
    m1.Temperatuur = 26; 
    m1.OpgemetenDoor = "Elon Musk";
    Meting m2 = new Meting();
    m2.Temperatuur = 34; 
    m2.OpgemetenDoor = "Dennis Rodman";

    ToonMetingInKleur(m1, ConsoleColor.Red);
    ToonMetingInKleur(m2, ConsoleColor.Gray);
}

static void ToonMetingInKleur (Meting inmeting, ConsoleColor kleur)
{
    Console.ForegroundColor = kleur;
    Console.WriteLine($"Temperatuur {inmeting.Temperatuur}°C werd opgemeten door {inmeting.OpgemetenDoor}");
    Console.ResetColor();
}
```

## Objecten in methoden aanpassen

Je kan dus ook methoden schrijven die meegegeven objecten aanpassen daar we deze **by reference** doorsturen. Een voorbeeld:

```csharp
static void ToonMetingEnVerhoog(Meting inmeting)
{
    ToonMetingInKleur(inmeting, ConsoleColor.Green);

    inmeting.Temperatuur++;
}
```

Als we deze methode als volgt aanroepen:

```csharp
Meting m1 = new Meting();
m1.Temperatuur = 26; m1.OpgemetenDoor = "Elon Musk";

ToonMetingEnVerhoog(m1);

Console.WriteLine(m1.Temperatuur);
```

Dan zullen we zien dat de temperatuur in `m1` effectief met 1 werd verhoogd.

Dit gedrag zouden we NIET zien bij volgende methode daar `int` **by value** wordt doorgegeven:

```csharp
static void VerhoogGetal(int inmeting)
{
    inmeting++;
}
```

## Delen van objecten als parameter

Stel dat we volgende methode hebben

```csharp
static double Gemiddelde(double getal1, double getal2)
{
    return (getal1 + getal2) / 2;
}
```

Je mag deze methode dus ook oproepen als volgt (we gebruiken de `Meting` objecten `m1` en `m2` uit vorige paragraaf):

```csharp
double result= Gemiddelde(m1.Temperatuur, m2.Temperatuur);
```

Het type van de property `Temperatuur` is `int` en mag je dus als parameter aan deze methoden meegeven.

# Objecten als resultaat

Weer hetzelfde verhaal: ook klassen mogen het resultaat van een methoden zijn.

```csharp
static Meting GenereerRandomMeting()
{
    Meting result = new Meting();
    Random r = new Random();
    result.Temperatuur = r.Next(-100, 200);
    result.OpgemetenDoor = "Onbekend";

    return result;
}
```

Deze methode kan je dan als volgt gebruiken:

```csharp
Meting m3 = GenereerRandomMeting();
```

Merk op dat het dus kan zijn dat een methode `null` teruggeeft. Het kan dus zeker geen kwaad om steeds in je code te controleren of je effectief iets hebt terug gekregen:

```csharp
Meting m3 = GenereerRandomMeting();
if(m3 != null)
{
    ToonMetingInKleur(m3, ConsoleColor.Red);
}
```



# Geheugenmanagement in C-Sharp

Tot nog toe lagen we er niet van wakker wat er achter de schermen van een C# programma gebeurde. We duiken nu dieper in wat er juist gebeurt wanneer we variabelen aanmaken.

## Twee soorten geheugen

Wanneer een C# applicatie wordt uitgevoerd krijgt het twee soorten geheugen toegewezen dat het 'naar hartelust' kan gebruiken:

1. Het kleine, maar snelle **stack** geheugen
2. Het grote, maar tragere **heap** geheugen

Afhankelijk van het soort variabele wordt ofwel de stack, ofwel de heap gebruikt. **Het is uitermate belangrijk dat je weet in welk geheugen de variabele zal bewaard worden!**

Er zijn namelijk twee soorten variabelen:

1. Value types
2. Reference types

Als je volgende tabel begrijpt dan beheers je geheugenmanagement in C#:

|                         | Value types                   | Reference types                           |
| ----------------------- | ----------------------------- | ----------------------------------------- |
| Inhoud van de variabele | De eigenlijke data            | Een referentie naar de eigenlijke data    |
| Locatie                 | (Data) **Stack**              | **Heap** (globaal)geheugen                |
| Beginwaarde             | `0`,`0.0`, `""`,`false`, etc. | `null`                                    |
| Effect van = operator   | Kopieert de actuele waarde    | Kopieert het adres naar de actuele waarde |

![img](./pg003.png)

## Waarom twee geheugens?

Waarom plaatsen we niet alles in de stack? De reden hiervoor is dat bij het compileren van je applicatie er reeds zal berekend worden hoeveel geheugen de stack zal nodig hebben. Wanneer je programma dus later wordt uitgevoerd weet het OS perfect hoeveel geheugen het minstens moet reserveren. Er is echter een probleem: we kunnen niet alles perfect berekenen/voorspellen. Een variabele van het type `int` is perfect geweten hoe groot die zal zijn (32 bit). Maar wat met een string? Of met een array waarvan we pas tijdens de uitvoer de lengte aan de gebruiker misschien vragen? Het zou nutteloos (en zonde) zijn om reeds bij aanvang een bepaalde hoeveelheid voor een array te reserveren als we niet weten hoe groot die zal worden. Beeld je maar eens in dat we 2k byte reserveren om dan te ontdekken dat we maar 5byte ervan nodig hebben. RAM is goedkoop, maar toch... De heap laat ons dus toe om geheugen op een wat minder gestructureerde manier in te palmen. Tijdens de uitvoer van het programma zal de heap als het ware dienst doen als een grote zandbak waar eender welke plek kan ingepalmd worden om zaken te bewaren. De stack daarentegen is het kleine bankje naast de zandbak: handig, snel, en perfect geweten hoe groot.

### Value types

**Value** types worden in de stack bewaard. De effectieve waarde van de variabele wordt in de stack bewaard. Dit zijn alle gekende, 'eenvoudige' datatypes die we tot nu toe gezien hebben, inclusief enums en structs (zie later):

- `sbyte`, `byte`
- `short`, `ushort`
- `int`, `uint`
- `long`, `ulong`
- `char`
- `float`, `double`, `decimal`
- `bool`
- structs (zien we niet in deze cursus)
- enums

#### = operator bij value types

Wanneer we een value-type willen kopieren dan kopieren de echte waarde:

```csharp
int getal=3;
int anderGetal= getal;
```

Vanaf nu zal `anderGetal` de waarde `3` hebben. Als we nu een van beide variabelen aanpassen dan zal dit **geen** effect hebben op de andere variabelen.

We zien hetzelfde effect wanneer we een methode maken die een parameter van het value type aanvaardt - we geven een kopie van de variabele mee:

```csharp
void DoeIets(int a)
{
    a++;
    Console.WriteLine($"In methode {a}");
}

//Elders:
int getal= 5;
DoeIets(getal);
Console.WriteLine($"Na methode {getal}");
```

De parameter `a` zal de waarde `5` gekopieerd krijgen. Maar wanneer we nu zaken aanpassen in `a` zal dit geen effect hebben op de waarde van `getal`. De output van bovenstaand programma zal zijn:

```
In methode 6
Na methode 5
```

### Reference types

**Reference** types worden in de heap bewaard. De *effectieve waarde* wordt in de heap bewaard, en in de stack zal enkel een **referentie** of **pointer** naar de data in de heap bewaard worden. Een referentie (of pointer) is niet meer dan het geheugenadres naar waar verwezen wordt (bv. `0xA3B3163`) Concreet zijn dit alle zaken die vaak redelijk groot zullen zijn:

- objecten, interfaces en delegates
- arrays

#### = operator bij reference types

Wanneer we de = operator gebruiken bij een reference type dan kopieren we de referentie naar de waarde, niet de waarde zelf.

**Bij objecten**

We zien dit gedrag bij alle reference types, zoals objecten:

```csharp
Student stud= new Student();
```

Wat gebeurt er hier?

1. `new Student()` : `new` roept de constructor van `Student` aan. Deze zal een constructor in de **heap** aanmaken en vervolgens de geheugenlocatie teruggeven.
2. Een variabele `stud` wordt in de **stack** aangemaakt.
3. De geheugenlocatie uit de eerste stap wordt vervolgens in `stud` opgeslagen in de stack.

**Bij arrays**

Maar ook bij arrays:

```csharp
int[] nummers= {4,5,10};
int[] andereNummers= nummers;
```

In dit voorbeeld zal `andereNummers` nu dus ook verwijzen naar de array in de heap waar de actuele waarden staan.

Als we dus volgende code uitvoeren dan ontdekken we dat beide variabele naar dezelfde array verwijzen:

```csharp
andereNummers[0]=999;
Console.WriteLine(andereNummers[0]);
Console.WriteLine(nummers[0]);
```

We zullen dus als output krijgen:

```
999
999
```

Hetzelfde gedrag zien we bij objecten:

```csharp
Student a= new Student("Abba");
Student b= new Student("Queen");
a=b;
Console.WriteLine(a.Naam);
```

We zullen in dit geval dus `Queen` op het scherm zien omdat zowel `b` als `a` naar het zelfde object in de heap verwijzen. Het originele "abba"-object zijn we kwijt en zal verdwijnen (zie Garbage collector verderop).

#### Methoden en reference parameters

Ook bij methoden geven we de dus de referentie naar de waarde mee. In de methode kunnen we dus zaken aanpassen van de parameter en dan passen we eigenlijk de originele variabele aan:

```csharp
void DoeIets(int[] a)
{
   a[0]++;
   Console.WriteLine($"In methode {a[0]}");
}

//Elders:
int[] getallen= {5,3,2};
DoeIets(getallen);
Console.WriteLine($"Na methode {getallen[0]}");
```

We krijgen als uitvoer:

```
In methode 6
Na methode 6
```

**Opgelet:** Wanneer we een methode hebben die een value type aanvaardt en we geven één element van de array mee dan geven we dus een kopie van de actuele waarde mee!

```csharp
void DoeIets(int a)
{
    a++;
    Console.WriteLine($"In methode {a}");
}

//Elders:
int[] getallen= {5,3,2};
DoeIets(getallen[0]); //<= VALUE TYPE!
Console.WriteLine($"Na methode {getallen[0]}");
```

De output bewijst dit:

```
In methode 6
Na methode 5
```

## De Garbage Collector (GC)

Een essentieel onderdeel van .NET is de zogenaamde GC, de Garbage Collector. Dit is een geautomatiseerd onderdeel van ieder C# programma dat ervoor zorgt dat we geen geheugen nodeloos gereserveerd houden. De GC zal geregeld het geheugen doorlopen en kijken of er in de heap data staat waar geen references naar verwijzen. Indien er geen references naar wijzen zal dit stuk data verwijderd worden.

In dit voorbeeld zien we dit in actie:

```
int[] array1= {1,2,3};
int[] array2= {3,4,5};
array2=array1;
```

Vanaf de laatste lijn zal er geen referentie meer naar `{3,4,5}` zijn in de heap, daar we deze hebben overschreven met een referentie naar `{1,2,3}`. De GC zal dus deze data verwijderen.

Wil je dat niet dan zal je dus minstens 1 variabele moeten hebben die naar de data verwijst. Volgend voorbeeld toont dit:

```
int[] array1= {1,2,3};
int[] array2= {3,4,5};
int[] bewaarArray= array2;
array2=array;
```

De variabele `bewaarArray` houdt dus een referentie naar `{3,4,5}` bij en we kunnen dus later via deze variabele alsnog aan de originele data.

# Meer weten?

Voor meer info, lees zeker volgende artikels:

- [Reference en value types](https://www.c-sharpcorner.com/uploadfile/prvn_131971/types-in-C-Sharp/)
- [Stack vs heap](https://www.c-sharpcorner.com/article/C-Sharp-heaping-vs-stacking-in-net-part-i/)

# Object references en null

Zoals nu duidelijk is bevatten variabelen steeds een referentie naar een object. Maar wat als we dit schrijven:

```csharp
Student stud1;
stud1.Naam= "Test";
```

Dit zal een fout geven. `stud1` bevat namelijk nog geen referentie. Maar wat dan wel?

Deze variabele bevat de waarde **`null`** . Net zoals bij value types die een default waarde hebben (bv. 0 bij een `int` ) als je er geen geeft, zo bevat reference types altijd `null`.

## NullReferenceException

Een veel voorkomende foutboodschap tijdens de uitvoer van je applicatie is de zogenaamde `NullReferenceException` . Deze zal optreden wanneer je code een object probeert te benaderen wiens waarde `null` is.

Laten we dit eens simuleren:

```csharp
Student stud1 = null;

Console.WriteLine(stud1.Name);
```

Dit zal resulteren in volgende foutboodschap:

![NullReferenceException error in VS](./pg004.png)

> We moeten in dit voorbeeld expliciet `=null` plaatsen daar Visual Studio slim genoeg is om je te waarschuwen voor eenvoudige potentiele NullReference fouten en je code anders niet zal compileren.

## NullReferenceException voorkomen

Objecten die niet bestaan zullen altijd `null` weergeven. Uiteraard kan je niet altijd al je code uitvlooien waar je misschien `=new SomeObject();` bent vergeten.

Voorts kan het ook soms by design zijn dat een object voorlopig `null` is.

Gelukkig kan je controleren of een object `null` is als volgt:

```csharp
if(stud1 == null)
    Console.WriteLine("Oei. Object bestaat niet.")
```

### Verkorte null controle notatie

Vaak moet je dit soort code schrijven:

```csharp
if(stud1 != null)
{
    Console.WriteLine(stud1.Name)
}
```

Op die manier voorkom je `NullReferenceException`. Het is uiteraard omslachtig om steeds die check te doen. Je mag daarom ook schrijven:

```csharp
Console.WriteLine(stud1?.Name)
```

Het vraagteken direct na het object geeft aan: *"de code na dit vraagteken enkel uitvoeren indien het object voor het vraagteken niét null is".*

Bovenstaande code zal dus gewoon een lege lijn op scherm plaatsen indien `stud1` effectief `null` is, anders komt de naam op het scherm.

## Return null

Uiteraard mag je dus ook expliciet soms `null` teruggeven als resultaat van een methode. Stel dat je een methode hebt die in een array een bepaald object moet zoeken. Wat moet de methode teruggeven als deze niet gevonden wordt? Inderdaad, we geven dan `null` terug.

Volgende methode zoekt in een array van studenten naar een student met een specifieke naam en geeft deze terug als resultaat. Enkel als de hele array werd doorlopen en er geen match is wordt er `null` teruggegeven (de werking van arrays van objecten worden later besproken):

```csharp
static Student ZoekStudent(Student[] array, string naam)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Name == naam)
            return array[i];
    }

    return null;
}
```

# Oefeningen - Meetlat

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

# Constructors

## Werking new operator

Objecten die je aanmaakt komen niet zomaar tot leven. Nieuwe objecten maken we aan met behulp van de `new` operator zoals we al gezien hebben:

```csharp
Student FrankVermeulen = new Student();

private int leeftijd= 35;
```

De `new` operator doet 2 dingen:

- Het maakt een object aan in het geheugen
- Het roept de **operator** van het object aan voor eventuele extra initialisatie

Via de constructor van een klasse kunnen we extra code meegeven die moet uitgevoerd worden **telkens een nieuw object van dit type wordt aangemaakt**.

De constructor is een unieke methode die wordt aangeroepen bij het aanmaken van een object, daarom dat we ronde haakjes zetten bij `new Student()`.

# Soorten constructors

Als programmeur van eigen klassen zijn er 3 opties voor je:

- Je gebruikt geen constructors: het leven gaat voort zoals het is. Je kunt objecten aanmaken zoals eerder getoond.
- Je hebt enkel een **default** constructor nodig. Je kan nog steeds objecten met `new Student()` aanmaken, maar je gaat zelf beschrijven wat er moet gebeuren bij de default constructor
- Je wenst gebruik te maken van een of meerdere **overloaded** constructoren, hierbij zal je dan extra argumenten kunnen meegeven bij de creatie van een object, bijvoorbeeld: `new Student(24, "Jos")`.

## Constructors zijn soms gratis, soms niet

![Opgelet](./pg005.jfif)

Een lege default constructor voor je klasse krijg je standaard wanneer je een nieuwe klasse aanmaakt. Je ziet deze niet en kan deze niet aanpassen. Je kan echter daarom altijd objecten met `new myClass()` aanmaken.

Van zodra je echter beslist om zelf een of meerdere constructors te schrijven zal C# zeggen "ok, jij je zin, nu doe je alles zelf". De default constructor die je gratis kreeg zal ook niet meer bestaan en heb je die dus nodig dan zal je die dus zelf moeten schrijven!

## Default constructor

De default constructor is een constructor die geen extra parameters aanvaardt. Een constructor bestaat ALTIJD uit volgende vorm:

- Dit semester is iedere constructor altijd `public` ([meer info](https://stackoverflow.com/questions/30995942/do-constructors-always-have-to-be-public))
- Heeft geen returntype, ook niet `void`.
- Heeft als naam de naam van de klasse zelf.

Stel dat we een klasse `Student` hebben:

```csharp
class Student
{
    private int age;
}
```

We willen telkens een Student-object wordt aangemaakt dat deze een random leeftijd heeft. Via de default constructor kunnen we dat oplossen (je kan namelijk niet schrijven `private int age = random.Next(10,20)` )

Eerst schrijven de default constructor, deze ziet er als volgt uit:

```csharp
class Student
{
    public Student()
    {
        // zet hier de code die bij initialisatie moet gebeuren
    }

    private int age;
}
```

Zoals verteld moet de constructor de naam van de klasse hebben, public zijn en geen returntype definiëren.

Vervolgens voegen we de code toe die we nodig hebben:

```csharp
class Student
{
    public Student()
    {
        Random r= new Random();
        age= r.Next(10,20);
    }

    private int age;
}
```

Telkens we nu een object zouden aanmaken met `new Student()` zal deze een willekeurige leeftijd hebben.

### Opmerking bij voorgaande code

- Als je twee of meerdere Studenten snel in je code na mekaar aanmaakt zullen deze dezelfde leeftijd hebben. Dit is omdat ieder object z'n eigen `Random` aanmaakt en zoals we weten zal een random generator dezelfde getallen genereren als deze vlak na mekaar (in tijd) zijn aangemaakt. Een oplossing zullen we hier later voor zien. Spoiler, `static` is de oplossing hiervoor:

```csharp
class Student
{
    static Random r= new Random();
    public Student()
    {
        age= r.Next(10,20);
    }

    private int age;
}
```

## Overloaded constructor

Soms wil je argumenten aan een object meegeven bij creatie. We willen bijvoorbeeld de leeftijd meegeven die het object moet hebben bij het aanmaken. Met andere woorden, stel dat we dit willen schrijven:

```csharp
Student jos= new Student(19);
```

Als we dit met voorgaande klasse , die enkel een default constructor heeft, uitvoeren zal de code een fout geven. C# vindt geen constructor die een int als parameter aanvaardt.

[Net zoals bij overloading van methoden](https://timdams.gitbooks.io/csharpfromantwerp/content/6_methoden/3_advancedmethod.html) kunnen we ook constructors overloaden. De code is verrassen gelijkaardig als bij method overloading:

```csharp
class Student
{
    public Student(int startage)
    {
        age= startage
    }

    private int age;
}
```

Dat was eenvoudig he. **Maar** denk eraan: je hebt een overloaded constructor geschreven en dus heeft C# gezet "ok, je schrijft zelf constructor, trek je plan. Maar de default zal je ook zal moeten schrijven!" Je kan nu enkel je objecten met `new Student(25)` aanmaken. Schrijf je `new Student()` dan zal je een error krijgen. Wil je die constructor, de default constructor, nog hebben dan zal je die dus ook moeten schrijven, bijvoorbeeld:

```csharp
class Student
{
    public Student(int startage) //overloaded
    {
        age= startage;
    }

    public Student() //default
    {
        Random r= new Random();
        age= r.Next(10,20);
    }

    private int age;
}
```

### Meerdere overloaded constructor

Wil je meerdere overloaded constructors dan mag dat ook. Je wilt misschien een constructor die de leeftijd vraag alsook een bool om mee te geven of het om een werkstudent gaat:

```csharp
class Student
{
    public Student(int startage) //overloaded
    {
        age= startage;
    }

    public Student(int startage, bool werkstart) //overloaded
    {
        age= startage;
        isWerkStudent= werkstart;
    }

    public Student() //default
    {
        Random r= new Random();
        age= r.Next(10,20);
    }

    private int age;
    private bool isWerkStudent
}
```

# Overloaded constructor

Soms wil je argumenten aan een object meegeven bij creatie. We willen bijvoorbeeld de leeftijd meegeven die het object moet hebben bij het aanmaken. Met andere woorden, stel dat we dit willen schrijven:

```csharp
Student jos= new Student(19);
```

Als we dit met voorgaande klasse , die enkel een default constructor heeft, uitvoeren zal de code een fout geven. C# vindt geen constructor die een int als parameter aanvaardt.

[Net zoals bij overloading van methoden](https://timdams.gitbooks.io/csharpfromantwerp/content/6_methoden/3_advancedmethod.html) kunnen we ook constructors overloaden. De code is verrassen gelijkaardig als bij method overloading:

```csharp
class Student
{
    public Student(int startage)
    {
        age= startage
    }

    private int age;
}
```

Dat was eenvoudig he.

**Maar** denk eraan: je hebt een overloaded constructor geschreven en dus heeft C# gezet "ok, je schrijft zelf constructor, trek je plan. Maar de default zal je ook zal moeten schrijven!" Je kan nu enkel je objecten met `new Student(25)` aanmaken. Schrijf je `new Student()` dan zal je een error krijgen. Wil je die constructor, de default constructor, nog hebben dan zal je die dus ook moeten schrijven, bijvoorbeeld:

```csharp
class Student
{
    public Student(int startage) //overloaded
    {
        age= startage;
    }

    public Student() //default
    {
        Random r= new Random();
        age= r.Next(10,20);
    }

    private int age;
}
```

### Meerdere overloaded constructor

Wil je meerdere overloaded constructors dan mag dat ook. Je wilt misschien een constructor die de leeftijd vraag alsook een bool om mee te geven of het om een werkstudent gaat:

```csharp
class Student
{
    public Student(int startage) //overloaded
    {
        age= startage;
    }

    public Student(int startage, bool werkstart) //overloaded
    {
        age= startage;
        isWerkStudent= werkstart;
    }

    public Student() //default
    {
        Random r= new Random();
        age= r.Next(10,20);
    }

    private int age;
    private bool isWerkStudent
}
```

# Object initializer syntax

Uit het vorige hoofdstuk over constructor leren we dat je moet opletten dat je niet tientallen overloaded constructor schrijft voor iedere combinatie van parameters die je mogelijk nodig hebt. Meestal beperken we het tot de default constructor en 1 of 2 heel veel gebruikte overloaded constructor.

Dankzij object initializer syntax kan je namelijk ook parameters aan variabelen meegeven zonder dat je hiervoor een specifieke constructor voor moet schrijven.

Object initializer syntax laat je toe om tijdens (eigenlijk direct er na) creatie van een object Propertier beginwaarden te geven.

Stel dat we volgende klasse hebben:

```csharp
class TemperatuurMeting
{
    public double Temperatuur {get;set;}
    public string GemetenDoor {get;set;}
    public bool IsGeconfirmeerd {get;set;}
}
```

We kunnen deze properties beginwaarden geven via volgende initializer syntax:

```csharp
TemperatuurMeting eenMeting = new TemperatuurMeting { Temperatuur= 3.4, IsGeconfirmeerd=true};
```

Enkele opmerkingen hierbij:

- Je ziet het niet, maar sowieso wordt eerst nu de (onzichtbare) default constructor aangeroepen. Pas wanneer die klaar is zullen de properties de waarden krijgen die je meegeeft. Als je dus zelf een default constructor in `TemperatuurMeting` had geschreven dan had eerst die code uitgevoerd zijn geweest. Voorgaande voorbeeld zal intern eigenlijk als volgt plaatsvinden:

```csharp
TemperatuurMeting eenMeting = new TemperatuurMeting();
eenMeting.Temperatuur = 3.4;
eenMeting.IsGeconfirmeerd = true;
```

- Je hoeft niet alle (publieke) properties via deze syntax in te stellen, enkel de zaken die je wilt meegeven.

# Destructor

https://www.geeksforgeeks.org/destructors-in-c-sharp/

# Static

Je hebt het keyword `static` al een paar keer zien staan voor methoden het vorige semester. En dit semester werd er dan weer nadrukkelijk verteld géén `static` voor methoden te plaatsen. Wat is het nu?

Bij klassen en objecten duidt `static` aan dat een methode of variabele "gedeeld" wordt over alle objecten van die klasse.

`static` kan op 2 manieren gebruikt worden:

1. Bij *variabelen* om een gedeelde variabele aan te maken, over de objecten heen.
2. Bij *methoden* om zogenaamde methoden-bibliotheken of hulpmethoden aan te maken.

## Variabelen en het static keyword

Zonder het keyword heeft ieder object z'n eigen variabelen en aanpassingen binnen het object aan die variabelen heeft geen invloed op andere objecten. We tonen eerst de werking zoals we gewend zijn en vervolgens hoe `static` werkt.

### Variabelen ZONDER static

Gegeven volgende klasse:

```csharp
class Mens
{
    private int leeftijd=1;
    public void Jarig()
    {
        leeftijd++;
    }

    public void ToonLeeftijd()
    {
        Console.WriteLine(leeftijd);
    }
}
```

Als we dit doen:

```csharp
Mens m1= new Mens();
Mens m2= new Mens();

m1.Jarig();
m1.Jarig();

m2.Jarig();

m1.ToonLeeftijd();
m2.ToonLeeftijd();
```

Dan zien we volgende uitvoer:

```text
3
2
```

Ieder object houdt de stand van z'n eigen variabelen bij. Ze kunne mekaars interne (zowel publieke als private) staat niet veranderen.

### Variabelen MET static

We maken de variabele `private int leeftijd` static als volgt: `private static int leeftijd=1;`.

We krijgen dan:

```csharp
class Mens
{
    private static int leeftijd=1;
    public void Jarig()
    {
        leeftijd++;
    }

    public void ToonLeeftijd()
    {
        Console.WriteLine(leeftijd);
    }
}
```

**We hebben nu gezegd dat ALLE objecten de variabele leeftijd delen. Er wordt van deze variabele dus maar een "instantie" in het geheugen gemaakt.**

Voeren we nu terug volgende code uit:

```csharp
Mens m1= new Mens();
Mens m2= new Mens();

m1.Jarig();
m1.Jarig();

m2.Jarig();

m1.ToonLeeftijd();
m2.ToonLeeftijd();
```

Dan wordt de uitvoer:

```
4
4
```

Static laat je dus toe om informatie over de objecten heen te delen. **Gebruik static niet te pas en te onpas: vaak druist het in tegen de concepten van OO en wordt het vooral misbruikt** Ga je dit vaak nodig hebben? Niet zo vaak. Het volgende concept wel.

## Methoden met static

Heb je er al bij stil gestaan waarom je dit kan doen:

```
Math.Pow(3,2);
```

Zonder dat we objecten moeten aanmaken in de trend van:

```csharp
Math myMath= new Math(); //dit mag niet!
myMath.Pow(3,2)
```

De reden dat je de math-bibliotheken kan aanroepen rechtsreeks **op de klasse** en niet op objecten van die klasse is omdat de methoden in die klasse als `static` gedefineerd staan.

## Voorbeeld van static methoden

Stel dat we enkele veelgebruikte methoden willen groeperen en deze gebruiken zonder telkens een object te moeten aanmaken dan doen we dit als volgt:

```csharp
class EpicLibray
{
    static public void ToonInfo()
    {
        Console.WriteLine("Ik ben ik");
    }

    static public int TelOp(int a, int b)
    {
        return a+b;
    }
}
```

We kunnen deze methoden nu als volgt aanroepen:

```csharp
EpicLibrary.ToonInfo();

int opgeteld= EpicLibrary.TelOp(3,5);
```

Mooi toch.

## Nog een voorbeeld

In het volgende voorbeeld gebruiken we een `static` variabele om bij te houden hoeveel objecten (via de constructor) er van de klasse reeds zijn aangemaakt:

```csharp
class Fiets
{
    private static int aantalFietsen = 0;
    public Fiets()
    {
        aantalFietsen++;
        Console.WriteLine($"Er zijn nu {aantalFietsen} gemaakt");
    }

    public static void VerminderFiets()
    {
        aantalFietsen--;
    }
}
```

Merk op dat we de methoden `VerminderFiets` enkel via de klasse kunnen aanroepen:

```csharp
Fiets.VerminderFiets();
```

# Static vs non-static

Van zodra je een methode hebt die `static` is dan zal deze methode enkel andere ``static` methoden en variabelen kunnen aanspreken. Dat is logisch: een static methode heeft geen toegang tot de gewone niet-statische variabelen van een individueel object, want welk object zou hij dan moeten aanpassen?

Volgende code zal dus een error geven:

```csharp
class Mens
{
    private int gewicht=50;

    private static void VerminderGewicht()
    {
        gewicht--;
    }
```

De error die verschijnt **An object reference is required for the non-static field, method, or property 'Program.Fiets.gewicht'** zal bij de lijn `gewicht--` staan.

Een eenvoudige regel is te onthouden dat van zodra je in een static omgeving (meestal een methode) bent je niet meer naar de niet-static delen van je code zal geraken.

# Static en main

Dit verklaart ook waarom je bij console applicaties in Program.cs steeds alle methoden `static` moet maken. Een console-applicatie is als volgt beschreven wanneer je het aanmaakt:

```csharp
public class Program
{
        public static void Main()
        {

        }
}
```

Zoals je ziet is de `Main` methode als `static` gedefinieerd. Willen we dus vanuit deze methode andere methoden aanroepen dan moeten deze als `static` aangeduid zijn.

Uiteraard kan je wel niet-static zaken gebruiken en daarom kan je dus gewone objecten etc. in je static methoden aanmaken.

# Een use-case met static

Beeld je in dat je (weer) een pong-variant moet maken waarbij meerdere balletjes over het scherm moeten botsen. Je wilt echter niet dat de balletjes zelf allemaal apart moeten weten wat de grenzen van het scherm zijn. Mogelijk wil bijvoorbeeld dat je code ook werkt als het speelveld kleiner is dan het eigenlijke Console-scherm.

We gaan dit oplossen met een static property waarin we de grenzen voor alle balletjes bijhouden. Onze basis-klasse wordt dan al vast:

```csharp
class Mover
{
    static public int Width { get; set; }
    static public int Height { get; set; }

    public void Update()
    {
        //Soon
    }

    public void Draw()
    {
        //Soon
    }
}
```

Elders kunnen we nu dit doen:

```csharp
Mover.Height = Console.WindowHeight;
Mover.Width = Console.WindowWidth;

Mover m1 = new Mover();
Mover m2= new Mover();
```

Maar dat hoeft dus niet, even goed maken we de grenzen voor alle balletjes kleiner:

```csharp
Mover.Height = 20;
Mover.Width = 10;

Mover m1 = new Mover();
Mover m2= new Mover();
```

De interne werking van de balletjes hoeft dus geen rekening meer te houden met de grenzen van het scherm. De klasse `Mover` bereiden we nu uit naar de standaard "beweeg" en "teken jezelf" code:

```csharp
class Mover
{
    public Mover(int xi, int yi, int dxi, int dyi)
    {
        x = xi;
        y = yi;
        dx = dxi;
        dy = dyi;
    }

    static public int Width { get; set; }
    static public int Height { get; set; }

    private int dx=1;
    private int dy=0;
    private int x=0;
    private int y=0;

    public void Update()
    {
        x += dx;
        if(x>=Mover.Width|| x<0)  //hier gebruiken we de static Width
        {
            dx *= -1;
            x += dx;
        }

        y += dy;
        if (y >= Mover.Height || y<0)
        {
            dy *= -1;
            y += dy;
        }
    }

    public void Draw()
    {
        Console.SetCursorPosition(x, y);
        Console.Write("O");
    }
}
```

En nu kunnen we vlot balletjes laten rondbewegen op het scherm:

```csharp
static void Main(string[] args)
{
    Console.CursorVisible = false; //handig dit hoor
    Mover.Height = Console.WindowHeight;
    Mover.Width = Console.WindowWidth;

    Mover m1 = new Mover(1,1,1,1);
    Mover m2 = new Mover(6,7,-2,1);

    while (true)
    {
        m1.Update();
        m1.Draw();

        m2.Update();
        m2.Draw();


        System.Threading.Thread.Sleep(50);
        Console.Clear();
    }
}
```

Stel dat we nu elke seconden het speelveld met 1 willen vergroten, dan hoeven we hiervoor enkel een extra variabele `int count=0` voor de loop te zetten en dan in de loop het volgende te doen:

```csharp
 if(count%20==0) //iedere seconde (daar we telkens 50ms slapen (1seconde =1000 ms => 1000ms/50ms == 20))
{
    Mover.Width++;
    Mover.Height++;
}
```

## Maximum grootte

Als je voorgaande code zou runnen zal je zien dat je redelijk snel een error krijgt. Dit komt omdat de hoogte en breedte van een Console maar tot bepaalde waardes kunnen verhogen.

We kunnen dit opvangen door in de klasse `Mover` volgende twee autoproperties:

```csharp
    static public int Width { get; set; }
    static public int Height { get; set; }
```

Te vervangen door fullproperties die controleren of er niet over de grenzen wordt gegaan mbv `Console.LargestWindowWidth` en `Console.LargestWindowHeight`. Voor ``Width`krijgen we dan:

```csharp
private static int width;

public static int Width
{
    get { return width; }
    set
    {
        if (value > 0 && value <  Console.LargestWindowWidth)
            width = value;
    }
}
```

# Oefeningen

## Meetlat constructor

Vul de `Meetlat` klasse aan met een constructor. De constructor laat toe om de lengte in meter als parameter mee te geven. De `LengteInMeter` write-only property vervang je door een private datafield `double lengteInMeter`.

## Sport simulator

Haal je Sport klasse boven en voeg volgende statische methode er aan toe (vervang het soort speler door de naam van jouw klasse. Mijn klasse noemde `Waterpolospeler`)

Schrijf een methode genaamd: `static void SimuleerSpeler(Waterpolospeler testspeler)`

(vervang dus Waterpolospeler door de klasse die je zelf hebt gemaakt)

De SimuleerSpeler-methode zal beide methoden van je klasse telkens 3x aanroepen m.b.v. een for-loop in de methode (dus in mijn geval 3x GooiBal en 3xWatertrappen)

Test je methode door 2 objecten aan te maken en telkens mee te geven als parameter.

Maak een tweede methode `static void SimuleerWedstrijd(Waterpolospeler speler1, Waterpolospeler speler2)`

Bij aanroep van de methode verschijnt er op het scherm wie van beide speler zou winnen als ze zouden spelen. Gebruik een random uitkomst om te bepalen over speler 1 of 2 wint. Toon op het scherm "Speler 1 wint." Gevolg door de aanroep van iedere methode van die speler.

Maak een derde methode `static Waterpolospeler BesteSpeler(Waterpolospeler speler1, Waterpolospeler speler2)`

Deze methode gaat ook random bepalen welke speler de beste is. Vervolgens geef je deze speler terug als resultaat. In de main roep je vervolgens iedere methode van dit object aan.

