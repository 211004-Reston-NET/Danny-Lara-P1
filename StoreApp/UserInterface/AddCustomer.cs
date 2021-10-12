//NOT DONE! Need to add/use logic checks for user input
using System;
using Models;
using BusinessLogic;
namespace UserInterface
{
    public class AddCustomer : IMenu
    {
        private static Customer _cust = new Customer();
        private CustomerBL _customerBL;
        public AddCustomer(CustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public MenuType Choice()
        {
            string i = Console.ReadLine();
            switch (i)
            {
                case "5":
                    _customerBL.Add(_cust);
                    Console.Clear();
                    return MenuType.MainMenu;
                case "4":
                    Console.WriteLine("Enter customer name:");
                    _cust.Name = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "3":
                    Console.WriteLine("Enter address:");
                    _cust.Address = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "2":
                    Console.WriteLine("Enter phone number:");
                    _cust.PhoneNumber = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "1":
                    Console.WriteLine("Enter email address:");
                    _cust.Email = Console.ReadLine();
                    return MenuType.AddCustomer;
                default:
                    Console.WriteLine("Invalid Input!");
                    Console.WriteLine("Press Enter to continue...");
                    return MenuType.AddCustomer;
            }
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Adding a new Customer");
            Console.WriteLine("Name - " + _cust.Name);
            Console.WriteLine("Address - " + _cust.Address);
            Console.WriteLine("Phone - " + _cust.PhoneNumber);
            Console.WriteLine("Email - " + _cust.Email);
            Console.WriteLine("[5] - Add Customer");
            Console.WriteLine("[4] - Input Name");
            Console.WriteLine("[3] - Input Address");
            Console.WriteLine("[2] - Input Phone Number");
            Console.WriteLine("[1] - Input Email Address");
            Console.WriteLine("[0] - Go Back");
        }
    }
}