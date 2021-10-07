using System;
namespace UserInterface
{
    public class MainMenu : IMenu
    {
        public MenuType Choice()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    return MenuType.AddCustomer;
                case "2":
                    return MenuType.Search;
                case "3":
                    return MenuType.Inventory;
                case "4":
                    return MenuType.PlaceOrder;
                case "5":
                    return MenuType.OrderHistory;
                case "6":
                    return MenuType.Replenish;
                case "7":
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
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] - Add a customer");
            Console.WriteLine("[2] - Search for a customer");
            Console.WriteLine("[3] - View store inventory");
            Console.WriteLine("[4] - Place an order");
            Console.WriteLine("[5] - View order history");
            Console.WriteLine("[6] - Replenish inventory");
            Console.WriteLine("[7] - Exit");
        }
    }
}