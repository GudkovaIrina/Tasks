using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.UI.ConsoleInterface
{
    public class DictionaryOfComand
    {
        public Dictionary<string, ElementOfMenu> Menu { get; private set; }
        private CommandsForMenu commandsForMenu;
        public HashSet<string> availableCommands;

        public DictionaryOfComand()
        {
            availableCommands = SetsOfAvailableCommands.InitAvailableCommands;
            commandsForMenu = new CommandsForMenu();
            Menu = new Dictionary<string, ElementOfMenu>();
            HashSet<string> availableCommandsAfter;
            
            availableCommandsAfter = SetsOfAvailableCommands.InitAvailableCommands;
            AddCommandToMenu("adduser", commandsForMenu.AddUser, availableCommandsAfter);
            AddCommandToMenu("addaward", commandsForMenu.AddAward, availableCommandsAfter);
            AddCommandToMenu("help", Help, availableCommands);
            
            availableCommandsAfter = new HashSet<string>(
                                         availableCommandsAfter.Union(new string[] { "detailsofcurrentuser" }));
            AddCommandToMenu("getusers", commandsForMenu.GetUsers, availableCommandsAfter);
            
            availableCommandsAfter = new HashSet<string>(
                                 availableCommandsAfter.Union(SetsOfAvailableCommands.AvailableCommandsForCurrentUser));
            AddCommandToMenu("detailsofcurrentuser", commandsForMenu.DetailsOfCurrentUser, availableCommandsAfter);
            AddCommandToMenu("editcurrentuser", commandsForMenu.EditCurrentUser, availableCommandsAfter);
            AddCommandToMenu("toawardcurrentuser", commandsForMenu.ToAwardCurrentUser, availableCommandsAfter);
            AddCommandToMenu("reawardcurrentuser", commandsForMenu.ReAwardCurrentUser, availableCommandsAfter);
            AddCommandToMenu("removecurrentuser", commandsForMenu.RemoveCurrentUser, availableCommandsAfter);

            availableCommandsAfter = new HashSet<string>(
                SetsOfAvailableCommands.InitAvailableCommands.Union(new string[] { "detailsofcurrentaward" }));
            AddCommandToMenu("getawards", commandsForMenu.GetAwards, availableCommandsAfter);

            availableCommandsAfter = new HashSet<string>(
                                availableCommandsAfter.Union(SetsOfAvailableCommands.AvailableCommandsForCurrentAward));
            AddCommandToMenu("detailsofcurrentaward", commandsForMenu.DetailsOfCurrentAward, availableCommandsAfter);
            AddCommandToMenu("editcurrentaward", commandsForMenu.EditCurrentAward, availableCommandsAfter);
            AddCommandToMenu("removecurrentaward", commandsForMenu.RemoveCurrentAward, availableCommandsAfter);
        }

        private void AddCommandToMenu(String key, Action command, HashSet<string> availableCommandsAfter)
        {
            ElementOfMenu element = new ElementOfMenu(command, availableCommandsAfter);
            Menu.Add(key, element);
        }

        public void Help()
        {
            Console.WriteLine("Доступные команды: ");
            foreach (var command in availableCommands)
            {
                Console.WriteLine(command);
            }
            Menu["help"].SetOfAvailableCommandAfter = availableCommands;
        }
    }
}
