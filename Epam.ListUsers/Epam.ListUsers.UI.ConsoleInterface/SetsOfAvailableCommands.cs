using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.UI.ConsoleInterface
{
    static public class SetsOfAvailableCommands
    {
        static public HashSet<string> InitAvailableCommands = 
            new HashSet<string>(
                new string[] {
                              "adduser",
                              "addaward",
                              "exit",
                              "help",
                              "getawards",
                              "getusers" 
                            });
        static public HashSet<string> AvailableCommandsForCurrentUser = 
            new HashSet<string>(
                new string[] {
                              "detailsofcurrentuser",
                              "editcurrentuser",
                              "reawardcurrentuser",
                              "removecurrentuser",
                              "toawardcurrentuser"
                            });
        static public HashSet<string> AvailableCommandsForCurrentAward =
            new HashSet<string>(
                new string[] {
                              "detailsofcurrentaward",
                              "editcurrentaward",
                              "removecurrentaward"
                            });
    }
}
