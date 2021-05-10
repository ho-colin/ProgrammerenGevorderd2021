# UDP versus TCP

![TCP versus UDP](./tcp_udp.jpg "TCP versus UDP")

TCP, UDP, netwerkprotocollen, databits: de kans is groot dat deze termen je niets zeggen als je geen ICT-expert bent. Toch is het handig om te weten wat deze termen betekenen. Wanneer je surft op het internet, je e-mail gebruikt of bestanden verzendt, maak je gebruik van TCP. Beschikbaarheid van servers en streaming zoals een live video bekijken zijn enkele toepassingen van UDP. 

TCP staat voor **Transmission Control Protocol**. Het is een veelgebruikt protocol. Hiermee worden gegevens overgedragen op het internet via netwerkverbindingen, maar ook op computernetwerken. TCP kan gegevens in een datastroom versturen, wat betekent dat deze gegevens gegarandeerd aankomen op hun bestemming. Communicatiefouten worden daarnaast ook opgevangen. TCP wordt niet alleen gebruikt voor verkeer op het internet, maar ook voor het downloaden en streamen van video’s.

Hoe werkt TCP? Wanneer je vanaf jouw computer op een link van een website klikt, stuurt de browser zogenaamde TCP packets naar de server van de betreffende website. De server van de website stuurt ook weer TCP packets terug. De packets krijgen een getal, waardoor de ontvanger deze packets in de juiste volgorde krijgt. Behalve het sturen van de packets controleert TCP deze data ook. De server stuurt dan bericht naar de verzender om de ontvangst van packets te bevestigen. Bij een onjuist antwoord worden de packets opnieuw gestuurd.

![TCP](./TCP_vs_UDP_01.gif "TCP")

UDP staat voor **User Datagram Protocol**. Dit is een bericht-georiënteerd protocol. Dit wil zeggen dat een verzender een bericht stuurt aan de ontvanger, net als bij het TCP protocol. Het verschil met TCP is echter dat de ontvanger bij UDP geen bevestiging stuurt naar de verzender. Dit betekent dat UDP vooral geschikt is voor eenrichtingscommunicatie, waarbij het verlies van enige data geen probleem vormt. Het UDP protocol wordt vooral gebruikt bij live streaming en online gaming.

UDP is sneller dan TCP, omdat het geen controles uitvoert en geen tweerichtingsverkeer is. Dit betekent echter wel dat UDP minder betrouwbaar is dan TCP als het gaat om het versturen van data.

![UDP](./TCP_vs_UDP_02.gif "UDP")

Wanneer gebruik je TCP en wanneer gebruik je UDP? TCP wordt vaak gebruikt wanneer er sprake is van een belangrijke overdracht van informatie. Denk hierbij aan het versturen van een bestand van de ene naar de andere computer. Het gaat hierbij niet om de snelheid, maar om de accuratesse waarmee een bestand wordt verstuurd. UDP wordt vooral gebruik wanneer snelheid boven veiligheid en accuratesse gaat. Een 100% foutloze verbinding is in dit geval niet noodzakelijk. Denk hierbij aan het streamen van een live video of online gaming. Kort gezegd draait het bij TCP om nauwkeurigheid en bij UDP om snelheid. Wil je een beide gevallen verzekerd zijn van een veilige verbinding? Gebruik dan een Virtual Private Network (VPN). Een VPN versleutelt je connectie, terwijl de snelheid op peil blijft.

UDP vs. TCP: wat zijn de belangrijkste verschillen tussen deze twee? In de eerste plaats gaat het om de manier waarop gegevens en data uitgewisseld worden. Toch zijn er nog meer verschillen zichtbaar. Hier vind je een overzicht van deze verschillen in een overzichtelijke tabel:

![TCP](./tcp-upd_infographic.png "TCP")

TCP zorgt gegarandeerd voor een betrouwbare maar ook een geordende levering van gegevens van de gebruiker naar de server en andersom. UDP is niet bedoeld voor end-to-end verbindingen en communicatie en controleert de gereedheid van de ontvanger niet. Verschillen:

### 1: Betrouwbaarheid

Wanneer je verzekerd wil zijn van een betrouwbare overdracht van informatie, kan je het beste TCP gebruiken. Waarom is TCP betrouwbaarder? Hier worden bericht-bevestiging en hertransmissies beheert wanneer er sprake is van verloren onderdelen. Er zullen dus nooit gegevens ontbreken. Bij UDP heb je nooit de zekerheid of de communicatie de ontvanger heeft bereikt. Concepten van bevestiging, hertransmissie en time-out zijn niet aanwezig.

### 2: Ordening van pakketten

Bij TCP overdrachten is er altijd sprake van een bepaalde volgorde. De data wordt in een bepaalde reeks naar de server verzonden, en kom in dezelfde volgorde terug. Komen bepaalde gegevens in de verkeerde volgorde aan? Dan herstelt TCP dat en verstuurt de data opnieuw. Bij UDP is er geen sprake van een volgorde. Van te voren kun je dan ook niet voorspellen in welke volgorde de gegevens worden ontvangen.

### 3: Verbinding

Bij TCP is een zwaargewicht verbinding die drie pakketten vereist voor een zogenaamde socket-verbinding. Een socket-verbinding wordt toegepast wanneer een verbinding met een andere host tot stand wordt gebracht. Een socket bestaat altijd uit een IP-adres. Deze verbinding zorgt bij TCP voor betrouwbaarheid. UDP is een lichtgewicht transportlaag, gecreëerd op een IP. Volgverbindingen of het ordenen van gegevens is dan ook niet mogelijk.

### 4: Foutencontrole

TCP gebruikt niet alleen foutencontrole, maar ook foutenherstel. Fouten worden gedetecteerd door middel van een controle. Is een pakket foutief? Dan wordt het niet door de ontvanger bevestigd. Daarna is er sprake van een hertransmissie door de verzender. Dit mechanisme wordt ook wel **Positive Acknowledgement with Retransmission** (PAR) genoemd.

UDP werkt op basis van best-effort. Dit betekent dat het protocol foutdetectie wel ondersteunt, maar er niets mee doet. Een fout kan worden gedetecteerd, maar daarna wordt het pakket genegeerd. Er wordt niet geprobeerd om het pakket opnieuw te verzenden om de fout te herstellen zoals dat bij TCP wel het geval is. Dit komt omdat UDP vooral wordt gebruikt voor de snelheid.

## SimpleTCP

SimpleTcp is een leuke bibliotheek, die veel kan. [Hier](https://github.com/BrandonPotter/SimpleTCP) zie je enkele ideeën. 

### Client-server chat programma

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

### Beide projecten starten

Om je programma de komende tijd te testen wil je uiteraard steeds dat er minstens 1 server en 1 client loopt. We gaan dit als volgt doen:

1. Rechterklik op je solution (in solution explorer)
2. Kies "Properties"
3. Ga naar "Startup Project" onder de "Common properties"
4. Selecteer "Multiple startup project"
5. Verander de action van beide projecten naar "Start"
6. Zorg ervoor dat je server-project eerst start: indien nodig klik je op het pijltje omhoog zodat die bovenaan staat

Als je nu je programma start (F5) of debugt dan zullen steeds beide projecten uitgevoerd worden.

### Server-code

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

### Client-code

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

## Multicasting

**Multicasting** laat het toe om over een netwerk te communiceren naar groepen van willekeurige grootte via een enkele transmissie door de bron. Men kan gecontroleerd data versturen naar een aantal (maar niet noodzakelijk alle) gebruikers. Hierdoor worden bijvoorbeeld televisie-uitzendingen via internet haalbaar vanuit een bron die zelf weinig bandbreedte ter beschikking heeft (men kan dus vanuit huis of met een beperkt budget zenden). Gebruikers moeten zich inschrijven op een multicastgroep om de datapakketten die hiernaar verzonden worden, te kunnen ontvangen. Als men niet meer wenst gebruik te maken van een bepaalde multicastgroep, kan men zich hiervoor uitschrijven. Gebruikers kunnen zich tegelijkertijd voor verscheidene multicastgroepen inschrijven. Om data te verzenden naar een multicastgroep is inschrijving echter niet vereist.

Alternatieven voor multicast zijn:

- **Unicast**: het verzenden van een pakket naar één host. De normale gang van zaken.
- **Broadcast**: het verzenden van een pakket naar alle hosts op een gegeven netwerk.
- **Anycast**: het verzenden van een pakket naar de dichtstbijzijnde host van een bepaalde klasse.

## WireShark

https://www.wireshark.org/

We installeren WireShark om TCP/UDP communicatie te bekijken: [eavesdropping](https://en.wikipedia.org/wiki/Eavesdropping)

## HTTP en HTTPS

![Wat is het verschil tussen HTTP en HTTPS?](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\iStock-1168740317.jpg)

### HTTP: Geen Encryptie van Gegevens

Elke URL-link die begint met HTTP gebruikt een basistype van 'hypertext transfer protocol'. Deze netwerkprotocolstandaard, ontwikkeld door Tim Berners-Lee in het begin van de jaren 1990, toen het internet nog in zijn kinderschoenen stond, zorgt ervoor dat webbrowsers en servers kunnen communiceren door gegevens uit te wisselen.

HTTP wordt ook wel een 'staatloos systeem' genoemd, wat betekent dat het op aanvraag een verbinding tot stand brengt. U klikt op een link, vraagt zo een verbinding aan, en uw webbrowser stuurt deze aanvraag naar de server, die reageert door de pagina te openen. Hoe sneller de verbinding, hoe sneller u de gegevens te zien krijgt.

Als 'toepassing laag protocol' blijft HTTP gericht op het presenteren van informatie, maar houdt het zich minder bezig met de manier waarop informatie van de ene plaats naar de andere wordt overgedragen. Dat betekent helaas dat HTTP [onderschept en mogelijk gemanipuleerd](https://www.globalsign.com/nl-nl/blog/wat-is-een-man-in-the-middle-aanval/) kan worden, waardoor zowel de informatie als de ontvanger ervan (u dus) kwetsbaar worden.

### HTTPS: Versleutelde Verbindingen

HTTPS is niet de tegenhanger van HTTP, eerder zijn jongere neefje. De twee zijn in wezen hetzelfde, omdat ze beide verwijzen naar hetzelfde 'hypertext transfer protocol', dat ervoor zorgt dat webgegevens op uw scherm worden weergegeven. HTTPS werkt echter iets anders, is meer geavanceerd en veel veiliger.

Eenvoudig gezegd: het HTTPS-protocol is een uitbreiding van HTTP. Die 'S' in de afkorting staat voor Secure (veilig) en aan de basis ervan ligt Transport Layer Security (TLS) [de opvolger van [Secure Sockets Layer (SSL)](https://www.globalsign.com/nl-nl/ssl-informatiecentrum/what-is-ssl)], de standaardbeveiligingstechnologie die een versleutelde verbinding tot stand brengt tussen een webserver en een browser.

Zonder HTTPS zouden alle gegevens die u op de website invoert (zoals gebruikersnaam/wachtwoord, creditcard- of bankgegevens, andere formuliergegevens enz.) gewoon worden verzonden en kunnen worden onderschept of afgeluisterd. Daarom moet u altijd controleren of een website HTTPS gebruikt voordat u gegevens invoert.

Naast het versleutelen van de gegevens die tussen de server en uw browser worden verzonden, authenticeert TLS ook de server waarmee u verbinding maakt en beschermt de verzonden gegevens tegen manipulatie.

Ik bekijk het als volgt, HTTP in HTTPS is het equivalent van een bestemming, terwijl SSL het equivalent is van een reis. Het eerste is verantwoordelijk om de gegevens op uw scherm weer te geven en het tweede bepaalt de manier waarop deze op het scherm terechtkomen. Samen zorgen ze voor een veilige gegevensoverdracht.

![image-20210508115041644](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\image-20210508115041644.png)

### De Voordelen en Nadelen van HTTPS

Zoals hierboven besproken, helpt HTTPS de cyberveiligheid te garanderen. Het is zonder twijfel een betere oplossing van netwerkprotocol dan zijn oudere neef, HTTP.

Heeft HTTPS dan alleen maar voordelen? Of zijn er ook nadelen aan verbonden? Laten we eens kijken. 

### De Voordelen van HTTPS

De hierboven vermelde beveiligingsvoordelen – de server authenticeren, de gegevensoverdracht versleutelen en de uitwisseling beschermen tegen manipulatie – zijn de voor de hand liggende voordelen van HTTPS. Siteoperators willen en moeten de gegevens van hun bezoekers beschermen (HTTPS is een vereiste voor websites die betalingsgegevens verzamelen in overeenstemming met de [PCI Data Security Standard](https://www.pcisecuritystandards.org/documents/PCIDSS_QRGv3_2.pdf?agreement=true&time=1525795317742)) en bezoekers willen weten dat hun gegevens op een veilige manier worden verzonden.

De stijgende vraag naar privacy en gegevensbeveiliging van het publiek is een bijkomend voordeel van het gebruik van HTTPS. Volgens [We Make Websites](https://wemakewebsites.com/blog/the-ultimate-guide-to-reduce-cart-abandonment) worden 13% van de winkelwagentjes niet afgerekend vanwege twijfels over de beveiliging van de betalingsgegevens. Sitebezoekers willen weten dat ze uw site kunnen vertrouwen, vooral als ze financiële gegevens invoeren, en HTTPS gebruiken is één manier om dat te doen (d.w.z. het is een manier om uw bezoekers te tonen dat de ingevoerde gegevens versleuteld worden).

HTTPS kan ook helpen bij uw Zoekmachine Optimalisatie (SEO). In 2014 [kondigde](https://webmasters.googleblog.com/2014/08/https-as-ranking-signal.html) Google aan dat HTTPS een ranking-signaal zou worden. Sindsdien hebben een aantal [studies](https://www.cloudtec.ch/blog/web/2014/will-switching-to-https-affect-my-seo-ranking) en [anekdotische ervaringen](https://www.cloudtec.ch/blog/web/2014/will-switching-to-https-affect-my-seo-ranking) van bedrijven, die HTTPS geïmplementeerd hebben, aangetoond dat er een verband is tussen hogere ranking en de zichtbaarheid van pagina's.

## WebSocket

Voor meer details, zie: https://nl.wikipedia.org/wiki/WebSocket.

**WebSocket** is een [netwerkprotocol](https://nl.wikipedia.org/wiki/Netwerkprotocol) dat [full-duplex](https://nl.wikipedia.org/wiki/Full-duplex) communicatie biedt over een enkele [TCP](https://nl.wikipedia.org/wiki/Transmission_Control_Protocol)-verbinding. Het WebSocketprotocol is gestandaardiseerd door de [Internet Engineering Task Force](https://nl.wikipedia.org/wiki/Internet_Engineering_Task_Force) in 2011 als [RFC](https://nl.wikipedia.org/wiki/Request_for_Comments) [6455](http://tools.ietf.org/html/rfc6455) en de WebSocketAPI gemaakt in [Web IDL](https://nl.wikipedia.org/w/index.php?title=Web_IDL&action=edit&redlink=1) is gestandaardiseerd door het [World Wide Web Consortium](https://nl.wikipedia.org/wiki/World_Wide_Web_Consortium).

WebSocket is ontworpen om te worden toegepast in [webbrowsers](https://nl.wikipedia.org/wiki/Webbrowser) en [webservers](https://nl.wikipedia.org/wiki/Webserver). Het WebSocketprotocol is een zelfstandig op [TCP](https://nl.wikipedia.org/wiki/Transmission_Control_Protocol) gebaseerd protocol. WebSocket vertoont enige gelijkenis met [HTTP](https://nl.wikipedia.org/wiki/Hypertext_Transfer_Protocol), omdat de [handshake](https://nl.wikipedia.org/w/index.php?title=Handshake&action=edit&redlink=1) van het WebSocketprotocol door [HTTP](https://nl.wikipedia.org/wiki/Hypertext_Transfer_Protocol)-servers wordt geïnterpreteerd als een Upgraderequest. Het WebSocket protocol maakt **bidirectioneel dataverkeer** mogelijk tussen webbrowsers en webservers. Dit kan doordat het protocol zorgt voor een standaard manier van dataverkeer zonder de noodzaak van een request door de webbrowser om vanaf de server data te sturen naar de browser. Daarnaast staat het protocol toe **berichten heen en weer te sturen en daarbij de connectie tussentijds open te houden**. Op deze manier is er een voortdurende bidirectionele conversatie tussen webserver en webbrowser. De communicatie vindt plaats over TCP-poort 80 (of TCP-poort 443 als de communicatie over TLS-versleutelde connecties gaat), wat een voordeel is in netwerkomgevingen waar poorten die niet bedoeld zijn voor het web (andere TCP-poorten dan 80 en 443) worden geblokkeerd door een firewall. 

Het WebSocketprotocol wordt momenteel ondersteund in de meeste grote browsers, waaronder: [Google Chrome](https://nl.wikipedia.org/wiki/Google_Chrome), [Microsoft Edge](https://nl.wikipedia.org/wiki/Microsoft_Edge), [Internet Explorer](https://nl.wikipedia.org/wiki/Internet_Explorer), [Firefox](https://nl.wikipedia.org/wiki/Mozilla_Firefox), [Safari](https://nl.wikipedia.org/wiki/Safari_(webbrowser)) en [Opera](https://nl.wikipedia.org/wiki/Opera_(webbrowser)). WebSocket heeft ook [webapplicaties](https://nl.wikipedia.org/wiki/Webapplicatie) op de server nodig om het te ondersteunen.

## Fiddler

https://www.telerik.com/fiddler

We installeren Fiddler Classic om http communicatie te bekijken

## OpenSSL certificates

Om een OpenSSL gebaseerde server en client te maken moet je een set SSL certificaten voorbereiden.

## SSL: eerste kennismaking

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\image01-fs8.png)

Voor wie SSL/TLS nog nieuw is én voor de ervaren rotten die hun kennis willen opfrissen, beginnen we met een reeks over de basisprincipes van SSL. 

Het SSL protocol werd al in 1995 geïntroduceerd als beveiligingsprotocol voor de verbinding tussen bezoekers van een website en de server waar de website is ondergebracht door middel van zeer sterke encryptie. Het protocol is in de loop der jaren verder ontwikkeld en overgenomen door een nieuwe versie, TLS, maar in de volksmond wordt het beveiligingsprotocol nog altijd SSL genoemd.

SSL certificaten komen in vele soorten en maten. Voor internetdoeleinden zijn er drie verschillende hoofdsoorten, die te onderscheiden zijn door de manier waarop de aanvraag van het certificaat wordt gevalideerd.

Er wordt vaak gedacht dat SSL alleen nodig is wanneer een bezoeker gegevens verstuurt via de website, bijvoorbeeld bij het inloggen of bij het invullen van een formulier, maar SSL werkt twee kanten op. Een SSL-beveiligde verbinding zorgt ervoor dat men niet kan meelezen met wat er naar de website wordt verstuurd. Maar het voorkomt ook dat de informatie die verstuurd wordt naar de website, of wordt verzonden vanaf de website, aangepast kan worden voor het zijn doel bereikt. Daarom is een SSL certificaat voor elke commerciële website een onmisbaar onderdeel van het securitybeleid.

SSL is gebaseerd op de versleuteling van gegevens met behulp van een private en een public key.

![What is Public and Private Key in Cryptography? – An Introduction](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\public-key-vs-private-key.png)

### Private key

Een private key wordt gecreëerd door een stukje automatisch gegenereerde tekst te converteren naar een key-bestand met behulp van een wiskundig algoritme, waardoor het een unieke waarde krijgt. Vervolgens wordt met dit key-bestand een CSR gegenereerd die weer gebruikt wordt om een SSL certificaat aan te maken. In dit CSR-proces wordt ook de public key aangemaakt. De private key moet te allen tijde geheim blijven. Met deze sleutel kan versleutelde data worden ontcijferd en berichten die met een certificaat ondertekend worden, worden versleuteld.

### Public key

De public key wordt tijdens het genereren van een CSR aangemaakt en mag publiek worden verspreid. Een public key wordt bijvoorbeeld gebruikt om informatie te versleutelen die alleen de eigenaar van de private key mag ontvangen. Alleen de combinatie van de public en private key kan deze gegevens vervolgens ontsleutelen. Een public key kan ook gebruikt worden om te verifiëren dat een bericht is gestuurd door de eigenaar van de private key.

### Versleutelingsalgoritme

Hoe sterk de encryptie van een certificaat is, is grotendeels te danken aan het versleutelingsalgoritme dat gebruikt is om de private key te genereren. Hackers zijn er dus op gebrand om deze versleutelingsalgoritmes te kraken: wanneer het algoritme op straat ligt, kan er met behulp van de public key worden teruggerekend naar de private key. Het RSA algoritme was tot voor kort het meest gebruikte algoritme, maar **het ECC algoritme, of Elliptic Curve Cryptography algoritme**, krijgt steeds meer voet aan de grond. Dit algoritme kan een veel kleinere key creëren die nog steeds net zo veilig is als de veel langere RSA keys. Zo is een ECC key van 228 bits net zo veilig als een RSA key van 2380 bits. Steeds meer Certificate Authorities stappen daarom over op ECC keys.

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\image02_1.png)

Eerst gaan we het over Certificate Signing Requests (CSR's) hebben. Deze kleine bestanden spelen een cruciale rol bij het aanvragen van een SSL/TLS-certificaat, maar wat zijn ze precies en hoe kan je er eentje eenvoudig genereren?

## Definitie van Certificate Signing Request

Een Certificate Signing Request (CSR) is een van de eerste stappen om je eigen SSL-certificaat te verkrijgen. De CSR wordt gegenereerd op de server waarop je het certificaat wil installeren. Een CSR bevat informatie (bv. common name, organisatie, land) die de certificeringsinstantie (CA) dan gaat gebruiken om jouw certificaat te creëren. De CSR bevat ook de public key die deel uitmaakt van jouw certificaat en wordt ondertekend met de overeenkomstige private key. Meer uitleg over de rollen van deze keys gaan we hieronder bespreken.

## Wat zit er precies in een CSR?

Een CA gebruikt de gegevens van de CSR om het SSL-certificaat te genereren. Deze gegevens zullen, afhankelijk van het validatieniveau, later verschijnen in het certificaat. De belangrijkste gegevens zijn:

**1. Informatie over het bedrijf en de website die je wil voorzien van SSL, waaronder:**

| Common Name (CN)(e.g. *.voorbeeld.nlwww.voorbeeld.nlmail.voorbeeld.nl) | De fully qualified domain name (FQDN) van de server.         |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| Bedrijfsnaam (*Organization - O*)                            | De juridische naam van het bedrijf. Gebruik geen afkortingen en suffixen, zoals Inc., Corp. of LLC.Voor EV en OV SSL-certificaten wordt deze informatie geverifieerd door de CA en opgenomen in het certificaat. |
| Afdeling (*Organizational Unit - OU*)                        | De afdeling van het bedrijf dat verantwoordelijk is voor het certificaat. |
| Stad (*City/Locality - L*)                                   | De plaats waar het bedrijf gevestigd is. Deze mag niet worden afgekort. |
| Regio (*State/County/Region - S*)                            | De provincie/regio waar het bedrijf gevestigd is. Deze mag niet worden afgekort. |
| Land (*Country - C*)                                         | De code met twee letters voor het land waar het bedrijf gevestigd is. |
| E-mailadres                                                  | Een e-mailadres dat gebruikt mag worden om contact op te nemen met het bedrijf. |


**2. De public key die deel uitmaakt van het certificaat.** SSL maakt gebruik van een [public key](https://www.globalsign.com/nl-nl/ssl-informatiecentrum/what-is-public-key-cryptography) of asymmetrische cryptografie om de gegevens die worden verzonden tijdens een SSL-sessie te versleutelen. De public key wordt gebruikt om gegevens te versleutelen en de private key die hierop past wordt gebruikt om de gegevens te ontsleutelen.

**3. Informatie over het type en de lengte van de key.** De meest voorkomende keygrootte is RSA 2048, maar sommige CA's, waaronder GlobalSign, ondersteunen ook grotere keys (bv. RSA 4096+) of een andere type zoals ECC-keys.

## Hoe ziet een CSR er uit?

De CSR zelf wordt doorgaans gecreëerd in een op Base-64 gebaseerde PEM-indeling. Je kan het CSR-bestand openen met een eenvoudige teksteditor. Dit ziet er dan uit als volgt. Je moet wel zelf nog even de header en footer invoegen (-----BEGIN NEW CERTIFICATE REQUEST-----) wanneer je de CSR bij een bestelling gebruikt.

-----BEGIN NEW CERTIFICATE REQUEST-----MIIDVDCCAr0CAQAweTEeMBwGA1UEAxMVd3d3Lmpvc2VwaGNoYXBtYW4uY29tMQ8w DQYDVQQLEwZEZXNpZ24xFjAUBgNVBAoTDUpvc2VwaENoYXBtYW4xEjAQBgNVBAcT CU1haWRzdG9uZTENMAsGA1UECBMES2VudDELMAkGA1UEBhMCR0IwgZ8wDQYJKoZI hvcNAQEBBQADgY0AMIGJAoGBAOEFDpnOKRabQhDa5asDxYPnG0c/neW18e8apjOk 1yuGRk+3GD7YQvuhBVS1x6wkw1D2RnmnZgN1nNUK0cRK7sIvOyCh1+jgD7u46mLk 81j+b4YSEmYZGPLIuclyocPDm0hXayjCUqWt7z6LMIKpLym8gayEZzz9Gn97PsbP kVFBAgMBAAGgggGZMBoGCisGAQQBgjcNAgMxDBYKNS4xLjI2MDAuMjB7BgorBgEE AYI3AgEOMW0wazAOBgNVHQ8BAf8EBAMCBPAwRAYJKoZIhvcNAQkPBDcwNTAOBggq hkiG9w0DAgICAIAwDgYIKoZIhvcNAwQCAgCAMAcGBSsOAwIHMAoGCCqGSIb3DQMH MBMGA1UdJQQMMAoGCCsGAQUFBwMBMIH9BgorBgEEAYI3DQICMYHuMIHrAgEBHloA TQBpAGMAcgBvAHMAbwBmAHQAIABSAFMAQQAgAFMAQwBoAGEAbgBuAGUAbAAgAEMA cgB5AHAAdABvAGcAcgBhAHAAaABpAGMAIABQAHIAbwB2AGkAZABlAHIDgYkAk0kf HSkr4jsEVya3mgUoyaYMO456ECNZr4Cb+WhPgexfjOO5qwOG1oDOTaKycrkc5pG+ IPBQnq+4cotT8hWJQwpc+qGb8xUETpxCokhrhN5079vFXq/5dsHkmtOTwkSqSnz9 yruVoxYeDQ8jI3KG3HTgxwFto8oZnm+E+Y4oshUAAAAAAAAAADANBgkqhkiG9w0B AQUFAAOBgQAuAxetLzgfjBdWpjpixeVYZXuPZ+6jvZNL/9hOw7Fk5pVVXWdr8csJ 6JUW8QdH9KB6ZlM4yg8Df+vat1/DG6GuD2hiIR7fQ0NtPFBQmbrSm+TTBo95lwP+ ZSZTusPFTLKaqValdnS9Uw+6Vq7/I4ouDA8QBIuaTFtPOp+8wEGBHQ==
-----END NEW CERTIFICATE REQUEST-----

## Hoe genereer ik een Certificate Signing Request? 

Hoe je een eigen CSR genereert, is eigenlijk steeds afhankelijk van het platform dat je gebruikt. We concentreren ons hier op OpenSSL.

## Productie

Afhankelijk van je project kan het nodig zijn om een traditioneel SSL-certificaat aan te schaffen dat ondertekend is door een Certificate Authority. Als je bijvoorbeeld de webbrowser van iemand anders met je WebSocket-project wilt laten praten, heb je een traditioneel SSL-certificaat nodig.

## Bestandsformaten en bijbehorende extensies

Een SSL Certificaat kan verschillende bestandsformaten hebben. Welk bestandsformaat je nodig hebt voor een installatie hangt af van je omgeving. Soms is het hierdoor noodzakelijk een SSL certificaat voor installatie te converteren naar het juiste bestandsformaat voor uw omgeving. 

| **Extensie**                       | **Naam**                                                     | **Beschrijving**                                             |
| ---------------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| *.pem*                             | *Privacy-enhanced Electronic Mail*                           | Dit zijn bestanden die "-----BEGIN CERTIFICATE-----" en "-----END CERTIFICATE----- tags bevatten met als extensie .pem of .cert. Onder andere Apache en IIS webservers werken met PEM-bestanden. Het PEM formaat is een verfijning van de Base64 versleuteling, wat inhoudt dat elke regel 64 tekens lang is. Het wordt met name gebruikt in de UNIX/LINUX omgeving. Een enkel PEM bestand kan ook opgesplitst zijn in meerdere PEM bestanden, waarbij elk bestand een deel van het originele PEM bestand bevat.   De meeste CA's leveren hun certificaten in dit formaat. |
| *.cer*                             | *Canonical Encoding Rules*                                   | Een .cer bestand (kan ook .crt of .cert heten) bevat alleen het certificaat en niet de root en intermediate certificaten of de private key. Het zijn Base64 versleutelde ASCII-bestanden. De gecodeerde tekenreeks is ingesloten tussen de "----- BEGIN CERTIFICATE -----" en "----- END CERTIFICATE -----" tags.  Xolphin levert certificaten en bijgeleverde root en intermediate certificaten altijd met de bestandsextensie .crt. Ze zijn leesbaar als platte tekst met een simpele teksteditor, zoals Notepad (Kladblok). |
| *.der*                             | *Distinguished Encoding Rules*                               | Meestal wordt dit bestand ook als een .cer bestand weergegeven maar het kan voorkomen dat deze .der wordt genoemd. Een bestand met .der formaat bevat alleen het certificaat. Dit formaat ondersteunt geen opslag van de private key of de root en intermediate certificaten. Het verschil tussen .cer en .der zit in de restricties die zij opleggen aan de verzender. Bij .der staat de lengte van de code vast terwijl bij .cer het eindstuk van de code uitgelezen wordt en de lengte niet vaststaat en hier ook geen limiet aan gesteld wordt. Hierdoor is .der meer geschikt voor kortere gecodeerde bestanden en .cer voor grotere bestanden. |
| *.p7b / .p7c (PKCS #7 standaard)*  | *Cryptographic Message Syntax Standard*                      | PKCS#7 bestanden bevatten de "-----BEGIN PKCS7-----" en "-----END PKCS7-----" tags en hebben als extensie .p7b of .p7c. Bestanden met deze extensies bevatten zowel het certificaat als de root en intermediate certificaten. Dit soort bestanden kan door veel servers/firewalls worden gebruikt om alles in één keer te importeren, zodat je niet de root en intermediate certificaten afzonderlijk hoeft te importeren. .p7b bestanden bevatten echter nooit de private key. Veel platformen zoals Microsoft Windows en Java Tomcat (Keytool) ondersteunen dit bestandsformaat. .p7b is de tegenhanger van .pfx en .p12, met het verschil dat laatstgenoemden wél de private key kunnen bevatten. |
| *.pfx / .p12 (PKCS #12 standaard)* | *Personal Information Exchange Format*                       | Bestanden met deze extensies kunnen de public key (het SSL certificaat), de root en intermediate certificaten én de private key bevatten. Omdat deze bestandsformaten de private key bevatten moeten ze beveiligd worden met een wachtwoord. Deze formaten worden gebruikt om het certificaat én de private key te exporteren en importeren; bijvoorbeeld als deze gerepliceerd moeten worden naar diverse servers of om een backup te maken van het certificaat. Tegenhanger van .p7b, .p7c, .cer en .crt, die nooit de private key bevatten. |
| *.csr / p10(PKCS #10)*             | [*Certificate Signing Request*](https://www.sslcertificaten.nl/support/Terminologie/Certificate_Signing_Request_(CSR)) | Dit bestandstype wordt aangemaakt op de server om certificaataanvragen bij de Certification Authority (CA) in te dienen. De CSR kan base64 versleuteld worden en is ingesloten tussen de tags "----- BEGIN NEW CERTIFICATE REQUEST -----" en "----- END NEW CERTIFICATE REQUEST -----". |
| *.crl*                             | [*Certificate Revocation List*](https://www.sslcertificaten.nl/support/Terminologie/Certificate_Revocation_List_(CRL)) | De lijst met ingetrokken certificaten of CRL is een bestandstype dat identificeert of een certificaat is ingetrokken of niet. Deze bestanden worden geleverd door de CA's. De client browser zal tijdens het bezoeken van een website onder https gebruik maken van het CRL Distribution Points-veld in het certificaat om de CRL te downloaden. Let op: Niet alle certificaten hebben een CRL-distribution points-veld, zoals bijvoorbeeld een self-signed certificaat. Zodra de browser de CRL informatie van het server-certificaat krijgt, downloadt die het CRL-bestand en controleert de lijst om er zeker van te zijn dat het huidige certificaat geen onderdeel is van die lijst. De CA kan de CRL ter beschikking stellen voor download naar de browser via HTTP, FTP of een ander protocol. |
| *.key*                             | *Private Key*                                                | Deze bestandsindeling bevat de private key van het certificaat. Op Windows is er geen mechanisme beschikbaar voor het extraheren van de private key uit het certificaat, omdat dit niet nodig is. Met OpenSSL is het wel mogelijk om alleen de private key van het certificaat te extraheren. Als je het bestand in notepad opent, zie je dat het een Base-64 versleutelde tekenreeks is met de "----- BEGIN RSA PRIVATE KEY -----" en "----- END RSA PRIVATE KEY ----- " tags. De private key wordt tegelijkertijd aangemaakt met de CSR. |

## Development

De onderstaande commando's, ingevoerd in de volgorde waarin ze zijn opgesomd, genereren een zelfondertekend certificaat voor ontwikkelings- of testdoeleinden.

Als je wat tijd wilt besparen, voer dan **Generate-Certs** uit en het zal de certificaten genereren in minder dan een minuut. Ondersteunt Windows + Linux.

Als je liever de commando's invoert om de certificaten handmatig te genereren, dan vind je hieronder de lijst in volgorde.

## Certificate Authority

- Create CA private key

```bash
openssl genrsa -passout pass:qwerty -out ca-secret.key 4096
```

- Remove passphrase

```bash
openssl rsa -passin pass:qwerty -in ca-secret.key -out ca.key
```

- Create CA self-signed certificate

```bash
openssl req -new -x509 -days 3650 -subj '/C=BY/ST=Belarus/L=Minsk/O=Example root CA/OU=Example CA unit/CN=example.com' -key ca.key -out ca.crt
```

- Convert CA self-signed certificate to PFX

```bash
openssl pkcs12 -export -passout pass:qwerty -inkey ca.key -in ca.crt -out ca.pfx
```

- Convert CA self-signed certificate to PEM

```bash
openssl pkcs12 -passin pass:qwerty -passout pass:qwerty -in ca.pfx -out ca.pem
```

## SSL Server certificate

- Create private key for the server

```bash
openssl genrsa -passout pass:qwerty -out server-secret.key 4096
```

- Remove passphrase

```bash
openssl rsa -passin pass:qwerty -in server-secret.key -out server.key
```

- Create CSR for the server

```bash
openssl req -new -subj '/C=BY/ST=Belarus/L=Minsk/O=Example server/OU=Example server unit/CN=server.example.com' -key server.key -out server.csr
```

- Create certificate for the server

```bash
openssl x509 -req -days 3650 -in server.csr -CA ca.crt -CAkey ca.key -set_serial 01 -out server.crt
```

- Convert the server certificate to PFX

```bash
openssl pkcs12 -export -passout pass:qwerty -inkey server.key -in server.crt -out server.pfx
```

- Convert the server certificate to PEM

```bash
openssl pkcs12 -passin pass:qwerty -passout pass:qwerty -in server.pfx -out server.pem
```

## SSL Client certificate

- Create private key for the client

```bash
openssl genrsa -passout pass:qwerty -out client-secret.key 4096
```

- Remove passphrase

```bash
openssl rsa -passin pass:qwerty -in client-secret.key -out client.key
```

- Create CSR for the client

```bash
openssl req -new -subj '/C=BY/ST=Belarus/L=Minsk/O=Example client/OU=Example client unit/CN=client.example.com' -key client.key -out client.csr
```

- Create the client certificate

```bash
openssl x509 -req -days 3650 -in client.csr -CA ca.crt -CAkey ca.key -set_serial 01 -out client.crt
```

- Convert the client certificate to PFX

```bash
openssl pkcs12 -export -passout pass:qwerty -inkey client.key -in client.crt -out client.pfx
```

- Convert the client certificate to PEM

```bash
openssl pkcs12 -passin pass:qwerty -passout pass:qwerty -in client.pfx -out client.pem
```

## Diffie-Hellman key exchange

- https://nl.wikipedia.org/wiki/Diffie-Hellman-sleuteluitwisselingsprotocol
- Create DH parameters

```bash
openssl dhparam -out dh4096.pem 4096
```

