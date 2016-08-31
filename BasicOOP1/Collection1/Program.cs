using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }

            var deleteEverySecond = new DeleteEveryMultiple<int>(arr);
            Console.WriteLine("Остался человек номер {0}", deleteEverySecond.ResultProcess(2));
            Console.ReadKey();
        }
    }
}
