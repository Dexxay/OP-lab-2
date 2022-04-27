using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2CSharp
{
    class Sphere
    {
        private double xCenterCoordinate, yCenterCoordinate, zCenterCoordinate, radius;

        public double GetXCoordinate()
        {
            return xCenterCoordinate;
        }

        public double GetYCoordinate()
        {
            return yCenterCoordinate;
        }

        public double GetZCoordinate()
        {
            return zCenterCoordinate;
        }

        public double GetRadius()
        {
            return radius;
        }
        public Sphere(double xCenterCoordinate, double yCenterCoordinate, double zCenterCoordinate, double radius)
        {
            this.xCenterCoordinate = xCenterCoordinate;
            this.yCenterCoordinate = yCenterCoordinate;
            this.zCenterCoordinate = zCenterCoordinate;
            this.radius = radius;
        }

        public bool isDotInTheSphere(double x, double y, double z)
        {
            bool result = Math.Pow(x - xCenterCoordinate, 2) + Math.Pow(y - yCenterCoordinate, 2) + Math.Pow(z - zCenterCoordinate, 2) <= Math.Pow(radius, 2);
            return result;
        }
    }
}
