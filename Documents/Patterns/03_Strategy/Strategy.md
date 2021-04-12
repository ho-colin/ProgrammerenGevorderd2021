# Choosing

Het 'Strategy' pattern is een patroon dat behoort tot de categorie *Behavioral* of *Gedrag*. Bij het Strategy pattern kun je wisselen van de ene implementatie naar een andere implementatie door het gebruik van een 'interface'. Je ziet: weerom is het begrip interface zeer belangrijk!

Concrete voorbeelden waarbij het Strategy pattern van pas komt, zijn:

- het maken van een rekenmachine waarbij elke operatie (+, -, * , /) een eigen uitvoering heeft op de invoer.
- het sorteren van lijsten waarbij verschillende implementaties mogelijk zijn (denk aan QuickSort, MergeSort en andere vormen).
- Andere situaties waarbij een *strategy* of *policy*) bepaalt welk algoritme of techniek gebruikt moet worden op tot een oplossing te komen.

Hieronder bootsen we een webwinkel na. Deze is een zeer minimalistische nabootsing van de 'Steam Store', bij gamers niet geheel onbekend. Als je hier een product aanschaft, kan je deze betalen met IDeal, PayPal, Visa en nog wat andere veelvoorkomende betaalsystemen. Daarnaast heb je binnen Steam ook een eigen 'Wallet'. Hier kun je zo nu en dan geld op zetten waarmee je dan vervolgens kan betalen.

Tijdens deze demo maken we alleen de implementatie van 'Wallet' en van PayPal om te kunnen afrekenen.

Om te beginnen maken we een nieuw .Net Core project, we gaan weer aan de slag met een simpele Console applicatie.

1: Start VS2019 en ga naar File > New Project > Visual C# en kies hier vervolgens .NET Core > Console Application .NET Core.

2: Geef het project een naam en selecteer een eigen gekozen locatie om het project op te slaan.

3: Je hebt nu een lege console applicatie. Je kunt testen of dit werkt door in 'Program.cs' de volgende code te schrijven in de 'Main' methode;

````Csharp
public static void Main(string[] args)
{
    Console.ReadKey();
}
````

4: Druk op F5 om de applicatie te starten en je ziet een Console venster draaien. Door een willekeurige toets wordt deze weer afgesloten.

Oke nu we een standaard .Net applicatie hebben, kunnen we beginnen met het maken van de classes. Om alvast een start te maken kun je al de map 'Interfaces' en 'Models' maken.

5: Maak in de map 'Models' een class met de naam 'Product'. Maak deze abstract en laat deze een 'Price' van het type 'int' retourneren. Zorg ervoor dat het 'Price' veld (of property) protected is en de methode om hem te benaderen publiek.

````csharp
public abstract class Product
{
    protected int Price { get; set; }

    public int GetPrice()
    {
        return Price;
    }
}
````

6: Maak vervolgens 3 nieuwe 'Product' classes: 'Game', 'Poster' en 'Sticker'. Zorg ervoor dat deze zijn afgeleid van 'Product' en dat de prijs wordt gezet in de constructor. Hier een klein voorbeeld van de 'Game' class.

````csharp
public class Game : Product
{
    public Game(int price)
    {
        this.Price = price;
    }
}
````

7: Nu we de producten hebben kun je aan de slag met een 'ShoppingCart'. Maak een nieuwe class genaamd 'Cart' en laat deze een lijst (List) bewaren van 'Product' objecten. Instantieer de lijst in de constructor van 'Cart'.

8: Maak vervolgens een methode 'AddProduct' met als parameter een object van het type 'Product'. Laat deze methode het object toevoegen aan de lijst.

9: Maak als laatste een methode om de lijst te legen, genaamd 'ClearCart':

````csharp
 public class Cart
{
    private List<Product> _items;

    public Cart()
    {
        _items = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _items.Add(product);
    }

    public void ClearCart()
    {
        _items.Clear();
    }
}
````

Nu we de start van ons model klaar hebben, kunnen we beginnen aan de eerste 'Strategy'. We beginnen eerst met het maken van een interface en vervolgens met de 'Wallet' strategy.

10: Maak een interface in de 'Interfaces' map met de naam 'IPaymentStrategy'.

11: Zorg er voor dat deze een methode van het type 'void' heeft genaamd 'Pay'.

12: Maak nu een class met de naam 'WalletStrategy' in de root map. Zorg ervoor dat deze de IPaymentStrategy implementeert.

13: Laat 'Pay' methode een simpele string retourneren naar de Console met Console.WriteLine().

14: Maak vervolgens een PaypalStrategy class en laat deze ook de IPaymentStrategy implementeren.

15: Zorg er hier ook voor dat de Pay methode een lijn naar de Console schrijft. Als voorbeeld zie je hieronder de IPaymentStrategy en WalletStrategy.

````csharp
public interface IPaymentStrategy
{
    void Pay();
}

public class WalletStrategy : IPaymentStrategy
{
    public WalletStrategy() { }
    
    public void Pay()
    {
        Console.WriteLine("Paid using In-Game Wallet.");
    }
}
````

Nu we onze 2 *basic* 'Strategies' hebben. Kunnen we het geheel in werking zien. Het is belangrijk dat de Cart een afrekeningsmethode krijgt en daarbij gebruik maakt van een van de strategies.

16: Open 'Cart.cs' en maak een nieuwe methode met de naam 'MakePayment' en geef deze een parameter van het type IPaymentStrategy. Hierdoor kan zowel de WalletStrategy als PaypalStrategy worden gebruikt.

````csharp
public void MakePayment(IPaymentStrategy paymentStrategy)
{
    paymentStrategy.Pay();
}
````

17: Ga vervolgens naar 'Program.cs' en maak een instantie van 'Cart'.

18: Voeg 3 of 4 producten toe aan de ShoppingCart.

````csharp
Cart shoppingCart = new Cart();
shoppingCart.AddProduct(new Game(50));
shoppingCart.AddProduct(new Game(15));
shoppingCart.AddProduct(new Sticker(5));
shoppingCart.AddProduct(new Poster(10));
````

19: Schrijf vervolgens twee regels waarbij je de 'MakePayment' methode aanroept met een nieuwe instantie van de PaypalStrategy en WalletStrategy.

20: Druk vervolgens op F5 en je ziet 2 lijnen verschijnen in de Console. namelijk 'Paid using Paypal.' (of een eigen gekozen zin) en 'Paid using In-Game Wallet.'.

**EXTRA**: voor gevorderen ... . We maken de uitdaging wat groter:

- Voeg een gebruikersnaam en wachtwoord toe aan de PayPalStrategy. Je kunt nu een 'test' Login methode maken om te controleren of de gebruiker is ingelogd en mag betalen.
- Voeg een budget toe aan de WalletStrategy. Als de totaalprijs nu meer is dan het budget, kan de Wallet de transactie niet voltooien.
- Voeg een gebruikersnaam toe aan de WalletStrategy.
- Over totaalprijs gesproken: maak een methode in 'Cart' die alle 'Price' van de verschillende producent bij elkaar op telt. Dit kan eenvoudig met Linq:

````csharp
var total = _items.Sum(x => x.GetPrice());
return total;
````

- Zorg ervoor dat de 'Pay' methode nu een 'int' met een totaalprijs kan ontvangen/gebruiken.
- Als laatste zou je de 'MakePayment' methode iets meer logica kunnen laten bevatten die maakt dat er eerst geprobeerd wordt te betalen met de Wallet en dan vervolgens bij ontoereikend budget toch de PaypalStrategy gebruikt.

**Stuur je oplossing in als antwoord op de opdracht en je ontvangt automatisch een werkende versie.**
