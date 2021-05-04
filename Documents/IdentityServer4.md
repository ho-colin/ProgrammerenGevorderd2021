Swagger

https://dotnettutorials.net/lesson/how-to-use-swagger-in-web-api/

https://www.c-sharpcorner.com/article/swagger-in-dotnet-core/

https://github.com/RicoSuter/NSwag

Postman

private key, public key openssl

udp, tcp, websockets

chat server on internet server

serilog

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\security.png)

Twee-weg authenticatie: een bankautomaat doet maar authenticatie in een enkele richting.

**Multifactorauthenticatie** (**MFA**) is een methode om de authenticiteit van een gebruiker te [verifiëren](https://nl.wikipedia.org/wiki/Authenticatie) op meer dan één enkele manier (met behulp van meerdere factoren). Door meerdere factoren te combineren kan de beveiliging bij [toegangscontrole](https://nl.wikipedia.org/wiki/Toegangscontrole) worden aangescherpt.

Dergelijke factoren bestaan doorgaans uit:[[1\]](https://nl.wikipedia.org/wiki/Multifactorauthenticatie#cite_note-1)

- iets dat de gebruiker **weet**, zoals een [wachtwoord](https://nl.wikipedia.org/wiki/Wachtwoord) of [pincode](https://nl.wikipedia.org/wiki/Persoonlijk_identificatienummer)
- iets dat de gebruiker **heeft**, zoals een pasje
- iets dat de gebruiker **is** (een eigenschap van de gebruiker), zoals een [vingerafdruk](https://nl.wikipedia.org/wiki/Vingerafdruk)

Extra mogelijke factoren:

- **Waar** de gebruiker is (locatie van de gebruiker): Bijvoorbeeld vanuit welk gebied de gebruiker toegang probeert te krijgen, of vanaf welk [IP-adres](https://nl.wikipedia.org/wiki/IP-adres).
- De **tijd**: Op welk tijdstip de gebruiker toegang probeert te krijgen.

Een welbekend voorbeeld van MFA is de [betaalkaart](https://nl.wikipedia.org/wiki/Betaalkaart) gecombineerd met een [pincode](https://nl.wikipedia.org/wiki/Persoonlijk_identificatienummer). Een pincode (*iets dat de gebruiker weet*) wordt gecombineerd met een pasje (*iets dat de gebruiker heeft*). Deze twee factoren maken dit voorbeeld tot two-factor-authenticatie (2FA). Het pasje is in dit voorbeeld voor een kwaadwillende derde onbruikbaar zonder de pincode en vice versa.

**Authenticatie in ASP .NET Core**

Authenticatie en autorisatie worden vaak in één adem genoemd en zijn in zekere zin ook onlosmakelijk aan elkaar verbonden. Toch hebben ze ieder hun specifieke verantwoordelijkheid. Met behulp van authenticatie kunnen gebruikers van een webapplicatie zich identificeren om toegang te krijgen tot de applicatie. Met autorisatie kunnen ze toegang krijgen tot specifieke functies en functionaliteit van een webapplicatie.

ASP.NET Core Identity is een zogenaamd membership system dat gebruikt wordt bij het bouwen van ASP.NET Core-webapplicaties, inclusief lidmaatschap, inloggen en gebruikersgegevens. ASP.NET Core Identity maakt het mogelijk om inlogfuncties toe te voegen aan een webapplicatie en maakt het eenvoudig om gegevens over de ingelogde gebruiker toe te passen.

ASP.NET Core Identity maakt authenticatie voor één enkele applicatie mogelijk. Het heeft zoals aangegeven redelijk wat features “out-of-the-box”. Wanneer je authenticatie op een meer gecentraliseerde en geïsoleerde manier wilt gebruiken voor meerdere client applicaties is het beter te kijken naar een token service met OAuth 2.0 and OpenID Connect implementatie zoals IdentityServer.

Hier wordt één van de manieren beschreven waarop binnen ASP.NET Core authenticatie kan worden geregeld met behulp van Identity Core.

De volgende items zullen aan de orde komen:

- Opzetten ASP.NET Core Identity framework (EF Core & migrations)
- Registratie van nieuwe gebruikers
- In-/uitloggen van gebruikers
- Account Lockout mechanisme
- Custom validatie naast de al in Identity aanwezige default validatie

# Opzetten ASP.NET Core Identity framework

Er bestaan in Visual Studio diverse templates die kunnen worden gebruikt bij het opzetten van een Identity Core framework. In alle gevallen is de basis een context die is afgeleid van IdentityDbContext. Dit is de base class voor de EF Core database context die gebruikt wordt voor Identity en waaraan het User objecttype wordt meegegeven:

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp1.png)

In de OnModelCreating methode kan een verdere configuratie van de objecten plaatsvinden zoals het verplicht maken van velden of het initiëren van de tabellen met bepaalde default data.

Daarnaast is in bovenstaande code snippet een DbSet aangemaakt die gebruikt gaat worden als IdentityUser object (en die is afgeleid van de IdentityUser base class).

Het registreren van de Identity DB context service en de setup voor het gebruik van (in dit geval) SQL Server gebeurt in de ConfigureServices methode van startup.cs:

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp2.png)

Na het uitvoeren van de diverse EF Core migration commando’s is er in SQL Server een Identity database aangemaakt met daarin een aantal standaard Identity tabellen (welke allemaal de prefix ‘AspNet’ hebben):

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp3.png)

In de volgende paragrafen zullen de betekenis en functie van diverse velden uit m.n. de AspNetUsers tabel verder aan de orde komen. Voor dit artikel zijn de volgende tabellen en hun onderlinge relatie van belang:

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp4.png)

Om de Identity Core functionaliteit beschikbaar te maken in de applicatie zijn tot slot twee zaken nodig in de startup.cs:

1. Het registreren van de services voor het ASP.NET Core Identity framework (in de ConfigureServices methode):
   ![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp5.png)

1. Het toevoegen van de authenticatie middleware (in de Configure methode):
   ![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp6.png)

# Registratie van nieuwe gebruikers

Om nieuwe Identity Users te registreren wordt gebruik gemaakt van de UserManager class. Deze class bevindt zich in de namespace Microsoft.AspNetCore.Identity en wordt d.m.v. dependecy injection in een controller geïnjecteerd:

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp7.png)

Om een nieuwe gebruiker te registreren is het noodzakelijk naast een gebruikersnaam en/of emailadres ook een wachtwoord op te geven. Met behulp van deze gegevens kan een gebruiker door de applicatie geauthentiseerd worden.

Er kan m.b.t. authenticatie gekozen worden voor de combinatie gebruikersnaam/wachtwoord of emailadres/wachtwoord. Wanneer voor de laatste optie wordt gekozen is het aan te raden tijdens het registreren van de services voor het ASP.NET Core Identity framework de optie mee te geven dat gevalideerd moet worden dat het emailadres van de nieuw toe te voegen Identity User uniek is (User.RequireUniqueEmail = true).

Voor de eerste optie geldt *by design* dat het Identity framework valideert dat de gebruikersnaam van de nieuw toe te voegen Identity User uniek is.

Registratie gebeurt vervolgens in een POST action in de controller:

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp8.png)

De return value van deze (async) functie is van het type IdentityResult en bevat een boolean flag Succeeded die aangeeft of de actie geslaagd is of niet. Indien de actie niet succesvol was bevat de property Errors de fout(en) die is/zijn opgetreden bij de CreateAsync actie.

Het wachtwoord wordt (indien de operatie succesvol was) volgens een hashing algoritme encrypted opgeslagen in de database. Daarnaast worden enkele velden automatisch gevuld zoals het NormalizedUserName en het NormalizedEmail veld.

# In-/uitloggen van gebruikers

Zoals aangegeven worden gebruikers geauthentiseerd op basis van een gebruikersnaam/wachtwoord of emailadres/wachtwoord combinatie. Het ASP.NET Core Identity framework biedt hiervoor twee mogelijkheden die ieder een verschillend doel dienen:

1. CheckPasswordAsync

Deze methode hasht het opgegeven wachtwoord en vergelijkt het met de bestaande wachtwoordhash (zoals dat bijvoorbeeld is opgeslagen in de database)

1. PasswordSignInAsync

Deze methode doet naast het controleren van het wachtwoord veel meer:

- Controleert of inloggen is toegestaan. Als de gebruiker bijvoorbeeld een bevestigde e-mail moet hebben voordat hij zich mag aanmelden, retourneert de methode Failed
- Roept UserManager.CheckPasswordAsync op om te controleren of het wachtwoord correct is. Wanneer een mislukte inlogpoging (wachtwoord is niet correct en de Lockout optie is enabled) het geconfigureerde maximum aantal mislukte aanmeldingspogingen overschrijdt wordt het account van de gebruiker geblokkeerd
- Als de optie two-factor authentication is ingeschakeld voor de gebruiker, stelt deze methode de cookie in en retourneert TwoFactorRequired
- Maakt een ClaimsPrincipal aan en persisteert dit via een cookie

 

Wanneer bevestigde e-mails en lockout geen vereiste zijn dan volstaat het om de CheckPasswordAsync methode uit de UserManager class te gebruiken. De SignInManager class is gekoppeld aan de cookie-authenticatie.

De volgende code snippet toont een manier om door middel van emailadres/wachtwoord combinatie authenticatie van een gebruiker te doen:

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp9.png)

Analoog aan bovenstaande code snippet kan een gebruiker worden geauthentiseerd via zijn/haar gebruikersnaam.

In de volgende paragraaf wordt uitgebreider ingegaan op het Lockout mechanisme waarmee restricties kunnen worden gesteld aan het aantal pogingen dat een gebruiker mag doen om zichzelf bij een applicatie te authentiseren.

# Account Lockout mechanisme

Het ASP.NET Core Identity framework biedt standaard een aantal belangrijke beveiligingsfuncties die het authenticatieproces van extra checks te voorzien. Denk hierbij aan:

- Two-Factor Authentication (met behulp van SMS of email)
- Account Lockout
- Account Confirmation

Account Lockout is een belangrijke functie van het ASP.NET Core Identity framework. Het blokkeert het account van de gebruiker als deze een bepaald aantal keren een verkeerd wachtwoord invoert. Dit kan worden gespecificeerd door het maximale aantal mislukte pogingen (default 5x) en de lockout-tijd (default 5 minuten) te configureren in startup.cs:

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp10.png)

De volgende code snippet toont het gebruik van het Lockout mechanisme: een mogelijkheid om het aantal inlogpogingen te beperken tot een opgegeven maximum. Zoals in de vorige paragraaf aangegeven is het hiervoor noodzakelijk gebruik te maken van de SignInManager.PasswordSignInAsync methode. Door de parameter lockoutOnFailure te activeren (true), wordt de lockout-functionaliteit ingeschakeld.

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp11.png)

# Custom validatie

Naast de standaard al aanwezige validatie in het ASP.NET Core Identity framework is het mogelijk eigen validatie toe te voegen zoals bijvoorbeeld het controleren op emaildomein of het uitsluiten van de mogelijkheid dat gebruikersnaam en wachtwoord identiek zijn. De volgende code snippets tonen enkele mogelijke custom validatie’s.

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp12.png)

Het opnemen van de (extra) custom validatie’s gebeurt in startup.cs:

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\asp13.png)

![ASP.NET auth.gif](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\ASP.NET_auth.gif)



![IdentityServerImage.jpg](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\IdentityServerImage.jpg)

Applicaties op een correcte manier beveiligen wordt er niet gemakkelijker op, terwijl het nochtans enorm belangrijk is. Of het nu gaat over een mobiele applicatie, een webapplicatie of een desktopapplicatie die binnen de muren van uw bedrijf leeft, steeds weer blijkt dat de oude manieren van beveiligen niet meer volstaan. 

Vandaag zijn OpenID Connect en OAuth 2.0 dé standaarden om op een correcte, veilige manier authenticatie en autorisatie af te handelen. IdentityServer is de facto de standaardoplossing binnen de .NET-wereld om dit tot een goed einde te brengen.

## Waarom IdentityServer?

IdentityServer is hét OpenID Connect en OAuth 2.0 framework voor .NET. IdentityServer gebruiken als Identity Provider (IDP) en Authorization Server (AS) zorgt ervoor dat al uw applicaties op een gestandaardiseerde en bewezen manier beveiligd worden. Bovendien is IdentityServer deel van de .NET Foundation.

#### Eén IDP, alle applicatietypes en API’s

IdentityServer kan gebruikt worden om mobiele applicaties, webapplicaties (onder andere ASP.NET, ASP.NET Core en Angular) en desktopapplicaties op een uniforme manier van authenticatie te voorzien. Daarnaast staat IdentityServer eveneens in voor de beveiliging van APIs die door die applicaties gebruikt worden. IdentityServer kan ook gebruikt worden om uw APIs veilig open te stellen aan externe partijen.

#### Single Sign On

Als er meerdere applicaties aan gebruikers aangeboden worden, wilt u niet dat de gebruiker bij elke applicatie opnieuw moet inloggen. IdentityServer ondersteunt dit principe out of the box, overheen verschillende applicatietypes. Bovendien zorgt dit ervoor dat de authenticatielogica op één plaats geconcentreerd is, in plaats van verspreid overheen applicaties.

#### Federation Gateway en Social Login

IdentityServer kan integreren met andere IDP’s overheen verschillende protocollen. Zo kunt u een federatie opzetten met uw eventuele zusterbedrijven, maar ook met Azure AD, Google, Facebook, Microsoft, ... Al deze logica bevindt zich op het niveau van IdentityServer, zodat u hier op applicatieniveau niets extra voor moet implementeren.

#### Customisatie

IdentityServer kan volledig aangepast worden aan de noden van uw bedrijf. Dit gaat over de gebruikersinterface, maar ook over integratie met allerhande user stores, van uw eigen gebruikersdatabank tot integratie met Active Directory. Bovendien kunnen verschillende manieren van authentiseren ingebouwd worden, van gebruikersnaam/wachtwoord tot en met 2-factorauthenticatie met een smartphone.

#### Snelheid van implementatiestandaarden

Binnen IT beweegt alles net iets sneller dan in de gewone wereld, en als er één domein is dat misschien wel het snelst van al beweegt, dan is het alles gerelateerd aan security. Wekelijks duiken nieuwe problemen op en op regelmatige basis worden nieuwe standaarden ontwikkeld om die problemen op te lossen. Het is dan ook van groot belang dat een Identity Provider deze standaarden snel en correct implementeert. IdentityServer staat bekend als een van de snelste en correcte implementators van deze nieuwe standaarden. Bovendien is IdentityServer volledig open source, wat betekent dat de code met argusogen door honderden experts bekeken kan worden.

Probleem: IdentityServer evolueert voorlopig niet meer ... de auteurs startten een commerciele oplossing.

# API Gateway or API Middleware

![img](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\68747470733a2f2f74687265656d616d6d616c732e636f6d2f696d616765732f6f63656c6f745f6c6f676f2e706e67)

https://github.com/ThreeMammals/Ocelot







We beveiligen .Net 5 microservices met behulp van standalone Identity Server 4 en backing met Ocelot API Gateway. 

We gaan onze ASP.NET Web MVC en API applicaties beveiligen met behulp van OAuth 2 en OpenID Connect in IdentityServer4. 

Het beveiligen van je web applicatie en API met tokens, het werken met claims, authenticatie en autorisatie middlewares en het toepassen van policies, enzovoorts.



Movies.API
Allereerst gaan we het Movies.API project ontwikkelen en deze API bronnen beveiligen met IdentityServer4 OAuth 2.0. Genereer JWT Token met client_credentials van IdentityServer4 en gebruik deze token voor het beveiligen van Movies.API beschermde bronnen.

Movies.MVC
Daarna gaan we het Asp.Net project Movies.MVC ontwikkelen voor de interactieve client van onze toepassing. Deze interactieve Movies.MVC-clienttoepassing wordt beveiligd met OpenID Connect in IdentityServer4. Onze client applicatie geeft credentials met logging door aan een Identity Server en ontvangt een JSON Web Token (JWT) terug.

Identity Server
We gaan ook een gecentraliseerde standalone Authenticatieserver en Identiteitsprovider ontwikkelen door het IdentityServer4 pakket te implementeren en de naam van de microservice is Identity Server. Identity Server4 is een open source framework dat OpenId Connect en OAuth2 protocollen implementeert voor .Net Core. Met Identity Server kunnen we authenticatie en toegangscontrole bieden voor onze webapplicaties of Web API's vanuit een enkel punt tussen applicaties of op gebruikersbasis.

Ocelot API Gateway
Tenslotte gaan we Ocelot API Gateway integreren en beveiligde beschermde API bronnen over de Ocelot API Gateway maken met het overbrengen van JWT web tokens. Zodra de client een bearer token heeft, zal deze het API endpoint aanroepen dat door Ocelot wordt aangestuurd. Ocelot werkt als een reverse proxy. Nadat Ocelot het verzoek heeft omgeleid naar de interne API, zal het het token presenteren aan de Identity Server in de autorisatie pijplijn. Als de client geauthoriseerd is zal het verzoek verwerkt worden en een lijst met films zal teruggestuurd worden naar de client.

Ook over dit plaatje hebben we de claim gebaseerde authenticaties toegepast.

Installatie
Volg deze stappen om uw ontwikkelomgeving op te zetten:

Controleer Alle projecten draaien profielen. Klik één voor één met de rechtermuisknop op het projectbestand, open het venster Eigenschappen en controleer de debugsectie. Launch Profile moet het "Project" zijn en App URLs moeten hetzelfde zijn als de grote afbeelding.
Voor alle projecten, één voor één, Stel een Startup project in en zie het Run profiel op de Run knop. Verander het standaard run profiel in IIS Express naar Project naam.
Meerdere opstart projecten. Klik met de rechtermuisknop op de oplossing, open Eigenschappen, en stel Meervoudig opstartproject in en Start alle 4 de toepassing klik op toepassen en ok.
Nu kunt u de gehele toepassing uitvoeren met Klik Start knop of F5. U ziet 4 project console venster en 1 chrome venster voor client-toepassing.
Movies.Client -> https://localhost:5002/
Controleer de toepassing met het aanmelden van het systeem met onderstaande referenties;

gebruikersnaam - wachtwoord 1 : alice - a1
gebruikersnaam - wachtwoord 2 : bob - b1









Je kunt zien dat we 4 microservices hebben die we één voor één gaan ontwikkelen. Begin met Movies.API

Allereerst gaan we het Movies.API project ontwikkelen en deze API bronnen beschermen met IdentityServer4 OAuth 2.0 implementatie.

Genereer JWT Token met client_credentials van IdentityServer4 en zal dit token gebruiken voor het beveiligen van Movies.API beschermde bronnen.

Daarna gaan we het Movies.MVC Asp.Net project ontwikkelen voor de interactieve client van onze toepassing.

Deze interactieve Movies.MVC client-toepassing zal worden beveiligd met OpenID Connect in IdentityServer4.

Onze client applicatie geeft referenties met logging door aan een Identity Server 4

en ontvangt een JSON Web Token (JWT) terug.

En natuurlijk IdentityServer, Ook gaan we gecentraliseerde standalone Authenticatie Server ontwikkelen

en Identity Provider met het implementeren van IdentityServer4 pakket en de naam van microservice is Identity Server.

Identity Server4 is een open source framework dat OpenId Connect en OAuth2 protocollen implementeert voor .Net Core.

Met IdentityServer kunnen we authenticatie en toegangscontrole bieden voor onze web applicaties of Web API's vanuit

een enkel punt tussen applicaties op een gebruiker basis.

Tenslotte gaan we Ocelot API Gateway ontwikkelen en beveiligde API bronnen maken over de Ocelot API

over de Ocelot API Gateway met het overbrengen van JWT web tokens.

Zodra de client een bearer token heeft, zal het het API endpoint aanroepen dat door Ocelot wordt fronted.

Ocelot werkt als een reverse proxy.

Nadat Ocelot het verzoek heeft omgeleid naar de interne API, presenteert het het token aan de Identity Server in de autorisatie pijplijn. Als de client geautoriseerd is, wordt het verzoek verwerkt en wordt een lijst met films teruggestuurd naar de client.

Over dit plaatje, hebben we ook de claim-gebaseerde autorisatie en authenticaties toegepast.

Laten we onze project code structuur controleren in de visual studio solution explorer venster.

Dit is de ons project code structuur van de visual studio solution explorer venster. U kunt de 4 Asp.Net Core microservices projecten zien die we hadden gezien op het algemene beeld.

Als we het project een voor een uitbreiden, zult u zien dat Movies.API, Movies.API is een asp.net core web api project dat omvat

die ruwe api operaties bevat.

En we hebben Movies.MVC

Client Applications, Movies.MVC is een asp.net core MVC web applicatie project dat Movies.API project verbruikt

en de gegevens weergeeft.

En we hebben natuurlijk, IdentityServer is een standalone Identity Provider voor onze architectuur.

En tenslotte hebben we een API Gateway Project, APIGateway is een api gateway tussen Movies.MVC en Movies.API.

Dus laten we onze applicatie draaien en zien wat er gebeurd

Zoals u kunt zien, draaien we alle 4 de microservices in de project console mode. We kunnen de logs van de console zien.

Alleen het MVC Web applicatie project draait in chrome.

Dus als je op de Movies link klikt, wordt je doorgestuurd naar de IS4 login pagina om te verbinden

met OpenId en een token te krijgen. Na het inloggen van het systeem,

Laat me inloggen in het systeem.

Ja, dit verzoek zal door de API Gateway gaan en een verzoek sturen naar Movies.API met een token

met een token en retourneert de Movie lijst op de pagina.



Postman Collectie

En we hebben een postman collectie die api verzoeken heeft naar alle toepassingen. 

GET-POST-PUT-DELETE ruwe operaties

Get Movies From Api Gateway

POST-PUT en DELETE operaties

Get Discovery Document

Get Token

![image-20210428153906615](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\image-20210428153906615.png)

![image-20210428153935025](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\image-20210428153935025.png)



https://jwt.io

![image-20210428160048559](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\image-20210428160048559.png)

![image-20210428160135642](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\image-20210428160135642.png)

![image-20210428160322184](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\image-20210428160322184.png)



![image-20210428160506223](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\IdentityServer4\image-20210428160506223.png)