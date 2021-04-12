using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.Models
{
    public abstract class Product
    {
        protected int Price { get; set; }

        public int GetPrice()
        {
            return Price;
        }
    }
}
