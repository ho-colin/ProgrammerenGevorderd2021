# Programmeren Gevorderd 2021

## Vooraf: Tien Geboden

* [YouTube](https://www.youtube.com/watch?v=tNBln0tv6oE&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=5&t=72s)
* Kort:
  * VS 2019 Enterprise 16.7.4 en hoger
  * .NET Core 3.1 C#
  * Gebruik het unit testing framework en geen console app, tenzij anders gevraagd
  * Een bestand per klasse
  * Method volledig zichtbaar op je VS scherm
  * Unit testing code coverage: >= 80%
  * Voorzie je code van zinvolle commentaar

## Object oriented programming

* [OOP](./OOP.md)
* [Objecten](./Objecten.md)
* [Overerving](./Overerving.md)
* [System.Object](./SystemObject.md)
* [Compositie](./Compositie.md)
* [UML naar code](./UMLNaarCode.md)
* [Polymorfisme](./Polymorfisme.md)
* [Interfaces](./Interfaces1.md)
* [Exception handling](./ExceptionHandling.md)
* [Generics](./Generics.md)
* [Abstracte klassen](./AbstracteKlassen.md)
* [Begeleide oefening:](./PG_OObasics_oef1_v2.pdf)

# Unit testing

* Video:
  * [Business code en test assemblies](https://www.youtube.com/watch?v=ayJYhxs4e6I&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=6&t=151s)
  * [Code quality](https://www.youtube.com/watch?v=WAVBJhTV4Ms&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=7)
  * [Running and debugging tests](https://www.youtube.com/watch?v=tKhnw61JC6U&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=8)
  * [Test logger](https://www.youtube.com/watch?v=mSJ3up_2Ecs&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=9)
  * [Assembly dependencies](https://www.youtube.com/watch?v=pDinrXTXoI8&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=10)
  * [Unit testing snippets](https://www.youtube.com/watch?v=3pyTcAzONMw&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=11&t=39s)
* [Inleiding](./UnitTestingIntro.pdf)
* [TDD](./UnitTestingTDD.pdf)
* [AAA](UnitTestingAAA.pdf)
* [Test methods: beknopt overzicht](./UnitTestingTestMethods.pdf)
* [Bank account walkthrough: TDD](./UnitTestingWalkthrough.pdf)

# Git



# Herhalingsoefening



# SOLID

## Inleiding

Software ontwikkelaars worden geconfronteerd met ontwerpproblemen. Professionals zullen echter merken dat bepaalde soorten van ontwerpproblemen steeds terugkomen. Eénmaal je een probleem herkent als een variant van een probleem dat je vroeger al eens hebt opgelost, kan je gebruik maken van de inzichten die je al verworven hebt. Je ziet bepaalde patronen terugkeren.

### Wat is nu precies een ontwerppatroon of design pattern

> Een ontwerppatroon is een standaardoplossing voor een vaak voorkomend ontwerpprobleem. Deze patronen zijn belangrijk omdat ze je de moeite kunnen besparen om telkens opnieuw het warm water uit te vinden. Bovendien heeft elk patroon een eigen naam, wat ervoor zorgt dat het heel eenvoudig wordt om bepaalde complexe ideeën in een oogwenk te communiceren aan een andere programmeur.

## Geschiedenis van het ontwerpen

Sinds het begin van het computertijdperk is probleem-oplossend denken ingrijpend veranderd.

### Programmeren: the sequel

In het begin programmeerden we met assembly, en was elk programma beperkt tot een honderdtal lijnen. Elke programmeur had zijn eigen stijl volgens intuïtie.

### Programmeren: flow based

Toen de complexiteit toenam, gingen meerdere programmeurs code reviews verrichten bij elkaar en merkte men al dat onderhoud en begrijpen van code niet voor de hand lag. Men trachtte normen op te leggen en ging flowcharts maken om programmeurs een goed design te laten maken. Flowcharts bleken ook nuttig om programma’s eenvoudiger te begrijpen.

### Programmeren: gestructureerd

Gestructureerd programmeren volgde in de jaren ‘70. Een gestructureerde code bestaat uit één enkel begin en afsluitpunt en daar tussen een set van modules. Gestructureerde programma’s zijn makkelijker te lezen en te begrijpen, te onderhouden en vereisen minder ontwikkel-tijd.

### Programmeren: object oriented

Object-georiënteerd programmeren gebeurt intuïtief en identificeert natuurlijke objecten ( Hero, vijand, ...) die voorkomen in je probleem. Daarnaast worden relaties zoals composities, referenties, overerving bepaald. Dit resulteert in herbruikbaarheid van code, en overzichtelijkere en makkelijk te onderhouden code.

### Vandaag...

Door de toenemende concurrentie moet je als programmeur tegenwoordig zeer dynamisch (Agile Principe) zijn. Ook is de gemiddelde levensduur van een product drastisch verlaagd. Organisaties moeten snel op marktveranderingen kunnen antwoorden. Ook worden business strategieën snel aangepast wat wil zeggen dat bijvoorbeeld een goed software design zeer belangrijk is om snel op deze veranderingen in te kunnen inspelen. Software moet snel ontwikkeld kunnen worden en staat dicht bij de klant ( deze kan al vaak worden betrokken bij de ontwikkeling van gepersonaliseerde software).

#### Object oriented

De basisgedachte achter object georiënteerd programmeren is dat mensen een beetje van de realiteit proberen te modelleren zodat het model in de vorm van een werkend programma kan worden gegoten. Je kan je object model beschouwen als een blackbox. Bijvoorbeeld een auto als blackbox betekent dat je een handvol pedalen, schakelaars hebt die fungeren als interface. Duwen op de rem betekent dat je auto mindert, maar je hoeft niet te weten hoe dat gebeurt, enkel maar wat er gebeurt. Dit principe heet encapsulatie.

> Encapsulatie: je probeert zoveel mogelijk zaken af te schermen van de rest.

Bijvoorbeeld een auto kan starten, maar je weet niet wat er allemaal moet gebeuren om de auto te starten. Dit noemen we een interface.

#### Klassen en objecten

> Klasse: een beschrijving en verzameling van dingen (objecten) met soortgelijke eigenschappen
>
> Object: een instantie van een klasse

Als voorbeeld kunnen we een auto nemen.Een auto catalogeren we als een klasse, want bestaat uit een aantal eigenschappen, zoals de kleur van de auto, het aantal pk, benzine of diesel motor, enzovoort. Maar ook het starten, stoppen, schakelen van de wagen worden als eigenschappen bezien.

Een object betekent bijvoorbeeld een nieuwe renault met een rode kleur, 100pk en dieselmotor.

De auto is de klasse die beschrijft hoe een auto er voor onze probleemstelling moet uit zien, terwijl de renault een instantie van de klasse is, of ook wel object genoemd. Wat betekent dat dit een effectieve auto is die je kan gebruiken.

## Hoe maak je een klasse

Een klasse kan bestaan uit:

- private member variabelen: bepalen de toestand van de klasse
- constructor
- public methoden: aanspreekpunten voor de buitenwereld, of interfaces genoemd
- properties: een gecontroleerde toegang tot de toestand
- private methoden: hulpmethoden die enkel beschikbaar zijn binnen het object

## SOLID

S.O.L.I.D. zijn 5 principes die ons helpen om een goede software architectuur te schrijven (door Robert C. Martin)

- [S : SRP (Single responsibility principle)](./SolidSRP.md)
- [O : OCP (Open closed principle)](./SolidOCP.md)
- [L : LSP (Liskov substitution principle)](./SolidLSP.md)
- [I : ISP (Interface segregation principle)](./SolidISP.md)
- [D : DIP (Dependency inversion principle)](./SolidDIP.md)

# Nuttige extra's

# Boeken

Er zijn quasi oneindig veel boeken over C# geschreven, althans zo lijkt het. Hier een selectie van boeken met een korte bespreking waarom ik denk dat ze voor jou een meerwaarde kunnen zijn bij het leren programmeren in C#:

## Beginner boeken

- [C# Programming](https://ineasysteps.com/products-page/all_books/c-sharp-programming-in-easy-steps/) van Mike McGrath: een uiterst compact, maar zeer helder en kleurrijk boekje dat ik ten stelligste aanbeveel als je wat last hebt met de materie van de eerste weken.
- [Microsoft Visual C# 2015: An introduction to OOP](https://www.amazon.com/Microsoft-Visual-2015-Introduction-Object-Oriented/dp/1285860233) van Joyce Farrell: Niet het meest sexy boek, maar wel het meest volledige qua overlap met de leerstof van deze cursus. Aanrader voor zij die wat meer in detail willen gaan en op zoek zijn naar oneindig veel potentiele examenvragen ;)
- [Head First C#](https://www.bol.com/nl/f/head-first-c/37019965/?country=BE) van Andrew Stellman & Jennifer Greene: laat de ietwat bizarre, bijna kleuterachtige look and feel van de head first boeken je niet afschrikken. Ieder boek in deze serie is goud waar. De head first boeken zijn de ideale manier als je zoekt naar een alternatieve manier om complexe materie te begrijpen. Bekijk zeker ook de Head First Design Patterns en Head First Sql boeken in de reeks!

## Geavanceerd

- [C# Unleashed](https://www.bol.com/nl/f/c-5-0-unleashed/9200000009902560/?country=BE) van Bart De Smet: in mijn opinie dé referentie om C# tot op het bot te begrijpen. Geschreven door een Belg die bij Microsoft in Redmond aan C# werkt.
- [Code Complete](https://www.amazon.de/Code-Complete-Practical-Construction-Costruction/dp/0735619670) van Steve McConnell: een referentiewerk over 'programmeren in het algemeen'. Het boek is al jaar en dag het te lezen boek als je je als programmeur wilt verdiepen in wat nu 'correct programmeren' behelst. Als je op je CV kunt zetten dat je dit boek door en door kent dan zal elk IT-bedrijf je stante pede aannemen ;)

## Game-based programmeren

Ideale manier om programmeren meer in de vingers te krijgen op een speelse manier:

### Apps

- [SoloLearn](https://play.google.com/store/apps/details?id=com.sololearn): Verplichte app! Simple as that!
- [Enki](https://play.google.com/store/apps/details?id=com.enki.insights&hl=en) Net zoals SoloLearn maar dan anders.
- [Memrise](https://www.memrise.com/course/700046/learn-c/) (aanrader!) Origineel vooral bedoeld om spreektalen te leren, maar bevat ook tal van andere zaken. Hoofdzakelijk nuttig om nieuwe aspecten te 'drillen'. Enkel dus nuttig indien je de basismaterie eerst hebt verwerkt. Bekijk zeker ook de tal van andere cursussen die er staan. Let er op dat je bij de filter Engels instelt, er zijn nog niet veel (goede) Nederlandstalige C# cursussen naar mijn weten. **Opgelet: je kan je enkel via de browser inschrijven op niet-spreektaal-cursussen. De app toont enkel spreektaalcursussen**.
- [Mimo](https://play.google.com/store/apps/details?id=com.getmimo) Speels en vrij beperkt in gratis versie, maar ideale aanvulling op SoloLearn.
- [Screeps](https://screeps.com/) Een steam spel om te leren programmeren. Weliswaar Javascript (nuttig voor Web Programming) maar het concept is te cool om niet hier te vermelden en zoals je zal ontdekken: leren programmeren kan je in eender welke taal, en het zal ook je andere programmeer-ervaring verbeteren. Give it a go!

### Websites

- [Exercism](https://exercism.io/tracks/csharp)
- [Coding game](https://www.codingame.com/start) zeer vet
- [Code Combat](https://codecombat.com/)
- [Pex For Fun](https://pexforfun.com/) (specifiek voor C#!)
- [Code Academy](https://www.codecademy.com/)
- [RPG Game in C#](http://scottlilly.com/learn-c-by-building-a-simple-rpg-index/) (behandelt leerstof van volledig eerste jaar en meer)
- [Advent of code](https://adventofcode.com/) Pittige programmeeroefeningen die jaarlijks in december verschijnen.
- [Free Programming Book](https://books.goalkicker.com/) Handig vorm gegeven gratis ebooks met tal van onderwerpen waaronder ook C# en het .NET Framework.
- [Tutorials teacher](https://www.tutorialsteacher.com/csharp/csharp-tutorials): De uitgebreidere, Engelstalige variant van deze cursus zeg maar.

## Tutorials

- [Dotnet beginning](http://dot.net/videos)
- [C# Getting started interactive quickstart tutorials](https://docs.microsoft.com/en-us/dotnet/csharp/quick-starts/): Aanrader.
- [Online video c# cursus](https://channel9.msdn.com/Series/C-Sharp-Fundamentals-Development-for-Absolute-Beginners): Zeer aan te raden indien je een bepaald concept uit de les niet begrijpt.
- [C-sharp.be](http://www.c-sharp.be/) : Nederlandstalige cursus met veel toffe oefeningen waarvan je sommige zelfs in deze cursus zal terugvinden.
- [Microsoft Virtual Academy](https://mva.microsoft.com/en-us/training-courses/c-fundamentals-for-absolute-beginners-16169?l=Lvld4EQIC_2706218949): Microsoft heeft een virtual academy cursus "C# fundamentals" uitgebracht. Ik kan deze cursus zeer erg aanbevelen.
- [Rob Miles's The C# Programming Yellow book](http://www.robmiles.com/c-yellow-book/): Zeer vermakelijk, vlot geschreven C# boek(je)
- [Open Source Game Clones](https://osgameclones.com/): "This site tries to gather open-source remakes of great old games in one place." Je vindt er ook tal van C# projecten terug zoals [GTA 2](https://code.google.com/archive/p/gta2net/).Klik bovenaan op "languages" en filter maar eens op C#.

## Streaming programmeurs

Ja hoor, ze bestaan. Meer en meer professionele én beginnende programmeurs streamen terwijl te programmeren. Dit is een ideale manier om te zien hoe andere mensen problemen aanpakken. De meeste programming streamers kan je terugvinden op youtube, maar ook op Twitch zijn er steeds meer. Enkele aanraders (bekijk zeker de filmpjes uit de archieven eens):

- [Handmade Hero](https://handmadehero.org/watch#EpisodeGuide): deze programmeur heeft een volledige RPG gemaakt en het hele proces gestreamd.
- [CSharpFrits](http://youtube.com/csharpfritz)
- [DevChatter](https://www.twitch.tv/devchatter)
- [Visual Studio Twitch](https://www.twitch.tv/visualstudio)
- [NoopKat](https://www.twitch.tv/noopkat)
- [The Coding train](https://www.youtube.com/channel/UCvjgXvBlbQiydffZU7m1_aw)