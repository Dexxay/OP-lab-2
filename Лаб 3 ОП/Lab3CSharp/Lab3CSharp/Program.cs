using System;

namespace Lab3CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Number N1 = new Number();

            Console.WriteLine("Second number: ");
            int decNumber = Operations.InputInt("decimal number", 0, 10000);
            Number N2 = new Number(decNumber);

            Number N3 = new Number(N1);

            Console.WriteLine("\nFourth number: ");
            int thousands = Operations.InputInt("number of thousands", 0, 10);
            int hundreds = Operations.InputInt("number of hundreds", 0, 10);
            int tens = Operations.InputInt("number of tens", 0, 10);
            int ones = Operations.InputInt("number of ones", 0, 10);                       
            Number N4 = new Number(ones, tens, hundreds, thousands);

            Operations.ShowNumber(N1, "\nFirst number (rand) is: ");
            Operations.ShowNumber(N2, "Second number (dec) is: ");
            Operations.ShowNumber(N3, "Third number (copy) is: ");
            Operations.ShowNumber(N4, "Fourth number (hand) is:");

            ++N1;
            --N2;

            Operations.ShowNumber(N1, "\nIncremented first number is:  ");
            Operations.ShowNumber(N2, "Decremented second number is: ");

            N3 = N1 + N2;

            Operations.ShowNumber(N3, "\nNew third number (N1+N2) is:  ");

            if (N3 > N4)
            {
                Console.WriteLine($"\nN3 is bigger than N4 ({N3.ReturnDecimalEquivalent()} > {N4.ReturnDecimalEquivalent()})");
                Console.WriteLine("N3 dec is: " + N3.ReturnDecimalEquivalent());
            }
            else
            {
                Console.WriteLine($"\nN4 is bigger than N3 ({N4.ReturnDecimalEquivalent()} > {N3.ReturnDecimalEquivalent()})");
                Console.WriteLine("N4 dec is: " + N4.ReturnDecimalEquivalent());
            }

            Console.ReadKey();
        }
    }
}
