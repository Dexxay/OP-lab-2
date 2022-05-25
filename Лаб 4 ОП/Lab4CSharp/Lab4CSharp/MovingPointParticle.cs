using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4CSharp
{
    abstract class MovingPointParticle
    {
        public abstract double GetCoordinates(double t, out double y);
        public abstract double GetDistance(double x2, double y2);
        public abstract void DisplayObject();
        public abstract void DisplayCoordinates(double t);
    }
}
