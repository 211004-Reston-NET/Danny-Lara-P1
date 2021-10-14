using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Models;

namespace DataAccessLogic
{
    public class Repository
    {
        private const string _storeFilepath = "./../DataAccessLogic/Database/StoreData.json";
        private const string _customerFilepath = "./../DataAccessLogic/Database/CustomerData.json";
        private string _jsonString;

        public Repository()
        {
            if(!File.Exists(_storeFilepath))
            {
                FileStream f = File.Create(_storeFilepath);
                f.Close();
                File.WriteAllText(_storeFilepath, "[]");
                StoreInit();
            }
            if(!File.Exists(_customerFilepath))
            {
                FileStream f = File.Create(_customerFilepath);
                f.Close();
                File.WriteAllText(_customerFilepath, "[]");
            }
        }

        public Store AddStore(Store p_store)
        {
            List<Store> storeList = GetAllStores();
            storeList.Add(p_store);

            _jsonString = JsonSerializer.Serialize(storeList, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(_storeFilepath,_jsonString);
            return p_store;
        }
        public List<Store> GetAllStores()
        {
            _jsonString = File.ReadAllText(_storeFilepath);
            return JsonSerializer.Deserialize<List<Store>>(_jsonString);
        }
        public List<Store> UpdateStores(List<Store> p_stores)
        {
            _jsonString = JsonSerializer.Serialize(p_stores, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(_storeFilepath,_jsonString);
            return p_stores;
        }

        public Customer AddCustomer(Customer p_customer)
        {
            List<Customer> customerList = GetAllCustomers();
            customerList.Add(p_customer);

            _jsonString = JsonSerializer.Serialize(customerList, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(_customerFilepath,_jsonString);
            return p_customer;
        }
        public List<Customer> GetAllCustomers()
        {
            _jsonString = File.ReadAllText(_customerFilepath);
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }
        public List<Customer> UpdateCustomers(List<Customer> p_customers)
        {
            _jsonString = JsonSerializer.Serialize(p_customers, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(_storeFilepath,_jsonString);
            return p_customers;
        }

        static void StoreInit()
        {
            Repository storeWriter = new Repository();

            Store s1 = new Store()
            {
                Name = "Rose's Roses",
                Address = "321 Baltic Ave. Orlando, FL",
                Products = new List<Product>()
            };
            Product p = new Product()
            {
                Name = "Roses (6)",
                Price = 10.99,
                Description = "Half a dozen roses.",
                Quantity = 20
            };
            s1.Products.Add(p);
            p = new Product()
            {
                Name = "Roses (12)",
                Price = 19.99,
                Description = "A dozen roses.",
                Quantity = 20
            };
            s1.Products.Add(p);
            storeWriter.AddStore(s1);

            Store s2 = new Store()
            {
                Name = "David's Daffodils",
                Address = "1600 Park Place Dr. Los Angeles, CA",
                Products = new List<Product>()
            };
            p = new Product()
            {
                Name = "Daffodils (12)",
                Price = 24.99,
                Description = "A dozen daffodils.",
                Quantity = 20
            };
            s2.Products.Add(p);
            p = new Product()
            {
                Name = "Flower pot",
                Price = 2.99,
                Description = "A small flower pot",
                Quantity = 20
            };
            s2.Products.Add(p);
            storeWriter.AddStore(s2);

            Store s3 = new Store()
            {
                Name = "Lily's Lilies",
                Address = "3 Privit Dr Little Winding, UK",
                Products = new List<Product>()
            };
            p = new Product()
            {
                Name = "Lilies (20)",
                Price = 69.99,
                Description = "20 stems of lilies.",
                Quantity = 20
            };
            s3.Products.Add(p);
            p = new Product()
            {
                Name = "Fancy Vase",
                Price = 74.99,
                Description = "A hand-painted fancy vase.",
                Quantity = 20
            };
            s3.Products.Add(p);
            storeWriter.AddStore(s3);

            Store s4 = new Store()
            {
                Name = "Steve's Sunflowers",
                Address = "722 Orchard Dr. Paso Robles, CA",
                Products = new List<Product>()
            };
            p = new Product()
            {
                Name = "Sunflowers (12)",
                Price = 12.99,
                Description = "A dozen sunflowers",
                Quantity = 20
            };
            s4.Products.Add(p);
            p = new Product()
            {
                Name = "Roasted Sunflower Seeds",
                Price = 1.75,
                Description = "A 5.25oz bag of roasted sunflower seeds",
                Quantity = 20
            };
            s4.Products.Add(p);
            storeWriter.AddStore(s4);
        }
    }
}