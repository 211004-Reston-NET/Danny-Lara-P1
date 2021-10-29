using System.Reflection.Emit;
using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class OrderHistory : IMenu
    {
        private StoreBL _storeBL;
        private CustomerBL _custBL;
        public OrderHistory(StoreBL p_storeBL, CustomerBL p_custBL)
        {
            _storeBL = p_storeBL;
            _custBL = p_custBL;
        }
        public MenuType Choice()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "2":
                    Console.Clear();
                    Console.WriteLine("----------Order History----------");
                    Console.WriteLine("Enter store ID or store name:");
                    string s = Console.ReadLine();
                    try
                    {
                        int storeID = Int32.Parse(s);
                        List<Order> orders = _storeBL.GetOrdersByStoreID(storeID);
                        Store store = _storeBL.GetStore(storeID);
                        Console.WriteLine($"Orders for {store.Name}:");
                        foreach (Order o in orders)
                        {
                            List<LineItems> l = _storeBL.GetOrderProducts(o.OrderNumber);
                            foreach (LineItems item in l)
                            {
                                item.Product = _storeBL.GetProduct(item.ProductID);
                            }
                            o.Items = l;
                            Console.WriteLine("=========================");
                            Console.WriteLine(o);
                            Console.WriteLine("=========================");
                        }
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        return MenuType.MainMenu;
                    }
                    catch (System.Exception)
                    {
                        List<Store> stores = _storeBL.GetAll();
                        int storeID = -1;
                        foreach (Store store in stores)
                        {
                            if (store.Name.ToLower().Contains(s.ToLower()))
                                storeID = store.StoreID;
                            break;
                        }
                        if (storeID == -1)
                        {
                            Console.WriteLine("Could not find store!\nPress Enter to try again...");
                            Console.ReadLine();
                            return MenuType.OrderHistory;
                        }
                        List<Order> orders = _storeBL.GetOrdersByStoreID(storeID);
                        foreach (Order o in orders)
                        {
                            List<LineItems> l = _storeBL.GetOrderProducts(o.OrderNumber);
                            foreach (LineItems item in l)
                            {
                                item.Product = _storeBL.GetProduct(item.ProductID);
                            }
                            o.Items = l;
                            Console.WriteLine("=========================");
                            Console.WriteLine(o);
                            Console.WriteLine("=========================");
                        }
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        return MenuType.MainMenu;
                    }
                case "1":
                    Console.Clear();
                    Console.WriteLine("----------Order History----------");
                    Console.WriteLine("Enter Customer ID:");
                    try
                    {
                        int custId = Int32.Parse(Console.ReadLine());
                        if (_custBL.CustExists(custId))
                        {
                            List<Order> orders = _custBL.GetOrdersByCustId(custId);
                            Customer cust = _custBL.GetCustomer(custId);
                            Console.WriteLine($"Orders for {cust.Name}:");
                            foreach (Order o in orders)
                            {
                                List<LineItems> l = _storeBL.GetOrderProducts(o.OrderNumber);
                                foreach (LineItems item in l)
                                {
                                    item.Product = _storeBL.GetProduct(item.ProductID);
                                }
                                o.Items = l;
                                Console.WriteLine("=========================");
                                Console.WriteLine(o);
                                Console.WriteLine("=========================");
                            }
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            return MenuType.MainMenu;
                        }
                        else
                        {
                            Console.WriteLine("Customer does not exist!\nPress Enter to try again...");
                            Console.ReadLine();
                            return MenuType.OrderHistory;
                        }
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Invalid input or customer does not exist!\nPress Enter to try again...");
                        Console.ReadLine();
                        return MenuType.OrderHistory;
                    }
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Invalid input!\nPress Enter to try again...");
                    Console.ReadLine();
                    return MenuType.OrderHistory;
            }
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("----------Order History----------");
            Console.WriteLine("[2] - Orders by Store");
            Console.WriteLine("[1] - Orders by Customer");
            Console.WriteLine("[0] - Go Back");
        }
    }
}