using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Round round = new Round();
            Console.WriteLine("Введите координаты центра круга");
            Console.Write("x: ");
            round.X = InputDate();
            Console.Write("y: ");
            round.Y = InputDate();
            Console.WriteLine("Введите радиус круга");
            round.R = ControlValidityOfRadius(InputDate());

            Console.WriteLine("Длина окружности вашего круга равна {0:N}", round.Length());
            Console.WriteLine("Площадь вашего круга равна {0:N}", round.Area());
        }

        static double InputDate()
        {
            double date;
            while (!(double.TryParse(Console.ReadLine(), out date)))
            {
                Console.WriteLine("Данные не корректны. Попробуйте еще раз!");
            }
            return date;
        }

        static double ControlValidityOfRadius( double radius)
        {
            while (radius <= 0)
            {
                Console.WriteLine("Радиус должен быть числом положительным. Попробуйте еще раз!");
                radius = InputDate();
            }
            return radius;
        }
    }
}
