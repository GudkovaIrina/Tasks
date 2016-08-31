using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP7
{
    class Circle : Round
    {
        public Circle(Point center, Point pointAtRound)
            :base(center, pointAtRound)
        {

        }
        public virtual double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return String.Format("Круг с центром в точке ({0:N}, {1:N}), радиуса {2:N}, с длиной окружности {3:N} и площадью {4:N}", this.Point1.X, this.Point1.Y, Radius, Length(), Area());
        }
    }
}
