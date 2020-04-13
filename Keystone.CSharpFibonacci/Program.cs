using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keystone.CSharpFibonacci
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide a value for n.");
            var nNumber = 0;
            while (!int.TryParse(Console.ReadLine(), out nNumber))
            {
                Console.WriteLine("You have not entered a number.  Please provide a value for n.");
                Console.ReadLine();
            }

            Console.WriteLine($@"The {nNumber}th value in the Fibonacci sequence is: {CalculateNthFibonacci(nNumber)}");
            Console.ReadKey();
        }

        public static int CalculateNthFibonacci(int n)
        {
            return (int)Math.Round(Math.Pow((1 + Math.Sqrt(5)) / 2, n)
                                   / Math.Sqrt(5));
        }
    }
}
