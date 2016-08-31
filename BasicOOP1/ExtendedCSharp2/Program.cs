using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCSharp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первую строку: ");
            string str1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            string str2 = Console.ReadLine();
            Console.Write("Результирующая строка: {0}", StringHandler.Doubler(str1,str2));
            Console.ReadKey();
        }
    }
}
