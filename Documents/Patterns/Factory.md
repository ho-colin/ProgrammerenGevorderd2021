# Creating a Factory

Factory is een **'creational' pattern**. In objectgeoriënteerde programmeertalen is het factory-ontwerppatroon een manier om objecten te instantiëren zonder exact vast hoeven te leggen van welke klasse deze objecten zullen zijn. De factory is een 'method' die een ontwikkelaar in staat stelt objecten te creeeren. Om voorbeelden te geven:

In dit patroon wordt een methode (de factory-methode) gebruikt die door subklassen geïmplementeerd kan worden. De klasse van het object dat door die methode geïnstantieerd wordt, implementeert een bepaalde interface. Elk van de subklassen kan vervolgens bepalen van welke klasse een object wordt aangemaakt, zolang deze klasse maar die interface implementeert.
Een factory 'method' is het beste in te zetten indien alle potentiele 'classes' zijn afgeleid van eenzelfde *super class*. Ook als je van tevoren nog niet weet welk object geinstantieerd moet worden, kan het gebruik van een factory het ontwikkelen vergemakkelijken.

Het doel van dit ontwerppatroon is het vereenvoudigen van het onderhoud van het programma. Als er nieuwe subklassen nodig zijn dan hoeft men alleen een nieuwe factory-methode te implementeren.

Een **voorbeeld** zal dit het meest duidelijk maken.

We starten met een simpele .Net Core console applicatie.

1: Start VS2019 en ga naar **File > New Project > Visual C#** en kies hier vervolgens **.NET Core > Console Application .NET Core**.

2: Geef het project een naam en selecteer een eigen gekozen locatie om het project op te slaan.

3: Je hebt nu een lege console applicatie. Je kunt testen of dit werkt door in 'Program.cs' de volgende code te schrijven in de 'Main' method:

````Csharp
public static void Main(string[] args)
{
    Console.ReadKey();
}
````

4: Druk op F5 om de applicatie te starten en je ziet een Console venster draaien. Door een willekeurige toets wordt deze weer afgesloten.

Nu begint het echte werk ... We zullen een Factory method maken voor een email-applicatie. Hierbij kunnen we een mail opstellen (niet inbegrepen) om vervolgens te kunnen verzenden naar een 'Recipient'. Deze kan bestaan uit 3 types, namelijk standaard, CC en BCC. We starten met het maken van een paar verschillende 'classes' en breiden deze vervolgens uit.

5: We maken folder 'Models'. In deze folder komt het model.

6: Maak een bestand aan met de naam Recipient.cs en maak de Recipient class 'abstract'. Geef de klasse een 'string' met de naam 'address' en zorg dat deze publiekelijk toegankelijk is. Als het goed is, ziet Recipient.cs er ongeveer zo uit:

````Csharp
public abstract class Recipient
{
    protected string address = "undefined";
    public string Address => address;
}
````

7: Maak nu 3 nieuwe classes met de namen: *EmailRecipient*, *CCRecipient* en *BCCRecipient*.

8: Zorg ervoor dat alle 3 de classes een *child* zijn van *Recipient*.

9: Vul van alle 3 de classes de constructor met een parameter van het type 'string'. Wijs de waarde van de parameter toe aan het veld 'address' van *Recipient*. Om een voorbeeld te geven zie je hier de implementatie van *EmailRecipient*:

````csharp
public class EmailRecipient : Recipient
{
    public EmailRecipient(string address)
    {
         base.address = address;
    }
}
````

Nu is het model klaar. We hebben 3 types van 'recipient' voor onze email app en kunnen beginnen aan de *RecipientFactory*. Als eerste maken we een interface die de methoden definieert.

10: Maak een nieuwe folder aan genaamd 'Interfaces'.

11: Maak een nieuw bestand genaamd IRecipientFactory.cs en zet hierin maar 1 methode. Dit is de 'CreateRecipient' methode. Zorg ervoor dat de methode 'public' is en dat het 2 parameters van het type 'string' bevat (namelijk 'type' en 'address'). Let er op dat de 'CreateRecipient' methode een object van het type *Recipient* terug moet geven.

12: Maak nu een nieuw bestand buiten de 'Interfaces' map genaamd 'RecipientFactory' en zorg dat deze afgeleid is van de interfact 'IRecipientFactory'. Je ziet dat VS een foutmelding geeft, omdat er geen implementatie zal zijn van de 'CreateRecipient' methode. Rechtermuisklik op de foutmelding zodat de methode automatisch verschijnt of schrijf de methode over vanuit de interface.

13: Instantieer nu een nieuw *Recipient* object en zorg ervoor dat deze terug gegeven wordt. Wacht... De Recipient class is natuurlijk 'abstract' dit betekent dat er geen directe instantie van dit object gemaakt kan worden, maar wel van de afgeleide classes. Geef in dat geval een *Recipient* terug van het type *EmailRecipient*.

14: Maak nu een switch statement die afhankelijk is van de parameter 'type' en Maak 3 verschillende 'cases' (er zijn er eigenlijk maar 2 nodig, maar toch). Zet in de eerste 'case' "email" en zorg dat deze een EmailRecipient retourneerd. Voor de andere 2 'cases' is dit "cc" > CCRecipient en "bcc" > BCCRecipient.

15: Zorg er voor dat de 'default' een standaard EmailRecipient object terug geeft.

16:. Als het goed is ziet de *RecipientFactory* er als volgt uit:

````csharp
public class RecipientFactory : IRecipientFactory
{
    public Recipient CreateRecipient(string type, string address)
    {
        switch (type)
        {
            case "email":
                return new EmailRecipient(address);
            case "cc":
                return new CCRecipient(address);
            case "bcc":
                return new BCCRecipient(address);
            default:
                return new EmailRecipient(address);
        }
    }
}
````

Tijd om te testen. Ga nu terug naar Program.cs en zorg ervoor dat de regel 'Console.ReadKey()' blijft staan.

17: Instantieer een nieuw object van het type 'RecipientFactory' en maak vervolgens gebruik van de Factory method, CreateRecipient, om Recipient objecten te maken. Het liefst van alle 3 de verschillende types: email, cc en bcc.

````csharp
IRecipientFactory recipientFactory = new RecipientFactory();
Recipient emailRecipient = recipientFactory.CreateRecipient("email", "jef.pieters@gmail.com");
Recipient ccRecipient = recipientFactory.CreateRecipient("cc", "jan.janssens@hotmail.com");
Recipient bccRecipient = recipientFactory.CreateRecipient("bcc", "tom.vervoort@live.nl");
````

18: Schrijf een stukje logica om de *class type* en het bijgegeven 'address' te tonen in de Console. Zelf hiervoor is gebruik gemaakt van 'String Interpolation'. Dit ziet er als volgt uit:

````csharp
Console.WriteLine($"Created a recipient of type {emailRecipient.GetType()} with address: {emailRecipient.Address}");
Console.WriteLine($"Created a recipient of type {ccRecipient.GetType()} with address: {ccRecipient.Address}");
Console.WriteLine($"Created a recipient of type {bccRecipient.GetType()} with address: {bccRecipient.Address}");
````

> GetType() is een standaard methode van .Net en geeft het 'classtype' terug.

19: Druk nu op F5 om de applicatie te starten. Je ziet in de Console dat er nu 3 soorten Recipient(s) zijn gemaakt van de 3 verschillende types.

**EXTRA**: Om toch wat minder afhankelijk te zijn van het parameter 'type' als 'string' in de CreateRecipient methode, is het aan te raden een 'Enum' te gebruiken.

1. Maak een nieuwe class/enum in de Models map met de naam 'RecipientType' en vul deze met de 3 verschillende types:

````csharp
public enum RecipientType
{
    EMAIL, CC, BCC
}
````

2. Wijzig nu in de IRecipientFactory de parameter 'type' van 'string' naar RecipientType. Doe dit vervolgens ook in de RecipientFactory implementatie en verander de 'cases' naar de bijbehorende types:

````csharp
public Recipient CreateRecipient(RecipientType type, string address)
{
    switch (type)
    {
        case RecipientType.EMAIL:
            return new EmailRecipient(address);
        case RecipientType.CC:
            return new CCRecipient(address);
        case RecipientType.BCC:
            return new BCCRecipient(address);
        default:
            return new EmailRecipient(address);
    }
}
````

3. Als laatste zorg je ervoor dat de 'RecipientType' ook gebruikt word in Program.cs. Verander daarom ook "email", "cc" en "bcc" met het desbetreffende RecipientType. Dit zou er als volgt uit moeten zien:

````csharp
Recipient emailRecipient = recipientFactory.CreateRecipient(RecipientType.EMAIL, "jef.pieters@gmail.com");
Recipient ccRecipient = recipientFactory.CreateRecipient(RecipientType.CC, "jan.janssens@hotmail.com");
Recipient bccRecipient = recipientFactory.CreateRecipient(RecipientType.BCC, "tom.vervoort@live.nl");
````

Druk nu nogmaals op F5 om te testen of dit hetzelfde resultaat geeft als de implementatie zonder RecipientType.

Je hebt nu in een eenvoudige implementatie kennis mogen maken met de Factory Method en het gebruik in .Net Core.