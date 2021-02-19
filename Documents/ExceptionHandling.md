# Exception Handling

Veel fouten in code zijn het gevolg van:

- Het aanroepen van **data die er niet is** (bijvoorbeeld een bestand dat werd verplaatst of hernoemd)
- **Invoerfouten** door de gebruiker (bijvoorbeeld de gebruiker voert een letter in terwijl het programma aan getal verwacht)
- **Programmeerfouten** (bijvoorbeeld de programmeur gebruikt een object dat nog niet met de new operator werd geïnitialiseerd). Deling door nul is een andere klassieke fout!

In de voorgaande gevallen zijn dan *exceptions* (uitzonderingen) nuttig. Door zogenaamde exceptions af te handelen (*exception handling*) kunnen we ons programma alternatieve opdrachten geven bij het optreden van een uitzondering.

Het concept van "Exception handling" moet je goed beheersen in .NET: het .NET framework werpt exceptions op bij probleemsituaties.

Het zoeken naar en oplossen van fouten beschrijven we in programmeerjargon met het begrip “debuggen”. In Visual Studio zijn in dit opzicht handig:

* F5: start en voer uit (tot aan volgend breakpoint)
* F10: stap over volgende method
* F11: stap in volgende method

## Code zonder exception handling

Je zal zelf al geregeld *exceptions* zijn tegengekomen in je console programma. Wanneer je je programma gewoon uitvoert en er verschijnt plots een hele hoop tekst (met ondere andere het woord Exception in) gevolgd door het prompt afsluiten ervan, dan heb je dus een *exception* gegenereerd die je niet hebt afgehandeld.

![img](./pg017.png)

Vooral het eerste zinnetje van zo’n *exception* is altijd veel verklarender dan je denkt!

Indien je aan het debuggen bent en je krijgt een exception dan zal deze anders getoond worden, maar het gaat wel degelijk om dezelfde fout:

![img](pg020.png)

## Try en Catch

Het mechanisme om exceptions af te handelen in C# bestaat uit 2 delen:

- Een `try` blok: binnen dit blok staat de code die je wil controleren op uitzonderingen
- Een of meerdere `catch`-blokken: dit blok zal mogelijk exceptions die in het bijhorende try block voorkomen opvangen. Met andere woorden: in dit blok staat de code die de uitzondering zal ‘verwerken’ zodat het programma op een deftige manier verder kan.

De syntax is als volgt (let er op dat de catch blok onmiddellijk na het try blok komt):

```csharp
try
{
    //code waar exception mogelijk kan optreden
}
catch (Exception e)
{
    //exception handling code here
}
```

De constructie “Try … Catch” is bedoeld om te beletten dat het programma crasht bij een onvoorziene fout. Het programma probeert elk statement van de code na elkaar uit te voeren. Wanneer in het Try-blok een fout optreedt, dan wordt de uitvoering van de code verdergezet in het Catch-blok. In het Catch-blok staat de code van om mogelijke fouten af te handelen.

## Een try catch voorbeeld

In volgend stukje code kunnen uitzonderingen optreden:

```csharp
string input = Console.ReadLine();
int converted = Convert.ToInt32(input)
```

Een `FormatException` zal optreden wanneer de gebruiker tekst invoert of wanneer een komma-getal wordt ingevoegd. De conversie verwacht dit niet. `Convert.ToInt16()` kan enkel werken met gehele getallen.

We tonen nu hoe we dit met *exception handling* kunnen opvangen:

```csharp
try
{
    string input = Console.ReadLine();
    int converted = Convert.ToInt32(input);
}
catch (Exception e)
{
    Console.WriteLine("Verkeerde invoer!");
}
```

Indien er nu een uitzondering optreedt dan zal de tekst “Verkeerde invoer” getoond worden. Vervolgens gaat het programma verder met de code die mogelijk na het catch-blok staat.

## Meerdere catch blokken

`Exception` is een klasse van het .NET framework. Er zijn van deze basis-klasse meerdere exception-klassen afgeleid die een specifieke uitzondering behelsen. Enkele veelvoorkomende zijn:

| Klasse                     | Omschrijving                                                 |
| -------------------------- | ------------------------------------------------------------ |
| `Exception`                | Basisklasse                                                  |
| `SystemException`          | Klasse voor uitzonderingen die niet al te belangrijk zijn en die mogelijk verholpen kunnen worden. (afgeleid van Exception) |
| `IndexOutOfRangeException` | De index is te groot of te klein voor de benadering van een array (afgeleid van SystemException) |
| `NullReferenceException`   | Benadering van een niet-geïnitialiseerd object (afgeleid van SystemException) |

Je kan in het catch blok aangeven welke soort exceptions je wil vangen in dat blok. In het voorbeeld hiervoor stond:

```csharp
catch (Exception e)
{
}
```

Hiermee vangen we dus **alle** Exceptions op, daar alle Exceptions van de klasse `Exception` afgeleid zijn en dus ook zelf een `Exception` zijn (=polymorfisme eigenschap).

We kunnen nu echter ook specifieke *exceptions* opvangen. De truuk is om de meest algemene *exception* onderaan te zetten en naar boven toe steeds specifieker te worden. Stel bijvoorbeeld dat we weten dat de `FormatException` kan voorkomen en we willen daar iets mee doen. Volgende code toont hoe dit kan:

```csharp
try
{
    //...
}
catch (FormatException e)
{
    Console.WriteLine("Verkeerd invoerformaat");
}
catch (Exception e)
{
    Console.WriteLine("Exception opgetreden");
}
```

Indien een FormatException optreedt dan zal het eerste catch-blok uitgevoerd worden, anders het tweede. Het tweede blok zal niet uitgevoerd worden indien een FormatException optreedt.

## Welke exceptions worden gegooid?

De MSDN bibliotheek is de manier om te weten te komen welke exceptions een methode mogelijk kan gooien. Gaan we bijvoorbeeld naar de constructor-pagina van de StreamWrite klasse ([hier](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter.-ctor?view=netframework-4.8#System_IO_StreamWriter__ctor_System_String_System_Boolean_System_Text_Encoding_System_Int32_) dan zie we daar een hoofstuk Exception waar klaar en duidelijk wordt beschreven wanneer welke Exception wordt gegooid.

![img](./pg021.png)

## Werken met de exception parameter

De Exceptions die worden ‘gegooid’ door het programma zijn objecten van de Exception klasse. Deze klasse bevat standaard een aantal interessante zaken, die je kan oproepen in je code.

Bovenaan de declaratie van het catch-blok geef je aan hoe het exception object in het blok zal heten. In de vorige voorbeelden was dit altijd `e` (standaardnaam)

![img](https://timdams.gitbooks.io/csharpfromantwerp/content/assets/20_exceptions/eexc.png)

Omdat alle exception van Exception afgeleid zijn bevatten ze allemaal minstens:

| Element      | Omschrijving                                                 |
| ------------ | ------------------------------------------------------------ |
| `Message`    | Foutmelding in relatief eenvoudige taal                      |
| `StackTrace` | Lijst van methoden die de exception hebben doorgegeven       |
| `TargetSite` | Methode die de exception heeft gegeneerde (staat bij StackTrace helemaal bovenaan) |
| `ToString()` | Geeft het type van de exception, Message en StackTrace terug als string. |

We kunnen via deze parameter meer informatie uit de opgeworpen uitzondering uitlezen en bijvoorbeeld aan de gebruiker tonen

```csharp
catch (Exception e)
{
    Console.WriteLine("Exception opgetreden");
    Console.WriteLine("Message:"+e.Message);

    Console.WriteLine("Targetsite:" + e.TargetSite);
    Console.WriteLine("StackTrace:" + e.StackTrace);
}
```

**Opgelet**: vanuit security standpunt is het zelden aangeraden om Exception informatie zomaar naar de gebruiker te sturen. Mogelijk bevat de informatie gevoelige informatie en zou deze door kwaadwillige gebruikers kunnen misbruikt worden!

# Waar exception handling in code plaatsen?

De plaats in je code waar je je exceptions zal opvangen, heeft invloed op de totale werking van je code. Stel dat je volgende stukje code hebt waarin je een methode hebt die een lijst van strings zal beschouwen als urls die moeten gedownload worden. Indien er echter fouten in de string staan dan zal er een uitzondering optreden bij lijn 16:

```csharp
static void Main(string[] args)
{
    string[] urllist= new string[3];
    urllist[0] = "http://www.ap.be";
    urllist[1] = "http:\\www.humo.be";
    urllist[2] = "lucvervoort.com";
    DownloadAllUris(urllist);
}

static public void DownloadAllUris(string[] urlstodownload)
{
    WebClient webClient = new WebClient();

    foreach (string url in urlstodownload)
    {
        Uri uril= new Uri(url);
        string result = webClient.DownloadString(uril);
        Console.WriteLine(url+ &quot; gedownload!&quot;);
    }
}
```

We bekijken nu een aantal mogelijk try/catch locaties in deze code en zien welke impact deze hebben op de totale uitvoer van het programma.

## Rondom methode aanroep in z'n geheel

```csharp
try
{
    DownloadAllUris(urllist);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

Zal resulteren in:

```text
http://www.ap.be gedownload!
Ongeldige URI: kan de Authority/Host niet parsen.
```

Met andere woorden, zolang de urls geldig zijn zal de download lukken. Bij de eerste fout die optreedt zal de volledige methode echter stoppen.

## Rond afzonderlijke elementen in de loop

```csharp
foreach (string url in urlstodownload)
{
    try
    {
        Uri uril = new Uri(url);
        string result = webClient.DownloadString(uril);
        Console.WriteLine(url + &quot; gedownload!&quot;);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}
```

Dit zal resulteren in:

```text
http://www.ap.be gedownload!
Ongeldige URI: kan de Authority/Host niet parsen.
Ongeldige URI: de indeling van de URI kan niet worden bepaald.
```

Met andere woorden, indien een bepaalde url niet geldig is dan zal deze overgeslagen worden en gaat de methode verder naar de volgende. Op deze manier kunnen we alsnog alle urls trachten te downloaden.

# Zelf exceptions opwerpen

Je kan ook in je eigen code uitzonderingen ‘opgooien’, zodat deze elders opgevangen worden. Je kan hierbij zelf exceptions maken (zie volgende hoofdstukje) of gewoon gebruik maken van een bestaande Exception klasse.

Een voorbeeld:

```csharp
static int DoeIets(int getal)
{
    if (getal == 0)
        throw new DivideByZeroException("Getal equals 0.You shouldn't do that!");
    else
        return 100 / getal;
}


static void Main(string[] args)
{
    try
    {
        Console.WriteLine(DoeIets(0));
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
```

De uitvoer zal zijn:

![img](./pg024.png)

De lijn `throw new DivideByZeroException("Getal equals 0.You shouldn't do that!");` zorgt er dus voor dat we een eigen boodschap 'verpakken'

> Merk op dat het zelden aangeraden is om je foutboodschappen te hardcoden in je moedertaal.

# Een eigen exception ontwerpen

Je kan ook eigen klassen afleiden van Exception zodat je eigen uitzonderingen kan maken en gooien in je programma. Je maakt hiervoor gewoon een nieuwe klasse aan die je laat overerven van de Exception klasse. Een voorbeeld:

```csharp
class MyException: Exception
{
    public override string ToString()
    {
        string extrainfo = "Exception Generated by Tim Dams:\n";
        return extrainfo+base.ToString();
    }
}
```

Om deze exception nu zelf op te ‘gooien’ gebruiken we het keyword `throw`. In volgende voorbeeld gooien we onze eigen exception op een bepaald punt in de code en vangen deze dan op (de reden van de exception moet je zelf verzinnen, het is maar een simplistisch voorbeeld):

```csharp
static void Main(string[] args)
{
    try
    {
        MyMethod();
    }
    catch (Exception e)
    {
       Console.WriteLine(e.ToString());
    }     
}
static public void MyMethod()
{
    //do stuff
    //when suddenly: an exception! 
    MyException exp = new MyException();
    throw exp;
}
```

# Finally

Na het *catch* blok kan je een *finally* blok opnemen: de code in dit blok zal steeds uitgevoerd worden, of je nu in het *catch* blok komt of niet. 

Wat is het nut van *finally*? Indien je resources (geheugen, connecties, ...) wenst vrij te geven, dan gebeurt dit best in het *finally* blok omdat ze dan steeds worden vrijgegeven - of er nu al dan niet een *exception* optreedt die afgehandeld wordt of niet.

# Hoe stoppen bij een bepaalde exception in Visual Studio?

* Menu: Debug > Windows > Exception Settings > Common Language Runtime Exceptions
* Vink aan bij welke exceptions je wil stoppen wanneer deze optreedt
* Je kan zelfs definieren in welke module(s) je wenst te stoppen

# [Uitdieping](./CSharpExceptionHandling.pdf)