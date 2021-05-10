# Nuget

.NET wordt geleverd met veel kernbibliotheken waarmee van alles kan worden verwerkt, van het beheer van bestanden tot HTTP tot het comprimeren van bestanden. Er bestaat ook een zeer groot ecosysteem met bibliotheken van derden. Je kan NuGet, het .NET-pakketbeheer, gebruiken om deze bibliotheken te installeren en ze in je toepassing te gebruiken.

.NET en het bijbehorende ecosysteem maken veel gebruik van het woord *afhankelijkheid*. Een pakketafhankelijkheid is een bibliotheek van derden. Dit is een stukje herbruikbare code waarmee je iets voor elkaar kunt krijgen en dat kan worden toegevoegd aan je toepassing. De bibliotheek van derden is iets waarvan je toepassing *afhankelijk* is om te kunnen functioneren, vandaar ook het woord *afhankelijkheid*.

De bibliotheek van derden kan worden beschouwd als een pakket dat in een opslagplaats wordt opgeslagen. Een pakket bestaat uit een of meer bibliotheken die je kan toevoegen aan je toepassing, zodat je kan profiteren van de functies ervan.

We richten ons op pakketafhankelijkheden. Een .NET-project kan andere typen afhankelijkheden hebben, zoals frameworks, analyses, projectverwijzingen en gedeelde projectafhankelijkheden naast verpakte afhankelijkheden.

## Bepalen of je een pakket nodig hebt

Hoe weet je nu zeker of je een pakket voor je project nodig hebt? Dit is een gecompliceerde vraag die enkele factoren omvat:

- **Betere code ophalen**. Ga bij jezelf na of je bijvoorbeeld te maken hebt met een taak als beveiliging en je verificatie en autorisatie wilt implementeren. Het is belangrijk deze taak *goed uit te voeren* om je gegevens en die van je klant te beveiligen. Er bestaan standaardpatronen en bibliotheken die door veel ontwikkelaars worden gebruikt. Met deze bibliotheken worden functies geïmplementeerd die je waarschijnlijk altijd nodig hebt. En problemen worden opgelost zodra ze ontstaan. Je kan beter dergelijke bibliotheken gebruiken in plaats van zelf bibliotheken te maken. Waarschijnlijk schrijft je code zelf niet zo goed, omdat er veel randzaken zijn waarmee je rekening moet houden.
- **Tijd besparen**. Je kan zelf waarschijnlijk het meeste bouwen, zoals hulpprogramma's of onderdeelbibliotheken voor de gebruikersinterface. Maar dat kost wel tijd. Zelfs als het resultaat vergelijkbaar is met wat er beschikbaar is, is het geen goed gebruik van je tijd om al het werk dat in het schrijven van de code zit te repliceren als dit niet hoeft.
- **Onderhoud**. Alle bibliotheken en apps hebben vroeg of laat onderhoud nodig. Onderhoud omvat het toevoegen van nieuwe functies en het corrigeren van bugs. Is het een goed idee om de tijd van jezelf en van je team te gebruiken voor het onderhouden van een bibliotheek? Of is het beter om een open-source softwareteam het te laten afhandelen?

## Een pakket evalueren

Voordat je een bibliotheek installeert, wil je wellicht controleren van welke afhankelijkheden deze ondersteuning krijgt. Deze afhankelijkheden sporen je wellicht aan het pakket te gebruiken, of misschien ontmoedigen ze je juist. Hier volgen enkele factoren waarmee je rekening moet houden wanneer je een afhankelijkheid voor je project selecteert:

- **Grootte**. Het aantal afhankelijkheden kan voor een flinke footprint zorgen. Als je een beperkte bandbreedte hebt of andere hardware beperkingen hebt, kan dit een probleem zijn.
- **Licentieverlening**. Je moet ervoor zorgen dat de licentie die voor de bibliotheek wordt verleend geschikt is voor je beoogde gebruik, ongeacht of dat commercieel, persoonlijk of academisch is.
- **Actief onderhoud**. Als je pakket afhankelijk is van een afhankelijkheid die is afgeschaft of gedurende een lange periode niet is bijgewerkt, kan dit een probleem zijn.

Je kan meer te weten komen over een pakket voordat je dit installeert door naar `https://www.nuget.org/packages/<package name>` te gaan. Met deze URL ga je naar een gedetailleerde pagina voor het pakket. Selecteer de vervolgkeuzelijst **Afhankelijkheden** om te zien van welke pakketten deze afhankelijk is om te functioneren.

Het aantal vermelde afhankelijkheden vertelt mogelijk niet de hele waarheid. Als je een pakket downloadt, eindig je mogelijk met een pakketafhankelijkheid die tientallen pakketten bevat. De reden hiervoor? Elk pakket heeft een lijst met afhankelijkheden. Om te garanderen dat je een pakket kan gebruiken, worden alle afhankelijkheden verkend en gedownload wanneer je de `dotnet add package <package name>`-opdracht uitvoert.

## Een pakket installeren

Er zijn verschillende manieren om pakketten te installeren. In Visual Studio en Visual Studio voor Mac zijn een ingebouwde opdrachtregel en GUI beschikbaar voor pakketbeheer. Je kan handmatig pakketverwijzingen toevoegen aan het projectbestand. Je kan ze ook installeren via een opdrachtregelprogramma zoals Paket of .NET Core CLI.

Voor deze module gebruiken we de ingebouwde .NET Core CLI om pakketten te installeren. Je kan een pakket toevoegen aan het .NET-project door de opdracht in een terminal aan te roepen. Een typische installatie-opdracht ziet er als volgt uit: `dotnet add package <name of package>`. Wanneer je de opdracht `add package` uitvoert, maakt het opdrachtregelprogramma verbinding met een globaal register, haalt dit het pakket op en plaatst het in een map in cache die door alle projecten kan worden gebruikt.

Na het installeren en compileren van het project worden de verwijzingen toegevoegd aan je mappen voor foutopsporing of release. Je projectmap ziet er ongeveer als volgt uit:

```bash
-| bin/
---| Debug/
------| net3.1
--------| <files included in the dependency>
```

## Een pakket zoeken

Individuele ontwikkelaars kunnen het globale register op NuGet.org gebruiken om pakketten te zoeken en te downloaden die ze nodig hebben voor hun apps. Een bedrijf kan een strategie erop hebben ingericht welke pakketten bruikbaar zijn en waar je ze kan vinden.

![Schermopname van NuGet.org met een lijst met populaire pakketten.](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\finding-nuget.png)

Pakketten kunnen zich op verschillende locaties bevinden. Sommige van deze bronnen zijn mogelijk openbaar beschikbaar. Sommige zijn mogelijk beperkt en alleen beschikbaar voor werknemers van een specifiek bedrijf. Hier volgen enkele plaatsen waar pakketten zich kunnen bevinden:

- **Registers**. Een voorbeeld kan een globaal register zijn, zoals het NuGet.org-register. Je kan je eigen registers hosten. Deze kunnen privé of openbaar zijn. Services zoals GitHub en Azure DevOps stellen persoonlijke registers beschikbaar.
- **Bestanden**. Je kan een pakket installeren vanuit een lokale map. Installeren vanuit een pakket komt vaak voor als je je eigen .NET-bibliotheken wilt ontwikkelen en het pakket lokaal wilt testen, of als je om een of andere reden geen register wilt gebruiken.

![Diagram waarin de relatie tussen pakketmakers, pakkethosts en pakketconsumenten wordt aangegeven.](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\nuget-roles.png)

### NuGet-register en dotnet-hulpprogramma

Wanneer je `dotnet add package <name of dependency>` uitvoert, gaat .NET naar een globaal register met de naam NuGet.org-register en zoekt daar naar de code die je wilt downloaden. Deze bevindt zich op `https://nuget.org`. Je kan hier ook bladeren naar pakketten als je de pagina bezoekt via een browser. Elk pakket heeft een toegewezen website die je kan bezoeken.

![Schermafbeelding van de landingspagina voor een NuGet-pakket.](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\Documents\nuget-info.png)

Op deze sites kan je meer informatie vinden over waar de broncode zich bevindt. Je kan ook informatie vinden zoals metrische gegevens over downloads en informatie over onderhoud.

![Schermopname van informatie en metrische gegevens voor een NuGet-pakket.](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\Documents\nuget-downloads.png)

### .NET-opdrachten

Tot nu toe heb je geleerd hoe je afhankelijkheden kunt installeren met .NET Core CLI. Dit hulpprogramma kan echter nog veel meer doen.

.NET Core CLI kent vele opdrachten. Met de opdrachten kan je taken uitvoeren, zoals pakketten installeren en ontwerpen en .NET-projecten initialiseren. Je hoeft de opdrachten niet allemaal tot in detail te kennen. Wanneer je begint met .NET, zal je waarschijnlijk slechts een klein gedeelte van de opdrachten gebruiken. Naarmate je meer van .NET gebruik gaat maken, ga je mogelijk steeds meer opdrachten van verschillende categorieën gebruiken.

Om te onthouden wat de opdrachten doen, is het handig om ze te beschouwen als behorend bij categorieën:

- **Afhankelijkheden beheren**. Er zijn opdrachten die te maken hebben met installatie, verwijdering en opschonen na pakketinstallaties. Er zijn ook opdrachten voor het bijwerken van pakketten.
- **Programma’s uitvoeren**. Het .NET Core-hulpprogramma kan je helpen bij het beheren van stromen in je toepassingsontwikkeling. Voorbeelden van stromen voor toepassingen zijn tests uitvoeren, je code compileren en migratieopdrachten uitvoeren voor het upgraden van projecten.
- **Pakketten ontwerpen en publiceren**. Verschillende opdrachten kunnen je helpen bij taken zoals het maken van een gecomprimeerd pakket en het pushen van het pakket naar een register.

Als  een gedetailleerde lijst met alle opdrachten wilt zien, voer je `dotnet --help` in de terminal in.

### Een pakket installeren

Je gebruikt de `dotnet add package <dependency name>`-opdracht voor het installeren van een normale afhankelijkheid die bedoeld is om te worden gebruikt als onderdeel van je toepassing.

 Notitie

Je kan sommige pakketten *globaal* installeren. Deze pakketten zijn niet bedoeld om te worden geïmporteerd in je project. Daarom zijn veel globale pakketten CLI-hulpprogramma's of sjablonen. Je kan deze globale hulpprogramma's ook vanuit een pakketopslagplaats installeren. Installeer hulpprogramma's met behulp van de opdracht `dotnet tool install <name of package>`. Installeer sjablonen met behulp van de opdracht `dotnet new -i <name of package>`.

### Na de installatie

De geïnstalleerde pakketten worden weergegeven in de sectie `dependencies` van je .csproj-bestand. Als je wilt weten welke pakketten zich in de map bevinden, kan je `dotnet list package` invoeren.

```output
Project 'DotNetDependencies' has the following package references
   [net5.0]:
   Top-level Package      Requested   Resolved
   > Humanizer            2.7.9       2.7.9
```

Met deze opdracht worden alleen de pakketten op het hoogste niveau vermeld, en niet de afhankelijkheden van zogenaamde *transitieve pakketten*. Dit is handig voor een snelle weergave. Als je een uitgebreidere weergave wilt, kan je alle transitieve pakketten weergeven. Wanneer je dit doet, ziet de `list`-opdracht er als volgt uit:

```dotnetcli
dotnet list package --include-transitive
```

Door transitieve pakketten op te nemen kan je afhankelijkheden weergeven samen met alle pakketten die je hebt geïnstalleerd. Als je `dotnet list package --include-transitive` uitvoert, zie je mogelijk de volgende uitvoer:

```output
Project 'DotNetDependencies' has the following package references
   [net5.0]:
   Top-level Package      Requested   Resolved
   > Humanizer            2.7.9       2.7.9

   Transitive Package               Resolved
   > Humanizer.Core                 2.7.9
   > Humanizer.Core.af              2.7.9
   > Humanizer.Core.ar              2.7.9
   > Humanizer.Core.bg              2.7.9
   > Humanizer.Core.bn-BD           2.7.9
   > Humanizer.Core.cs              2.7.9
   ...
```

## Afhankelijkheden herstellen

Wanneer je een project maakt of kloont, worden de opgenomen afhankelijkheden pas gedownload of geïnstalleerd wanneer je je project compileert. Je kan afhankelijkheden en projectgerelateerde hulpprogramma's die zijn opgegeven in het projectbestand handmatig herstellen met de opdracht `dotnet restore`. In de meeste gevallen hoef je de opdracht niet expliciet te gebruiken. NuGet restore wordt zo nodig impliciet uitgevoerd wanneer je opdrachten als `new`, `build` en `run`uitvoert.

## Afhankelijkheden opschonen

Op een gegeven moment zal je zich waarschijnlijk realiseren dat je een bepaald pakket niet meer nodig hebt. Het is ook mogelijk dat het pakket dat je hebt geïnstalleerd, niet het pakket is dat je nodig hebt. Misschien hebt je er een gevonden waarmee je de taak beter kunt uitvoeren. Wat de reden ook is, afhankelijkheden die je niet gebruikt kan je het beste verwijderen. Op die manier houd je het overzicht. Afhankelijkheden nemen ook ruimte in beslag.

Als je een pakket uit je project wilt verwijderen, gebruik je de opdracht `remove` als volgt: `dotnet remove <name of dependency>`. Met deze opdracht wordt het pakket verwijderd uit het .csproj-bestand voor je project.