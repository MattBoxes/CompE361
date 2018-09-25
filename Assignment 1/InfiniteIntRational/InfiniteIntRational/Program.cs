using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfIntClass;
using RationalClass;
namespace InfiniteIntRational
{
    class Program
    {
        static void Main(string[] args)
        {
            try { 
            //InfInt test1 = new InfInt("400");
            //InfInt test2 = new InfInt("1");
            // InfInt test3 = new InfInt("1453242414");
            Rational frac1 = new Rational(3,18);
            Rational frac2 = new Rational(0, 7);
            Console.WriteLine(frac1.ToString());
            Console.WriteLine(frac1.RationalToDecimal());
            Console.WriteLine($"subtract: {frac1 - frac2}");
            Console.WriteLine($"multiply: {frac1 * frac2}");
            Console.WriteLine($"divide: {frac1 / frac2}");
           InfInt test1 = new InfInt("400");
            InfInt test2 = new InfInt("1");
            InfInt test3 = new InfInt("1453242414");


            Console.WriteLine($" Addition: {test1.Add(test2)}");
            Console.WriteLine($" subtraction: {test2.Subtract(test1)}");
            Console.WriteLine($"compareto: {test1.CompareTo(test2)}");
                // Console.WriteLine($" divide: {test1.Divide(test2)}");
                //Console.WriteLine($"multiply: {test1.Multiply(test2)}");
                 }
            catch(Exception)
            {
                return;
            }

        }
    }
}
