using System;
using System.Collections.Generic;

namespace Lab2CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Operations.InputInteger("Enter number of spheres: ");
            Console.WriteLine();
            Sphere[] arrayOfSpheres = Operations.InputSpheres(number);

            Console.WriteLine("Enter coordinates of the point: ");
            double xDotCoordinate = Operations.InputCoordinate("x");
            double yDotCoordinate = Operations.InputCoordinate("y");
            double zDotCoordinate = Operations.InputCoordinate("z");
            Console.WriteLine();

            List<int> numbers = Operations.GetNumberOfSpheres(arrayOfSpheres, xDotCoordinate, yDotCoordinate, zDotCoordinate, out bool[] result);
            Operations.ShowResult(arrayOfSpheres, xDotCoordinate, yDotCoordinate, zDotCoordinate, result, numbers);
            Console.WriteLine();
            Operations.ShowNumbers(numbers);
            Console.ReadKey();
        }
    }
}
