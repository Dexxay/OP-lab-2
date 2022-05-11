using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3CSharp
{
    class Operations
    {
        public static int InputInt(string message, int minLimit, int maxLimit)
        {
            Console.Write($"Enter {message} ({minLimit} <= N < {maxLimit}): ");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number) && number >= minLimit && number < maxLimit)
                {
                    return number;
                }
                else
                {
                    Console.Write("Wrong input. Try again: ");
                }
            }
        }

        public static void ShowNumber(Number number, string message)
        {
            string result = message + "\tdec: \t" + Convert.ToString(number.ReturnDecimalEquivalent()) + "\tthousands: \t" + Convert.ToString(number.GetThousands()) + "\thundreds: \t" + Convert.ToString(number.GetHundreds()) + "\ttens: \t" + Convert.ToString(number.GetTens()) + "\tones: \t" + Convert.ToString(number.GetOnes());
            Console.WriteLine(result);
        }

    }
}
