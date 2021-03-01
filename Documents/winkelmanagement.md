# Opdracht: winkelmanagement met events

## Inleiding

Een klant vraagt je om een applicatie te bouwen waarbij de verkoop in een winkel wordt opgevolgd door de verkoopafdeling en het magazijn. 

## Ontwerp: class diagram

![class diagram](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\winkelmanagement2.png)

## Detailinformatie

De producten die verkocht worden, worden beschreven door middel van een enumeratie:

```csharp
public enum ProductType { Dash, Leffe, ToiletPapier, Nespresso };
```

Wanneer een product verkocht wordt, noemen we dat een **Bestelling** en deze bevat volgende informatie (we tonen de signatuur van de constructor):

```csharp
public Bestelling(ProductType product, decimal prijs, int aantal, string adres)
```

Maak een klasse **Winkel** die enkel een methode heeft om producten te verkopen:

```csharp
w.VerkoopProduct(new Bestelling(ProductType.Leffe, 50, 25, "Moerbeekstraat 25 - Geraadsbergen"));
w.VerkoopProduct(new Bestelling(ProductType.Nespresso, 50, 25, "Moerbeekstraat 25 - Geraadsbergen"));
w.VerkoopProduct(new Bestelling(ProductType.ToiletPapier, 100, 50, "Stationsstraat 10 - Zottegem"));
w.VerkoopProduct(new Bestelling(ProductType.Nespresso, 10, 95, "Moerbeekstraat 25 - Geraadsbergen"));
```

Maak een klasse **Verkoopafdeling**. Deze beheert een inventaris van alle geplaatste bestellingen en biedt een methode aan om deze te rapporteren (via *Console.WriteLine()*). Bestellingen worden bijgehouden per klant: de klant wordt geïdentificeerd aan de hand van zijn/haar adres.

Maak een klasse **Stockbeheer** die voor elk product bijhoudt hoeveel er in stock is: we initialiseren de stock van elk product op 100. Telkens wanneer een bestelling aangemaakt wordt, moet de stock aangepast worden. Wanneer de stock van een bepaald product onder een minimumgrens valt, in dit geval 25, moet de groothandelaar geïnformeerd worden zodat een bestelling geplaatst wordt om de stock aan te vullen. De klasse Stockbeheer voorziet een methode om de stock aan te vullen en een methode om de stock te rapporteren (via *Console.WriteLine()*).

Maak een klasse **Groothandelaar**: deze houdt een lijst bij van alle bestellingen die geplaatst worden en biedt een methode aan om de laatste bestelling op te vragen en een methode om alle bestellingen te rapporteren (via Console.WriteLine()).

Stockbeheer en Verkoopafdeling schrijven zich in op het event WinkelEventArgs; dit event wordt opgeroepen bij het plaatsen van een bestelling. Groothandelaar schrijft zich in op het event StockbeheerEventArgs dat aangeboden wordt door Stockbeheer.

**Maak een bibliotheek voor je business code en een aparte Console App.** 

## Voorbeeld

Bij elke verkoop worden drie rapporten afgedrukt: dat van de verkoopafdeling, groothandelaar en stockbeheer. Na de laatste verkoop zien deze rapporten er als volgt uit:

![uitvoer](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\winkelmanagement3.png)



