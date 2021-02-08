# Book

## Deel 1

```csharp
class Book
{
    public int ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    private double price;

    public virtual double Price
    {
        get { return price; }
        set { price = value; }
    }

    public static Book TelOp(Book b1, Book b2)
    {
        Book result = new Book();

        result.Title = $"Omnibus van {b1.Author},{b2.Author}";
        result.Price = (b1.Price + b2.Price) / 2;

        return result;
    }

}

class TextBook : Book
{
    public int GradeLevel { get; set; }

    public override double Price
    {
        get { return base.Price; }
        set
        {
            if (value >= 20 && value <= 80)
                base.Price = value;
        }
    }

    class CoffeeTableBook : Book
    {
        public override double Price
        {
            get { return base.Price; }
            set
            {
                if (value >= 35 && value <= 100)
                    base.Price = value;
            }
        }
    }
}
```

## Deel 2

Voeg dit toe aan de klasse `Book`

```csharp
public override string ToString()
{
    return $"{Title} - {Author}({ISBN}) {Price}";
}
```

(PRO) Equals methode. Voeg dit toe aan de klasse `Book`

```csharp
public override bool Equals(object obj)
{
    Book tocomp = (Book)obj;
    if (tocomp.ISBN == ISBN)
        return true;
    return false;
}
```

## Money, Money, Money

```csharp
abstract class Rekening
{
    private double saldo = 0;
    public double Saldo
    {
        get { return Saldo; }
    }
    public void VoegGeldToe(double hoeveel)
    {
        saldo += hoeveel;
    }

    public bool HaalGeldAf(double hoeveel)
    {
        if (saldo - hoeveel < 0)
            return false;

        saldo -= hoeveel;
        return false;
    }

    public abstract double BerekenRente();

}

class BankRekening : Rekening
{
    public override double BerekenRente()
    {
        if(Saldo>0)
        {
            return Saldo + (Saldo*0.05);
        }
        return Saldo;
    }
}

class SpaarRekening : Rekening
{
    public override double BerekenRente()
    {
        return Saldo+(Saldo*0.02);
    }
}

class ProRekening : SpaarRekening
{
    public override double BerekenRente()
    {
        int aantal1000 =(int)Saldo / 1000;
        return base.BerekenRente() + aantal1000*10;
    }
}
```

# Geometric Figures

```csharp
abstract class GeometricFigure
{
    public int Hoogte { get; set; }
    public int Breedte { get; set; }
    public double Oppervlakte
    {
        get
        {
            return BerekenOppervlakte();
        }
    }
    public abstract double BerekenOppervlakte();
}

class Rechthoek : GeometricFigure
{
    public override double BerekenOppervlakte()
    {
        return Breedte * Hoogte;
    }
}

class Vierkant: Rechthoek
{
    public Vierkant(int b, int h)
    {
        if (b!=h)
        {
            b = h;
        }
        Hoogte = h;
        Breedte = b;
    }

    public Vierkant(int l)
    {
        Hoogte = Breedte = l;
    }
}

class Driehoek: GeometricFigure
{
    public override double BerekenOppervlakte()
    {
        return (Breedte * Hoogte) / 2;
    }
}
```