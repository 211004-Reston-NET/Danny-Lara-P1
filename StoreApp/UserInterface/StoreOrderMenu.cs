using System;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class StoreOrderMenu : IMenu
    {
        private StoreBL _storeBL;
        private Store _store;
        private Order _order;
        
        public StoreOrderMenu(StoreBL p_storeBL, Store p_store)
        {
            _storeBL = p_storeBL;
            _store = p_store;
            _order = new Order();
        }
        public MenuType Choice()
        {
            throw new System.NotImplementedException();
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Current order:");
            Console.WriteLine(_order);
            Console.WriteLine("[0] - Go Back");
            Console.WriteLine("[1] - Place Order");
            int menuIndex = 2;
            foreach (Product p in _store.Products)
            {
                Console.WriteLine($"[{menuIndex}] - {p.Name} -> {p.Price}");
                menuIndex++;
            }
        }
    }
}