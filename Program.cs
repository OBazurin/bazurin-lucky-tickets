using System;
using System.Collections.Generic;
using System.Linq;

namespace bazurin_lucky_tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (key.Key != ConsoleKey.Escape)
            {
                List<byte> numbers = new List<byte>();
                Console.Write("Input ticket number: ");
                var ticketNumber = Console.ReadLine();
                if (ticketNumber.Length < 4 || ticketNumber.Length > 8)
                {
                    Console.WriteLine("PLease input number with length 4 to 8");
                    continue;
                }
                foreach (var item in ticketNumber)
                {
                    numbers.Add((byte)char.GetNumericValue(item));
                }
                if (numbers.Count() % 2 != 0) numbers.Insert(0, 0);

                if (IsNumberLucky(numbers))
                {
                    Console.WriteLine("Congragulations! your number is lucky!");
                }
                else
                {
                    Console.WriteLine("You will be lucky next time! ;)");
                }

                Console.Write("Press any key to continue. Esc to exit.");
                key = Console.ReadKey();
                Console.Clear();
            }
        }

        static bool IsNumberLucky(List<byte> numbers)
        {
            return numbers.Take(numbers.Count / 2).Sum(x => x) == 
                numbers.TakeLast(numbers.Count / 2).Sum(x => x);
        }
    }
}
