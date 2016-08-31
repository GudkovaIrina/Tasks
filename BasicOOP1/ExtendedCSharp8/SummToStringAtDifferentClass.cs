using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCSharp8
{
    class SummToStringAtDifferentClass
    {
        static public void SummToStringAtClassString()
        {
            int N = 100;
            string str = "";
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
        }

        static public void SummToStringAtClassStringBuilder()
        {
            int N = 100;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
        }
    }
}
