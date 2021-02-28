## Willem Tell

Stel dat wij een regio moeten besturen. Een mooi gebied met mooie bergen, schone meren en lekkere kaas. Een idyllisch gebied met één nadeel. Het wordt bewoond door mensen die ons niet kunnen luchten of zien en die niet willen snappen wat voor een voorrecht het is om deel uit te maken van ons bestuursgebied. Kortom, een zeer ondankbare taak, maar gelukkig hebben we de nodige bestuursinstrumenten om de regio te besturen en ons C# programma is zo’n bestuursinstrument. We definiëren in ons C# programma de “dingen” die van belang zijn in de desbetreffende regio.

## Landsknecht

In de desbetreffende regio woont Willem Tell. Willem Tell is een landsknecht en een bekende van ons. We zijn hem namelijk al eerder tegengekomen als tegenstander tijdens de slag bij Morgarten in 1315. Aan de slag bij Morgarten worden we liever niet herinnerd. De afloop en de gevolgen van die slag waren niet zo prettig voor ons. We zijn echter niet haatdragend en we zien in Willem Tell een goede aanwinst voor het besturen van de regio. We definiëren in ons C# programma de landsknecht:

```c#
class Landsknecht 
{
    public` `string` `Naam { ``get``; ``set``; }``}` `// object``Landsknecht landsknecht = ``new` `Landsknecht();``landsknecht.Naam = ``"Willem Tell"``;
```

*(Zwitserse) Landsknecht: dienstplichtige Zwitserse mannen uit verschillende kantons , 14e-16e eeuw , meestal werkzaam in de landbouw waardoor ze maar voor korte tijd de wapens op konden nemen.

## Landvoogd

We gaan ook een landvoogd benoemen die orde op zaken gaat stellen in de regio. Hermann Gessler is, gezien zijn (brute) staat van dienst de persoon om de klus te klaren:

```c#
class` `Landvoogd : Landsknecht``{`` ``public` `string` `Kanton { ``get``; ``set``; }``}` `// object``Landsvoogd landvoogd = ``new` `Landsvoogd();``landsvoogd.Naam = ``"Hermann Gessler"``;``landsvoogd.Kanton = ``"Uri"``;
```

Na verloop van tijd komen we erachter dat Willem Tell niet zo gecharmeerd is van onze aanwezigheid. We besluiten dan ook Willem Tell om te kopen door hem te benoemen tot landvoogd. Gessler bakt er als landvoogd niet veel van en die promoveren we wel weg.

## is

We sturen een aantal van onze hoogwaardigheidsbekleders naar Willem Tell met het aanbod om landvoogd te worden. Onze hoogwaardigheidsbekleders komen echter terug met een bedankbriefje van Willem Tell waarin hij ons aanbod afslaat. Willem Tell is geen landvoogd geworden en dat brengen we als volgt tot uiting in ons C#-programma:

```c#
// Is-operator``if` `(!(landsknecht ``is` `Landvoogd))``{`` ``// de hoogwaardigheidsbekleders `` ``// komen onverrichterzake terug`` ``Console.WriteLine(landsknecht.Naam + `` ``" is geen landvoogd."``);``}
```

We gebruiken de **is**-operator en de operator geeft de waarde false.

## GetType / typeOf

We doen een hernieuwd bod en we sturen opnieuw een aantal hoogwaardigheidsbekleders om het bod over te brengen. Deze keer zijn de hoogwaardigheidsbekleders wat gespierder qua fysiek en ze hebben de bevoegdheid om indien nodig wat directer te zijn als dat nodig mocht zijn om Willem Tell te kunnen overtuigen.

Helaas mislukt ook deze poging. De hoogwaardigheidsbekleders komen besmeurd met pek en veren terug met wederom een bedankbrief van Willem Tell waarin hij ons aanbod afslaat. We brengen het falen als volgt tot uiting in ons C#-programma:

```c#
if` `(landsknecht.GetType() != ``typeof``(Landvoogd))``{`` ``// de hoogwaardigheidsbekleders komen`` ``// besmeurd met pek en veren terug`` ``Console.WriteLine(landsknecht.Naam + `` ``" is nog steeds geen landvoogd."` `+ `` ``Environment.NewLine);``}
```

De **GetType** en de **typeOf**-operatoren retourneren de gegevenstype van het te onderzoeken object en in dit geval wordt gegevenstype Landsknecht geretourneerd en niet gegevenstype Landvoogd, de gegevenstype waarop we hadden gehoopt.

## as

We sturen een speciale werkgroep met speciale tools en de werkgroep mag haar tools naar eigen inzicht toepassen om Willem Tell over te halen op ons aanbod in te gaan. Helaas mislukt ook deze poging want de leden van de werkgroep zijn opeens spoorloos verdwenen. We krijgen van Willem Tell wel een brief waarin hij nogmaals benadrukt dat hij niet ingaat op ons aanbod. We brengen deze mislukte poging als volgt tot uiting in ons C#-programma:

```c#
Landvoogd nieuweLandvoogd = landsknecht ``as` `Landvoogd;``if` `(nieuweLandvoogd == ``null``)``{``  ``// resultaat = null en zo ook ``  ``// onze werkgroep die is opeens ook null``  ``Console.WriteLine(landsknecht.Naam + ``  ``" wil nog steeds niet landvoogd worden."` `+``  ``Environment.NewLine);``}
```

Het resultaat van de **as** operator is null. Willem Tell komt niet opdagen als zijnde de nieuwe landvoogd (en de leden van de werkgroep ook niet).

## cast

Onze pogingen worden met de nodige hoon en minachting door Gessler gade geslagen. Gessler verklaart dat wij maar prutsers zijn. Hij zal de klus wel klaren mits hij maar genoeg medewerkers en middelen krijgt. We geven Gessler zijn zin en de landvoogd gaat op pad.

Helaas wordt het een enorm fiasco. Gessler keert een beetje dood terug van zijn expeditie en ons C# bestuursinstrument crashed met een exception. We brengen het mislukken van de expeditie als volgt tot uiting in ons C# programma met een cast:

```c#
 ``// Casten`` ``Landvoogd nieuweLandvoogd2 = `` ``(Landvoogd)landsknecht;``}` `catch` `(Exception ex)``{        `` ``Console.WriteLine(``"Casten geeft een exception"``);`` ``Console.WriteLine(``"Gessler is een beetje dood nu"``);`` ``Console.WriteLine(``"De regio ontdoet zich van ons"``);`` ``Console.WriteLine(ex.Message);`` ``Console.WriteLine(ex.GetType());``}
```

## De Coalescing / Ternary operator in C#

1. [Inleiding](https://www.mrasoft.nl/de-coalescing-en-de-ternary-operator-in-csharp/#inleiding)
2. [Coalescing operator](https://www.mrasoft.nl/de-coalescing-en-de-ternary-operator-in-csharp/#coalescing)
3. [Ternary operator](https://www.mrasoft.nl/de-coalescing-en-de-ternary-operator-in-csharp/#ternary)
4. [Slot](https://www.mrasoft.nl/de-coalescing-en-de-ternary-operator-in-csharp/#slot)
5. [Voorbeeldprogramma](https://www.mrasoft.nl/de-coalescing-en-de-ternary-operator-in-csharp/#voorbeeldprogramma)

## Inleiding

**De Coalescing operator en de Ternary operator zul je regelmatig tegenkomen in C# programma’s. Daarom een posting over deze bijzondere operatoren. We lichten het weer toe aan de hand van de legende van [Willem Tell.](https://www.mrasoft.nl/gegevenstypes-in-csharp-type-bepalen/)**

Terugkomend op de posting over [**Willem Tell**](https://www.mrasoft.nl/gegevenstypes-in-csharp-type-bepalen/), zoeken we iemand die landvoogd wil worden. In eerste instantie bedankt iedereen voor deze hondenbaan en variabele **kandidaat** heeft nog geen waarde. De naam van de landvoogd krijgt via een coalescing operator de waarde **Geen**:

[up](https://www.mrasoft.nl/de-coalescing-en-de-ternary-operator-in-csharp/#top) | [down](https://www.mrasoft.nl/de-coalescing-en-de-ternary-operator-in-csharp/#coalescing)

## Coalescing operator

```c#
// De landvoogd``Landvoogd landvoogd = ``new` `Landvoogd();` `// Niemand gevonden``string` `kandidaat = ``null``;``bool` `vacatureIsVervuld;` `// Coalescing operator``landvoogd.Naam = kandidaat ?? ``"Geen"``;``Console.WriteLine(``"En de landvoogd is: {0}"``, landvoogd.Naam);
```

Uiteindelijk is Gessler beschikbaar (na de zoveelste arbeidsconflict op de andere afdeling en aantijgingen van grensoverschrijdend gedrag waardoor ze hem liever kwijt dan rijk zijn). Gessler is de enige kandidaat en via de coalescing operator (**??**) wordt de naam van de landvoogd Hermann Gessler omdat variabele **kandidaat** een waarde heeft (die van Hermann Gessler). Gessler reist af naar kanton Uri en we wensen hem veel succes toe in zijn nieuwe baan:

```c#
// Gessler wil wel landvoogd worden``kandidaat = ``"Hermann Gessler"``;``landvoogd.Naam = kandidaat ?? ``"Geen"``;``Console.WriteLine(``"En de landvoogd is: {0}"``, ``landvoogd.Naam);
```

## Ternary operator

Het heugelijke nieuws dat de vacature van landvoogd is vervuld brengen we tot uiting in boolean variabele **vacatureIsVervuld** waarbij de variabele als volgt door een ternary operator (**?**) wordt gevuld:

```c#
// Ternary Operator``vacatureIsVervuld = ``landvoogd.Naam != ``"Geen"` `? ``true` `: ``false``;` `if` `(vacatureIsVervuld) ``Console.WriteLine(``"We hebben een landvoogd!"``);` `// Gessler, have fun over there in Uri``landvoogd.Kanton = ``"Uri"``;
```

Resultaat:

![img](https://www.mrasoft.nl/wp-content/uploads/2020/06/De-Coalescing-operator-en-de-Ternary-operator-resultaat.png)

## Voorbeeldprogramma

```c#
using` `System;` `namespace` `BijzondereOperatoren``{`` ``class` `MainClass`` ``{``  ``class` `Landsknecht``  ``{``   ``public` `string` `Naam { ``get``; ``set``; }``  ``}``  ` `  ``class` `Landvoogd: Landsknecht``  ``{``   ``public` `string` `Kanton { ``get``; ``set``; }``  ``}``  ` `  ``public` `static` `void` `Main(``string``[] args)``  ``{``   ``// De landvoogd``   ``Landvoogd landvoogd = ``   ``new` `Landvoogd();``   ` `   ``// Niemand gevonden``   ``string` `kandidaat = ``null``;``   ``bool` `vacatureIsVervuld;``   ` `   ``// Coalescing operator``   ``landvoogd.Naam = kandidaat ?? ``"Geen"``;``   ``Console.WriteLine(``   ``"En de landvoogd is: {0}"``, ``   ``landvoogd.Naam);``   ` `   ``// Gessler wil wel landvoogd worden``   ``kandidaat = ``"Hermann Gessler"``;``   ``landvoogd.Naam = kandidaat ?? ``"Geen"``;``   ``Console.WriteLine(``   ``"En de landvoogd is: {0}"``, ``   ``landvoogd.Naam);``   ` `   ``// Ternary Operator``   ``vacatureIsVervuld =``   ``landvoogd.Naam != ``"Geen"` `? ``true` `: ``false``;``   ``if` `(vacatureIsVervuld) ``   ``Console.WriteLine(``"We hebben een landvoogd!"``);``   ` `   ``// Gessler, have fun over there in Uri``   ``landvoogd.Kanton = ``"Uri"``;``  ``}`` ``}``}
```