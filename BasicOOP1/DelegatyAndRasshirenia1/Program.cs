using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatyAndRasshirenia1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[] { "hjbjik", "hgvab", "4dfgjn", "aaaaa" };
            Sort<string>(arr, 0, arr.Length - 1, CompareString);
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }

        static int Partition<T>(T[] arr, int a, int b, Func<T,T,int> func)
        {
            int i = a;
            for (int j = a; j <= b; j++)         
            {
                if (func(arr[j],arr[b]) <= 0)  
                {
                    T t = arr[i];                  
                    arr[i] = arr[j];                 
                    arr[j] = t;                    
                    i++;                         
                }
            }
            return i - 1;                        
        }

        static public void Sort<T>(T[] arr, int a, int b, Func<T, T, int> func)
        {
            if (a >= b) return;
            int c = Partition(arr, a, b, func);
            Sort(arr, a, c - 1, func);
            Sort(arr, c + 1, b, func);
        }

        static public int CompareString(string str1, string str2)
        {
            if (str1 == str2)
	        {
		        return 0;
	        }
            if (str1.Length != str2.Length)
            {
                return str1.Length - str2.Length;
            }
            else
            {
                int i = 0;
                while (str1[i] == str2[i])
                {
                    i++;
                }
                return str1[i].CompareTo(str2[i]);
            }
        }
    }
}
