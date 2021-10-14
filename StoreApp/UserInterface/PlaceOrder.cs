using System;
using DataAccessLogic;
namespace UserInterface
{
    public class PlaceOrder : IMenu
    {
        public MenuType Choice()
        {
            throw new NotImplementedException();
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Which store would you like to see?");
            Console.WriteLine("[4] - Rose's Roses");
            Console.WriteLine("[3] - David's Daffodils");
            Console.WriteLine("[2] - Lily's Lilies");
            Console.WriteLine("[1] - Steve's Sunflowers");
            Console.WriteLine("[0] - Go back to Main Menu");
        }
    }
}