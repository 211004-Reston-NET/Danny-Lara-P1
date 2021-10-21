using System;
using BusinessLogic;
using DataAccessLogic;

namespace UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            IFactory factory = new MenuFactory();
            IMenu page = new MainMenu();

            while (loop)
            {
                Console.Clear();
                page.Menu();
                MenuType currentPage = page.Choice();
                
                if (currentPage == MenuType.Exit)
                {
                    Console.WriteLine("Thanks for shopping with us!");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    loop = false;
                }
                else
                    page = factory.GetMenu(currentPage);
            }
            
        }
    }
}