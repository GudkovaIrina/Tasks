using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP4
{
    class Program
    {
        static void Main(string[] args)
        {

            var str1 = new MyString(5);
            str1[0] = 'a';
            str1[1] = 'b';
            str1[2] = 'c';
            str1[3] = 'd';
            str1[4] = 'e';
            Console.WriteLine(str1);
            Console.WriteLine("Длина строки: " + str1.Length);
            string s = str1;
            MyString str2 = (MyString)s;
            char[] ch = { '1', '2', '3' };
            str2 = str1 + new MyString(ch);
            Console.WriteLine(str2);
            Console.WriteLine("Длина строки: " + str2.Length);
            str1.Insert(1, str2);
            Console.WriteLine(str1);
            Console.WriteLine("Длина строки: " + str1.Length);
            Console.ReadKey();
        }
    }
}
