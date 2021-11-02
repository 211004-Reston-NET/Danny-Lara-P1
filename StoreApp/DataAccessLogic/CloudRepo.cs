using System.Collections.Generic;
using Model = Models;
using Entity = DataAccessLogic.Entities;
using System.Linq;
using System;

namespace DataAccessLogic
{
    /// <summary>
    /// This class talks to the database and the business layer to process data for the user
    /// </summary>
    public class CloudRepo
    {
        private static Entity.DataContext _context;
        public CloudRepo(Entity.DataContext p_context)
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
        private static Model.Store AddStore(Model.Store p_store)
        {
            _context.Stores.Add(
                new Entity.Store()
                {
                    StoreName = p_store.Name,
                    StoreAddress = p_store.Address
                }
            );
            _context.SaveChanges();
            return p_store;
        }
        /// <summary>
        /// Gets all the stores in the table
        /// </summary>
        /// <returns>A list of all the stores in the database</returns>
        public List<Model.Store> GetAllStores()
        {
            return _context.Stores.Select(s =>
                new Model.Store()
                {
                    StoreID = s.StoreId,
                    Name = s.StoreName,
                    Address = s.StoreAddress
                }
            ).ToList();
        }
        /// <summary>
        /// This method will be called if the store table in the database is empty and 
        /// it will populate the store and product tables with store and product data
        /// </summary>
        private static void StoreInit() //Used to populate the database with the stores and their products
        {
            Model.Store s1 = new Model.Store()
            {
                Name = "Rose's Roses",
                Address = "321 Baltic Ave. Orlando, FL",
                Products = new List<Model.Product>()
            };
            AddStore(s1);
            Model.Product p = new Model.Product()
            {
                Name = "Roses (6)",
                Price = 10.99,
                Description = "Half a dozen roses.",
                Quantity = 20,
                StoreID = 1
            };
            AddProduct(p);
            p = new Model.Product()
            {
                Name = "Roses (12)",
                Price = 19.99,
                Description = "A dozen roses.",
                Quantity = 20,
                StoreID = 1
            };
            AddProduct(p);

            Model.Store s2 = new Model.Store()
            {
                Name = "David's Daffodils",
                Address = "1600 Park Place Dr. Los Angeles, CA",
                Products = new List<Model.Product>()
            };
            AddStore(s2);
            p = new Model.Product()
            {
                Name = "Daffodils (12)",
                Price = 24.99,
                Description = "A dozen daffodils.",
                Quantity = 20,
                StoreID = 2
            };
            AddProduct(p);
            p = new Model.Product()
            {
                Name = "Flower pot",
                Price = 2.99,
                Description = "A small flower pot",
                Quantity = 20,
                StoreID = 2
            };
            AddProduct(p);

            Model.Store s3 = new Model.Store()
            {
                Name = "Lily's Lilies",
                Address = "3 Privit Dr Little Winding, UK",
                Products = new List<Model.Product>()
            };
            AddStore(s3);
            p = new Model.Product()
            {
                Name = "Lilies (20)",
                Price = 69.99,
                Description = "20 stems of lilies.",
                Quantity = 20,
                StoreID = 3
            };
            AddProduct(p);
            p = new Model.Product()
            {
                Name = "Fancy Vase",
                Price = 74.99,
                Description = "A hand-painted fancy vase.",
                Quantity = 20,
                StoreID = 3
            };
            AddProduct(p);
            Model.Store s4 = new Model.Store()
            {
                Name = "Steve's Sunflowers",
                Address = "722 Orchard Dr. Paso Robles, CA",
                Products = new List<Model.Product>()
            };
            AddStore(s4);
            p = new Model.Product()
            {
                Name = "Sunflowers (12)",
                Price = 12.99,
                Description = "A dozen sunflowers",
                Quantity = 20,
                StoreID = 4
            };
            AddProduct(p);
            p = new Model.Product()
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
        public int AddCustomer(Model.Customer p_cust)
        {
            _context.Customers.Add(
                new Entity.Customer(){
                    CustName = p_cust.Name,
                    CustAddress = p_cust.Address,
                    CustEmail = p_cust.Email,
                    CustPhoneNumber = p_cust.PhoneNumber
                }
            );
            _context.SaveChanges();
            List<Model.Customer> custs = GetAllCustomers();
            return custs[custs.Count-1].CustID;
        }
        /// <summary>
        /// Gets a customer from the customer table using the primary key (Customer_ID)
        /// </summary>
        /// <param name="p_custID">The ID of the customer to find</param>
        /// <returns>The customer being requested</returns>
        public Model.Customer GetCustomerByCustId(int p_custID)
        {
            Entity.Customer cust = _context.Customers.Find(p_custID);
            return new Model.Customer(){
                CustID = cust.CustId,
                Name = cust.CustName,
                Address = cust.CustAddress,
                Email = cust.CustEmail,
                PhoneNumber = cust.CustPhoneNumber
            };
        }
        /// <summary>
        /// Gets all the customers in the customer table
        /// </summary>
        /// <returns>A list of all the customers in the database</returns>
        public List<Model.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(c =>
                new Model.Customer(){
                    CustID = c.CustId,
                    Name = c.CustName,
                    Address = c.CustAddress,
                    Email = c.CustEmail,
                    PhoneNumber = c.CustPhoneNumber
                }).ToList();
        }
        /// <summary>
        /// Although not implemented, will be able to change/update a customer's info.
        /// </summary>
        /// <param name="p_cust">The customer that will be updated</param>
        /// <returns>True if the update was successful or false if it failed</returns>
        public bool UpdateCustomer(Model.Customer p_cust)
        {
            try
            {
                _context.Customers.Update(new Entity.Customer(){
                    CustId = p_cust.CustID,
                    CustName = p_cust.Name,
                    CustAddress = p_cust.Address,
                    CustEmail = p_cust.Email,
                    CustPhoneNumber = p_cust.PhoneNumber
                });
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
        public int AddOrder(Model.Order p_order)
        {
            _context.Orders.Add(
                new Entity.Order(){
                    CustId = p_order.CustID,
                    StoreId = p_order.StoreID,
                    OrderTotalPrice = (decimal)p_order.TotalPrice
                }
            );
            _context.SaveChanges();
            List<Model.Order> orders = GetAllOrders();
            return orders[orders.Count-1].OrderNumber;
        }
        /// <summary>
        /// Gets all the orders from a specific store using 
        /// the store ID (primary key)
        /// </summary>
        /// <param name="p_storeId">The store ID</param>
        /// <returns>A list of all the orders at the specified store</returns>
        public List<Model.Order> GetOrdersByStoreId(int p_storeId)
        {
            return _context.Orders.Where(o => o.StoreId == p_storeId)
                    .Select(o => new Model.Order(){
                        OrderNumber = o.OrderNumber,
                        CustID = o.CustId,
                        StoreID = o.StoreId,
                        TotalPrice = (double)o.OrderTotalPrice
                    }).ToList();
        }
        /// <summary>
        /// Gets all the orders currently in the database
        /// </summary>
        /// <returns>A list of all the orders in the database</returns>
        private static List<Model.Order> GetAllOrders()
        {
            return _context.Orders.Select(o => new Model.Order(){
                        OrderNumber = o.OrderNumber,
                        CustID = o.CustId,
                        StoreID = o.StoreId,
                        TotalPrice = (double)o.OrderTotalPrice
                    }).ToList();
        }
        /// <summary>
        /// Gets all the orders from the order table made by the 
        /// specified customer using the customer's ID
        /// </summary>
        /// <param name="p_custId">The customer's ID</param>
        /// <returns>A list of all the orders made by the customer</returns>
        public List<Model.Order> GetOrdersByCustId(int p_custId)
        {
            return _context.Orders.Where(o => o.CustId == p_custId)
                    .Select(o => new Model.Order(){
                        OrderNumber = o.OrderNumber,
                        CustID = o.CustId,
                        StoreID = o.StoreId,
                        TotalPrice = (double)o.OrderTotalPrice
                    }).ToList();
        }

        //Product Methods
        /// <summary>
        /// Gets all the products from a specified store 
        /// using the store's ID
        /// </summary>
        /// <param name="p_storeId">The ID of the store</param>
        /// <returns>A list of all the products the store has</returns>
        public List<Model.Product> GetProductsByStoreId(int p_storeId)
        {
            return _context.Products.Where(p => p.StoreId == p_storeId).Select(p => 
                new Model.Product(){
                    Id = p.ProductId,
                    StoreID = p.StoreId,
                    Name = p.ProductName,
                    Price = (double)p.ProductPrice,
                    Description = p.ProductDescription,
                    Quantity = p.ProductQuantity
                }).ToList();
        }
        /// <summary>
        /// Gets a specific product using the product's ID
        /// </summary>
        /// <param name="p_id">The ID of the product</param>
        /// <returns>The product from the product table in the database</returns>
        public Model.Product GetProductByProductId(int p_id)
        {
            Entity.Product prodToFind = _context.Products.Find(p_id);
            return new Model.Product(){
                Id = prodToFind.ProductId,
                StoreID = (int)prodToFind.StoreId,
                Name = prodToFind.ProductName,
                Price = (double)prodToFind.ProductPrice,
                Description = prodToFind.ProductDescription,
                Quantity = prodToFind.ProductQuantity
            };
        }
        /// <summary>
        /// Adds a product to the database in the product table
        /// </summary>
        /// <param name="p_product">The product to be added</param>
        /// <returns>The product that was added</returns>
        public static Model.Product AddProduct(Model.Product p_product)
        {
            _context.Products.Add(new Entity.Product(){
                ProductName = p_product.Name,
                ProductPrice = (decimal)p_product.Price,
                ProductQuantity = p_product.Quantity,
                StoreId = p_product.StoreID,
                ProductDescription = p_product.Description
            });
            _context.SaveChanges();
            return p_product;
        }
        /// <summary>
        /// Updates the specified product in the product table 
        /// in the database
        /// </summary>
        /// <param name="p_product">The product to update</param>
        /// <returns>True if the update was successful or false otherwise</returns>
        public bool UpdateProduct(Model.Product p_product)
        {
            try
            {
                _context.Products.Update(new Entity.Product(){
                    ProductId = p_product.Id,
                    StoreId = p_product.StoreID,
                    ProductName = p_product.Name,
                    ProductPrice = (decimal)p_product.Price,
                    ProductDescription = p_product.Description,
                    ProductQuantity = p_product.Quantity
                });
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
        public List<Model.LineItems> GetLineItemsByOrderNum(int p_orderNum)
        {
            return _context.LineItems.Where(l => l.OrderNumber == p_orderNum)
                .Select(l =>
                    new Model.LineItems()
                    {
                        LineItemId = l.LineItemId,
                        OrderNumber = l.OrderNumber,
                        ProductID = l.ProductId,
                        Quantity = l.LineItemQuantity
                    }
            ).ToList();
        }
        /// <summary>
        /// Adds a line item to the line item table in the database
        /// </summary>
        /// <param name="p_lineItem">The line item to be added</param>
        /// <returns>The line item that was added</returns>
        public Model.LineItems AddLineItem(Model.LineItems p_lineItem)
        {
            _context.LineItems.Add(new Entity.LineItem(){
                LineItemId = p_lineItem.LineItemId,
                OrderNumber = p_lineItem.OrderNumber,
                ProductId = p_lineItem.ProductID,
                LineItemQuantity = p_lineItem.Quantity
            });
            _context.SaveChanges();
            return p_lineItem;
        }
        /// <summary>
        /// Updates the specified line item in the database
        /// </summary>
        /// <param name="p_lineItem">The line item to be updated</param>
        /// <returns>True if the update was successful or false otherwise</returns>
        public bool UpdateLineItem(Model.LineItems p_lineItem)
        {
            try
            {
                 _context.LineItems.Update(new Entity.LineItem(){
                     LineItemId = p_lineItem.LineItemId,
                     OrderNumber = p_lineItem.OrderNumber,
                     ProductId = p_lineItem.ProductID,
                     LineItemQuantity = p_lineItem.Quantity
                 });
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