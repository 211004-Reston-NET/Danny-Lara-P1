using System.Collections.Generic;
using Models;
using System.Linq;
using System;

namespace DataAccessLogic
{
    /// <summary>
    /// This class talks to the database and the business layer to process data for the user
    /// </summary>
    public class CloudRepo
    {
        private static DataContext _context;
        public CloudRepo(DataContext p_context)
        {
            _context = p_context;
            if(_context.Stores.Count() == 0) //Checks to see if the stores table is empty
                StoreInit(); //If it is empty then it will populate the store table
        }

        //Store Methods
        /// <summary>
        /// Adds a store to the database. Specifically the Store table
        /// </summary>
        /// <param name="p_store">The store object to be added</param>
        /// <returns>Returns the store that was added</returns>
        private static Store AddStore(Store p_store)
        {
            _context.Stores.Add(p_store);
            _context.SaveChanges();
            return p_store;
        }
        /// <summary>
        /// Gets all the stores in the table
        /// </summary>
        /// <returns>A list of all the stores in the database</returns>
        public List<Store> GetAllStores()
        {
            return _context.Stores.ToList();
        }
        /// <summary>
        /// This method will be called if the store table in the database is empty and 
        /// it will populate the store and product tables with store and product data
        /// </summary>
        private static void StoreInit() //Used to populate the database with the stores and their products
        {
            Store s1 = new Store()
            {
                Name = "Rose's Roses",
                Address = "321 Baltic Ave. Orlando, FL",
                Products = new List<Product>()
            };
            AddStore(s1);
            Product p = new Product()
            {
                Name = "Roses (6)",
                Price = 10.99,
                Description = "Half a dozen roses.",
                Quantity = 20,
                StoreID = 1
            };
            AddProduct(p);
            p = new Product()
            {
                Name = "Roses (12)",
                Price = 19.99,
                Description = "A dozen roses.",
                Quantity = 20,
                StoreID = 1
            };
            AddProduct(p);

            Store s2 = new Store()
            {
                Name = "David's Daffodils",
                Address = "1600 Park Place Dr. Los Angeles, CA",
                Products = new List<Product>()
            };
            AddStore(s2);
            p = new Product()
            {
                Name = "Daffodils (12)",
                Price = 24.99,
                Description = "A dozen daffodils.",
                Quantity = 20,
                StoreID = 2
            };
            AddProduct(p);
            p = new Product()
            {
                Name = "Flower pot",
                Price = 2.99,
                Description = "A small flower pot",
                Quantity = 20,
                StoreID = 2
            };
            AddProduct(p);

            Store s3 = new Store()
            {
                Name = "Lily's Lilies",
                Address = "3 Privit Dr Little Winding, UK",
                Products = new List<Product>()
            };
            AddStore(s3);
            p = new Product()
            {
                Name = "Lilies (20)",
                Price = 69.99,
                Description = "20 stems of lilies.",
                Quantity = 20,
                StoreID = 3
            };
            AddProduct(p);
            p = new Product()
            {
                Name = "Fancy Vase",
                Price = 74.99,
                Description = "A hand-painted fancy vase.",
                Quantity = 20,
                StoreID = 3
            };
            AddProduct(p);
            Store s4 = new Store()
            {
                Name = "Steve's Sunflowers",
                Address = "722 Orchard Dr. Paso Robles, CA",
                Products = new List<Product>()
            };
            AddStore(s4);
            p = new Product()
            {
                Name = "Sunflowers (12)",
                Price = 12.99,
                Description = "A dozen sunflowers",
                Quantity = 20,
                StoreID = 4
            };
            AddProduct(p);
            p = new Product()
            {
                Name = "Roasted Sunflower Seeds",
                Price = 1.75,
                Description = "A 5.25oz bag of roasted sunflower seeds",
                Quantity = 20,
                StoreID = 4
            };
            AddProduct(p);
        }

        //Customer Methods
        /// <summary>
        /// Adds a customer to the customer table
        /// </summary>
        /// <param name="p_cust">The customer that is being added</param>
        /// <returns>The customer that was added</returns>
        public int AddCustomer(Customer p_cust)
        {
            _context.Customers.Add(p_cust);
            _context.SaveChanges();
            List<Customer> custs = GetAllCustomers();
            return custs[custs.Count-1].CustID;
        }
        /// <summary>
        /// Gets a customer from the customer table using the primary key (Customer_ID)
        /// </summary>
        /// <param name="p_custID">The ID of the customer to find</param>
        /// <returns>The customer being requested</returns>
        public Customer GetCustomerByCustId(int p_custID)
        {
            return _context.Customers.Find(p_custID);
        }
        /// <summary>
        /// Gets all the customers in the customer table
        /// </summary>
        /// <returns>A list of all the customers in the database</returns>
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
        /// <summary>
        /// Although not implemented, will be able to change/update a customer's info.
        /// </summary>
        /// <param name="p_cust">The customer that will be updated</param>
        /// <returns>True if the update was successful or false if it failed</returns>
        public bool UpdateCustomer(Customer p_cust)
        {
            try
            {
                _context.Customers.Update(p_cust);
                return true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Update Customer failed!");
                return false;
            }
        }

        //Order Methods
        /// <summary>
        /// Adds an order to the order table in the database
        /// </summary>
        /// <param name="p_order">The order being added to the database</param>
        /// <returns>The order number of the order being added (The primary key)</returns>
        public int AddOrder(Order p_order)
        {
            _context.Orders.Add(p_order);
            _context.SaveChanges();
            List<Order> orders = GetAllOrders();
            return orders[orders.Count-1].OrderNumber;
        }
        /// <summary>
        /// Gets all the orders from a specific store using 
        /// the store ID (primary key)
        /// </summary>
        /// <param name="p_storeId">The store ID</param>
        /// <returns>A list of all the orders at the specified store</returns>
        public List<Order> GetOrdersByStoreId(int p_storeId)
        {
            List<Order> orderList = GetAllOrders();
            List<Order> returnList = new List<Order>();
            foreach (Order o in orderList)
            {
                if (p_storeId == o.StoreID)
                    returnList.Add(o);
            }
            return returnList;
        }
        /// <summary>
        /// Gets all the orders currently in the database
        /// </summary>
        /// <returns>A list of all the orders in the database</returns>
        private static List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }
        /// <summary>
        /// Gets all the orders from the order table made by the 
        /// specified customer using the customer's ID
        /// </summary>
        /// <param name="p_custId">The customer's ID</param>
        /// <returns>A list of all the orders made by the customer</returns>
        public List<Order> GetOrdersByCustId(int p_custId)
        {
            List<Order> allOrders = GetAllOrders();
            List<Order> returnList = new List<Order>();
            foreach (Order o in allOrders)
            {
                if (p_custId == o.CustID)
                    returnList.Add(o);
            }
            return returnList;
        }

        //Product Methods
        /// <summary>
        /// Gets all the products from a specified store 
        /// using the store's ID
        /// </summary>
        /// <param name="p_storeId">The ID of the store</param>
        /// <returns>A list of all the products the store has</returns>
        public List<Product> GetProductsByStoreId(int p_storeId)
        {
            List<Product> allProducts = _context.Products.ToList();
            List<Product> returnList = new List<Product>();
            foreach (Product p in allProducts)
            {
                if (p_storeId == p.StoreID)
                    returnList.Add(p);
            }
            return returnList;
        }
        /// <summary>
        /// Gets a specific product using the product's ID
        /// </summary>
        /// <param name="p_id">The ID of the product</param>
        /// <returns>The product from the product table in the database</returns>
        public Product GetProductByProductId(int p_id)
        {
            return _context.Products.Find(p_id);
        }
        /// <summary>
        /// Adds a product to the database in the product table
        /// </summary>
        /// <param name="p_product">The product to be added</param>
        /// <returns>The product that was added</returns>
        public static Product AddProduct(Product p_product)
        {
            _context.Products.Add(p_product);
            _context.SaveChanges();
            return p_product;
        }
        /// <summary>
        /// Updates the specified product in the product table 
        /// in the database
        /// </summary>
        /// <param name="p_product">The product to update</param>
        /// <returns>True if the update was successful or false otherwise</returns>
        public bool UpdateProduct(Product p_product)
        {
            try
            {
                _context.Products.Update(p_product);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Update Product Failed!");
                return false;
            }
        }

        //LineItem Methods
        /// <summary>
        /// Gets all the line items associated with the 
        /// specified order number
        /// </summary>
        /// <param name="p_orderNum">The order number</param>
        /// <returns>A list of all the line items in the specified order</returns>
        public List<LineItems> GetLineItemsByOrderNum(int p_orderNum)
        {
            List<LineItems> allLineItems = _context.LineItems.ToList();
            List<LineItems> returnList = new List<LineItems>();
            foreach (LineItems item in allLineItems)
            {
                if (p_orderNum == item.OrderNumber)
                    returnList.Add(item);
            }
            return returnList;
        }
        /// <summary>
        /// Adds a line item to the line item table in the database
        /// </summary>
        /// <param name="p_lineItem">The line item to be added</param>
        /// <returns>The line item that was added</returns>
        public LineItems AddLineItem(LineItems p_lineItem)
        {
            _context.LineItems.Add(p_lineItem);
            _context.SaveChanges();
            return p_lineItem;
        }
        /// <summary>
        /// Updates the specified line item in the database
        /// </summary>
        /// <param name="p_lineItem">The line item to be updated</param>
        /// <returns>True if the update was successful or false otherwise</returns>
        public bool UpdateLineItem(LineItems p_lineItem)
        {
            try
            {
                 _context.LineItems.Update(p_lineItem);
                 _context.SaveChanges();
                 return true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Update LineItem failed!");
                return false;
            }
            
        }
    }
}