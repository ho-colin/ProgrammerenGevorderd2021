# UML naar code (*)

Kan je volgende 2 UML-diagrammen implementeren in code? Uiteraard kan je dat: make it happen!

![img](./pg009.png)

![img](./pg010.png) 

# Politiek

Maak een programma om de politieke situatie van een land te simuleren.

Maak volgende klassen:

- Land
- Minister
- President

## Minister

Een Minister heeft geen speciale eigenschappen. Enkel een autoproperty om de Naam van de minister in bij te houden

## President

Een President is een minister maar met 1 extra property met private setter: hij heeft een teller die start op 4 alsook een methode `JaarVerder`die deze teller met 1 iedere aanroep verlaagt.

## Land

- Een land heeft 0 of 1 president (of koning, kies zelf)
- Een land heeft 0 of 1 eerste minister
- Een land heeft 0 tot 4 ministers (via een `List<Minister>`)

Al deze compositieobjecten zijn private. Een land heeft volgende publieke methoden:

### `MaakRegering`

Deze methode aanvaardt volgende parameters:

1. 1 president object die aan de private president variabele wordt toegekend
2. Een `List<Minister>` object waarin tussen de 1 tot 5 ministers in staan: de eerste minister in de lijst wordt toegewezen aan de private eerste minister variabele. De overige ministers in de lijst worden aan de private lijst van ministers toegewezen.

Deze methode zal enkel iets doen indien er geen president in het land is (`null`). Indien er reeds een regering is dan zal er een foutboodschap ,verschijnen.

### `JaarVerder`

Deze methode aanroepen zal de `JaarVerder` aanroepen op de president indien deze er is (en dus niet `null` is). Deze methode controleert ook of de teller van de president na deze aanroep op 0 staat. Als dat het geval is dan worden alle ministers en president in het land op `null` gezet.

## Eindfase

Controleer je klasse Land door enkele ministers en een president te maken en deze in een object van het type Land via `MaakRegering` door te geven. Test dan wat er gebeurt indien je enkele malen `JaarVerder` op het land aanroept.

# Moederbord

Maak een klasse `Moederbord` die een, je raadt het nooit, moederbord van een computer voorstelt. Kies een van de vele moederborden die je online vindt ([enkele voorbeelden](https://www.google.com/search?biw=1368&bih=802&tbm=isch&sa=1&ei=4oK9XNqCKt3UmwXbk5-4Cg&q=motherboard+parts&oq=motherboard+parts&gs_l=img.3..0l10.1974.2413..2560...0.0..0.68.290.5......1....1..gws-wiz-img.aurN6S4Da0I#imgrc=_)) en bekijk uit welke delen een moederbord bestaat ('heeft een').

Maak voor ieder deel een aparte klasse. Voorzie vervolgens via compositie de nodige objecten in je moederbord. Denk er aan dat je bijvoorbeeld 2 (of 4) RAM-slots hebt en dus hier ofwel een array moet voorzien van het type `List<RAM>`, oftewel twee aparte delen `RAMSlot1` en `RAMSlot2`.

Maak een methode `TestMoederbord` in de klasse `Moederbord`. Wanneer je deze aanroept zal deze weergeven welke onderdelen nog leeg zijn (`==null`).

Iedere module moet via een property langs buiten ingesteld worden. (beeld je in dat je effectief een moederbord ineenknutselt):

```csharp
Moederbord Z390E_GAMING = new Moederbord();
Z390E_GAMING.AGP= new AGPSlot("GeForceRTX2080");
Z390E_GAMING.CPU= new CPUSlot("IntelCorei9_9900K");
//etc.
```

Kan je zelf een computer samenstellen door enkele objecten van verschillende types aan te maken en deze aan je moederbord-object toe te wijzen?

# Een eigen huis (*)

Gebruik compositie én overerving om een klasse `Huis` te voorzien van enkele kamers, waarbij iedere kamer een klasse op zich is (denk aan `BadKamer`, `Salon`, etc). Alle kamers erven over van de klasse `Kamer`. Iedere kamer heeft een oppervlakte (in vierkante meter), een naam en prijs. Standaard is de prijs van een kamer 400euro, maar mogelijke child-klassen zullen deze property soms overriden.

Maak minstens volgende klassen:

- Badkamer: kost 500 euro
- Gang: kost 10 euro per vierkante meter dat deze kamer groot is
- Salon: kost 300 euro indien er geen schouw aanwezig is (via `bool` bijhouden) anders 500 euro

De klasse `Huis` heeft een array van kamers. De klasse heeft ook een methode `BerekenPrijs` die de totale prijs van het huis berekent gebaseerd op de prijzen van iedere kamer in de array.

Test je klasse door enkele huizen te maken en er enkele kamers in te plaatsen (bepaal zelf hoe je de kamers aan het huis toevoegt: via methode, constructor, etc) en vervolgens de prijs ervan te tonen.



# Maak volgende klassen

Maak 2 klassen: `Enclave` en `StadsEnclave` ![img](./pg011.jfif)

Een enclave heeft 1 hospitaal, 1 generator en 1 of meerdere woonsten. Wanneer een enclave wordt aangemaakt heeft deze 3 woningen van bij de start, alsook een werkende generator en hospitaal. Al deze gebouwen komenop een willekeurige plek.

Een enclave heeft een virtuele methode `BouwWoonst`. Wanneer deze wordt aangemaakt wordt er een woonst aan de enclave toegevoegd. Het huis komt op een willekeurige locatie maar nooit op een plek waar reeds andere gebouwen staan.

Een enclave heeft een virtuele methode `ToonEnclave` die alle gebouwen op het scherm zal ztetten.

Een stadsenclave heeft naast alles wat hij dankzij overerving van de enclave heeft ook nog een waterkrachtcentrale, een extra hospitaal en 1 of 2 flats. Van bij de start heeft een stadsenclave enkel de zaken die een gewone enclave van bij de start heeft.

De stadsenclave override `BouwWoonst`. Deze zal nog steeds een woonst toevoegen, maar iedere keer als de enclave 3 woningen heeft worden deze verwijderd en komt er een flat in de plaats (op locatie naar keuze).

De stadsenclave override `ToonEnclave` om ook de andere gebouwen (flat, extra hospitaal, waterkrachtcentrale) op het scherm te tekenen.

# Applicatie

Maak een eenvoudig programma dat 2 enclaves en 2 stadsenclaves aanmaakt. De gebruiker kan per enclave/stadenclave kiezen van welke enclave de bouwwoonst methode moet aangeroepen worden. Vervolgens wordt deze enclave op het scherm getoond m.b.v. toonenclave. Vervolgens verschijnt terug het keuze menu waarin gebruiker kan kiezen welke enclave nu een woonst moet bouwen. Dit blijft oneindig duren.

# Dictionary

Maak nu een dictionary aan: `Dictionary<string, Enclave>`. De string is de naam van de enclave (bv "Antwerpen"). Merk op dat je zowel `Enclave` als `StadsEnclave` objecten aan deze lijst kunt toevoegen.

De gebruiker kan nu naast de werking van daarnet ook volgende zaken doen

1. Een nieuwe enclave of stadsenclave aanmaken en deze een naam geven. Zo wordt deze in de dictionary bewaard
2. Via de naam van de enclave kan de gebruiker kiezen van welke enclave `BouwWoonst` moet aangeroepen worden.

