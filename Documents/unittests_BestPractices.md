

## Best Practices

### Inleiding

Ontwikkelaars hebben vaak een liefde-haat-verhouding tot het werken met unit tests. Visual Studio biedt uitstekende ondersteuning, maar vaak blijkt de stap om met het opzetten van testen te starten, te groot, hoe minimaal deze ook is. De voordelen zijn nochtans, bij uitstek na verloop van tijd, heel groot. Je kan met gerust gemoed drastischer codewijzigingen doorvoeren: de set unit tests toont waar je fouten maakte. Door te starten met unit tests op je business laag kan je snel tot een applicatie komen die iets lijkt te doen wat in de goede richting ligt.

De volledige voorbeeldocde voor dit onderdeel "Best Practices" vind je in 

### AAA Concept

Een benadering die veel gebruikt wordt door de industrie en die je toelaat unit tests te schrijven volgens een herhaalbaar en inzichtelijk patroon. Vaak wordt boven de AAA-delen in commentaar het onderdeel vermeld:

// Arrange
    - initialiseer een class, mock een interface (zie een latere walkthrough)
// Act
    - we ageren op de opzet en roepen de te testen code op.
// Assert
    - we "bevestigen" dat het resultaat van de opgeroepen code gelijk is aan wat we verwachten

### Naming Convention

Het is een goed idee om in de naam van de unit test aan te geven wat er getest wordt. Er zijn vele "naming conventions" maar een goede is bijvoorbeeld:
    - de naam van de method die getest wordt (bijvoorbeeld *Reverse*)
    - gevolgd door een korte beschrijving van het test scenario (bijvoorbeeld *ShouldThrowArgumentException*)
    - gevolgd door de verwachting van het scenario (bijvoorbeeld *IfWordIsNull*)
    - waarbij elk onderdeel gescheiden wordt door een underscore

```csharp
public void Reverse_ShouldThrowArgumentException_IfWordIsNull()
{
	...
}
```

## Beschikbare Assert methods

De vergelijking bij Assert methods houdt rekening met het gegevenstype: 10L (long) is bijvoorbeeld verschilllend van 10 (int). Naast de AreEqual() method, bestaan er nog vele andere. Probeer altijd de meest geschikte te gebruiken in functie van leesbaarheid en onderhoudbaarheid.

- **AreNotEqual()**: wanneer we wensen te verifieren dat twee objecten NIET gelijk zijn (de andere "Niet" methods bespreken we verder hier niet meer)
- **AreSame()**: controleert of twee objecten naar hetzelfde object verwijzen (vergelijkt met ==).
- **Equals()**: vergelijkt twee objecten met de Equals() method.
- **Fail()**: veroorzaakt het falen van de test; meestal gebruikt met een voorwaarde en optionele parameters zoals de foutmelding en parameters.
- **Inconclusive()**: vergelijkbaar met Fail(), maar wijst op het niet beslist zijn van de test.
- **IsFalse()**: verifieert of een uitdrukking False is.
- **IsInstanceOfType()**: verifieert of een object een instantie van de specifieke class is.
- **IsNull()**: verifieert dat de waarde null is.
- **IsTrue()**: verifieert dat een uitdrukking True is.
- **ReplaceNullChars()**: vervangt null karakters ("\0") door "\\0". Veel gebruikt bij feedback.
- **ThrowsException()**: voert de opgegeven delegate uit en verifieert of er wel een uitzondering opgeworpen wordt van het type dat als generiek argument is meegegeven. Van deze method bestaat ook een asynchrone versie die noemt ThrowsExceptionAsync().

Opgelet: de ReferenceEquals() method is een method die op alle classes bestaat en is geen inderdeel van deze set Assert() methods.

## Initialisatie en opkuis

Wanneer je methods van een class test, kan het gebeuren dat je de class meermaals wenst te initialiseren, namelijk net voor de uitvoering van elke test. Hiervoor kan je het [TestInitialize] attribuut in MSTest (of ([SetUp] in NUnit of de constructur xUnit.NET) gebruiken.

Zo kunnen we ook gebruik maken van het [TestCleanup] attribuut in MSTest ([TearDown] in NUnit of een implementatie van de IDisposable interface in xUnit.NET) om objecten op te kuisen wanneer alle testen uitgevoerd zijn.

In het voorbeeld hieronder, waarin we vooruit lopen op volgende les, schrijven we de initialisatie slechts eenmaal en een instantie van de class zal opgezet worden elkens voor elke test uitgevoerd wordt:

```csharp
ILogger _log;
IWordUtils _wordUtils;

[TestInitialize]
public void Initialize()
{
	_log = Mock.Of<ILogger<WordUtils>>();
	_wordUtils = new WordUtils(_log);
}

[TestMethod]
public void Reverse_ShouldBeWordInReverse_IfWordIsValid()
{
	string word = "mountain";
	string reverseWord = _wordUtils.Reverse(word);
	reverseWord.ShouldBe("niatnuom");
}

[TestCleanup]
public void Cleanup()
{
	// Optionally dispose or cleanup objects
	...
}
```

