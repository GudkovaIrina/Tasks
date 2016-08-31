using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP3
{
    class Employee : User
    {
        const int  MinimumAgeForRecruit = 14;
        public string Position { get; set; }
        DateTime dateOfBegining;
        public DateTime DateOfBegining 
        { 
            get
            { return dateOfBegining; }
            set
            {
                if (this.DateOfBirth.AddYears(MinimumAgeForRecruit) > value)
                {
                    throw new ArgumentException("User under aged 14 years must not recruit!");
                }
                else
                {
                    dateOfBegining = value;
                }
            }
        }

        public Employee(User user, DateTime dateOfBegining, String position)
            :base(user.Surname, user.Name, user.Patronymic, user.DateOfBirth)
        {
            DateOfBegining = dateOfBegining;
            Position = position;
        }

        public int Experience()
        {
            int experience = DateTime.Now.Year - DateOfBegining.Year;
            if (DateOfBegining.AddYears(experience) > DateTime.Now)
            {
                return experience - 1;
            }
            else
            {
                return experience;
            }
        }
    }
}
