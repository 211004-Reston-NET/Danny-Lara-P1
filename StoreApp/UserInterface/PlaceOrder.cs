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
        public PlaceOrder(StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
            _stores = _storeBL.GetAll();
        }
        public MenuType Choice()
        {
            string input = Console.ReadLine();
            IMenu page = new MainMenu();
            MenuType m = new MenuType();
            bool loop = true;
            switch (input)
            {
                case "0":
                    page = new StoreOrderMenu(_storeBL, 0);
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
                    page = new StoreOrderMenu(_storeBL, 1);
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
                    page = new StoreOrderMenu(_storeBL, 2);
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
                    page = new StoreOrderMenu(_storeBL, 3);
                    while (loop)
                    {
                        page.Menu();
                        m =page.Choice();
                        Console.Clear();
                        if (m != MenuType.StoreOrderMenu)
                            loop = false;
                    }
                    return m;
                case "4":
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
            Console.Clear();
            Console.WriteLine("Which store would you like to order from?");
            Console.WriteLine("[0] - Rose's Roses");
            Console.WriteLine("[1] - David's Daffodils");
            Console.WriteLine("[2] - Lily's Lilies");
            Console.WriteLine("[3] - Steve's Sunflowers");
            Console.WriteLine("[4] - Go back to Main Menu");
        }
    }
}