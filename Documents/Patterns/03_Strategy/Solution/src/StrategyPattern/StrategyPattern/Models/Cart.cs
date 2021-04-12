using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StrategyPattern.Interfaces;

namespace StrategyPattern.Models
{
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

        public void MakePayment(IPaymentStrategy paymentStrategy)
        {
            paymentStrategy.Pay(GetTotalPrice());
        }
        private int GetTotalPrice()
        {
            var total = _items.Sum(x => x.GetPrice());
            return total;
        }

    }
}
