using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP9
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDynamicArray<int> arr = new MyDynamicArray<int>(5);
            arr.Add(10);
            arr.Add(20);
            arr.Add(30);
            arr.Add(40);
            arr.Add(50);
            arr.Add(60);
            arr.AddRange(new int[] { 70, 80, 90, 100, 110, 120, 130, 140, 150 });
            arr[5] = 111;
            arr.Remove(111);
            arr.Insert(5, 111);
            foreach (var item in arr)
            {
                Console.WriteLine("{0} ", item);
            }

            var arr1 = new MyDynamicArray<int>(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            foreach (var item in arr1)
            {
                Console.WriteLine("{0} ", item);
            }
            
            

            Console.ReadKey();
        }
    }
}
