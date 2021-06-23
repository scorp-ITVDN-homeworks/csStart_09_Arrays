using System;
using System.Threading;

namespace CS5_09
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.Write("Countdown from ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("(type a number here)");
                Console.ResetColor();

                int number = Convert.ToInt32(Console.ReadLine());

                int[] numsArray = new int[number];

                for(int i = 1; i <= number; i++)
                {
                    numsArray[i - 1] = i;
                }

                Console.WriteLine(new string('-', 60));
                for (int i = number; i > 0; i--)
                {
                    Thread.Sleep(200);
                    Console.WriteLine(numsArray[i - 1]);
                }
                Console.WriteLine(new string('-', 60));


                Console.WriteLine("Do another countdown? (y/n)");
                if (Console.ReadLine() != "y") break;

            } while (true);
        }
    }
}
