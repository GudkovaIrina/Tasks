using Epam.ListUsers.BLL.Logic;
using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Epam.ListUsers.UI.ConsoleInterface
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DictionaryOfComand commands = new DictionaryOfComand();
            commands.Help();
            string command;
            do
            {
                Console.Write("Введите команду: "); 
                command = Console.ReadLine().ToLower().Trim();
                while (!commands.availableCommands.Contains(command))
                {
                    Console.WriteLine("Эта команда в данный момент недоступна. Введите другую команду: ");
                    commands.Help();
                    command = Console.ReadLine().ToLower().Trim();
                }
                if (commands.Menu.ContainsKey(command))
                {
                    commands.Menu[command].Command();
                    commands.availableCommands = commands.Menu[command].SetOfAvailableCommandAfter;
                }
            } while (command != "exit");
        }
    }
}