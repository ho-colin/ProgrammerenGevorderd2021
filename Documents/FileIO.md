# Bestanden lezen en schrijven

## Inleiding

In dit hoofdstuk gaan we kijken naar het lezen en schrijven van eenvoudige bestanden met C#. Gelukkig maakt C# dat gemakkelijk voor ons. De File class, van de **System.IO** namespace heeft ongeveer alles wat we nodig hebben van wat we maar zouden willen. Daardoor is het erg gemakkelijk om een bestand te lezen of er naar toe te schrijven.

In ons eerste voorbeeld maken we een extreem minimalistische tekstverwerker. In feite is die zo simpel dat we maar één bestand kunnen lezen en daarna nieuwe content er naartoe schrijven, en dat met maar één enkele regel tekst per keer. Maar het laat wel zien hoe gemakkelijk het is om de File class te gebruiken:

```csharp
using System;
using System.IO;

namespace FileHandlingArticleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if(File.Exists("test.txt"))
            {
                string content = File.ReadAllText("test.txt");
                Console.WriteLine("Current content of file:");
                Console.WriteLine(content);
            }
            Console.WriteLine("Please enter new content for the file:");
            string newContent = Console.ReadLine();
            File.WriteAllText("test.txt", newContent);
        }
    }
}
```

Het zal je opvallen dat we de File class op drie plaatsen gebruiken: 

1. We gebruiken hem om te zien of het bestand bestaat.
2. We gebruiken de ReadAllText() method om de inhoud van het bestand te lezen.
3. (3) we gebruiken de WriteAllText() method om nieuwe content naar het bestand te schrijven. 

Je ziet dat we geen absoluut pad gebruiken, maar alleen een simpele bestandsnaam. Dit plaatst het bestand in dezelfde directory als het uitvoerbare bestand. Afgezien daarvan is het voorbeeld gemakkelijk genoeg te begrijpen: we checken het bestaan van het bestand, we lezen de inhoud en sturen deze naar de console. Daarna vragen we de gebruiker om nieuwe content, en als we dat hebben, schrijven we dat naar het bestand. Het is duidelijk dat dit de reeds aanwezige inhoud zal overschrijven. We zouden echter ook de AppendAllText method kunnen gebruiken. Probeer de WriteAllText regel in dit te veranderen:

```csharp
File.AppendAllText("test.txt", newContent);
```

Als je dit uitvoert, zal je zien dat de nieuwe tekst is toegevoegd aan de bestaande tekst in plaats van deze te overschrijven. Maar we krijgen nog steeds maar een regel tekst bij elke uitvoering van onze applicatie. Laten we wat creatiever zijn en daar verandering in brengen. 

Vervang de laatste regels in ons voorbeeld door:

```csharp
Console.WriteLine("Please enter new content for the file - type exit and press enter to finish editing:");
string newContent = Console.ReadLine();
while(newContent != "exit")
{
    File.AppendAllText("test.txt", newContent + Environment.NewLine);
    newContent = Console.ReadLine();
}
```

Zoals je ziet, vragen we de gebruiker het woord 'exit' in te toetsen wanneer hij wil stoppen met het editen van het bestand. En zolang hij dat niet doet, blijft gebruikersinvoer toegevoegd worden en wordt gevraagd om een nieuwe regel. We voegen ook een teken toe voor een 'nieuwe regel', **System.Environment.NewLine**, om het er als echte tekstregels te laten uitzien.

Echter, in plaats van elke keer naar het bestand te moeten schrijven, is het onderstaande een betere oplossing:

```csharp
Console.WriteLine("Please enter new content for the file - type exit and press enter to finish editing:");
using(StreamWriter sw = new StreamWriter("test.txt"))
{
    string newContent = Console.ReadLine();
    while(newContent != "exit")
    {
        sw.Write(newContent + Environment.NewLine);
        newContent = Console.ReadLine();
    }
}
```

Het gebruik van Streams ligt nog wat buiten ons blikveld en wordt verderop behandeld, maar het mooie van dit voorbeeld is dat we maar één keer het bestand openen en veranderingen aanbrengen. 

In dit geval maken we gebruik van het 'using' statement van C#, waardoor we er zeker van zijn dat de **referentie naar het bestand wordt gesloten** als hij buiten het bereik treedt, dat wil zeggen, als het klaar is met het blok van { } . Als je het 'using' statement niet gebruikt, moet je zelf de Close() method oproepen in StreamWriter.

# Manipuleren van bestanden en directories

## Inleiding

In het vorige hoofdstuk bekeken we het lezen en schrijven van tekst met eenvoudige bestanden. We gebruikten hiervoor de File class, maar deze kan veel meer dan alleen maar lezen en schrijven. Als we hem combineren met de Directory class, kunnen we vrijwel elke bestandssysteem handeling uitvoeren, zoals 'naam wijzigen', 'verplaatsen', 'wissen' enzovoorts.

Dit hoofdstuk geeft talloze voorbeelden om die dingen te doen. De uitleg zal beperkt zijn, want de methods zijn simpel en gemakkelijk te gebruiken. Je moet aan twee dingen denken: vooreerst, gebruik de System.IO namespace. 

Doe dat op deze manier:

```csharp
using System.IO;
```

Weet ook dat we hier niet aan exception handling doen. We checken vooraf of bestanden en directories bestaan, maar omdat er geen exception handling is, zal de zaak crashen als er iets fout gaat. Exception handling is over het algemeen juist een goed idee als je bezig bent met IO operaties. 

## Het wissen van een bestand

```csharp
if(File.Exists("test.txt"))
{
    File.Delete("test.txt");
    if(File.Exists("test.txt") == false)
    Console.WriteLine("File deleted...");
}
else
    Console.WriteLine("File test.txt does not yet exist!");
```

## Het wissen van een directory

```csharp
if(Directory.Exists("testdir"))
{
    Directory.Delete("testdir");
    if(Directory.Exists("testdir") == false)
    Console.WriteLine("Directory deleted...");
}
else
    Console.WriteLine("Directory testdir does not yet exist!");
```

Als testdir niet leeg is, ontvang je een exception. Waarom? Omdat deze versie van Delete() in de Directory class alleen werkt bij lege directories. Dat is echter gemakkelijk te veranderen:

```c#
Directory.Delete("testdir", true);
```

De extra parameter maakt het zeker dat de Delete() method recursief is, wat betekent dat het door subdirectories heenloopt en de bestanden erin wist, alvorens de directories te wissen.

## Bestandsnaam wijzigen

```c#
if(File.Exists("test.txt"))
{
    Console.WriteLine("Please enter a new name for this file:");
    string newFilename = Console.ReadLine();
    if(newFilename != String.Empty)
    {
    File.Move("test.txt", newFilename);
    if(File.Exists(newFilename))
    {
        Console.WriteLine("The file was renamed to " + newFilename);
        Console.ReadKey();
    }
    }
}
```

Je ziet dat we de Move() method gebruiken om de naam van het bestand te wijzigen. Waarom geen Rename() method? Omdat zo'n method niet bestaat en verplaatsen en hernoemen in essentie hetzelfde is.

## Een directorynaam wijzigen

Hetzelfde doen met een directory is net zo gemakkelijk:

```c#
if(Directory.Exists("testdir"))
{
    Console.WriteLine("Please enter a new name for this directory:");
    string newDirName = Console.ReadLine();
    if(newDirName != String.Empty)
    {
    Directory.Move("testdir", newDirName);
    if(Directory.Exists(newDirName))
    {
        Console.WriteLine("The directory was renamed to " + newDirName);
        Console.ReadKey();
    }
    }
}
```

## Een nieuwe directory maken

Een splinternieuwe directory maken is eveneens gemakkelijk. Gebruik gewoon de **CreateDirectory()** method in de Directory klasse, zoals hier:

```c#
Console.WriteLine("Please enter a name for the new directory:");
string newDirName = Console.ReadLine();
if(newDirName != String.Empty)
{
    Directory.CreateDirectory(newDirName);
    if(Directory.Exists(newDirName))
    {
    Console.WriteLine("The directory was created!");
    Console.ReadKey();
    }
}
```

## Lezen en schrijven van bestanden

Als laatste voorbeeld laten we je zien hoe de File class het ons gemakkelijk maakt om te lezen ván en te schrijven náár een bestand. Dit kan met C# op een heleboel manieren gebeuren, maar de Read* en Write* methods van de File class zijn wellicht het gemakkelijkst in het gebruik. Er zijn drie versies: **WriteAllBytes()**, **WriteAllLines()** en **WriteAllText()**, met corresponderende Read methods. De simpelste is de laatste die een simpele string als input neemt. Via een eenvoudig voorbeeld zal ik illustreren hoe het werkt:

```c#
string fileContents = "John Doe & Jane Doe sitting in a tree...";
File.WriteAllText("test.txt", fileContents);

string fileContentsFromFile = File.ReadAllText("test.txt");
Console.WriteLine(fileContentsFromFile);
```

Kijk maar eens hoe weinig code nodig is om iets naar een bestand te schrijven en het daarna terug te lezen! De eerste parameter in beide methods is het pad waar naartoe de tekst moet worden geschreven en waarvan moet worden gelezen. Normaal gesproken zou je hier een volledig pad specificeren, maar om het voorbeeld duidelijker te maken, specificeer ik alleen de bestandsnaam.

## Samenvatting

Zoals je kunt zien, zijn File en Directory classes een geweldige steun als je met bestanden en directories moet werken. Ze helpen je de meeste noodzakelijke handelingen te doen, en als je nog meer gevorderd spul zou moeten doen, dan kunnen deze classes en hun methods prima dienen als geweldige bouwstenen om op voort te bouwen.

# Informatie over een bestand of een directory

De File en de Directory classes die we in de vorige paar hoofdstukken hebben gebruikt zijn uitstekend geschikt voor directe bestands- en directory manipulatie. Maar soms ook willen we informatie hebben óver bestand en directory, en alweer komt de System.IO namespace ont te hulp: de FileInfo en DirectoryInfo klassen. 

## Klasse FileInfo

```c#
static void Main(string[] args)
{
    FileInfo fi = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
    if(fi != null)
    Console.WriteLine(String.Format("Information about file: {0}, {1} bytes, last modified on {2} - Full path: {3}", fi.Name, fi.Length, fi.LastWriteTime, fi.FullName));c#
    Console.ReadKey();
}
```

We maken een nieuw exemplaar van de FileInfo class. Deze krijgt één parameter, dat het pad is naar het bestand waar we iets van willen weten. We hadden natuurlijk ook alleen de naam van het bestand kunnen aangeven, maar we veronderstelden dat het leuker was om info te krijgen over de applicatie waar we aan werken, en dat is het EXE bestand waarin ons bestand is gecompileerd. Omdat we in een Console applicatie geen toegang hebben tot het Applicatie project ( Console is deel van de Winforms assemblage), gebruiken we wat **Reflection** om het pad naar de assembly te krijgen. Dit is buiten de scope van dit speciale hoofdstuk, maar nu weet je er tenminste van.

## Klasse DirectoryInfo

```c#
DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
if(di != null)
{
    FileInfo[] subFiles = di.GetFiles();
    if(subFiles.Length > 0)
    {
    Console.WriteLine("Files:");
    foreach(FileInfo subFile in subFiles)
    {
        Console.WriteLine("   " + subFile.Name + " (" + subFile.Length + " bytes)");
    }
    }
}
```

Misschien willen we ook de directories:

```c#
DirectoryInfo[] subDirs = di.GetDirectories();
if(subDirs.Length > 0)
{
    Console.WriteLine("Directories:");
    foreach(DirectoryInfo subDir in subDirs)
    {
    Console.WriteLine("   " + subDir.Name);
    }
}
```

```c#
FileInfo[] subFiles = di.GetFiles("*.exe");
DirectoryInfo[] subDirs = di.GetDirectories("*test*");
```

```c#
FileInfo[] subFiles = di.GetFiles("*.exe", SearchOption.AllDirectories);
```

```c#
FileInfo[] subFiles = di.GetFiles("*.exe", SearchOption.TopDirectoryOnly);
```

# Streams

## Inleiding

In het .NET framework wordt het concept Streams gebruikt als je gegevens wilt lezen en/of schrijven van en naar een brede reeks bronnen/bestemmingen, bv. het geheugen, een bestand, via een netwerkverbinding of elke andere situatie waar je bytes wil overbrengen van de ene plaats naar de andere.

Bij het werken met vele van de IO-gerelateerde classes in het .NET framework, zal je zien dat ze methods hebben die een parameter accepteren van het type **Stream**. Stream is de basis class voor het omgaan met strings en kan vele vormen aannemen, bv. een MemoryStream of een FileStream. Echter, de Stream class zelf is abstract, wat betekent dat je hem niet kunt aanmaken. Hij dient alleen maar als gemeenschappelijke basisclass voor de diverse typen van streams.

De meeste Stream typen kunnen drie dingen doen: Lezen (Read), Schrijven (Write) en Zoeken (Seek) (overbrengen naar een nieuwe plaats in de stream, om te lezen of schrijven vanaf daar in plaats vanaf de huidige positie). Daarom implementeert de Stream class drie methods om te beslissen of de afgeleide stream class al of niet dit kan doen: **CanRead**, **CanWrite** en **CanSeek**. Je kunt deze properties altijd raadplegen bij de stream waarmee je werkt, om er zeker van te zijn dat de door jou gewenste operatie (bv. schrijven (writing)) beschikbaar is.

Een Stream moet altijd kunnen worden beëindigd als je ermee klaar bent. Anders zou hij een hulpmiddel kunnen blokkeren dat niet meer geblokkeerd moet worden, bv. een bestand als je bezig bent met FileStream. De Stream basis class implementeert het **IDisposable** interface, dus het opstarten daarvan is even gemakkelijk als het aanroepen van de *Dispose()* method, of, misschien zelfs beter, het gebruik van de stream inkapselen met een *using()* block.

## Stream readers en writers

Een algemeen gebruik van streams is om een van de Reader of Writer classes tot steun te zijn, bv. FileReader of BinaryWriter. Je kunt je streams doorgeven aan nieuwe exemplaren van deze classes om bv. een heel bestand te lezen, het in het geheugen te bewerken en dan terug te schrijven; er zijn tal van mogelijkheden. We gaan dit ook zien in de volgende artikelen.

## Samenvatting

Een stream is in feite een mechanisme om bytes van de ene plek naar de ander te verplaatsen, bv. naar een bestand of vanuit een netwerk bron. Het .NET framework gebruikt de abstracte Stream class voor al deze dingen, en biedt daarbij diverse afgeleide implementaties ervan, bv. FileStream en MemoryStream.

## MemoryStream

De MemoryStream is een van de eenvoudigste Stream classes die vaak gebruikt wordt. Deze stream verwerkt gegevens in het geheugen zoals de naam impliceert en wordt vaak gebruikt om bytes te verwerken die van een ander plaats komen, bv. een bestand of een netwerklocatie, zonder de bron te blokkeren.

Je zou dus bijvoorbeeld de hele inhoud van een bestand kunnen inlezen in een MemoryStream, die het bestand onmiddellijk sluit en weer opent, en dan gaan werken aan de bytes in een MemoryStream. Als je vaak heen en weer moet zoeken in de bytes, gaat dit veel sneller dan hetzelfde direct in bv. een FileStream doen, omdat de bytes in een MemoryStream worden opgeslagen in het geheugen in plaats van op de schijf.

Daarom zie je vaak dat een MemoryStream wordt geïnitialiseerd met een array van bytes (byte[]) die van een andere bron komen. Vaak zal je zien dat de geïnstantieerde MemoryStream wordt doorgeschoven naar een ander mechanisme dat de MemoryStream zal gebruiken, bv. één van de StreamReader typen. Hier is een voorbeeld:

```c#
public void UseMemoryStream()
{
	var fileContents = File.ReadAllBytes("test.txt");
	using(MemoryStream memoryStream = new MemoryStream(fileContents))
	{
		using(TextReader textReader = new StreamReader(memoryStream))
		{
			string line;
			while((line = textReader.ReadLine()) != null)
				Console.WriteLine(line);
		}
	}
}
```

In dit voorbeeld lezen we alle bytes in een simpel tekstbestand. Dan creëren we een MemoryStream met deze bytes en dan creëren we een StreamReader die alle regels van de MemoryStream zal lezen. Zoals dit voorbeeld illustreert, is de MemoryStream een prima hulpbron voor een andere class die het werk zal doen, in dit geval de StreamReader.

StreamReader/StreamWriter klassen laten toe eenvoudig te werken met de onderliggende stream. Als je wil, kan je echter de bytes ook direct uit de MemoryStream oplezen. MemoryStream biedt verschillende methoden aan om dit te doen, bijvoorbeeld de ReadByte() methode. Deze leest de byte op de huidige positie, geeft deze terug en schuift een positie verder zodat de stream klaar staat om de volgende byte uit te lezen (zie property Position). 

Een voorbeeld:

```csharp
public void UseMemoryStream()
{
	var fileContents = File.ReadAllBytes("test.txt");
	using(MemoryStream memoryStream = new MemoryStream(fileContents))
	{
		int b;
		while((b = memoryStream.ReadByte()) >= 0)
			Console.WriteLine(Convert.ToChar(b));
	}
}
```

De MemoryStream klasse kan gebruikt worden als hulpbron voor data die je in het geheugen wilt houden. Dit levert een geweldige tijdelijke opslag voor data die vanuit een bestand komen of vanuit een netwerk bron, om blokkering te voorkomen terwijl je met de data aan het werk bent.

## Binair of text

### De namespace System.IO en de abstracte klasse Stream

Om gebruik te maken van streams moeten we een referentie toevoegen naar de namespace System.IO. 

```
using System.IO; 
```

Deze namespace bevat onder andere de abstracte klasse Stream, welke de mogelijkheden definieert die een concrete stream klasse nodig heeft. De Stream klasse heeft properties die bepalen wat je kan doen met een bepaalde stream, informatie omtrent de stream (zoals lengte, huidige positie in de stream, enzovoort) en methoden om bytes of arrays van bytes te lezen en te schrijven. 

Volgend voorbeeld demonstreert het gebruik van een Stream object. We verkrijgen een stream (als voorbeeld) via de methoden GetOutputStream en GetInputStream om respectievelijk te schrijven naar en te lezen van een stream. 

```c#
//Bytes schrijven naar een stream 
Stream output = GetOutputStream(); 
byte[] outbuf = new byte[5]{20,21,22,23,24}; 
output.write(outbuf, 0, outbuf.length); 
output.close(); 

//Bytes lezen van een stream 
Stream input = GetInputStream(); 
byte[] inbuf = new byte[(int)instr.length]; 
input.read(inbuf, 0, inbuf.length); 
input.close(); 
```

In bovenstaande code kunnen de streams output en input om het even welk type stream zijn, bvb. een FileStream, een NetworkStream of een ander type stream.

Omdat streams meestal gebufferd werken (bvb. FileStream), is het noodzakelijk de stream te flushen na gebruik. Dat kan via de methode Flush van een stream, maar er wordt ook automatisch een flush uitgevoerd bij het afsluiten van je stream via de methode Close. Het is dus belangrijk dat je na gebruik van een stream de methode Close aanroept (of Flush wanneer je de stream nog wenst te gebruiken). Als je dit niet doet, zal de buffer pas geflushed worden wanneer de garbage collector het object als verwijderbaar detecteert, en effectief verwijdert uit het geheugen, maar dat kan om het even wanneer zijn, en is dus zeker geen *good practice*. Ook zal het bestand in gebruik blijven totdat de stream gesloten wordt (Close), waardoor het niet toegankelijk is voor verder gebruik (Tenzij anders ingesteld, bij de parameters voor je stream).

### Bytes? Chars? Strings? Tekst schrijven naar een stream

Bytes, chars en strings zijn niet gelijk aan elkaar (anders zouden deze 3 verschillende datatypes niet bestaan natuurlijk). 

* Byte: 1 byte
* Char: 2 bytes (unicode!)
* String: een object (reference type) dat een serie unicode characters bevat.

Streams schrijven gegevens typisch weg als bytes. We moeten dus een manier hebben om onze chars te converteren naar bytes en onze strings te converteren naar een byte array. Het mag voor zich spreken dat .net  deze mogelijkheid aanbiedt. Er is een ASCII Encoding klasse beschikbaar via de System.Text namespace. 

```c#
Using System.Text;

//... 

string str = "Hello world"; 
byte[] b = new byte[str.length]; 
Encoding.ASCII.GetBytes(str.ToCharArray(), 0, str.length, b, 0); 
```

Een string object heeft de methode ToCharArray, dewelke een char array teruggeeft met de unicode chars van de string. Een string heeft ook een property Length, waarmee we weten uit hoeveel characters de string bestaat. Via de Encoding.ASCII klasse uit de System.Text namespace kunnen we de character array van een string omzetten naar een byte array, die we dan wel kunnen wegschrijven naar een stream. (Zie MSDN voor de methoden en overloads). Ook het omgekeerde is mogelijk natuurlijk (een byte array omzetten naar een string): 

```C#
byte[] buf = new byte[11]{72,101,108,108,111,32,119,111,114,108,100}; 
string str; 
str = System.Text.Encoding.ASCII.GetString(buf); 
```

String str zal de tekst *Hello world* bevatten.

### Readers en Writers 

Misschien vinden jullie het al wat omslachtig om eerst conversies te moeten doen vooraleer je de gegevens kan wegschrijven. Wel, dat is ook zo, maar je moet er rekening mee houden dat we tot nu toe het lezen en schrijven van gegevens naar een stream, geïnstancieerd van de abstracte klasse Stream demonstreerden. De ontwerpers van het .net zorgden er echter voor dat er enkele andere klassen beschikbaar zijn die de mogelijkheid geven om wel rechtstreeks strings en chars (en andere data types) weg te schrijven naar een stream. Deze klassen breiden als het ware de mogelijkheden van het werken met een stream uit. Zo zijn er de klassen BinaryReader, BinaryWriter, StreamReader en StreamWriter. Typisch nemen deze klassen een stream als parameter voor hun constructor, maar je kan bij de StreamReader en StreamWriter klassen ook een bestandspad opgeven als parameter aan de constructor, waarbij dan automatisch de stream gecreëerd wordt (BinaryReader en BinaryWriter nemen enkel een stream als parameter, geen bestandspad). Omdat we het pas later hebben over de concrete stream klassen, geven we hier enkel een codevoorbeeld van de StreamReader en StreamWriter klassen:

```c#
//Schrijven naar bestand 
StreamWriter sw = new StreamWriter("test.txt", false, Encoding.ASCII); 
sw.writeline("hello world"); 
sw.close(); 

//Terug lezen van bestand 
StreamReader sr = new StreamReader("test.txt", Encoding.ASCII); 
string input = sr.readline(); 
sr.close(); 
```

Er zijn verscheidene constructors voor deze 2 klassen, één voor ieder zijn noden -. Bovenstaande demonstratiecode is heel simpel, en zou voor zich moeten spreken. De parameter false voor de StreamWriter constructor zet append op false voor dit object. Er wordt een string geschreven naar het bestand test.txt via een instantie van de klasse StreamWriter, en deze wordt terug uitgelezen via een instantie van de klasse StreamReader. 

### Formatters 

Wat hebben we tot nu toe gezien? We kunnen reeds simpele gegevens (hoofdzakelijk strings en value types) wegschrijven naar en lezen van een stream. Dit is heel bruikbaar voor simpele testjes, of zelfs voor het werken met een log bestand, maar in de praktijk gebeurt het meer dat er objecten worden weggeschreven naar een stream. Eventueel zou je dit kunnen omzeilen via de methode ToString van een object, en bij het terug inlezen van een object zou je een constructor die deze string kan parsen kunnen gebruiken, maar er is een efficiëntere methode. 

Wat we gaan doen, wordt **Object Serialization** genoemd (I/O met objecten). Dit gebeurt in samenwerking met een Formatter. Object Serialization serialiseert een object naar een bytestream, en we leerden reeds dat streams gebaseerd zijn op het lezen en schrijven van bytes. Om een klasse serialiseerbaar te maken, moet je de statement [Serializable] voor de klassedefinitie plaatsen. (Als je in de MSDN informatie naleest omtrent verschillende klassen, is meestal ook vermeld of je een bepaalde klasse kan serialiseren). 

Een voorbeeldklasse Point : 

```c#
[Serializable] 
public class Point 
{ 
	private double _xval; 
	private double _yval;

	[NonSerialized] 
	private double _len = 0; 

	public Point(int x, int y) 
	{ 
		_xval = x; 
        _yval = y; 
	} 

	public double x { get { return _xval; } } 
	public double y { get { return _xval; } } 
	
	public double Length 
	{ 
		get 
		{ 
			if (_len == 0) 
			_len = Math.Sqrt(x*x + y*y); 
			return _len; 
		} 
	} 
}
```

Door het statement **Serializable** weet de compiler dat desbetreffende klasse serialiseerbaar is. Let op het attribuut [NonSerialized]. Wegens het statement NonSerialized zal dit veld niet opgenomen worden in het geserializeerde object. Deze nonserialized velden gaan een waarde null meekrijgen bij het serializeren, afhankelijk van hun datatype, bijvoorbeeld 0 voor een integer, en null voor een reference. 

Laat ons nu een demonstreren hoe een object geserializeerd wordt naar een stream (we maken gebruik van bovenstaande klasse Point, stm is de stream voor volgend voorbeeld) : 

```c#
Point p1 = new Point(1, 2); 
Point p2 = new Point(3, 4); 
Point p3 = new Point(5, 6); 
BinaryFormatter bf = new BinaryFormatter(); 
bf.serialize(stm, p1); 
bf.serialize(stm, p2); 
bf.serialize(stm, p3); 
str.close(); 
```

Je kan dus gebruik maken van een BinaryFormatter object, en via zijn methode Serialize kan je je object serializeren op een stream. Omgekeerd is even simpel, je deserializeert de objecten van een stream: 

```
Point p4, p5, p6; 
p4 = (Point)bf.Deserialize(str); 
p5 = (Point)bf.Deserialize(str); 
p6 = (Point)bf.Deserialize(str); 
```

De methode deserialize creëert een instantie van het geserialiseerde object, waarbij alle geserialiseerde velden geïnitialiseerd worden naar de opgeslagen waarde. De nonserialised fields gaan op hun null waarde ingesteld worden. 

Noot: De BinaryFormatter krijgt volle toegang tot private mmbers, waardoor je je daar geen zorgen om hoeft te maken - Fantastisch niet!? 

Hoe kan deserialize nu weten welk type klasse hij moet instanciëren? Er wordt naast de objectgegevens ook wat informatie omtrent de klasse van het object weggeschreven. Dit wordt bepaald door de klasse SerializationInfo.

### FileStream

De Stream klasse is abstract, nu gaan we het hebben over concrete stream klassen, die afgeleid zijn van de Stream klasse. De manier waarop je een stream aanmaakt verschilt van stream klasse tot stream klasse. 

Met volgende code kan je bijvoorbeeld een FileStream verkrijgen: 

```c#
File.OpenRead("sourcefile.txt"); 
```

Noot: OpenRead is een statische methode van de klasse File, die beschikbaar is van de System.IO namespace. Deze klasse File bevat nog meer van deze heel interessante mogelijkheden, zoals File.Exists om te checken of een bestand bestaat, enzovoort ... 

We kunnen als volgt werken: 

```c#
StreamReader input; 

input = new StreamReader( File.OpenRead("test.txt") );
```

 En om te schrijven naar een bestand : 

```c#
StreamWriter write; 

write = new StreamWriter( File.OpenWrite("destfile.txt") ); 
```

Je weet nu dat sommige methoden je een stream kunnen teruggeven (als return value). Je kan streams natuurlijk ook zelf definiëren. In volgend voorbeeld definiëren we zelf een FileStream om te lezen uit een bestand: 

```c#
FileStream f = new FileStream( test.txt, FileMode.Open, FileAccess.Read, FileShare.Read ); 
```

Voor de verschillende overloads van de constructors van de stream klassen kijk je best in de Microsoft documentatie. 

Een volledig voorbeeld:

```c#
using System;
using System.IO;
using System.Text;

namespace FileStreamDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string bestand = @"c:\tmp\gegevens.txt";
            var schrijfTekst = Encoding.ASCII.GetBytes("Dit is een tekst.");
            var schrijfStream = File.Create(bestand);
            schrijfStream.Write(schrijfTekst, 0, schrijfTekst.Length);
            schrijfStream.Close();
            
            var leesStream = File.OpenRead(bestand);
            var leesTekst = new byte[leesStream.Length];
            leesStream.Read(leesTekst, 0, leesTekst.Length);
            leesStream.Close();
            Console.WriteLine(Encoding.ASCII.GetString(leesTekst));
        }
    }
}
```

Enkele van de belangrijkste stream klassen: 

- **FileStream** : gebufferde stream om te lezen van en schrijven naar bestanden. 
- **NetworkStream** : ongebufferde stream om gegevens te verzenden tussen meerdere computers via een netwerk. 
- **MemoryStream** : gegevens kunnen opgeslagen worden in het computergeheugen. 
- **BufferedStream** : hiermee kan je ongebufferde streams gebufferd laten werken. 