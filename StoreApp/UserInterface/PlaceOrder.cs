using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class PlaceOrder : IMenu
    {
        private StoreBL _storeBL;
        private List<Store> _stores;
        private int _custId;
        public PlaceOrder(StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
            _stores = _storeBL.GetAll();
            for (int i = 0; i < _stores.Count; i++)
            {
                _stores[i].StoreID = i+1;
            }
        }
        public MenuType Choice()
        {
            string input = Console.ReadLine();
            IMenu page = new MainMenu();
            MenuType m = new MenuType();
            bool loop = true;
            switch (input)
            {
                case "4":
                    page = new StoreOrderMenu(_storeBL, 0, _custId);
                    while (loop)
                    {
                        page.Menu();
                        m =page.Choice();
                        Console.Clear();
                        if (m != MenuType.StoreOrderMenu)
                            loop = false;
                    }
                    return m;
                case "3":
                    page = new StoreOrderMenu(_storeBL, 1, _custId);
                    while (loop)
                    {
                        page.Menu();
                        m =page.Choice();
                        Console.Clear();
                        if (m != MenuType.StoreOrderMenu)
                            loop = false;
                    }
                    return m;
                case "2":
                    page = new StoreOrderMenu(_storeBL, 2, _custId);
                    while (loop)
                    {
                        page.Menu();
                        m =page.Choice();
                        Console.Clear();
                        if (m != MenuType.StoreOrderMenu)
                            loop = false;
                    }
                    return m;
                case "1":
                    page = new StoreOrderMenu(_storeBL, 3, _custId);
                    while (loop)
                    {
                        page.Menu();
                        m =page.Choice();
                        Console.Clear();
                        if (m != MenuType.StoreOrderMenu)
                            loop = false;
                    }
                    return m;
                case "0":
                    Console.Clear();
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Invalid input!\nPress Enter to try again...");
                    Console.ReadLine();
                    Console.Clear();
                    return MenuType.PlaceOrder;
            }
        }

        public void Menu()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Enter Customer ID:");
                try
                {
                    _custId = Int32.Parse(Console.ReadLine());
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Invaild input!\nPress Enter to try again...");
                    Console.ReadLine();
                }
                if (_storeBL.CustExists(_custId))
                    loop = false;
                else
                {
                    Console.WriteLine("Customer not found!\nPress Enter to try again...");
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Console.WriteLine("---------------Place Order---------------");
            Console.WriteLine("Which store would you like to order from?");
            Console.WriteLine("[4] - Rose's Roses");
            Console.WriteLine("[3] - David's Daffodils");
            Console.WriteLine("[2] - Lily's Lilies");
            Console.WriteLine("[1] - Steve's Sunflowers");
            Console.WriteLine("[0] - Go back to Main Menu");
        }
    }
}