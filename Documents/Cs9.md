**Wat is nieuw?**

C# is aanbeland bij versie 9.0. Elke versie brengt nieuwe features en verbeteringen met zich mee. De 4 meest interessante veranderingen voor je op een rij.

- Init only setters
- Verbeteringen in verband met het new keyword
- Top-level statements
- Er zijn verder ook andere toffe verbeteringen, zoals records en verbeterde pattern matching. 

**Init only setters**

Init only setters maken het makkelijker om het instantiëren van een object wat "correcter" neer te zetten. Een goed voorbeeld is deze situatie.

In veel projecten maak je gebruik van DTO's. Dit zijn Data Transfer Objects, en zijn eigenlijk types die je gebruikt om data door te geven aan een andere laag van je applicatie. Deze DTO's kunnen vaak redelijk wat properties bevatten. Om zo'n type op een makkelijke manier te instantiëren kun je op dit moment twee dingen doen. 1) Je gebruikt een constructor. 2) Je gebruikt Object initializers, ook wel bekend als de properties, om het object aan te maken. Het gebruik van constructors bij klasse met veel properties brengt een aantal nadelen met zich mee. Deze zijn algemeen bekend. 

Stel we hebben de volgende DTO:

![img](https://www.arcady.nl/media/1943/schermafbeelding-2020-12-02-om-103149.png?width=500&height=206.10446821900567)

Er zijn wat nadelen met deze aanpak. Bijvoorbeeld dat je je properties hierna nog mag wijzigen door bijvoorbeeld **userDto.Voornaam = achternaam**; kan typen. Dit is niet gewenst; zo'n DTO maak je een keer aan en geef je door; je wilt properties niet meer wijzigen.

**Init only setters** helpen je hierbij met de volgende syntax:

![img](https://www.arcady.nl/media/1944/schermafbeelding-2020-12-02-om-103320.png?width=500&height=91.7981072555205)![img](https://www.arcady.nl/media/1944/schermafbeelding-2020-12-02-om-103320.png)

Wanneer je nu een instantie hebt van het **UserDto** type en je probeert Voornaam te wijzigen

**userDto.Voornaam = achternaam;**

Dan zal je een error krijgen van de compiler. Je mag de property namelijk slechts één keer setten en dat is tijdens het instantiëren van het object.

*Init only setters* bieden consistente syntax om leden van een onderwerp te initialiseren. *Property initializers* maken duidelijk welke waarde welke *property* plaatst. Het nadeel is dat die *properties* instelbaar moeten zijn. Door C# 9.0 te gebruiken kun je init *accessors* in plaats van set *accessors* voor *properties* en *indexers* maken. Developers kunnen de *property initializer syntax* gebruiken om waardes in *creation expressions* te zetten, maar die *properties* zijn *readonly* wanneer de bouw voltooid is. *Init only setters* bieden een venster om de staat te veranderen. Dat venster sluit wanneer de bouwfase eindigt. De bouwfase eindigt na alle initialisatie, hierbij horen ook *property initializers* en *with-expressions* die voltooid zijn.

Je kunt init *only setters* in elke type die je schrijft vaststellen. Bijvoorbeeld de volgende *struct*, deze definieert een weer observatie structuur:

![img](https://www.partech.nl/publication-image/%7B4DE42283-D40F-4D13-9610-E58A5EB57C6A%7D)

Developers kunnen de *property initializer syntax* gebruiken om waarden in te stellen terwijl ze de onveranderlijkheid kunnen behouden:

![img](https://www.partech.nl/publication-image/%7B983B4726-CC74-4852-BF53-F540597AAEC6%7D)

Maar het veranderen van een observatie na het initialiseren geeft een error door het toewijzen aan een *init-only property* buiten het initialiseren:

![img](https://www.partech.nl/publication-image/%7BF7522480-D76F-4EA3-8C4B-479B5089A00B%7D)

*Init only setters* kunnen bruikbaar zijn om *base class properties* van afgeleide *classes* in te stellen. Ze kunnen ook afgeleide *properties* door helpers in een *base class* instellen. Positionele *records* stellen *properties* door het gebruik van *init only setters* vast. Die *setters* worden gebruikt in *with-expressions*. Je kunt *init only setters* vaststellen voor elke class of struct die je definieert.

### RECORD TYPES

C# 9.0 introduceert *record* types, wat een referentie type is die zorgt voor gesynthetiseerde methodes om waarde *semantics* voor gelijkheid beschikbaar te maken. *Records* zijn standaard onveranderlijk.

*Record types* maken het makkelijk om onveranderlijke referentie types te maken in .NET. Vroeger waren .NET types grotendeels geclassificeerd als referentie types (hierbij horen *classes* en anonieme types) en waarde types (hierbij horen *structs* en *tuples*). Terwijl onveranderlijke waarde types aanbevolen zijn, komen er vaak geen errors van veranderlijke waarde types. Variabelen die waarde types zijn houden de waarden, dus veranderingen worden gemaakt naar een kopie van de originele data wanneer waarde types doorgezet worden naar methoden.

Ook zijn er veel voordelen voor het gebruik van onveranderlijke referentie types. Deze voordelen zijn meer uitgesproken in andere programma’s met gedeelde data. Helaas dwong C# je ertoe om meer extra codering te schrijven om een onveranderlijk referentie type te maken. *Records* bieden een typverklaring voor een onveranderlijk referentie type die gebruik maakt van waarde *semantics* voor gelijkheid. De gesynthetiseerde methoden voor gelijkheid en *hash codes* beoordelen twee *records* als gelijk wanneer hun *properties* allemaal gelijk zijn. Neem deze definitie:

![img](https://www.partech.nl/publication-image/%7BCD20A9F5-F5DD-41E6-A264-0DDF4ED4E4A2%7D)

De *record* definitie maakt een Person type dat twee *readonly properties* bevat: FirstName en LastName. De Person type is een referentie type. Wanneer je naar de *IL* kijkt is het een *class*. Het is onveranderlijk in het feit dat geen van de *properties* gemodificeerd kunnen worden wanneer het gemaakt is. Wanneer je een *record* type definieert synthetiseert de *compiler* verschillende andere methoden voor je:

- Methoden voor waarde gebaseerde gelijkheidsvergelijkingen
- Overschrijven voor *GetHashCode()*
- Kopiëren en klonen van leden
- PrintMembers en *ToString()*

*Records* ondersteunen *inheritance*. Je kunt een nieuwe *record* afgeleid van Person vaststellen:

![img](https://www.partech.nl/publication-image/%7BD76DE16F-A261-434D-A945-E664DF07AD68%7D)

Je kunt ook *records* afsluiten om verdere afleidingen te voorkomen:

![img](https://www.partech.nl/publication-image/%7B12E76194-05D0-45E6-BF23-ABC9DE94A4EC%7D)

De *compiler* synthetiseert verschillende versies van de methoden hierboven. De methode signaturen hangen af van het feit of de *record* type afgesloten is en of de directe *base class* onderwerp is. *Records* moeten de volgende mogelijkheden hebben:

- Gelijkheid is waarde gebaseerd en omvat een check dat de types matchen. Een Student kan bijvoorbeeld niet gelijk zijn aan een Person, zelfs als de twee *records* dezelfde naam delen.
- *Records* hebben een consistente *string* representatie aangemaakt voor jou.
- *Records* ondersteunen kopieer constructie. Een goede kopieer constructie moet *inheritance* hiërarchieën bevatten en *properties* toegevoegd door developers.
- *Records* kunnen gekopieerd worden met modificatie. Deze kopieer en modificeer operaties ondersteunen non-destructieve verandering.

In aanvulling op de bekende Equals overloads, operator == en operator !=, is de *compiler* synthetiseren een nieuwe EqualityContract *property*. De *property* geeft een Type onderwerp terug dat matcht met de type *record*. Wanneer de *base* type object is dan is de *property* virtual. Wanneer de *base* type een ander *record* type is, dan is de *property* een override. Wanneer de *record* type sealed is, is de *property* ook sealed. De gesynthetiseerde GetHashCode gebruikt de GetHashCode van alle *properties* en velden verklaard in de *base* type en de *record* type. Deze gesynthetiseerde methoden dwingen waarde gebaseerde gelijkheid door *inheritance* hiërarchie. Dat betekent dat een Student nooit gelijk gezien kan worden met een Person met dezelfde naam. De types van de twee *records* moeten matchen evenals alle *properties* tussen de *record* types.

*Records* hebben ook een gesynthetiseerde bouwer en een *’clone’* methode voor het maken van kopieën. De gesynthetiseerde bouwer heeft een enkele parameter van de *record* type. Het produceert een nieuwe *record* met dezelfde waarden voor alle *properties* van de *record*. Deze bouwer is privé wanneer de *record* gesloten is, anders is het beschermd. De gesynthetiseerde *‘clone’* methode ondersteunt kopieer constructie voor *record* hiërarchieën. De term *‘clone’* is tussen haakjes omdat de daadwerkelijke naam is gegenereerd door de *compiler*. Je kunt geen methode maken genaamd Clone in een *record* type. De gesynthetiseerde *‘clone’* methode geeft de type *record* terug wanneer hij gekopieerd is door het gebruik van virtuele verzending. De *compiler* voegt verschillende *modifiers* toe voor de *‘clone’* methode afhankelijk van de toegankelijkheid *modifiers* op de record:

- Wanneer de *record* type abstract is, is de *‘clone’* methode ook abstract. Wanneer de *base* type niet object is, is de methode ook override.
- Voor *record* types die niet abstract zijn wanneer de *base* type object is:
  - Wanneer de *record* sealed is, worden geen additionele *modifiers* toegevoegd aan de *‘clone’* methode (dit betekent dat het niet virtual is).
  - Wanneer de *record* sealed is, is de *‘clone’* methode virtual.
- Voor *record* types die niet abstract zijn wanneer de *base* type niet object is:
  - Wanneer de record sealed is, is de *‘clone’* methode ook sealed.
  - Wanneer de record niet sealed is, is de *‘clone’* methode override.

Het resultaat van al deze regels is dat de gelijkheid consistent is geïmplementeerd door elke hiërarchie van *record* types. Twee *records* zijn gelijk aan elkaar als hun *properties* gelijk zijn en hun types gelijk zijn, zoals in het volgende voorbeeld:

![img](https://www.partech.nl/publication-image/%7B4FF27DEF-AFCD-4DE2-A485-8195E2FAE18A%7D)

De *compiler* synthetiseert twee methoden die geprinte output ondersteunen: een *ToString()* *override* en PrintMembers. De Printmembers pakt een *System.Text.StringBuilder* als zijn argument. Het voegt een door komma gescheiden lijst van *property* namen toe en waarden voor alle *properties* in de *record* type. PrintMembers roept de *base* implementatie op voor elke *record* afgeleid van andere *records*. De *ToString()* *override* geeft de *string* gemaakt door PrintMembers terug. Bijvooorbeeld, de *ToString()* methode voor Student geeft een string terug zoals de volgende code:

![img](https://www.partech.nl/publication-image/%7BD6FDEDC8-055A-4BA5-B5B2-5949CABF370B%7D)

De voorbeelden die tot nu toe voorbij gekomen zijn maken gebruik van traditionele syntax om *properties* vast te stellen. Er is een preciezere vorm genaamd *positional records*. Hier zijn drie *record* types eerder gedefinieerd als positionele *records*:

![img](https://www.partech.nl/publication-image/%7BBE80944D-F2BE-4E71-B3D9-3F871CACFA88%7D)

Deze verklaringen creëren dezelfde functionaliteit als de eerdere versie (met wat extra features). Deze verklaringen eindigen met een puntkomma in plaats van haakjes omdat deze *records* geen additionele methoden toevoegen. Je kunt een *body* toevoegen en omvatten ook elke additionele methoden:

![img](https://www.partech.nl/publication-image/%7B8EAC5BCD-ADFC-4B2F-B179-0CA5F850EE3C%7D)

De *compiler* maakt een Deconstruct methode aan voor positionele *records*. De Deconstruct methode heeft parameters die matchen met de namen van alle publieke *properties* in de *record* type. De Deconstruct methode kan gebruikt worden om de *record* te deconstrueren in zijn component *properties*:

![img](https://www.partech.nl/publication-image/%7B6A0A2DE4-7EF0-4420-86DB-D942EC4BE600%7D)

Tenslotte, worden *with* expressions ondersteund door *records*. Een *with expression* instrueert de *compiler* om een kopie te maken van een *record*. Maar dit met gespecificeerde *properties* gemodificeerd:

![img](https://www.partech.nl/publication-image/%7B13D220AC-9655-4757-BBF0-064AD8475A59%7D)

De vorige regel creëert een nieuwe Person *record* waar de LastName *property* een kopie is van person en de FirstName “Paul” is. Je kunt elk aantal *properties* in een with *expression* vaststellen. Je kunt ook gebruik maken van with *expressions* om een exacte kopie te maken. Je specificeert de lege set voor de *properties* om te modificeren:

![img](https://www.partech.nl/publication-image/%7B6C0F56C5-BED0-4C9A-89CE-B573CC9E7DB5%7D)

Alle gesynthetiseerde leden behalve de *‘clone’* methode kan geschreven zijn door jou. Als een *record* type een methode heeft die de signatuur van welke gesynthetiseerde methode dan ook matcht, synthetiseert de *compiler* die methode niet.



**Verbeteringen voor het new keyword**

Tijdens de aankondiging van deze feature werden er redelijk wat negatieve reacties gegeven. Dit komt omdat er nu een 3de manier is om in je code de objecten aan te maken met het **new** keyword. De eerste manier is door het type expliciet te beschrijven:

**UserRepository repository = new UserRepository ( ) ;**

Dit is simpel genoeg. Het enige probleem met deze aanpak is dat je redelijk wat moet typen. In C# 3 is het **var** keyword geïntroduceerd. Dit maakt het iets makkelijker:

**var repository = new UserRepository ( ) ;**

Tijdens compile-time checkt de compiler het type dat erbij hoort. Als je probeert om het type te wijzigen **(repository = new Dog ( ) ;** ), krijg je een error. Het enige verschil is dus dat je wat minder hoeft te typen. Dit is vooral handig bij code zoals **Dictionary<int,**

**UserState> dictionary = new Dictionary<int, UserState> ( ).** Het is veel makkelijker om de code te lezen. Aan de rechterkant van de expressie zie je al van welk type het object het zal zijn, dus waarom zou je het aan de linkerkant ook vereisen?

Nu, in C# 9 wordt de 3de manier geïntroduceerd... Hou je vast!

**Dictionary<int, UserState> dictionary = new ( ) ;**

Nu denk je misschien: "Wat is het voordeel? Dit is het omgekeerde van het **var** keyword. Nu staat er meer code aan de linkerkant dan aan de rechterkant!". Dit was ook mijn eerste reactie, en ook de reactie van veel andere mensen. Maar wat blijkt, het is eigenlijk een zeer handige toevoeging.

In eerste instantie moest je deze stukken code typen:

![img](https://www.arcady.nl/media/1945/schermafbeelding-2020-12-02-om-104100.png?width=500&height=43.233082706766915)

In dit soort gevallen heb je redelijk veel code die je twee keer moet typen.

Nu nogmaals met het gebruik van **new ( ):**

**![img](https://www.arcady.nl/media/1946/schermafbeelding-2020-12-02-om-104108.png)![img](https://www.arcady.nl/media/1946/schermafbeelding-2020-12-02-om-104108.png?width=500&height=32.88201160541586)**

 

**Top-level statements**

**Top-level statements** maken het een stuk makkelijker voor mensen om te beginnen met C#. Een bestand in je programma hoeft namelijk een stuk minder boilerplate te bevatten!

Het kan ook gebruikt worden in bestaande c# applicaties, maar ik raad dit af vanwege de restricties die opgelegd worden met het gebruik van deze feature. Maar ook vanwege het weinige voordeel dat het heeft in bestaande codebases. Ik kom zometeen nog terug op de restricties. Zie bijvoorbeeld dit standaard "Hello world" voorbeeld:

![img](https://www.arcady.nl/media/1947/schermafbeelding-2020-12-02-om-104212.png?width=500&height=134.6153846153846)

Voor mensen die C# kennen is dit simpel genoeg. We snappen wat er gebeurt. Maar voor beginners is dit een ander verhaal. Waar je met python gewoon met **print ("Hello World!")** begint, begin je met C# met de volgende onderwerpen:

- Wat is een **using**?
- Wat is een **namespace**?
- Wat is een **class**?
- Wat zijn die **{ }** ?
- Wat is die **Main** regel? En wat is **static** en **void**? Waarom zijn er **string [ ] args**?
- **Console**? Waar komt dat vandaan?
- Wat doet die ; daar? En waarom alleen op de regel van de **using** en op de regel van de **Writeline ( )**?

Voor beginners is dit niet heel vriendelijk.

**Top-level statements** kunnen beginners hierbij helpen. Met top-level statements wordt de volgende code ‘onderwater’ hetzelfde als de code hierboven:

![img](https://www.arcady.nl/media/1948/schermafbeelding-2020-12-02-om-104501.png?width=500&height=69.98738965952082)

Dit is handig voor beginners! Zo kunnen ze beetje bij beetje meer leren over de onderwerpen die ik hierboven benoemde.

Daarnet had ik het over restricties. Dit zijn er twee:

- Slechts één bestand in de applicatie mag gebruik maken van **top-level statements**
- Je mag het niet combineren met **program entry methods** zoals **Main ( )**; die wordt namelijk onderwater voor je aangemaakt.

Oftewel, gebruik dit om C# te leren. Misschien zelfs om een paar kleine console projecten te maken of misschien in kleine Azure Functions. Maar ik zou niet de **Program.cs** van een bestaand project aanpassen om dit te gebruiken. Voor mensen die deze feature niet kennen, zal het verwarrend zijn. Je krijgt niet veel voordeel hiervan.

**Nog meer veranderingen**

 Wil je meer weten? Check dan dit [artikel.](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9)

Zo wordt .NET 5 uitgebracht, een nieuw framework dat probeert om alle verschillende .NET omgevingen (.NET Core, .NET Framework, Mono) samen te brengen. Daarnaast wordt er hard gewerkt aan .NET MAUI, een nieuw UI Framework van Microsoft. Hiermee kan je straks moderne UI applicaties bouwen voor zowel desktop als voor telefoons. Een evolutie van Xamarin.