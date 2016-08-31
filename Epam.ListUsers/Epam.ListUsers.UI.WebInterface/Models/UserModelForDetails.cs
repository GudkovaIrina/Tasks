using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ListUsers.UI.WebInterface.Models
{
    public class UserModelForDetails
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DateOfBirth { get; set; }

        public List<String> Awards { get; set; }

        public int Age { get; set; }
    }
}