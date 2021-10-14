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
        private List<Product> _allProducts;
        private List<LineItems> _orderProducts;
        private Order _order = new Order();
        public PlaceOrder(StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
            _stores = _storeBL.GetAll();
            _orderProducts = new List<LineItems>();
            _allProducts = new List<Product>();
            for (int i = 0; i < _stores.Count; i++)
            {
                for (int j = 0; j < _stores[i].Products.Count; j++)
                {
                    _allProducts.Add(_stores[i].Products[j]);
                }
            }
        }
        public MenuType Choice()
        {
            string input = Console.ReadLine();
            if(input == "0")
                return MenuType.MainMenu;
            try
            {
                 
            }
            catch (System.Exception)
            {
                Console.WriteLine("Invalid input!\nPress Enter to continue...");
                return MenuType.PlaceOrder;
            }
            return MenuType.MainMenu;
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Current order:");
            Console.WriteLine(_order);
            Console.WriteLine("[0] - Go Back");
            Console.WriteLine("[1] - Place Order");
            int menuIndex = 2;
            foreach (Product p in _allProducts)
            {
                Console.WriteLine($"[{menuIndex}] - {p.Name} -> {p.Price}");
                menuIndex++;
            }
        }
    }
}