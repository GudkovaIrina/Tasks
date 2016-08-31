using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP7
{
    class Ring : Circle
    {
        private double innerRadius;
        public double InnerRadius 
        {
            get
            {
                return innerRadius;
            }
            set
            {
                if ((value <= 0)||(value >= Radius))
                {
                    throw new FormatException("Inner radius must be positive number and less at radius!");
                }
                else
                {
                    innerRadius = value;
                }
            }
        }

        public Ring(Point center, Point pointAtRound, double innerRadius)
            :base(center, pointAtRound)
        {
            InnerRadius = innerRadius;
        }

        public override double Length()
        {
            return base.Length() + 2*Math.PI*InnerRadius;
        }

        public override double Area()
        {
            return base.Area() - Math.PI*InnerRadius*InnerRadius;
        }

        public override string ToString()
        {
            return String.Format("Кольцо с центром в точке ({0:N}, {1:N}), радиуса {2:N} и внутреннего радиуса {3:N}, с длиной окружности {4:N} и площадью {5:N}", this.Point1.X, this.Point1.Y, Radius, InnerRadius, Length(), Area());
        }
    }
}
