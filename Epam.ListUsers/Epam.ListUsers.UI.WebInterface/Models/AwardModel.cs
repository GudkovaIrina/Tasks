using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ListUsers.UI.WebInterface.Models
{
    public class AwardModel
    {
        public Guid Id { get; set; }

        public String Title { get; set; }

        public List<String> Users { get; set; }
    }
}