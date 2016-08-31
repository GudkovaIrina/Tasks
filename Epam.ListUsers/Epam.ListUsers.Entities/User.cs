using System;
using System.Collections.Generic;

namespace Epam.ListUsers.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Award> Awards { get; set; }

        public User(string name, DateTime dateOfBirth)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Awards = new List<Award>();
        }

        public int Age()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateOfBirth.AddYears(age) > DateTime.Now)
            {
                return age - 1;
            }
            return age;
        }
    }
}