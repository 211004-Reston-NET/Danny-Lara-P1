﻿using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Models;

namespace DataAccessLogic
{
    public class StoreRepo
    {
        private const string _storeFilepath = "./../DataAccessLogic/Database/StoreData.json";
        private string _jsonString;

        public StoreRepo()
        {
            if(!File.Exists(_storeFilepath))
            {
                FileStream f = File.Create(_storeFilepath);
                f.Close();
                File.WriteAllText(_storeFilepath, "[]");
                StoreInit();
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
        public Store UpdateStore(Store p_store)
        {
            List<Store> stores = GetAllStores();
            for (int i = 0; i < stores.Count; i++)
            {
                if (stores[i].Name.Equals(p_store.Name))
                    stores[i] = p_store;
            }
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                MaxDepth = 0,
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            };
            _jsonString = JsonSerializer.Serialize(stores, options);
            File.WriteAllText(_storeFilepath,_jsonString);
            return p_store;
        }
        public List<Customer> UpdateCustomers(List<Customer> p_customers)
        {
            _jsonString = JsonSerializer.Serialize(p_customers, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(_storeFilepath,_jsonString);
            return p_customers;
        }

        static void StoreInit()
        {
            StoreRepo storeWriter = new StoreRepo();

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

        public object Add(object p_newObject)
        {
            List<object> list = GetAll();
            List<Store> storeList = new List<Store>();
            foreach (object item in list)
            {
                storeList.Add((Store)item);
            }
            storeList.Add((Store)p_newObject);

            _jsonString = JsonSerializer.Serialize(storeList, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(_storeFilepath,_jsonString);
            return p_newObject;
        }

        public List<object> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(List<object> p_newList)
        {
            throw new System.NotImplementedException();
        }
    }
}