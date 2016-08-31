using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCSharp8
{
    class Program
    {
        static void Main(string[] args)
        {
            //int N = 100;
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            //string str = "";
            //for (int i = 0; i < N; i++)
            //{
            //    str += "*";
            //}
            SummToStringAtDifferentClass.SummToStringAtClassString();
            Console.WriteLine(stopwatch.ElapsedTicks);
            
            stopwatch.Restart();
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < N; i++)
            //{
            //    sb.Append("*");
            //}
            SummToStringAtDifferentClass.SummToStringAtClassStringBuilder();
            Console.WriteLine(stopwatch.ElapsedTicks);
            stopwatch.Stop();

            Console.ReadKey();
        }
    }
}
