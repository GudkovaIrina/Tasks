using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty_i_rasshirenia4
{
    static public class ArrayOfNumber
    {
        public static int Summa(this int[] arr)
        {
            int summa = 0;
            foreach (var item in arr)
            {
                summa += item;
            }
            return summa;
        }
    }
}
