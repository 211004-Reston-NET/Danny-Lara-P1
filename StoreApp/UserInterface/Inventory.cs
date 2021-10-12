using System;
using DataAccessLogic;
namespace UserInterface
{
    public class Inventory : IMenu
    {
        public MenuType Choice()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //Get info for Store 1
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default:
                    break;
            }
            Console.Clear();
            return MenuType.MainMenu;
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Which store would you like to see?");
            Console.WriteLine("[1] - Rose's Roses");
            Console.WriteLine("[2] - David's Daffodils");
            Console.WriteLine("[3] - Lily's Lilies");
            Console.WriteLine("[4] - Steve's Sunflowers");
            Console.WriteLine("[5] - Go back to Main Menu");
        }
    }
}