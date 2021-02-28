# UDP versus TCP

![TCP versus UDP](./Documents/tcp_udp.jpg "TCP versus UDP")

TCP, UDP, netwerkprotocollen, databits: de kans is groot dat deze termen je niets zeggen als je geen ICT-expert bent. Toch is het handig om te weten wat deze termen betekenen. Wanneer je surft op het internet, je e-mail gebruikt of bestanden verzendt, maak je gebruik van TCP. Beschikbaarheid van servers en streaming zoals een live video bekijken zijn enkele toepassingen van UDP. 

TCP staat voor Transmission Control Protocol. Het is een veelgebruikt protocol. Hiermee worden gegevens overgedragen op het internet via netwerkverbindingen, maar ook op computernetwerken. TCP kan gegevens in een datastroom versturen, wat betekent dat deze gegevens gegarandeerd aankomen op hun bestemming. Communicatiefouten worden daarnaast ook opgevangen. TCP wordt niet alleen gebruikt voor verkeer op het internet, maar ook voor het downloaden en streamen van video’s.

Hoe werkt TCP? Wanneer je vanaf jouw computer op een link van een website klikt, stuurt de browser zogenaamde TCP packets naar de server van de betreffende website. De server van de website stuurt ook weer TCP packets terug. De packets krijgen een getal, waardoor de ontvanger deze packets in de juiste volgorde krijgt. Behalve het sturen van de packets controleert TCP deze data ook. De server stuurt dan bericht naar de verzender om de ontvangst van packets te bevestigen. Bij een onjuist antwoord worden de packets opnieuw gestuurd.

![TCP](./Documents/TCP_vs_UDP_01.gif "TCP")

UDP staat voor User Datagram Protocol. Dit is een bericht-georiënteerd protocol. Dit wil zeggen dat een verzender een bericht stuurt aan de ontvanger, net als bij het TCP protocol. Het verschil met TCP is echter dat de ontvanger bij UDP geen bevestiging stuurt naar de verzender. Dit betekent dat UDP vooral geschikt is voor eenrichtingscommunicatie, waarbij het verlies van enige data geen probleem vormt. Het UDP protocol wordt vooral gebruikt bij live streaming en online gaming.

UDP is sneller dan TCP, omdat het geen controles uitvoert en geen tweerichtingsverkeer is. Dit betekent echter wel dat UDP minder betrouwbaar is dan TCP als het gaat om het versturen van data.

![UDP](./Documents/TCP_vs_UDP_02.gif "UDP")

Wanneer gebruik je TCP en wanneer gebruik je UDP? TCP wordt vaak gebruikt wanneer er sprake is van een belangrijke overdracht van informatie. Denk hierbij aan het versturen van een bestand van de ene naar de andere computer. Het gaat hierbij niet om de snelheid, maar om de accuratesse waarmee een bestand wordt verstuurd. UDP wordt vooral gebruik wanneer snelheid boven veiligheid en accuratesse gaat. Een 100% foutloze verbinding is in dit geval niet noodzakelijk. Denk hierbij aan het streamen van een live video of online gaming. Kort gezegd draait het bij TCP om nauwkeurigheid en bij UDP om snelheid. Wil je een beide gevallen verzekerd zijn van een veilige verbinding? Gebruik dan een Virtual Private Network (VPN). Een VPN versleutelt je connectie, terwijl de snelheid op peil blijft.

UDP vs. TCP: wat zijn de belangrijkste verschillen tussen deze twee? In de eerste plaats gaat het om de manier waarop gegevens en data uitgewisseld worden. Toch zijn er nog meer verschillen zichtbaar. Hier vind je een overzicht van deze verschillen in een overzichtelijke tabel:

![TCP](./Documents/tcp-upd_infographic.png "TCP")

TCP zorgt gegarandeerd voor een betrouwbare maar ook een geordende levering van gegevens van de gebruiker naar de server en andersom. UDP is niet bedoeld voor end-to-end verbindingen en communicatie en controleert de gereedheid van de ontvanger niet. Verschillen:

### 1: Betrouwbaarheid

Wanneer je verzekerd wil zijn van een betrouwbare overdracht van informatie, kan je het beste TCP gebruiken. Waarom is TCP betrouwbaarder? Hier worden bericht-bevestiging en hertransmissies beheert wanneer er sprake is van verloren onderdelen. Er zullen dus nooit gegevens ontbreken. Bij UDP heb je nooit de zekerheid of de communicatie de ontvanger heeft bereikt. Concepten van bevestiging, hertransmissie en time-out zijn niet aanwezig.

### 2: Ordening van pakketten

Bij TCP overdrachten is er altijd sprake van een bepaalde volgorde. De data wordt in een bepaalde reeks naar de server verzonden, en kom in dezelfde volgorde terug. Komen bepaalde gegevens in de verkeerde volgorde aan? Dan herstelt TCP dat en verstuurt de data opnieuw. Bij UDP is er geen sprake van een volgorde. Van te voren kun je dan ook niet voorspellen in welke volgorde de gegevens worden ontvangen.

### 3: Verbinding

Bij TCP is een zwaargewicht verbinding die drie pakketten vereist voor een zogenaamde socket-verbinding. Een socket-verbinding wordt toegepast wanneer een verbinding met een andere host tot stand wordt gebracht. Een socket bestaat altijd uit een IP-adres. Deze verbinding zorgt bij TCP voor betrouwbaarheid. UDP is een lichtgewicht transportlaag, gecreëerd op een IP. Volgverbindingen of het ordenen van gegevens is dan ook niet mogelijk.

### 4: Foutencontrole

TCP gebruikt niet alleen foutencontrole, maar ook foutenherstel. Fouten worden gedetecteerd door middel van een controle. Is een pakket foutief? Dan wordt het niet door de ontvanger bevestigd. Daarna is er sprake van een hertransmissie door de verzender. Dit mechanisme wordt ook wel Positive Acknowledgement with Retransmission (PAR) genoemd.

UDP werkt op basis van best-effort. Dit betekent dat het protocol foutdetectie wel ondersteunt, maar er niets mee doet. Een fout kan worden gedetecteerd, maar daarna wordt het pakket genegeerd. Er wordt niet geprobeerd om het pakket opnieuw te verzenden om de fout te herstellen zoals dat bij TCP wel het geval is. Dit komt omdat UDP vooral wordt gebruikt voor de snelheid.

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

![Schermopname van NuGet.org met een lijst met populaire pakketten.](./Documents/finding-nuget.png)

Pakketten kunnen zich op verschillende locaties bevinden. Sommige van deze bronnen zijn mogelijk openbaar beschikbaar. Sommige zijn mogelijk beperkt en alleen beschikbaar voor werknemers van een specifiek bedrijf. Hier volgen enkele plaatsen waar pakketten zich kunnen bevinden:

- **Registers**. Een voorbeeld kan een globaal register zijn, zoals het NuGet.org-register. Je kan je eigen registers hosten. Deze kunnen privé of openbaar zijn. Services zoals GitHub en Azure DevOps stellen persoonlijke registers beschikbaar.
- **Bestanden**. Je kan een pakket installeren vanuit een lokale map. Installeren vanuit een pakket komt vaak voor als je je eigen .NET-bibliotheken wilt ontwikkelen en het pakket lokaal wilt testen, of als je om een of andere reden geen register wilt gebruiken.

![Diagram waarin de relatie tussen pakketmakers, pakkethosts en pakketconsumenten wordt aangegeven.](./Documents/nuget-roles.png)

### NuGet-register en dotnet-hulpprogramma

Wanneer je `dotnet add package <name of dependency>` uitvoert, gaat .NET naar een globaal register met de naam NuGet.org-register en zoekt daar naar de code die je wilt downloaden. Deze bevindt zich op `https://nuget.org`. Je kan hier ook bladeren naar pakketten als je de pagina bezoekt via een browser. Elk pakket heeft een toegewezen website die je kan bezoeken.

![Schermafbeelding van de landingspagina voor een NuGet-pakket.](./Documents/nuget-info.png)

Op deze sites kan je meer informatie vinden over waar de broncode zich bevindt. Je kan ook informatie vinden zoals metrische gegevens over downloads en informatie over onderhoud.

![Schermopname van informatie en metrische gegevens voor een NuGet-pakket.](./Documents/nuget-downloads.png)

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

# Client-server chat programma

We maken een klein , eenvoudige applicatie zodat meerdere clients berichten naar de server kunnen sturen. We gaan hiervoor gebruik maken van een bestaande Nuget-Bibliotheek `SimpleTcp`

Voer volgende stappen uit:

1. Maak een nieuwe solution aan en voeg 2 projecten toe, 1 voor de client, 1 voor de server.
2. Voeg aan ieder project de SimpleTc Nuget-bibliotheek toe als volgt:
   1. Rechterklik op je project (in solution explorer)
   2. Kies "Manage nuget packages..."
   3. Klik op "Browse" in het nieuw verschenen scherm
   4. Zoek naar `SimpleTcp`
   5. Klik op de eerste hit (die van BrandonPotter) en kies rechts op "Install"
3. Als alles goed is verlopen zie je bij de references in beide projecten nu ook `SimpleTcp` staan.
4. Voeg in iedere Program.cs bovenaan `using SimpleTCP;` toe
5. Profit!

# Beide projecten starten

Om je programma de komende tijd te testen wil je uiteraard steeds dat er minstens 1 server en 1 client loopt. We gaan dit als volgt doen:

1. Rechterklik op je solution (in solution explorer)
2. Kies "Properties"
3. Ga naar "Startup Project" onder de "Common properties"
4. Selecteer "Multiple startup project"
5. Verander de action van beide projecten naar "Start"
6. Zorg ervoor dat je server-project eerst start: indien nodig klik je op het pijltje omhoog zodat die bovenaan staat

Als je nu je programma start (F5) of debugt dan zullen steeds beide projecten uitgevoerd worden.

# Server-code

Telkens de server een string krijgt die eindigt op een enter zal de server deze boodschap op het scherm tonen. Om te voorkomen dat de server afsluit van zodra hij lijn 2 heeft uitgevoerd plaatsen we een ``ReadLine```achteraan. Op die manier zal de server blijven reageren op events tot de gebruiker op enter duwt om alles af te sluiten:

```csharp
static void Main(string[] args)
{
    var server = new SimpleTCP.SimpleTcpServer().Start(1111);
    server.DelimiterDataReceived += Server_DelimiterDataReceived;
    Console.ReadLine();
}

private static void Server_DelimiterDataReceived(object sender, SimpleTCP.Message e)
{
    Console.WriteLine( e.MessageString);
}
```

# Client-code

```csharp
static void Main(string[] args)
{
    var client = new SimpleTcpClient().Connect("127.0.0.1", 1111);
    while (true)
    {
        string msg = Console.ReadLine();
        client.WriteLine(msg);
    }
}
```

Je kan nu meerdere clients tegelijk starten. Zolang ze allemaal maar op dezelfde poort (1111 in dit geval) verbinden kunnen ze berichten naar de server sturen.

# En nu jij...

SimpleTcp is een leuke bibliotheek, die veel meer kan. [Hier](https://github.com/BrandonPotter/SimpleTCP) zie je enkele ideeën. Het grootste probleem van deze bibliotheek is het gebrek aan deftige documentatie. Kan je zelf een eenvoudig chat programma maken waarbij meerdere clients alle berichten van mekaar zien die ze naar de server sturen (een soort [IRC](https://en.wikipedia.org/wiki/Internet_Relay_Chat))?