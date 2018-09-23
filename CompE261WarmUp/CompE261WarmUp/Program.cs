using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CompE261WarmUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Warmup.Address address1 = new Warmup.Address { FirstName = "John", LastName = "Doe", LineOne = "Yeet", LineTwo = "Kobe", City = "San Diego", State = "California", PhoneNumber = "858-321-1111", ZipCode = 41321 };
            Warmup.Address address2 = new Warmup.Address { FirstName = "David", LastName = "Doe", LineOne = "Yeet", LineTwo = "Kobe", City = "San Diego", State = "California", PhoneNumber = "858-321-1111", ZipCode = 41321 };

            Console.WriteLine(address1);
            Console.WriteLine(address1.Equals(address2));
            Console.WriteLine(address1.CompareTo(address2));

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
