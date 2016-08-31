using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ListUsers.UI.WebInterface.Models
{
    public class AwardModelForDetailsAndReAward
    {
        public Guid IdAward { get; set; }

        public Guid IdUser { get; set; }

        public String Title { get; set; }

        public String NameUser { get; set; }
    }
}