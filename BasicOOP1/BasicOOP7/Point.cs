using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP7
{
    public class Point : IEquatable<Point>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double DistanceTo(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X - this.X, 2) + Math.Pow(point.Y - this.Y, 2));
        }

        public override bool Equals(object obj)
        {
            Point p = obj as Point;
            
            if (obj is Point)
            {
                if (this.GetHashCode() == p.GetHashCode())
                {
                    return (this.X == p.X) && (this.Y == p.Y);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException("This object can not cast to type Point");
            }
        }

        public override int GetHashCode()
        {
            //return (int)(X*Y);

            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Point point1, Point point2)
        {
            
            return (point1.Equals(point2));
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !(point1 == point2);
        }

        public bool Equals(Point other)
        {
            if (this.GetHashCode() == other.GetHashCode())
            {
                return (this.X == other.X) && (this.Y == other.Y);
            }
            else
            {
                return false;
            }
        }
    }
}
