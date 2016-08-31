using System;

namespace Epam.ListUsers.Entities
{
    public class Award
    {
        public Guid Id { get; set; }

        public String Title { get; set; }

        public Award(string title)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
        }
    }
}