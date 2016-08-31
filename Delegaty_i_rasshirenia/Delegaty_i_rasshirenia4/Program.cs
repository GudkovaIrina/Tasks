using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty_i_rasshirenia4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 3, 6, 9, 7 };
            Console.WriteLine(arr.Summa());
            Console.WriteLine("225".IsPositiveNumber());
            Console.WriteLine("8h5".IsPositiveNumber());
        }
    }
}
