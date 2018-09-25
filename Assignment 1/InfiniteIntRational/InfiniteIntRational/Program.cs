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
            InfInt test1 = new InfInt("123456789012345678901234567890123467890");
            InfInt test2 = new InfInt("3241");
            InfInt test3 = new InfInt("1453242414");
            
            test1 = test1.Add(test2);


            Console.WriteLine($" Addition: {test1}");
            Console.WriteLine($"compareto: {test1.CompareTo(test1)}");
        }
    }
}
