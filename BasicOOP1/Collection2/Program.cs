using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку, состоящую из букв английского алфавита, пробелов и запятых:");
            string str = Console.ReadLine();
            Dictionary<string, int> dict = SpliterForString.Spliter(str);
            foreach (var item in dict)
            {
                Console.WriteLine("{0}\t{1}", item.Key, item.Value);
            }
            Console.WriteLine("Средняя длина слов: {0:N}", SpliterForString.AverageLengthOfWords(str));
            Console.ReadKey();
        }
    }
}
