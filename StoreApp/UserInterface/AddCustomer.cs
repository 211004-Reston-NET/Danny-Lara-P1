//NOT DONE! Need to add/use logic checks for user input
using System;
using Models;
using DataAccessLogic;
namespace UserInterface
{
    public class AddCustomer : IMenu
    {
        public MenuType Choice()
        {
            Console.WriteLine("Press Enter to go back to Main Menu...");
            Console.ReadLine();
            Console.Clear();
            return MenuType.MainMenu;
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Enter customer name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter email address:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            string phone = Console.ReadLine();
            Customer newCust = new Customer(name, address, email, phone);
            Console.WriteLine("New Customer created!");
        }
    }
}