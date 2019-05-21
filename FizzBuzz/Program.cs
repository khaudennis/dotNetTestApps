using System;
using System.Text;
using System.Threading;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;

            for (i = 1; i <= 100; i++)
            {
                if ((i % 3 == 0) && (i % 5 == 0)) { Console.WriteLine("FizzBuzz\n"); }
                else if (i % 3 == 0) { Console.WriteLine("Fizz\n"); }
                else if (i % 5 == 0) { Console.WriteLine("Buzz\n"); }
                else { Console.WriteLine(i.ToString() + "\n"); }

                Thread.Sleep(1000);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
