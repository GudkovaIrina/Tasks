using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP7
{
    class Rectangle :Shape
    {
        public Rectangle(Point topLeftUpper, Point topRigthLower)
            : base(topLeftUpper, topRigthLower)
        {
            if ((Point1.X == Point2.X)||(Point1.Y == Point2.Y))
            {
                throw new FormatException("Такого прямоугольника не существует!!!");
            }
        }

        public double Width 
        { 
            get 
            {
                return Math.Abs(this.Point1.X - this.Point2.X); 
            } 
        }

        public double Heigth
        {
            get
            {
                return Math.Abs(this.Point1.Y - this.Point2.Y);
            }
        }

        public double Perimeter()
        {
            return 2 * (this.Width + this.Heigth);
        }

        public double Area()
        {
            return this.Heigth * this.Width;
        }

        public override string ToString()
        {
            return String.Format("Прямоугольник со сторонами {0:N} и {1:N}, периметра {2:N} и площади {3:N}", Width, Heigth, Perimeter(), Area());
        }
    }
}
