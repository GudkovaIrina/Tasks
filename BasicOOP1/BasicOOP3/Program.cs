using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP3
{
    class Program
    {
        static void Main(string[] args)
        {
            var u = new User();
            u.Surname = "Петров";
            u.Name = "Иван";
            u.Patronymic = "Павлович";
            u.DateOfBirth = DateTime.Parse("11.09.1987");
            var emp = new Employee(u, DateTime.Parse("12.09.2001"), "teacher");
            Console.WriteLine("{0} {1} {2} возраст {3} должность {4} стаж {5}", emp.Surname, emp.Name, emp.Patronymic, emp.Age(), emp.Position, emp.Experience());
            Console.ReadKey();
        }
    }
}
