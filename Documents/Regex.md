# Reguliere Expressies (Regex)

## Inleiding

We hebben eerder al veel gesproken over strings - de mogelijkheid om tekst te kunnen verwerken en manipuleren is zo ontzettend belangrijk voor alle programmeurs die er zijn! Maar terwijl het opknippen van strings met de SubString method of een paar simpele string-to-string vervangingen beschouwd kunnen worden als simpele stringverwerkingen, is stringverwerking met Regular Expressions (gebruikelijk afgekort tot Regex) de extreme versie daarvan!

Om te beginnen, Regular Expressions (Regex) is geen uitvinding van Microsoft/.NET. Ze werden al vóór uitgevonden het .NET framework uitgevonden, als manier om een zoekpatroon tot uitdrukking te brengen. Dit zoekpatroon kan dan gebruikt worden om zoek- of zoek/vervangoperaties uit te voeren bij een stuk tekst. Jouw eerste gedachte zou kunnen zijn dat je niet nóg een "taal" nodig hebt om een string te doorzoeken. Maar wacht toch maar even af om te zien wat je ermee kunt doen!

Het mooie van Regular Expressions is dat ze door vrijwel elke programmeertaal worden ondersteund, en hoewel er kleine variaties zijn, kun je dezelfde regex in al deze talen gebruiken om hetzelfde te bereiken. Het .NET framework kent een hele mooie implementatie van RTergular Expressions, gecentreerd rond de *Regex* class die te vinden is in de *System.Text.RegularExpressions* namespace.

## Samenvatting

Met Regular Expressions kun je een zoekpatroon definiëren om op een string 'zoek en zoek/vervang' operaties uit te voeren. Het .NET framework kan goed werken met jouw RTegular Expressions zoals we in de volgende artikelen zullen ontdekken. Daar zullen we werken met de *Regex* class zowel als met 'hulpclasses' als de *Match* en *MatchCollection* classes.

# Zoeken met de Regex class

Zoals we in het vorige hoofdstuk bespraken, kun je met Regular Expressions zoekpatronen definiëren voor het werken met strings. Voor het verwerken van dit zoekpatroon, komt het .NET framework met een zeer veelzijdige class: de Regex class. In dit artikel zullen we een aantal zoekpatronen definiëren en die gebruiken met de Regex class. Denk er echter alsjeblieft aan dat de syntaxis van Regular Expressions behoorlijk gecompliceerd kan zijn en dat dit een C# tutorial is en geen Regex tutorial. Toch zal ik een paar eenvoudige Regex patronen gebruiken om te demonstreren hoe je er in C# mee kunt werken. Als je meer wil weten over Regular Expressions: [Regular Expression Tutorial](https://www.regular-expressions.info/tutorial.html).

## De IsMatch Method

In dit eerste voorbeeld zal ik één van de meest basale methods van de Regex class gebruiken, genaamd IsMatch. Hij retourneert alleen maar true of false, afhankelijk van of er één of meerder 'matches' gevonden worden in de test string:

```c#
string testString = "John Doe, 42 years";
Regex regex = new Regex("[0-9]+");
if (regex.IsMatch(testString))
    Console.WriteLine("String contains numbers!");
else
    Console.WriteLine("String does NOT contain numbers!");
```

We definiëren een test string en daarna creëren we een exemplaar van de Regex class. We voeren in de huidige Regular Expression een string in, in dit geval, en de regex specificeert dat we naar een getal van ongeacht wat voor lengte zoeken. Daarna 'outputten' we een tekstregel, afhankelijk van of de regex een 'match' is voor onze test string. Heel fraai, maar in de meeste gevallen wil je iets doen met de 'match(es)', en hiervoor hebben de Match class>

## De Match Class & Method

In dit volgende voorbeeld leggen we het gevonden getal uit de test string vast en tonen het aan de gebruiker, in plaats van alleen maar te verifiëren dat het er is:

```c#
string testString = "John Doe, 42 years";
Regex regex = new Regex("[0-9]+");
Match match = regex.Match(testString);
if (match.Success)
    Console.WriteLine("Number found: " + match.Value);
```

We gebruiken dezelfde regex en test string als zopas. Ik roep de **Match()** method aan, die een exemplaar van de Match class zal retourneren, dit gebeurt zowiezo of er nu wel of geen match wordt gevonden. Om er zeker van te zijn dat een match *is* gevonden, check ik de **Success** property. Als ik er zeker van ben dat een match is gevonden, gebruik ik de **Value** property om hem op te halen.

De match class bevat meer nuttige info dan alleen maar de gematchte string, bv. kun je zomaar uitzoeken waar de match werd gevonden en hoe lang hij is, enzovoorts:

```c#
string testString = "John Doe, 42 years";
Regex regex = new Regex("[0-9]+");
Match match = regex.Match(testString);
if (match.Success)
    Console.WriteLine("Match found at index " + match.Index + ". Length: " + match.Length);
```

De **Index** en **Length** properties worden hier gebruikt om informatie te tonen over de locatie en de lengte van de 'match'.

### Capture Groepen

In de eerste paar voorbeelden vonden we maar een enkele waarde in onze zoekstring, maar Regular Expressions kan natuurlijk veel meer doen dan dat! We kunnen bijvoorbeeld zowel naam als leeftijd in onze teststring vinden, terwijl we irrelevant spul zoals de command en de 'years' tekst eruit gooien. Iets dergelijks is een 'eitje' voor Regular Expressions, maar als je niet bekend bent met de syntaxis lijkt het erg gecompliceerd. Laten we toch maar een poging wagen:

```c#
string testString = "John Doe, 42 years";
Regex regex = new Regex(@"^([^,]+),\s([0-9]+)");
Match match = regex.Match(testString);
if (match.Success)
    Console.WriteLine("Name: " + match.Groups[1].Value + ". Age: " + match.Groups[2].Value);
```

Ik heb de gemodificeerde regex zo veranderd dat hij naar alles zoekt wat GEEN komma is. Deze waarde is geplaatst in de eerste 'capture' groep, dankzij de omringende ronde haken. Daarna zoekt hij naar de scheidingskomma en daarna naar een getal, dat in de tweede 'capture' groep is geplaatst (alweer dankzij de ronde haken). In de laatste regel gebruik ik de Groups property om toegang te krijgen tot de gematchte groepen. Ik gebruik index 1 voor de naam en 2 voor de leeftijd omdat het de volgorde gebruikt waarin de match groepen werden gedefinieerd in de regex string (index 0 bevat de gehele match).

#### Capture Groups met Naam

Zodra de regex meer gevorderd/langer is dan die we zojuist gebruikt hebben, kunnen genummerde 'capture groups' onhanteerbaar worden omdat je je voortdurend de volgorde en de index ervan moet herinneren. Gelukkig voor ons ondersteunt Regular Expressions en het .NET framework 'capture groups' met een naam, waardoor je elke groep in de regex een naam kan geven en er daarna aan kunt refereren in de Groups property. Bekijk dit herschreven voorbeeld waar we groepsnamen gebruiken in plaats van nummers:

```c#
string testString = "John Doe, 42 years";
Regex regex = new Regex(@"^(?<name>[^,]+),\s(?<age>[0-9]+)");
Match match = regex.Match(testString);
if (match.Success)
    Console.WriteLine("Name: " + match.Groups["name"].Value + ". Age: " + match.Groups["age"].Value);
```

Het gaat precies zoals eerst, maar nu kun je logische namen gebruiken om de gematchte waarden op te zoeken in plaats van de juiste index te moeten onthouden. Dit is weliswaar geen groot verschil in ons simpele voorbeeld, maar, zoals gezegd, zul je het gaan appreciëren wanneer jouw Regular Expressions toeneemt in complexiteit en lengte

## De MatchCollection Class

De Match class is hèt middel als je alleen maar met één enkele match wilt werken (denk eraan dat een match meerdere values kan bevatten, zoals we zagen in de vorige voorbeelden). Maar soms wil je met meerdere matches tegelijk werken. Hiervoor hebben we de **Matches()** method, die een MatchCollection class retourneert. Hij bevat alle gematchte waarden in de volgorde waarin ze werden gevonden. Laten we eens kijken hoe deze class te gebruiken is:

```c#
string testString = "123-456-789-0";
Regex regex = new Regex(@"([0-9]+)");
MatchCollection matchCollection = regex.Matches(testString);
foreach (Match match in matchCollection)
    Console.WriteLine("Number found at index " + match.Index + ": " + match.Value);
```

Ik heb de regex en de teststring veranderd, vergeleken met de voorgaande voorbeelden. We hebben nu een teststring met meerdere getallen en een regex die specifiek zoekt naar strings die uit één of meer getallen bestaan. We gebruiken de **Matches()** method om een MatchCollection van onze regex te krijgen, die de matches bevat die in de string werden gevonden. In dit geval zijn er vier matches die we na elkaar 'outputten' met een *foreach* loop. Het resultaat ziet er ongeveer zo uit:

```output
Number found at index 0: 123
Number found at index 4: 456
Number found at index 8: 789
Number found at index 12: 0
```

Als er geen matches zouden worden gevonden, dan zou een lege MatchCollection worden geretourneerd.

## Samenvatting

Met behulp van de Regex class, en samen met de Match en MatchCollection classes, kunnen we strings op een heel geavanceerde manier matchen. De Regular Expression syntaxis kan erg gecompliceerd lijken, maar als je het eenmaal snapt dan heb je een zeer sterk hulpmiddel. Zelfs als je geen tijd wilt investeren in het leren van de regex syntaxis, kun je vaak voor specifieke behoeften via 'Google search' expressions vinden , die door andere programmeurs zijn gemaakt. Zodra je de regex string hebt geschreven of geleend, kun je hem voor je eigen doeleinden gaan gebruiken met de technieken en classes die we in dit artikel hebben gedemonstreerd.

Maar zoeken is maar een deel van de pret. Je kunt ook een paar heel interessante search/replace (zoek/vervang) operaties doen met Regular Expressions. Dit gaan we bekijken in één van de volgende artikelen.

# Search/Replace met de Regex Class

In een vorig artikel hebben we de Regex class besproken en hoe we die kunnen gebruiken als we een string willen doorzoeken. Regular Expressions zijn hier prima geschikt voor, maar een ander gebruiksgeval doet zich voor als je search/replace operations wilt uitvoeren, waarbij je zoekt naar een specifiek patroon dat je door iets anders wilt vervangen. De String class heeft al een Replace() method, maar die is alleen maar geschikt voor simpele zoekopdrachten. Als je Regular Expressions gebruikt, kun je de kracht van regex zoekopdrachten gebruiken en zelfs 'captured' groepen gebruiken als onderdeel van de vervangende string. Klinkt dat gecompliceerd? Geen zorgen, we beginnen met een eenvoudig voorbeeld en werken dan gestadig door naar meer geavanceerde gevallen.

Zoals in het voorgaande artikel, gaan alle voorbeelden ervan uit dat je de RegularExpressions namespace hebt geimporteerd:



```c#
using System.Text.RegularExpressions;
```

Als dat gedaan is, gaan we werken aan stringvervanging via Regular Expressions. We zullen de **Replace()** method gebruiken die we vonden in de **Regex** class:

[Download sample code](https://csharp.net-tutorials.com/download-csharp-package-pdf-and-sample-code/?utm_source=website&utm_medium=link&utm_campaign=codebox)

```c#
string testString = "<b>Hello, <i>world</i></b>";
Regex regex = new Regex("<[^>]+>");
string cleanString = regex.Replace(testString, "");
Console.WriteLine(cleanString);
```

Dit voorbeeld laat een gesimplificeerde benadering zien van het verwijderen van HTML tags bij een string. We matchen alles waar blokhaken ([ ]) omheen staan (<>) en gebruiken dan de Replace() method om elke voorval te vervangen met een lege string, wat vooral betekent het verwijderen van de HTML tags uit de teststring.

## Vervanging met Gevangen Waarden (Captured Values)

Maar stel nu, dat je ze niet wil verwijderen, maar in plaats daarvan de tags wil veranderen in iets dat niet door de browser geïnterpreteerd zal worden, bv. door de punthaken (<>) te vervangen door vierkante haken ([ ] ) . Dit is precies waar de Regular Expressions hun ware kracht tonen, omdat het in feite heel gemakkelijk is, zoals geïllustreerd in deze lichtelijk herschreven versie van ons vorige voorbeeld:

```c#
string testString = "<b>Hello, <i>world</i></b>";
Regex regex = new Regex("<([^>]+)>");
string cleanString = regex.Replace(testString, "[$1]");
Console.WriteLine(cleanString);
```

Ik veranderde alleen maar twee minieme details: Ik voegde een paar ronde haken toe aan de regex om een 'capture' groep te maken, in wezen het 'capturen' van de waarde tussen de vierkante haken in de eerste 'capture' groep. In de **Replace()** method refereer ik hiernaar met gebruik van de speciale notatie **$1**,, dat in feite alleen maar betekent 'capture' groep nummer 1. Dit gedaan hebbende, ziet onze output er nu zo uit:

```c#
[b]Hello, [i]world[/i][/b]
```

### Capture Groepen met Naam

Je kunt natuurlijk hetzelfde doen met 'capture' groepen die een naam hebben gekregen (besproken in het vorige artikel), op deze manier:

```c#
string testString = "<b>Hello, <i>world</i></b>";
Regex regex = new Regex("<(?<tagName>[^>]+)>");
string cleanString = regex.Replace(testString, "[${tagName}]");
Console.WriteLine(cleanString);
```

Als je 'capture' groepen met een naam gebruikt, neem dan alleen maar de **${name-of-capture-group}** notatie.

## Gebruik van een MatchEvaluator method

Maar als je nu nog meer controle wilt over hoe de waarde wordt vervangen? We kunnen hiervoor een MatchEvaluator parameter gebruiken. Dat is in feite niet meer dan een referentie (plaatsvervanger) naar een method die steeds wordt aangeroepen als een vervanging moet worden gemaakt. Hierdoor kun je de vervangingswaarde wijzigen voordat hij gebruikt wordt. Laten we bij het HTML tags voorbeeld blijven dat we al een paar keer hebben gebruikt. Deze keer echter bepalen we welke HTML tags worden gebruikt. Hier volgt het volledige voorbeeld:

```c#
using System;
using System.Text.RegularExpressions;

namespace RegexSearchReplaceMethod
{
    class Program
    {
    static void Main(string[] args)
    {
        string testString = "<b>Hello, <i>world</i></b>";
        Regex regex = new Regex("<(?<tagName>[^>]+)>");
        string cleanString = regex.Replace(testString, ProcessHtmlTag);
        Console.WriteLine(cleanString);
    }

    private static string ProcessHtmlTag(Match m)
    {
        string tagName = m.Groups["tagName"].Value;
        string endTagPrefix = "";
        if(tagName.StartsWith("/"))
        {
        endTagPrefix = "/";
        tagName = tagName.Substring(1);
        }
        switch (tagName)
        {
        case "b":
            tagName = "strong";
            break;
        case "i":
            tagName = "em";
            break;
        }
        return "<" + endTagPrefix + tagName.ToLower() + ">";
    }
    }
}
```

Het eerste deel van het voorbeeld ziet er precies zo uit als zojuist, maar in plaats van een vervangingsstring te leveren, maken we een referentie naar onze *ProcessHtmlTag()* method. Zoals genoemd, wordt deze method steeds opgeroepen als een vervanging ophanden is, met de Match in kwestie als parameter. Dit betekent dat we in onze MatchEvaluator method alle info over de match hebben, zodat we gepast kunnen handelen. In dit geval gebruiken we de gelegenheid om de tags meer semantisch te maken door de vetgedrukte (b) tag te vervangen door de strong tag en de schuingedrukt (i) tag met een nadruk (em) tag. Het maakt niet uit of de tag is veranderd of niet, we maken er 'lowercase' van.

Het is duidelijk dat een MatchEvaluator parameter erg veel kan, en dit is nog maar een eenvoudig voorbeeld van wat bereikt kan worden.

## Samenvatting

Zoek/vervang (search/replace) operaties zijn tot veel in staat als je Regular Expressions gebruikt, en zelfs tot nog meer met de MatchEvaluator parameter. Hierdoor zijn de mogelijkheden om strings te manipuleren vrijwel eindeloos.

## Regex Modifiers

In previous articles, we talked about what Regular Expressions are and how to use them in C# for matching, replacing and so on. At this point, you should already have realized how powerful Regular Expressions are and how they can help you in a lot of situations, but they get even more powerful when you know about the possible **modifiers**.

When working with Regular Expressions, you can use one or several modifiers to control the behavior of the matching engine. For instance, a Regex matching process is usually case-sensitive, meaning that "a" is not the same as "A". However, in a lot of situations, you want your match to be case-insensitive so that the character "a" is just a letter, no matter if its in lowercase or UPPERCASE. Simply supply the RegexOptions.IgnoreCase option when creating the Regex instance and your match will be case-insensitive.

You'll find all the available modifiers in the RegexOptions enumeration. Several of them are common among all programming languages supporting the Regular Expression standard, while others are specific to the .NET framework.

As you'll see in the first example, Regex modifiers are usually specified as the second parameter when creating the Regex instance. You can specify more than one option by separating them with a pipe (|) character, like this:

```c#
new Regex("[a-z]+", RegexOptions.IgnoreCase | RegexOptions.Singleline);
```

Now let's run through all the modifiers to give you an idea of how they work and what they can do for you.

## RegexOptions.IgnoreCase

This will likely be one of your most used modifiers. As described above, it will change your Regular Expressions from being case-sensitive to being case-insensitive. This makes a big difference, as you can see in this example:

```c#
public void IgnoreCaseModifier()
{
	string testString = "Hello World";
	string regexString = @"^[a-z\s]+$";
	Regex caseSensitiveRegex = new Regex(regexString);
	Regex caseInsensitiveRegex = new Regex(regexString, RegexOptions.IgnoreCase);

	Console.WriteLine("Case-sensitive match: " + caseSensitiveRegex.IsMatch(testString));
	Console.WriteLine("Case-insensitive match: " + caseInsensitiveRegex.IsMatch(testString));
}
```

We specify a simple Regex, designed to match only letters (a-z) and whitespaces. We use it to create to Regex instances: One without the RegexOptions.IgnoreCase modifier and one with it, and then we try to match the same test string, which consists of lowercase and UPPERCASE characters and a single space. The output will, probably not surprisingly, look like this:

```output
Case-sensitive match: False
Case-insensitive match: True
```

## RegexOptions.Singleline

In Regular Expressions, the dot (.) is basically a catch-all character. However, by default, it doesn't match linebreaks, meaning that you can use the dot to match an entire line of letters, numbers, special characters and so on, but the match will end as soon as a linebreak is encountered. However, if you supply the **Singleline** modifier, the dot will match linebreaks as well. Allow me to demonstrate the difference:

```c#
public void SinglelineModifier()
{
	string testString = 
						@"Hello World
						This string contains
						several lines";
	string regexString = ".*";
	
	Regex normalRegex = new Regex(regexString);
	Regex singlelineRegex = new Regex(regexString, RegexOptions.Singleline);			

	Console.WriteLine("Normal regex: " + normalRegex.Match(testString).Value);
	Console.WriteLine("Singleline regex: " + singlelineRegex.Match(testString).Value);
}
```

The output will look like this:

```output
Normal regex: Hello World

Singleline regex: Hello World
							This string contains
                            several lines
```

## RegexOptions.Multiline

As we have talked about in this chapter, Regular Expressions consists of many different characters which have special purposes. Another example of this is these two characters: **^** and **$**. We actually used them in the case-sensitivity example above, to match the beginning and end of a string. However, by supplying the **Multiline** modifier, you can change this behavior from matching the beginning/end of a string to match the beginning/end of lines. This is very useful when you want to deal individually with the lines matched. Here's an example:

```c#
public void MultilineModifier()
{
	string testString =
						@"Hello World
						This string contains
						several lines";
	string regexString = "^.*$";

	Regex singlelineRegex = new Regex(regexString, RegexOptions.Singleline);
	Regex multilineRegex = new Regex(regexString, RegexOptions.Multiline);

	Console.WriteLine("Singleline regex: " + singlelineRegex.Match(testString).Value);

	Console.WriteLine("Multiline regex:");
	MatchCollection matches = multilineRegex.Matches(testString);
	for(int i = 0; i < matches.Count; i++)
		Console.WriteLine("Line " + i + ": " + matches[i].Value.Trim());
}
```

Notice how I use several a test string consisting of several lines and then use the matching mechanisms differently: With **singlelineRegex**, we treat the entire test string as one line, even though it contains linebreaks, as we discussed above. When using the **multilineRegex** we treat the test string as multiple lines, each resulting in a match. We can use the Regex.Matches() method to catch each line and work with it - in this case, we simply output it to the Console.

## RegexOptions.Compiled

While Regular Expressions are generally pretty fast, they can slow things down a bit if they are very complex and executed many times, e.g. in a loop. For these situations, you may want to use the **RegexOptions.Compiled** modifier, which will allow the framework to compile the Regex into an assembly. This costs a little extra time when you create it, compared to just instantiating a Regex object normally, but it will make all subsequent Regex operations (matches enzovoort) faster:

```c#
Regex compiledRegex = new Regex("[a-z]*", RegexOptions.Compiled);
```

## More modifiers

The above modifiers are the most interesting ones, but there's a few more, which we'll just go through a bit faster:

- **RegexOptions.CultureInvariant**: With this modifier, cultural differences in language is ignored. This is mostly relevant if your application works with multiple non-English languages.
- **RegexOptions.ECMAScript**: Changes the Regex variant used from the .NET specific version to the ECMAScript standard. This should rarely be necessary.
- **RegexOptions.ExplicitCapture**: Normally, a set of parentheses in a Regex acts as a capturing group, allowing you to access each captured value through an index. If you specify the ExplicitCapture modifier, this behavior is changed so that only named groups are captured and stored for later retrieval.
- **RegexOptions.IgnorePatternWhitespace**: When this modifier is enabled, whitespace in the Regex is ignored and you are even allowed to include comments, prefixed with the hash (#) char.
- **RegexOptions.RightToLeft**: Changes matching to start from right and move left, instead of the default from left to right.