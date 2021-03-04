# Debugging

Als je in Visual Studio aan het debuggen bent, zullen de tool vensters onderaan het scherm veranderen en zullen er nieuwe verschijnen (tenzij je die hebt uitgezet). Die vensters hebben namen als "Locals", "Watch", "Call stack" en "Immediate window" en ze hebben allemaal te maken met de debugging 'experience'. In dit onderdeel kijken we naar elk van hen en laten we zien wat ze voor je kunnen doen.

## Locals

Dit venster is het eenvoudigste van allemaal. Als een pauzepunt wordt bereikt, worden alle locale variabelen hier in een lijst verzameld, waardoor je een snel overzicht krijgt over hun naam, type en waarde. Je kunt zelfs rechts-klikken in het raster en kiezen voor "Edit value", om een variabele een nieuwe waarde te geven. Hierdoor kun je je code testen onder andere condities dan de huidige.

## Watch

Het Watch venster is een beetje zoals het *Locals* venster, maar hier kun je beslissen welke variabelen worden gevolgd, locale of globale. Je kunt te bewaken variabelen toevoegen door ze uit het code venster, of uit het *Locals* venster te slepen, of door hun naam op de laatste lege regel te schrijven. Jouw variabelen blijven in het Watch venster totdat je ze weer verwijdert, maar ze worden alleen maar bijgewerkt als je binnen de huidige scope aan het debuggen bent. Bijvoorbeeld een variabele in functie A wordt niet bijgewerkt als je door functie B 'stapt'. Net als bij het *Locals* venster kun je een bewaakte variabele rechts-klikken en "Edit value" selecteren om de huidige waarde van de variabele te wijzigen.

## Call Stack

Het *Call Stack* venster toont je de huidige hiërarchie van de opgeroepen functies. Bijvoorbeeld als functie A functie B oproept die vervolgens C oproept en die weer D, dan zal het *Call Stack* venster dat laten zien, en kun je naar elk van de functiedeclaraties springen. Je kunt ook zien welke parameters aan elke functie werden toegevoegd. In de eenvoudige voorbeelden waarmee tot nu toe hebben gewerkt, lijkt dit geen zin te hebben omdat het bijhouden van welke functie welke functie oproept triviaal is. Maar zodra je code een hoger niveau van complexiteit bereikt en je hebt functies in classes welke functies in andere classes oproepen, dan kan de *Call Stack* een echte redder zijn.

## Immediate window

Het *Immediate* venster is wellicht het nuttigste van allemaal. Je kunt er code regels in de huidige context van de debugger mee uitvoeren. Hierdoor kun je variabelen checken, hun waarde veranderen of alleen maar een regel code testen. Je hoeft hem alleen maar in het venster in te toetsen, op Enter te drukken en de regel zal worden uitgevoerd. Toets de naam van een variabele in, en de waarde ervan wordt getoond. Geef een variabele een waarde door a = 5 in te toetsen. Het resultaat (als dat er is) daarvan wordt getoond en elke verandering die je aanbrengt, wordt weerspiegeld als je verder gaat met het uitvoeren van de code. Het *Immediate* venster is als een C# terminal waar je code kunt invoeren en meteen het resultaat te zien krijgt. 

# Geavanceerde pauzepunten

In een eerder hoofdstuk hebben we het eerste pauzepunt gezet en dat was goed. Maar er is meer te zeggen over pauzepunten, tenminste, als je Visual Studio gebruikt. Het lijkt erop dat Microsoft deze extra debugging functies in enkele Express versies buiten werking heeft gesteld, maar maak je geen zorgen: het is leuk om ze te hebben, maar je kunt er ook zonder. Voor degenen die Visual Studio hebben, zijn hier de interessantste kenmerken die aan het pauzepunt zijn gerelateerd. Je komt erbij door een pauzepunt neer te zetten, dan er rechts op te klikken met de muis en dan de gewenste functie te selecteren.

## Voorwaarde (condition)

Met deze optie kun je een voorwaarde definiëren die, waar moet zijn, of, moet worden veranderd, voordat het pauzepunt wordt bereikt. Dit kan werkelijk nuttig zijn als je met meer geavanceerde code te maken hebt, waarbij je de uitvoering alleen maar onder bepaalde omstandigheden wilt stoppen. Je hebt bv een lus die veel tijd vergt voordat die bij de relevante code is gearriveerd. In zo'n situatie zou je eenvoudig een pauzepunt kunnen zetten en dan een passende voorwaarde bedenken. Hier is een tamelijk saai voorbeeld om te laten zien hoe dat werkt:

```c#
static void Main(string[] args)
{
    for(int i = 0; i < 10; i++)
        Console.WriteLine("i is " + i);
}
```

Zet een pauzepunt op de regel waar we naar de console schrijven. Voer nu de applicatie uit. Het pauzepunt wordt steeds getriggerd als de lus wordt uitgevoerd. Maar misschien willen we dat niet. Misschien willen we het alleen maar als i gelijk is aan 4 (de 5e doorloop). Doe dat door een eenvoudige voorwaarde te definiëren, zoals hier:

```output
i == 4
```

Het pauzepunt wordt nu een beetje wit van binnen en als je de applicatie uitvoert, stopt hij alleen als de i variabele gelijk is aan 4. Je kunt ook de "has changed" (is gewijzigd) optie gebruiken om de debugger te instrueren om alleen maar te stoppen als het resultaat van bovenstaand statement is veranderd, bv. van false naar true.

## Tellen van de 'hits'

Met deze dialoog kun je een alternatieve voorwaarde definiëren, gebaseerd op het aantal keren dat het pauzepunt wordt bereikt. Je kunt bv. besluiten dat jouw pauzepunt de uitvoering alleen maar mag stoppen totdat het een aantal keren is bereikt. Er zijn verschillende opties om dit te controleren, afhankelijk van wat je nodig hebt. Gedurende 'debugtijd' kun je deze dialoog checken om te zien hoe vaak het pauzepunt tot dan toe is bereikt.

## When hit... ( zodra bereikt...)

Als je deze dialoog gebruikt, kun je alternatief gedrag definiëren voor wanneer het pauzepunt wordt bereikt. Dit kan reuze handig zijn in vele situaties waarbij je niet wilt dat de uitvoering stopt, maar je een bericht over de toestand wilt ontvangen of dat een macro geactiveerd wordt. Je kunt zelf een bericht bedenken en laten verschijnen, waarin je alle mogelijke info kan opnemen over de uitvoering. Voor gevorderde gebruikers zal de optie tot uitvoering van een specifieke macro bij het bereiken van het pauzepunt ook nuttig zijn.