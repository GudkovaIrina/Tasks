using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP1
{
    class Ring : Round
    {
        private double innerR;
        public double InnerR
        {
            get
            {
                return innerR;
            }
            set
            {
                if ((value > 0) && (value < this.R))
                {
                    innerR = value;
                }
                else
                {
                    throw new FormatException();
                }
            }
        }

        public override double Area()
        {
            return base.Area() - Math.PI * InnerR * InnerR;
        }

        public override double Length()
        {
            return base.Length() + 2*Math.PI * InnerR;
        }
    }
}
