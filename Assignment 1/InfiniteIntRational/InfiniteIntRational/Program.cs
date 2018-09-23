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
            InfInt test1 = new InfInt("1453242414");
            InfInt test2 = new InfInt("3241");

            test1 = test1.Add(test2);

            Console.WriteLine($"Addition: {test1}");
        }
    }
}
