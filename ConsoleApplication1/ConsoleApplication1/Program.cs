using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        [Flags]
        enum Options
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
        }
        static void Main(string[] args)
        {
            Options Opt = Options.None;
            string str = String.Empty;
            Console.WriteLine("Параметры надписи: " + Opt);
            
            while (str != "0")
            {
                Console.WriteLine("Введите:");
                Console.WriteLine("0: Stop!");
                Console.WriteLine("1: Bold");
                Console.WriteLine("2: Italic");
                Console.WriteLine("3: Underline");
                
                str = Console.ReadLine();
                
                switch (str)
                {
                    case "1": Opt ^= Options.Bold; break;
                    case "2": Opt ^= Options.Italic; break;
                    case "3": Opt ^= Options.Underline; break;
                    default: str = "0"; break;
                }
                Console.WriteLine("Параметры надписи: " + Opt);
            }
            
        }
    }
}
