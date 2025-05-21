using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTrade.Logic.Services
{
    public interface IFibonacciHandler
    {
        (int prev1, int prev2) GetPreviousFibonacci(int n);
    }
}
