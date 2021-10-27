using System;
using DataAccessLogic;
namespace UserInterface
{
    public class MainMenu : IMenu
    {
        public MenuType Choice()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "6":
                    return MenuType.AddCustomer;
                case "5":
                    return MenuType.Search;
                case "4":
                    return MenuType.Inventory;
                case "3":
                    return MenuType.PlaceOrder;
                case "2":
                    return MenuType.OrderHistory;
                case "1":
                    return MenuType.Replenish;
                case "0":
                    return MenuType.Exit;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to the Flower Shop App!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[6] - Add a customer");
            Console.WriteLine("[5] - Search for a customer");
            Console.WriteLine("[4] - View store inventory");
            Console.WriteLine("[3] - Place an order");
            Console.WriteLine("[2] - View order history");
            Console.WriteLine("[1] - Replenish inventory");
            Console.WriteLine("[0] - Exit");
        }
    }
}