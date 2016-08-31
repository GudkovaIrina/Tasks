using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCSharp2
{
    class StringHandler
    {
        static public string Doubler(string str1, string str2)
        {
            StringBuilder result = new StringBuilder(str1.Length * 2);
            for (int i = 0; i < str1.Length; i++)
            {
                result.Append(str1[i]);
                if (str2.Contains(str1[i]))
                {
                    result.Append(str1[i]);
                }
            }
            return result.ToString();
        }
    }
}
