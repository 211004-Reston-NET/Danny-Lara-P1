using System;
using System.Collections.Generic;
using BusinessLogic;
using DataAccessLogic;
using Models;

namespace UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Flower Shop App!");
            bool loop = true;
            IMenu page = new MainMenu();

            while (loop)
            {
                page.Menu();
                MenuType currentPage = page.Choice();
                switch (currentPage)
                {
                    case MenuType.MainMenu:
                        page = new MainMenu();
                        break;
                    case MenuType.AddCustomer:
                        page = new AddCustomer(new CustomerBL(new Repository()));
                        break;
                    case MenuType.Search:
                        page = new Search(new CustomerBL(new Repository()));
                        break;
                    case MenuType.Inventory:
                        page = new Inventory();
                        break;
                    case MenuType.PlaceOrder:
                        page = new PlaceOrder();
                        break;
                    case MenuType.OrderHistory:
                        page = new OrderHistory();
                        break;
                    case MenuType.Replenish:
                        page = new Replenish();
                        break;
                    case MenuType.Exit:
                        Console.WriteLine("Thank you, and have a nice day!");
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Forgot to add a menu!");
                        loop = false;
                        break;
                }
            }
            
        }
        static void StoreInit()
        {
            StoreBL storeWriter = new StoreBL(new Repository());

            Store s1 = new Store();
            s1.Name = "Rose's Roses";
            s1.Address = "321 Baltic Ave. Orlando, FL";
            List<Product> roseProducts = new List<Product>();
            Product p = new Product();
            p.Name = "Roses (6)";
            p.Price = 10.99;
            p.Description = "Half a dozen roses.";
            p.Category = "Flowers";
            roseProducts.Add(p);
            p = new Product();
            p.Name = "Roses (12)";
            p.Price = 19.99;
            p.Description = "A dozen roses.";
            p.Category = "Flowers";
            roseProducts.Add(p);
            s1.Products = roseProducts;
            storeWriter.Add(s1);

            Store s2 = new Store();
            s1.Name = "David's Daffodils";
            s2.Address = "1600 Park Place Dr. Los Angeles, CA";
            List<Product> daffList = new List<Product>();
            p = new Product();
            p.Name = "Daffodils (12)";
            p.Price = 24.99;
            p.Description = "A dozen daffodils.";
            p.Category = "Flowers";
            daffList.Add(p);
            p = new Product();
            p.Name = "Flower pot";
            p.Price = 2.99;
            p.Description = "A small flower pot";
            p.Category = "Pots";
            daffList.Add(p);
            s2.Products = daffList;
            storeWriter.Add(s2);

            Store s3 = new Store();
            s3.Name = "Lily's Lilies";
            s3.Address = "3 Privit Dr Little Winding, UK";
            List<Product> lilyProducts = new List<Product>();
            p = new Product();
            
        }
    }
}