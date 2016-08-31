using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ListUsers.UI.WebInterface.Models
{
    public class AwardsModelForToAward
    {
        public Guid IdUser { get; set; }

        public List<AwardModel> Awards { get; set; }
    }
}