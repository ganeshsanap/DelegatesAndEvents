using System;

namespace DelegatesAndEvents
{
    class Program
    {
        public delegate int CalculateDelegate(int a, int b);
        
        static int Add(int a, int b)
        {
            int c = a + b;
            Console.WriteLine("Addition: {0} + {1} = {2}", a, b, c);
            return c;
        }

        static int Subtract(int a, int b)
        {
            int c = a - b;
            Console.WriteLine("Subtraction: {0} - {1} = {2}", a, b, c);
            return c;
        }

        static int Multiply(int a, int b)
        {
            int c = a * b;
            Console.WriteLine("Multiplication: {0} * {1} = {2}", a, b, c);
            return c;
        }

        static int Divide(int a, int b)
        {
            int c = a / b;
            Console.WriteLine("Division: {0} / {1} = {2}", a, b, c);
            return c;
        }


        static int Square(int x)
        {
            int c = x * x;
            Console.WriteLine("Square: {0} * {0} = {1}", x, c);
            return c;
        }


        static void Main(string[] args)
        {
            #region Simple Delegates
            //Singlecast Delegate
            CalculateDelegate calculateDelegate1 = Add;
            calculateDelegate1(30, 15);

            //Multicast Delegate
            CalculateDelegate calculateDelegate2 = Add;
            calculateDelegate2 += Subtract;
            calculateDelegate2 += Multiply;
            calculateDelegate2 += Divide;

            calculateDelegate2.Invoke(20, 10);
            // OR like below
            //foreach (CalculateDelegate cd in calculateDelegate2.GetInvocationList())
            //{
            //    Console.WriteLine(cd(20, 10));
            //}
            #endregion

            #region Execute delegates from other classes
            Calculator calculator = new Calculator();
            Calculator.CalculatorDelegate calculatorDelegate = Square;
            calculator.ExecuteDelegate(calculatorDelegate, 5); 
            
            // OR like below
            Calculator calculator1 = new Calculator();
            calculator1.ExecuteDelegate(Square, 6);

            //Func
            Calculator calculator2 = new Calculator();
            calculator2.ExecuteFunc(Square, Console.WriteLine, 7);

            //Func and Action
            Calculator calculator3 = new Calculator();
            calculator3.ExecuteFuncAction(Square, Console.WriteLine, 8);

            //Lamba
            Calculator calculator4 = new Calculator();
            calculator4.ExecuteFunc((x) => x * x, Console.WriteLine, 9);
            calculator4.ExecuteFuncAction((x) => x * x, Console.WriteLine, 9);

            #endregion
        }
    }
}
