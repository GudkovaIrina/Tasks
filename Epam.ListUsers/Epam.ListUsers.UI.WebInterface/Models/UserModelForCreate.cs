using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ListUsers.UI.WebInterface.Models
{
    public class UserModelForCreate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DateOfBirth { get; set; }
    }
}