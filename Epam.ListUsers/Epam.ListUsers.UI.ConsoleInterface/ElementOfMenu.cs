using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.UI.ConsoleInterface
{
    public class ElementOfMenu
    {
        public Action Command { get; set; }

        public HashSet<string> SetOfAvailableCommandAfter { get; set; }

        public ElementOfMenu(Action command, HashSet<string> setOfAvailableCommandAfter)
        {
            Command = command;
            SetOfAvailableCommandAfter = setOfAvailableCommandAfter;
        }
    }
}
