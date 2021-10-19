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
        private static List<Store> _allStores;
        private List<LineItems> _orderProducts;
        private Order _order;
        
        public StoreOrderMenu(StoreBL p_storeBL, int p_storeIndex)
        {
            _storeBL = p_storeBL;
            _orderProducts = new List<LineItems>();
            _order = new Order();
            _allStores = _storeBL.GetAll();
            _store = _allStores[p_storeIndex];
            _order.Store = _store;
            if (_store.Orders == null)
                _store.Orders = new List<Order>();
        }
        public MenuType Choice()
        {
            string input = Console.ReadLine();
            if(input == "0")
                return MenuType.PlaceOrder;
            if(input == "1")
            {
                //_order.Items = _orderProducts;
                //_order.UpdatePrice();
                for (int i = 0; i < _allStores.Count; i++)
                {
                    if (_allStores[i].Name.Equals(_store.Name))
                        _allStores[i].Orders.Add(_order);
                }
                /*Console.WriteLine(_store);
                Console.WriteLine("===================");
                Console.WriteLine(_order);
                Console.WriteLine("===================");
                Console.WriteLine(_store.Orders);
                _store.Orders.Add(_order);*/
                //_storeBL.Update(_allStores);
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
                Console.ReadLine();
                Console.Clear();
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
                Console.WriteLine($"[{menuIndex}] - {p.Name} - {p.Price.ToString("C")}");
                menuIndex++;
            }
        }
    }
}