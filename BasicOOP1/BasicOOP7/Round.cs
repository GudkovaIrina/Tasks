using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP7
{
    class Round : Shape
    {
        public Round(Point center, Point pointAtRound )
            :base(center,pointAtRound)
        {

        }
        public double Radius 
        {
            get
            {
                return this.Point1.DistanceTo(this.Point2);
            }
        }

        public virtual double Length()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return String.Format("Окружность с центром в точке ({0:N}, {1:N}), радиуса {2:N}, с длиной окружности {3:N}", this.Point1.X, this.Point1.Y, Radius, Length());
        }
    }
}
