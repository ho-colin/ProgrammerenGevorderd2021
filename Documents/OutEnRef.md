# Parameters by reference doorgeven

Je kan parameters op 2 manieren by reference doorgeven:

- Indien de parameters reeds een waarde heeft dan kan je het ref keyword gebruiken. Dit gebruik je dus voor in/out-parameters.
- Indien de parameter pas in de methode een waarde krijgt toegekend dan wordt het out keyword gebruikt. Dit gebruik je dus voor out-parameter.

Je geeft parameters by reference door door het keyword ref voor de parameter in kwestie te zetten, zowel in de methode-declaratie als in de aanroep van de methode zelf.

**Opgelet**: parameters by reference doorgeven kan vaak tot problemen leiden indien je niet goed oplet, daar je rechtstreeks werkt met geheugenlocaties. Als je bijvoorbeeld verkeerdelijk een referentie optelt bij een value dan krijg je een nieuwe referentie die echter naar, mogelijk, een onbestaand stuk geheugen wijst. De ontwikkelaars van Visual Studio raden het gebruik van ref en out dan ook af, zeker indien je een beginnende programmeur bent. .

# Out en ref

Via de keywords out en ref kunnen we parameters by reference dooregeven (ipv by value), het verschil daarbij is:

- `ref`: de parameter bevat reeds een waarde wanneer deze naar de methode wordt gestuurd
- `out`: de parameter bevat nog geen parameter en er wordt verwacht dat deze een waarde krijgt in de methode

Het verschil tussen het gebruik van `out` of `ref` keyword tonen we aan in het volgende voorbeeld.

Laten we dit aantonen met een voorbeeld. Stel dat we het vorige voorbeeld herschreven maar ‘vergeten’ om de parameter tweede een begin-waarde te geven:

```csharp
static void Main(string[] args)
{
    int eerste = 5;
    int tweede;
    RefValueVerschil(eerste, ref tweede);

    Console.WriteLine("Eerste bedraagt na method:{0}", eerste);
    Console.WriteLine("Tweede bedraagt na method:{0}", tweede);
}
```

Dan krijgen we volgende, terechte, foutmelding:

![img](./outref1.png)

Door nu het out keyword te gebruiken geven we expliciet aan dat we beseffen dat de parameter in kwestie pas binnen de methode een waarde zal toegekend krijgen.

We zouden dus ons programma kunnen herschrijven met deze parameter. Hierbij moeten we ons ervan vergewissen dat we zeker de parameter getal2 een waarde toekennen in de methode!

```csharp
static void RefValueVerschil(int getal1, out int getal2)
{
    getal2 = 10;
    getal1 = getal1 + 1;
    getal2 = getal2 + 2;
    Console.WriteLine("Getal1 bedraagt in method:{0}", getal1);
    Console.WriteLine("Getal2 bedraagt in method:{0}", getal2);

}

static void Main(string[] args)
{
    int eerste = 5;
    RefValueVerschil(eerste, out int tweede);

    Console.WriteLine("Eerste bedraagt na method:{0}", eerste);
    Console.WriteLine("Tweede bedraagt na method:{0}", tweede);
}
```

Dit geeft terug als output:

```
Getal1 bedraagt in method:6
Getal2 bedraagt in method:12
Eerste bedraagt na method:5
Tweede bedraagt na method:12
```

Volgende methode zal 2 parameters meekrijgen. De eerste wordt bij value gebruikt, de tweede by reference:

```csharp
static void RefValueVerschil(int getal1, ref int getal2)
{
    getal1 = getal1 + 1;
    getal2 = getal2 + 2;
    Console.WriteLine("Getal1 bedraagt in methode:{0}", getal1);
    Console.WriteLine("Getal2 bedraagt in methode:{0}", getal2);
}

static void Main(string[] args)
{
    int eerste = 5;
    int tweede = 10;
    RefValueVerschil(eerste, ref tweede);
    Console.WriteLine("Eerste bedraagt na methode:{0}", eerste);
    Console.WriteLine("Tweede bedraagt na methode:{0}", tweede);
}
```

De uitvoer is de volgende, zoals verwacht: :

```
Getal1 bedraagt in method:6
Getal2 bedraagt in method:12
Eerste bedraagt na method:5
Tweede bedraagt na method:12
```

Merk dus op dat enkel de variabele tweede aangepast wordt buiten de methode doordat we deze by reference doorgeven.

