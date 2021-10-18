using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class StoreOrderMenu : IMenu
    {
        private StoreBL _storeBL;
        private Store _store;
        private List<Store> _allStores;
        private List<LineItems> _orderProducts;
        private Order _order;
        
        public StoreOrderMenu(StoreBL p_storeBL, Store p_store)
        {
            _storeBL = p_storeBL;
            _store = p_store;
            _orderProducts = new List<LineItems>();
            _order = new Order();
            _order.Store = p_store;
            _allStores = _storeBL.GetAll();
        }
        public MenuType Choice()
        {
            string input = Console.ReadLine();
            if(input == "0")
                return MenuType.PlaceOrder;
            if(input == "1")
            {
                _order.Items = _orderProducts;
                _order.Store = _store;
                _order.UpdatePrice();
                foreach (Store s in _allStores)
                {
                    if(s.Name.Equals(_store.Name))
                        s.Orders.Add(_order);
                }
                _storeBL.Update(_allStores);
                Console.WriteLine("Order placed!\nPress Enter to return to the Main Menu...");
                Console.ReadLine();
                return MenuType.MainMenu;
            }
            try
            {
                int j = Int32.Parse(input);
                Console.WriteLine($"How many {_store.Products[j-2].Name} would you like?");
                int quantity = Int32.Parse(Console.ReadLine());
                if (_store.Products[j-2].Quantity < quantity)
                {
                    Console.WriteLine("Not enough stock for that quantity!");
                    Console.WriteLine($"Please enter an amount of {_store.Products[j-2].Quantity} or less...");
                    quantity = Int32.Parse(Console.ReadLine());
                }
                _orderProducts.Add(new LineItems(_store.Products[j-2], quantity));
                _store.Products[j-2].Quantity -= quantity;
                _order.Items = _orderProducts;
                _order.UpdatePrice();
                return MenuType.StoreOrderMenu;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Invalid input!\nPress Enter to continue...");
                return MenuType.StoreOrderMenu;
            }
            //return MenuType.MainMenu;
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
                Console.WriteLine($"[{menuIndex}] - {p.Name} - {p.Price}");
                menuIndex++;
            }
        }
    }
}