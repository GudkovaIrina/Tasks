using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegaty_i_rasshirenia3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr2 = new string[] { "hjbjik", "hgvab", "4dfgjn", "aaaaa" };
            Sorting<string> arrForSorting = new Sorting<string>(arr2, CompareString);
            arrForSorting.SortingIsMade += OnSortingIsMade;
            arrForSorting.SortInSeparateThread();
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

        static public void OnSortingIsMade(object sender, EventArgsForSortingIsMade<string> e)
        {
            Console.WriteLine(e.Message);
            foreach (var item in e.arr)
            {
                Console.Write(item + " ");
            }
        }
    }
}
