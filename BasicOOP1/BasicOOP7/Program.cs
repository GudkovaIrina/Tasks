using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP7
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point() { X = 1, Y = 1};
            Point p2 = new Point() { X = 1, Y = 1 };
            
            Line line = new Line(p1, p2);
            Console.WriteLine(line);

            Round round = new Round(p1, p2);
            Console.WriteLine(round);

            var circle = new Circle(p1, p2);
            Console.WriteLine(circle);

            var ring = new Ring(p1, p2, 1);
            Console.WriteLine(ring);

            var rect = new Rectangle(p1, p2);
            Console.WriteLine(rect);

            Console.ReadKey();
        }
    }
}
