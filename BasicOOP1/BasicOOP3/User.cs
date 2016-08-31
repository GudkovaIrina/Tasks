using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP3
{
    public class User
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set 
            {
                if (value.AddYears(100) < DateTime.Now)
                {
                    throw new FormatException("This is very old human!");
                }
                else if (value > DateTime.Now)
                {
                    throw new FormatException("This human was not born yet!");
                }
                else
                {
                    dateOfBirth = value;
                }
            }
        }

        public User()
        {

        }

        public User(string surname, string name, string patronymic, DateTime dateOfBirth)
        {
            this.Surname = surname;
            this.Name = name;
            this.Patronymic = patronymic;
            this.DateOfBirth = dateOfBirth;
        }
        public int Age()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateOfBirth.AddYears(age) > DateTime.Now)
            {
                return age - 1;
            }
            else 
            {
                return age;
            }
        }
    }
}
