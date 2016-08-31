using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tr = new Triangle(3, 4, 5);
            Console.WriteLine("Стороны треугольника: {0:N}, {1:N}, {2:N}", tr.A, tr.B, tr.C);
            Console.WriteLine("Периметр треугольника: {0:N}", tr.Perimeter());
            Console.WriteLine("Площадь треугольника: {0:N}", tr.Area());
            tr.ChangeSides(5, 4, 8);
            Console.WriteLine("Стороны нового треугольника: {0:N}, {1:N}, {2:N}", tr.A, tr.B, tr.C);
            Console.ReadKey();
        }
    }
}
