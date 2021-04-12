using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StrategyPattern.Interfaces;

namespace StrategyPattern.Models
{
    public class PaypalStrategy : IPaymentStrategy
    {
        private string email;
        private string password;

        public PaypalStrategy(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public void Pay(int amount)
        {
            var authorized = LogInUser(email, password);
            if (authorized)
            {
                Console.WriteLine($"{amount} euro's paid by {email} with Paypal");
            }
            else
            {
                Console.WriteLine($"{email} is not a valid user. Please log in.");
            }
        }

        private bool LogInUser(string email, string password)
        {
            return (email != password);
        }
    }
}
