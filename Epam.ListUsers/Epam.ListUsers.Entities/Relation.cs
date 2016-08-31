using System;
using System.Collections.Generic;

namespace Epam.ListUsers.Entities
{
    public class Relation
    {
        public Guid IdOfUser { get; set; }

        public List<Guid> IdOfAwards;

        public Relation()
        {
        }

        public Relation(Guid idOfUser, IEnumerable<Guid> IdOfAwards)
        {
            this.IdOfUser = idOfUser;
            this.IdOfAwards = new List<Guid>(IdOfAwards);
        }
    }
}