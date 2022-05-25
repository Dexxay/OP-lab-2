using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4CSharp
{
    class MovingPointParticleX : MovingPointParticle
    {
        private double x;
        private double x0;
        private double a1;
        private double y;

        public double GetX0()
        {
            return x0;
        }

        public double GetA1()
        {
            return a1;
        }

        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }

        public MovingPointParticleX()
        {
            int minRandX = -100;
            int maxRandX = 100;
            int minRandA = -10;
            int maxRandA = 10;
            int precision = 10;

            Random rand = new Random();
            x = 0;
            y = 0;
            x0 = Convert.ToDouble(rand.Next(minRandX * precision, maxRandX * precision + 1) / Convert.ToDouble(precision));
            a1 = Convert.ToDouble(rand.Next(minRandA * precision, maxRandA * precision + 1) / Convert.ToDouble(precision));
        }

        public override double GetCoordinates(double t, out double y)
        {
            y = 0;
            x = x0 + a1 * Math.Sin(t);
            return x;
        }

        public override double GetDistance(double x2, double y2)
        {
            return Math.Abs(x2 - x);
        }

        public override void DisplayObject()
        {
            Console.WriteLine($"\ta1 = \t{a1}\tx0 = \t{x0}");
        }

        public override void DisplayCoordinates(double t)
        {
            Console.WriteLine($"\tx is: \t{Math.Round(GetCoordinates(t, out y), 3)}");
        }
    }
}
