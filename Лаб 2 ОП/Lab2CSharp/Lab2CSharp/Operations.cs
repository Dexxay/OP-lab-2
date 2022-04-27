using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2CSharp
{
    class Operations
    {
        public static Sphere[] InputSpheres(int number)
        {
            Sphere[] result = new Sphere[number];
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"Enter info about {i}) sphere: ");
                double x = InputCoordinate("x");
                double y = InputCoordinate("y");
                double z = InputCoordinate("z");
                double radius = InputInteger("\tEnter radius: ");
                result[i] = new Sphere(x, y, z, radius);
                Console.WriteLine();
            }
            return result;
        }

        public static int InputInteger(string message)
        {
            Console.Write(message);
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result) && result > 0)
                {
                    return result;
                }
                else
                {
                    Console.Write("\tWrong input. Try again: ");
                }
            }
        }

        public static double InputCoordinate(string message)
        {
            Console.Write($"\tEnter {message} coordinate: ");
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double result))
                {
                    return result;
                }
                else
                {
                    Console.Write("\tWrong input. Try again: ");
                }
            }
        }

        public static List<int> GetNumberOfSpheres(Sphere[] spheres, double x, double y, double z, out bool[]result) 
        {
            List<int>numbers = new List<int>();
            result = new bool[spheres.Length];
            for (int i = 0; i < spheres.Length; i++)
            {
                if (spheres[i].isDotInTheSphere(x, y, z))
                {
                    result[i] = true;
                    numbers.Add(i);
                }
                else
                {
                    result[i] = false;
                }
            }
            return numbers;
        }

        public static void ShowResult(Sphere[] spheres, double xDot, double yDot, double zDot, bool[]result, List<int>numbers)
        {
            Console.WriteLine("Result: ");
            Console.Write($"Coordinates of the point are:     ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"x =\t{xDot}, y =\t{yDot}, z =\t{zDot}");
            Console.ResetColor();

            for (int i = 0; i < spheres.Length; i++)
            {
                Console.Write($"Coordinates of the {i}) sphere are: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"x =\t{spheres[i].GetXCoordinate()}, y =\t{spheres[i].GetYCoordinate()}, z =\t{spheres[i].GetZCoordinate()}, r =\t{spheres[i].GetRadius()}");
                Console.ResetColor();

                if (spheres[i].isDotInTheSphere(xDot, yDot, zDot))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\tthe point is in the sphere");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tthe point is outside of the sphere");
                    Console.ResetColor();
                }
            }
        }

        public static void ShowNumbers(List<int>numbers)
        { 
            Console.Write("Sequence numbers of suitable spheres are: ");
            if (numbers.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("None");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            for (int k = 0; k < numbers.Count; k++)
            {
                Console.Write(numbers[k] + ") ");
            }
            Console.ResetColor();
        }
    }
}
