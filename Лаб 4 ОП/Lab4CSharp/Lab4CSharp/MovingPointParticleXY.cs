using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4CSharp
{
    class MovingPointParticleXY : MovingPointParticle
    {
        private double x;
        private double y;
        private double x0;
        private double y0;
        private double a1;
        private double a2;

        public double GetX0()
        {
            return x0;
        }
        public double GetY0()
        {
            return y0;
        }

        public double GetA1()
        {
            return a1;
        }
        public double GetA2()
        {
            return a2;
        }

        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }

        public MovingPointParticleXY()
        {
            int minRandX = -100;
            int maxRandX = 100;
            int minRandY = -100;
            int maxRandY = 100;
            int minRandA1 = -10;
            int maxRandA1 = 10;
            int minRandA2 = -10;
            int maxRandA2 = 10;
            int precision = 10;

            Random rand = new Random();
            x = 0;
            y = 0;
            x0 = Convert.ToDouble(rand.Next(minRandX * precision, maxRandX * precision + 1) / Convert.ToDouble(precision));
            y0 = Convert.ToDouble(rand.Next(minRandY * precision, maxRandY * precision + 1) / Convert.ToDouble(precision));
            a1 = Convert.ToDouble(rand.Next(minRandA1 * precision, maxRandA1 * precision + 1) / Convert.ToDouble(precision));
            a2 = Convert.ToDouble(rand.Next(minRandA2 * precision, maxRandA2 * precision + 1) / Convert.ToDouble(precision));
        }

        public override double GetCoordinates(double t, out double y)
        {
            x = x0 + a1 * Math.Sin(t);
            y = y0 + a2 * Math.Cos(t);
            return x;
        }

        public override double GetDistance(double x2, double y2)
        {
            return (Math.Sqrt(Math.Pow((x2-x),2) + Math.Pow((y2 - y), 2)));
        }

        public override void DisplayObject()
        {
            Console.WriteLine($"\ta1 = \t{a1}\ta2 = \t{a2}\tx0 = \t{x0}\ty0 = \t{y0}");
        }

        public override void DisplayCoordinates(double t)
        {
            Console.WriteLine($"\tx is: \t{Math.Round(GetCoordinates(t, out y), 3)}\ty is: {Math.Round(y, 3)}");
        }
    }
}

