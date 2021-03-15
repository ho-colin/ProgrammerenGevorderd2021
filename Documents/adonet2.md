## Het 3-tier model

Het spreekt voor zich dat wanneer een applicatie groter wordt, de complexiteit toeneemt. Het goed organiseren van de code is van groot belang om:

- de code overzichtelijk te houden en gemakkelijk terug te vinden
- efficiënt samen te werken met andere programmeurs
- makkelijker fouten weg te werken
- alle functionaliteit eenmalig te coderen
- …

De voordelen van het lagenmodel zijn dan ook:

- onderhoudbaarheid
- schaalbaarheid
- flexibiliteit
- beschikbaarheid.

Het 3-tier model is een veelgebruikt model om de code gestructureerd en overzichtelijk te organiseren met een duidelijke aanpak. Bij het hanteren van het 3-tier model wordt de applicatie onderverdeeld in 3 aparte lagen, namelijk de presentatielaag, de business-laag (of ook: het domeinmodel) en de data-laag.

[![Database: Het 3-Tier model](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\3TierModel.jpg)](http



De **presentatielaag** of **GUI** is de bovenste laag. Deze laag bestaat uit de pagina’s die de gebruiker kan zien aan de buitenkant van het systeem, namelijk de lay-out van de webpagina’s en de navigatie.

De **business-laag** zorgt voor de verbinding met de ander lagen en bevat alle programmeerlogica, objecten en methoden. Tijdens de uitvoering van het programma wordt de invoer van de gebruikers opgeslagen in de objecten en worden de businessregels toegepast.

De **datalaag** of **persistence manager** verbindt de toepassing met de databank. Hierin staat de code die gegevens ophaalt uit de database en die bewerkingen uitvoert op de database. Enkel de datalaag bevat de SQL-code. SQL (Structured Query Language) is een opdrachttaal voor het invoeren, wijzigen, verwijderen, raadplegen en beveiligen van gegevens in een relationele databank.

