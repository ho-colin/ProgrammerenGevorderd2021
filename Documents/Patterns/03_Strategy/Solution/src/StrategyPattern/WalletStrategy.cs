using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StrategyPattern.Interfaces;

namespace StrategyPattern
{
    public class WalletStrategy : IPaymentStrategy
    {
        private string username;
        private int budget;
        public WalletStrategy(string username)
        {
            this.username = username;
            budget = 50;
        }
        public void Pay(int amount)
        {
            if (budget < amount)
                Console.WriteLine($"{amount} can't be paid. Budget is only {budget}.");
            else
                Console.WriteLine($"{amount} euro's paid by {username} using In-Game Wallet.");
        }
    }
}
