//NOT DONE! Need to add/use logic checks for user input
using System;
using Models;
using BusinessLogic;
using System.Collections.Generic;

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
                    _cust.Orders = new List<Order>();
                    try
                    {
                         _customerBL.Add(_cust);
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("You must have all fields to add customer!\nPress Enter to continue...");
                        Console.ReadLine();
                        return MenuType.AddCustomer;
                    }
                    Console.WriteLine("Customer added!\nPress Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return MenuType.MainMenu;
                case "4":
                    Console.WriteLine("Enter customer name:");
                    try
                    {
                        _cust.Name = Console.ReadLine();
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Invalid name format! Names contain only letters!\nPress Enter to continue...");
                        Console.ReadLine();
                        return MenuType.AddCustomer;
                    }
                    
                    return MenuType.AddCustomer;
                case "3":
                    Console.WriteLine("Enter address:");
                    try
                    {
                        _cust.Address = Console.ReadLine();
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Invalid address format!\nPress Enter to continue...");
                        Console.ReadLine();
                        return MenuType.AddCustomer;
                    }
                    return MenuType.AddCustomer;
                case "2":
                    Console.WriteLine("Enter phone number:");
                    try
                    {
                        _cust.PhoneNumber = Console.ReadLine();                         
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Invalid phone number!\nUse format (***)***-****\nPress Enter to continue...");
                        Console.ReadLine();
                        return MenuType.AddCustomer;
                    }
                    return MenuType.AddCustomer;
                case "1":
                    Console.WriteLine("Enter email address:");
                    try
                    {
                        _cust.Email = Console.ReadLine();
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Invalid email format!\nPress Enter to continue...");
                        Console.ReadLine();
                        return MenuType.AddCustomer;
                    }
                    
                    return MenuType.AddCustomer;
                case "0":
                    Console.Clear();
                    return MenuType.MainMenu;
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