using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;
namespace UserInterface
{
    public class Replenish : IMenu
    {
        private StoreBL _storeBL;
        private List<Store> _stores;
        private List<Product> _allProducts;
        public Replenish(StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
            _stores = _storeBL.GetAll();
            List<Product> _allProducts = new List<Product>();
            foreach (Store s in _stores)
            {
                foreach (Product p in s.Products)
                {
                    _allProducts.Add(p);
                }
            }
        }
        public MenuType Choice()
        {
            List<Product> _allProducts = new List<Product>();
            foreach (Store s in _stores)
            {
                foreach (Product p in s.Products)
                {
                    _allProducts.Add(p);
                }
            }
            string input = Console.ReadLine();
            if (input == "0")
                return MenuType.MainMenu;
            try
            {
                int j = Int32.Parse(input); //Get user input as a number. Will throw an exception if not a number
                Console.WriteLine($"How many {_allProducts[j-1].Name}'s would you like to stock?");
                int restock = Int32.Parse(Console.ReadLine()); //Gets restock quantity and throws an exception if it's not a number
                try
                {
                    if (restock < 0) //Makes sure restock quantity is a positive number
                        throw new Exception("Resock must be a possitive number!");
                    _allProducts[j-1].Quantity += restock; //Updates product object's quantity
                    _storeBL.UpdateProduct(_allProducts[j-1]); //Updates product in the database
                    Console.WriteLine($"{_allProducts[j-1].Name} has been restocked! There are now {_allProducts[j-1].Quantity}.");
                    Console.WriteLine("Press Enter to return to the main menu...");
                    Console.ReadLine();
                    return MenuType.MainMenu;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Restock quantity cannot be less than zero!");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return MenuType.Replenish;
                }
                 
            }
            catch (System.Exception)
            {
                Console.WriteLine("Invalid input!\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
                return MenuType.Replenish;
            }
        }

        public void Menu()
        {
            List<Product> _allProducts = new List<Product>();
            foreach (Store s in _stores) //Gets all products from all stores
            {
                foreach (Product p in s.Products)
                {
                    _allProducts.Add(p);
                }
            }
            Console.WriteLine("Which item would you like to restock?");
            Console.WriteLine("[0] - Go back to Main Menu");
            for (int i = 0; i < _allProducts.Count; i++) //Displays all products
            {
                Console.WriteLine($"[{i+1}] - {_allProducts[i].Name} Qty: {_allProducts[i].Quantity}");
            }
        }
    }
}