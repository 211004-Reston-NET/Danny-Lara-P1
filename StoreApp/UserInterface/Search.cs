using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;
namespace UserInterface
{
    public class Search : IMenu
    {
        private CustomerBL _customerBL;
        private List<Customer> _customerList;
        public Search(CustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
            _customerList = _customerBL.GetAll();
        }
        public MenuType Choice()
        {
            string i = Console.ReadLine();
            switch (i)
            {
                case "6":
                    Console.Clear();
                    foreach (Customer c in _customerList)
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine(c);
                        Console.WriteLine("================================");
                    }
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return MenuType.MainMenu;
                case "5":
                    Console.WriteLine("Enter customer ID:");
                    try
                    {
                        int custId = Int32.Parse(Console.ReadLine());
                        foreach (Customer c in _customerList)
                        {
                            if(custId == c.CustID)
                            {
                                Console.Clear();
                                Console.WriteLine("Customer Found!");
                                Console.WriteLine(c);
                                Console.WriteLine("Place an order? Y/N");
                                string response = Console.ReadLine();
                                if(response.ToLower() == "y")
                                    return MenuType.PlaceOrder;
                                else
                                    return MenuType.MainMenu;
                            }
                            Console.WriteLine("Customer not found!\nPress Enter to search again...");
                            Console.ReadLine();
                            return MenuType.Search;
                        }
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Invalid input!\nPress Enter to try again...");
                        Console.ReadLine();
                        return MenuType.Search;
                    }
                    Console.WriteLine("Unknown error!\nPress Enter to try again...");
                    Console.ReadLine();
                    return MenuType.Search;
                case "4":
                    Console.WriteLine("Enter customer name:");
                    string name = Console.ReadLine();
                    foreach (Customer c in _customerList)
                    {
                        if(name.ToLower().Equals(c.Name.ToLower()))
                        {
                            Console.Clear();
                            Console.WriteLine("Customer Found!");
                            Console.WriteLine(c);
                            Console.WriteLine("Place an order? Y/N");
                                string response = Console.ReadLine();
                                if(response.ToLower() == "y")
                                    return MenuType.PlaceOrder;
                                else
                                    return MenuType.MainMenu;
                        }
                    }
                    Console.WriteLine("Customer not found!\nPress Enter to try again...");
                    Console.ReadLine();
                    return MenuType.Search;
                case "3":
                    Console.WriteLine("Enter customer address:");
                    string a = Console.ReadLine();
                    foreach (Customer c in _customerList)
                    {
                        if(a.Equals(c.Address))
                        {
                            Console.Clear();
                            Console.WriteLine("Customer Found!");
                            Console.WriteLine(c);
                            Console.WriteLine("Place an order? Y/N");
                                string response = Console.ReadLine();
                                if(response.ToLower() == "y")
                                    return MenuType.PlaceOrder;
                                else
                                    return MenuType.MainMenu;
                        }
                    }
                    Console.WriteLine("Customer not found!\nPress Enter to try again...");
                    Console.ReadLine();
                    return MenuType.Search;
                case "2":
                    Console.WriteLine("Enter customer phone number:");
                    string num = Console.ReadLine();
                    foreach (Customer c in _customerList)
                    {
                        if(num.Equals(c.PhoneNumber))
                        {
                            Console.Clear();
                            Console.WriteLine("Customer Found!");
                            Console.WriteLine(c);
                            Console.WriteLine("Place an order? Y/N");
                            string response = Console.ReadLine();
                            if(response.ToLower() == "y")
                                return MenuType.PlaceOrder;
                            else
                                return MenuType.MainMenu;
                        }
                    }
                    Console.WriteLine("Customer not found!\nPress Enter to try again...");
                    Console.ReadLine();
                    return MenuType.Search;
                case "1":
                    Console.WriteLine("Enter customer email address:");
                    string custEmail = Console.ReadLine();
                    foreach (Customer c in _customerList)
                    {
                        if(custEmail.Equals(c.Email))
                        {
                            Console.Clear();
                            Console.WriteLine("Customer Found!");
                            Console.WriteLine(c);
                            Console.WriteLine("Place an order? Y/N");
                            string response = Console.ReadLine();
                            if(response.ToLower() == "y")
                                return MenuType.PlaceOrder;
                            else
                                return MenuType.MainMenu;;
                        }
                    }
                    Console.WriteLine("Customer not found!\nPress Enter to try again...");
                    Console.ReadLine();
                    return MenuType.Search;
                case "0":
                    Console.Clear();
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Unknown error!\nPress Enter to try again...");
                    Console.ReadLine();
                    return MenuType.Search;
            }
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("-----Searching for a customer-----");
            Console.WriteLine("How would you like to search?");
            Console.WriteLine("[6] - View All Customers");
            Console.WriteLine("[5] - Customer ID");
            Console.WriteLine("[4] - Name");
            Console.WriteLine("[3] - Address");
            Console.WriteLine("[2] - Phone Number");
            Console.WriteLine("[1] - Email");
            Console.WriteLine("[0] - Go Back");
        }
    }
}