using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCSharp3_7
{
    class Program
    {
        static void Main(string[] args)
        {
            //3
            Console.Write("Введите текст, содержащий дату в формате dd-mm-yyyy: ");
            string str = Console.ReadLine();
            if (InspectionStrings.ExistDate(str))
            {
                Console.WriteLine("В тексте \"{0}\" содержится дата", str);
            }
            else
            {
                Console.WriteLine("В тексте \"{0}\" не содержится дата", str);
            }

            //4
            Console.Write("Введите HTML текст: ");
            str = Console.ReadLine();
            Console.WriteLine("Результат замены: {0}", InspectionStrings.ReplaceTags(str));

            Console.Write("Введите строку c электронными адресами: ");
            str = Console.ReadLine();
            Console.WriteLine("Найденные адреса электронной почты:");
            foreach (var item in InspectionStrings.SearchEmail(str))
            {
                Console.WriteLine(item);
            }

            //5
            Console.Write("Введите число: ");
            str = Console.ReadLine();
            Console.WriteLine(InspectionStrings.DefineNotationOfNumber(str));

            //6
            Console.Write("Введите текст, в котором несколько раз присутствует время: ");
            str = Console.ReadLine();
            Console.WriteLine("Время в тексте присутствует {0} раз.", InspectionStrings.DefineNumberTimeInText(str));

            Console.ReadKey();
        }
    }
}
