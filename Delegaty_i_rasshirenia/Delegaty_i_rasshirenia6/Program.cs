using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty_i_rasshirenia6
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            IEnumerable<int> result;
            int[] arr = new int[1000];
            long mediana = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-500, 500);
            }

            Stopwatch watch = new Stopwatch();
            
            mediana = 0;
            for (int i = 0; i < 100; i++)
            {
                watch.Start();
                result = SearchPositiveNumber(arr);
                watch.Stop();
                mediana += watch.ElapsedTicks;
            }
            Console.WriteLine(mediana/100);

            Predicate<int> predicate = IsPositive;
            mediana = 0;
            for (int i = 0; i < 100; i++)
            {
                watch.Start();
                result = SearchOfDelegat(arr, predicate);
                watch.Stop();
                mediana += watch.ElapsedTicks;
            }
            Console.WriteLine(mediana / 100);

            mediana = 0;
            for (int i = 0; i < 100; i++)
            {
                watch.Start();
                result = SearchOfDelegat(arr, delegate(int x) { return x > 0; });
                watch.Stop();
                mediana += watch.ElapsedTicks;
            }
            Console.WriteLine(mediana / 100);

            mediana = 0;
            for (int i = 0; i < 100; i++)
            {
                watch.Start();
                result = SearchOfDelegat(arr, x => x > 0);
                watch.Stop();
                mediana += watch.ElapsedTicks;
            }
            Console.WriteLine(mediana / 100);

            mediana = 0;
            for (int i = 0; i < 100; i++)
            {
                watch.Start();
                result = arr.Where(x => x > 0);
                watch.Stop();
                mediana += watch.ElapsedTicks;
            }
            Console.WriteLine(mediana / 100);

            Console.ReadKey();
        }

        static IEnumerable<int> SearchPositiveNumber(int[] arr)
        {
            foreach (var item in arr)
            {
                if (item > 0)
                {
                    yield return item;
                }
            }
        }

        static IEnumerable<int> SearchOfDelegat(int[] arr, Predicate<int> predicate)
        {
            foreach (var item in arr)
	        {
		        if (predicate(item))
	            {
                    yield return item;
	            }
	        }
        }

        static bool IsPositive(int a)
        {
            return a > 0;
        }
    }
}
