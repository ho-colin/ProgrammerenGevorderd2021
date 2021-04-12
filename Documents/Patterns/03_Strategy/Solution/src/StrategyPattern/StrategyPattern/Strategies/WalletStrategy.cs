using System;
using StrategyPattern.Interfaces;

namespace StrategyPattern
{
    public class WalletStrategy : IPaymentStrategy
    {
        private string _username;
        private int _budget;
        public WalletStrategy(string username)
        {
            this._username = username;
            _budget = 50;
        }
        public void Pay(int amount)
        {
            if (_budget < amount)
                Console.WriteLine($"{amount} can't be paid. Budget is only {_budget}.");
            else
                Console.WriteLine($"{amount} euro's paid by {_username} using In-Game Wallet.");
        }
    }
}
