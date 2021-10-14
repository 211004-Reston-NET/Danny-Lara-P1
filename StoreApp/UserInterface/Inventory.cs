using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;
namespace UserInterface
{
    public class Inventory : IMenu
    {
        private StoreBL _storeBL;
        private List<Store> _stores;
        public Inventory(StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
            _stores = _storeBL.GetAll();
        }
        public MenuType Choice()
        {
            List<Product> products;
            Store store;
            string input = Console.ReadLine();
            switch (input)
            {
                case "4":
                    products = _stores[0].Products;
                    store = _stores[0];
                    break;
                case "3":
                    products = _stores[1].Products;
                    store = _stores[1];
                    break;
                case "2":
                    products = _stores[2].Products;
                    store = _stores[2];
                    break;
                case "1":
                    products = _stores[3].Products;
                    store = _stores[3];
                    break;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Invalid input!\nPress Enter to continue...");
                    return MenuType.Inventory;
            }
            Console.Clear();
            Console.WriteLine($"Inventory for {store.Name}:\n");
            foreach (Product item in products)
            {
                Console.WriteLine(item + "\n");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
            return MenuType.MainMenu;
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Which store would you like to see?");
            Console.WriteLine("[4] - Rose's Roses");
            Console.WriteLine("[3] - David's Daffodils");
            Console.WriteLine("[2] - Lily's Lilies");
            Console.WriteLine("[1] - Steve's Sunflowers");
            Console.WriteLine("[0] - Go back to Main Menu");
        }
    }
}