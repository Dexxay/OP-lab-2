using System;

namespace Lab4CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = Operations.InputNumber("k");
            int n = Operations.InputNumber("n");

            MovingPointParticleX[] pointXArray = new MovingPointParticleX[k];
            for (int i = 0; i < k; i++)
            {
                pointXArray[i] = new MovingPointParticleX();
            }

            MovingPointParticleXY[] pointXYArray = new MovingPointParticleXY[n];
            for (int j = 0; j < n; j++)
            {
                pointXYArray[j] = new MovingPointParticleXY();
            }

            Console.WriteLine();
            Console.WriteLine("Generated objects in xArray: ");
            Operations.ShowObjects(pointXArray);
            Console.WriteLine();

            Console.WriteLine("Generated objects in xyArray: ");
            Operations.ShowObjects(pointXArray);
            Console.WriteLine();

            double t = Operations.InputTime();

            Console.WriteLine();
            Console.WriteLine("X coordinates of objects in xArray: ");
            Operations.ShowCoordinates(pointXArray, t);
            Console.WriteLine();

            Console.WriteLine("X and Y coordinates of objects in xyArray: ");
            Operations.ShowCoordinates(pointXYArray, t);
            Console.WriteLine();

            double maxDistanceX = Operations.ReturnMaxDistance(pointXArray, out int firstX, out int secondX, t);
            //double maxDistanceX = Operations.ReturnMaxDistanceX(pointXArray, out int firstX, out int secondX);
            Console.WriteLine($"Max distance in xArray is {Math.Round(maxDistanceX, 3)} (between {firstX + 1}) and {secondX + 1}) points)");

            double maxDistanceXY = Operations.ReturnMaxDistance(pointXYArray, out int firstXY, out int secondXY, t);
            //double maxDistanceXY = Operations.ReturnMaxDistanceXY(pointXYArray, out int firstXY, out int secondXY);
            Console.WriteLine($"Max distance in xyArray is {Math.Round(maxDistanceXY, 3)} (between {firstXY + 1}) and {secondXY + 1}) points)");
        }
    }
}
