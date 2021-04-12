using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StrategyPattern.Models;

namespace StrategyPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cart shoppingCart = new Cart();
            shoppingCart.AddProduct(new Game(50));
            shoppingCart.AddProduct(new Sticker(5));
            shoppingCart.AddProduct(new Sticker(5));
            shoppingCart.AddProduct(new Poster(10));

            Console.WriteLine("Products payment");
            shoppingCart.MakePayment(new PaypalStrategy("test@test.net", "test@test.net"));
            shoppingCart.MakePayment(new PaypalStrategy("test@test.net", "test123"));
            shoppingCart.MakePayment(new WalletStrategy("TestUser"));

            shoppingCart.ClearCart();
            shoppingCart.AddProduct(new Game(50));
            shoppingCart.MakePayment(new WalletStrategy("TestUser"));

            Console.ReadKey();

        }
    }
}
