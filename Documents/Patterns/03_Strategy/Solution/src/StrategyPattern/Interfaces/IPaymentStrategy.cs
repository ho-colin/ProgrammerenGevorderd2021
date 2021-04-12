using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.Interfaces
{
    
    public interface IPaymentStrategy
    {
        void Pay(int amount);
    }
}
