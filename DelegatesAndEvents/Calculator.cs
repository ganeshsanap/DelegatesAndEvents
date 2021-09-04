using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class Calculator
    {
        public delegate int CalculatorDelegate(int x);

        public delegate void Print(int x);

        public int ExecuteDelegate(CalculatorDelegate calculatorDelegate, int x)
        {
            return calculatorDelegate(x);
        }

        public int ExecuteFunc(Func<int, int> calculate, Print print, int x)
        {
            var y = calculate(x);
            print(y);
            return y;
        }

        public int ExecuteFuncAction(Func<int, int> calculate, Action<int> print, int x)
        {
            var y = calculate(x);
            print(y);
            return y;
        }

    }
}
