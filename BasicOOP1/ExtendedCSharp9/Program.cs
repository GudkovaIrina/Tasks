using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCSharp9
{
    class Program
    {
        delegate void func();
        static void Main(string[] args)
        {
            WatchingByFolder watching = null; ;
            bool endWorkProgram = false;
            do
            {
                int mode = SelectedMode();
                switch (mode)
                {
                    case 1: 
                        {
                            watching = new WatchingByFolder(@"D:\watch"); 
                            watching.StartWatching();
                        } break;
                    case 2: IfModeWatchingRun(watching, watching.PauseWatching); break;
                    case 3: IfModeWatchingRun(watching, watching.StartWatching); break;
                    case 4: IfModeWatchingRun(watching, watching.StopWatching); break;
                    case 5:
                        {
                            var backChanges = new BackChanges(@"D:\watch");
                            Console.WriteLine("Введите время, на какой момент восстановить в формате: dd-mm-yyyy hh:mm:ss");
                            DateTime time;
                            if (DateTime.TryParse(Console.ReadLine(), out time))
                            {
                                backChanges.BackAtTime(time);
                            }
                        }
                        break;
                    case 6:
                            if (watching.IfRunWatching())
                            {
                                Console.WriteLine("Прежде чем закончить работу программы, надо закончить режим наблюдения!");
                            }
                            else
                            {
                                endWorkProgram = true;
                            }; break;
                }

            } while (!endWorkProgram);
        }

        static public int SelectedMode()
        {
            Console.WriteLine("Введите номер режима работы программы:");
            Console.WriteLine("1. Запустить режим наблюдения");
            Console.WriteLine("2. Приостановить режим наблюдения");
            Console.WriteLine("3. Возобновить режим наблюдения");
            Console.WriteLine("4. Закончить режим наблюдения");
            Console.WriteLine("5. Запустить режим отката изменений");
            Console.WriteLine("6. Закончить работу программы");

            int mode;
            while (!int.TryParse(Console.ReadLine(), out mode) || mode < 1 || mode > 6)
            {
                Console.WriteLine("Введены некорректные данные, попробуйте еще раз выбрать режим работы программы:");
            }
            return mode;
        }

        static void IfModeWatchingRun(WatchingByFolder watching, func func)
        {
            if (watching == null)
            {
                Console.WriteLine("Режим наблюдения еще не запущен!");
            }
            else
            {
                func();
            }
        }
    }
}
