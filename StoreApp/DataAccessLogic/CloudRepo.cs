using System.Collections.Generic;
using Models;
using System.Linq;
using System;

namespace DataAccessLogic
{
    /// <summary>
    /// This class talks to the database and the business layer to process data for the user
    /// </summary>
    public class CloudRepo : IRepository
    {
        private DataContext _context;
        public CloudRepo(DataContext p_context)
        {
            _context = p_context;
            if(_context.Stores.Count() == 0) //Checks to see if the stores table is empty
                StoreInit(); //If it is empty then it will populate the store table
        }

        //Store Methods
        public Store AddStore(Store p_store)
        {
            _context.Stores.Add(p_store);
            _context.SaveChanges();
            return p_store;
        }
        public List<Store> GetAllStores()
        {
            if (_context.Stores.Count() == 0)
                StoreInit();
            return _context.Stores.ToList();
        }
        /// <summary>
        /// This method will be called if the store table in the database is empty and 
        /// it will populate the store and product tables with store and product data
        /// </summary>
        private void StoreInit() //Used to populate the database with the stores and their products
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
        public int AddCustomer(Customer p_cust)
        {
            _context.Customers.Add(p_cust);
            _context.SaveChanges();
            List<Customer> custs = GetAllCustomers();
            return custs[custs.Count-1].CustID;
        }
        public Customer GetCustomerByCustId(int p_custID)
        {
            return _context.Customers.Find(p_custID);
        }
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
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
        public int AddOrder(Order p_order)
        {
            _context.Orders.Add(p_order);
            _context.SaveChanges();
            List<Order> orders = GetAllOrders();
            return orders[orders.Count-1].OrderNumber;
        }
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
        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }
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
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
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
        public Product GetProductByProductId(int p_id)
        {
            return _context.Products.Find(p_id);
        }
        public Product AddProduct(Product p_product)
        {
            _context.Products.Add(p_product);
            _context.SaveChanges();
            return p_product;
        }
        /*private void AddNewProduct(Product p_product)
        {
            _context.Products.Add(p_product);
            _context.SaveChanges();
        }*/
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
        public LineItems AddLineItem(LineItems p_lineItem)
        {
            _context.LineItems.Add(p_lineItem);
            _context.SaveChanges();
            return p_lineItem;
        }
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