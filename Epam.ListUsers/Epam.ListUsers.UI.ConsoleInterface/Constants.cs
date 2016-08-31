using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.UI.ConsoleInterface
{
    public class Constants
    {
        public const string PatternForNameOfUser = @"(?:(?:[a-zA-ZА-Яа-яЁё]+)(?:[ ’'-][a-zA-ZА-Яа-я]+)? ){0,2}";
        public const string PatternForDateOfBirthOfUser = @"^(?:(?:0?[1-9])|(?:[12][0-9])|(?:3[01]))\.(?:(?:0[1-9])|(?:[1][0-2]))\.[12][0-9]{3}$";
        public const string PatternForTitleOfAward = @"(?:[a-zA-ZА-Яа-яЁё]+)(?:[12][0-9]{3})?";
        public const string PatternForNameNumberOfEntity = @"^[1-9]+[0-9]*?";

    }
}
