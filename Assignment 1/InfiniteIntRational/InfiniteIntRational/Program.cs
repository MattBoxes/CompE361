using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfIntClass;
using RationalClass;
using infRationalClass;

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
            Rational frac2 = new Rational(1, 7);
            //Console.WriteLine(frac1.ToString());
            Console.WriteLine(frac2.RationalToDecimal());
            Console.WriteLine($"subtract: {frac1 - frac2}");
            //Console.WriteLine($"multiply: {frac1 * frac2}");
            Console.WriteLine($"divide: {frac1 / frac2}");
           InfInt test1 = new InfInt("40");
           InfInt test2 = new InfInt("400");
           InfInt test3 = new InfInt("1453242414");
           infRational bigfrac = new infRational(test1, test2);
           infRational bigfrac2 = new infRational("23141", "312");
           infRational bigfrac3 = new infRational("23141", "312");
                Console.WriteLine($" Addition: {test1.Add(test2)}");
                //Console.WriteLine($" subtraction: {test2.Subtract(test1)}");
                //Console.WriteLine($"compareto: {test1.CompareTo(test2)}");
                //Console.WriteLine($" divide: {test1.Divide(test2)}");
                //Console.WriteLine($"multiply: {test1.Multiply(test2)}");

                Console.WriteLine($"{bigfrac}");
                Console.WriteLine($"{bigfrac2}");
                Console.WriteLine($"{bigfrac2.CompareTo(bigfrac3)}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Cannot Divide by zero");
               
            }
            

        }
    }
}
