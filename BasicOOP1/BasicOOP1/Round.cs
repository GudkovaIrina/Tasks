using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP1
{
    public class Round
    {
        public double X { get; set; }
        public double Y { get; set; }
        private double r;
        public double R 
        {
            get 
            {
                return r;
            }
            set
            {
                if (value > 0)
                {
                    r = value;
                }
                else 
                {
                    throw new FormatException();
                }
            }
        }

        public virtual double Length()
        {
            return 2 * Math.PI * R;
        }

        public virtual double Area()
        {
            return Math.PI * R * R;
        }
    }
}
