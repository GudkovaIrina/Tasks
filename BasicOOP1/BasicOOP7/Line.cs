using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP7
{
    class Line : Shape
    {
        public Line(Point point1, Point point2)
            :base(point1,point2)
        {

        }
        public override string ToString()
        {
            return String.Format("Линия, проходящая через точки: ({0:N}, {1:N}) и ({2:N}, {3:N})", Point1.X, Point1.Y, Point2.X, Point2.Y);
        }
    }
}
