using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtendedCSharp3_7
{
    class InspectionStrings
    {
        static public bool ExistDate(string str)
        {
            return Regex.IsMatch(str, @"(?:(?:[0][1-9])|(?:[1-3][0-9]))-(?:(?:[0][1-9])|(?:[1][0-2]))-[12][0-9]{3}");
        }
        static public string ReplaceTags(string str)
        {
            return Regex.Replace(str, @"<\/?.*?>","_");
        }

        static public MatchCollection SearchEmail(string str)
        {
            return Regex.Matches(str, @"[A-Za-z0-9][A-Za-z0-9\-_\.]*[A-Za-z0-9]@([A-Za-z0-9][A-Za-z0-9\-_]*[A-Za-z0-9]\.)*[a-z]{2,6}");
        }

        static public string DefineNotationOfNumber(string str)
        {
            if (Regex.IsMatch(str, @"^-?[0-9]+(?:\.[0-9]+)?$"))
            {
                return "Это число в обычной нотации";
            }
            else if (Regex.IsMatch(str, @"^-?[0-9]\.[0-9]+e-?[0-9]+$"))
            {
                return "Это число в научной нотации";
            }
            else
            {
                return "Это не число";
            }
        }

        static public int DefineNumberTimeInText(string str )
        {
            return Regex.Matches(str, @"(?:(?:[0-1]?[0-9])|(?:2[0-4])):[0-5][0-9]").Count;
        }
    }
}
