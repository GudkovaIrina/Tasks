using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP2
{
    public class Triangle
    {
        double a;
        double b;
        double c;

        public double A
        {
            get 
            {
                return a;
            }
            set 
            {
                if (value > 0)
                {
                    if ((a < b + c) && (b < a + c) && (c < a + b))
                    {
                        a = value;
                    }
                    else
                    {
                        throw new ArgumentException("This triangle does not exist!");
                    }
                }
                else 
                {
                    throw new ArgumentException("Side of triangle must be positive number!");
                }
            }
        }

        public double B
        {
            get
            {
                return b;
            }
            set
            {
                if (value > 0)
                {
                    if ((a < b + c) && (b < a + c) && (c < a + b))
                    {
                        b = value;
                    }
                    else
                    {
                        throw new ArgumentException("This triangle does not exist!");
                    }
                }
                else
                {
                    throw new ArgumentException("Side of triangle must be positive number!");
                }
            }
        }

        public double C
        {
            get
            {
                return c;
            }
            set
            {
                if (value > 0)
                {
                    if ((a < b + c) && (b < a + c) && (c < a + b))
                    {
                        c = value;
                    }
                    else
                    {
                        throw new ArgumentException("This triangle does not exist!");
                    }
                }
                else
                {
                    throw new ArgumentException("Side of triangle must be positive number!");
                }
            }
        }

        public Triangle(double a, double b, double c)
        {
            this.ChangeSides(a, b, c);
        }

        public void ChangeSides(double a, double b, double c)
        {
            if ((a < b + c) && (b < a + c) && (c < a + b))
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            else
            {
                throw new ArgumentException("This triangle does not exist!");
            }
        }

        public double Perimeter()
        {
            return A + B + C;
        }

        public double Area()
        { 
            double p = this.Perimeter()/2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
