using System;

namespace UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Flower Shop App!");
            bool loop = true;
            IMenu page = new MainMenu();

            while (loop)
            {
                page.Menu();
                MenuType currentPage = page.Choice();
                switch (currentPage)
                {
                    case MenuType.MainMenu:
                        page = new MainMenu();
                        break;
                    case MenuType.AddCustomer:
                        page = new AddCustomer();
                        break;
                    /*case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":*/
                    case MenuType.Exit:
                        Console.WriteLine("Thank you, and have a nice day!");
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Forgot to add a menu!");
                        loop = false;
                        break;
                }
            }
            
        }
    }
}