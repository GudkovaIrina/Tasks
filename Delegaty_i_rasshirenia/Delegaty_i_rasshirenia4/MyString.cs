using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Delegaty_i_rasshirenia4
{
    static public class MyString
    {
        public static bool IsPositiveNumber(this string str)
        {
            return Regex.IsMatch(str, @"^[1-9][0-9]*$");
        }
    }
}
