using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP7
{
     abstract class Shape
    {
        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }
        public Shape(Point point1, Point point2)
        {
            if (point1 == point2)
            {
                throw new ArgumentException("Points shoud not coincide!");
            }
            Point1 = point1;
            Point2 = point2;
        }
    }
}
