using System.Collections.Generic;
using Model = Models;
using Entity = DataAccessLogic.Entities;
using System.Linq;
using System;

namespace DataAccessLogic
{
    public class CloudRepo //: IRepository
    {
        private static Entity.DataContext _context;
        public CloudRepo(Entity.DataContext p_context)
        {
            _context = p_context;
            if(_context.Stores.Count() == 0)
                StoreInit();
        }

        //Store Methods
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
        public bool UpdateStore(Model.Store p_store)
        {
            try
            {
                _context.Stores.Update(new Entity.Store(){
                    StoreId = p_store.StoreID,
                    StoreName = p_store.Name,
                    StoreAddress = p_store.Address
                });
                _context.SaveChanges();
                 return true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Update Store failed!");
                return false;
            }
        }
        private static void StoreInit()
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
        private static List<Model.Order> GetAllOrders()
        {
            return _context.Orders.Select(o => new Model.Order(){
                        OrderNumber = o.OrderNumber,
                        CustID = o.CustId,
                        StoreID = o.StoreId,
                        TotalPrice = (double)o.OrderTotalPrice
                    }).ToList();
        }
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
        public bool UpdateOrder(Model.Order p_order)
        {
            try
            {
                _context.Orders.Update(new Entity.Order(){
                    OrderNumber = p_order.OrderNumber,
                    CustId = p_order.CustID,
                    StoreId = p_order.StoreID,
                    OrderTotalPrice = (decimal)p_order.TotalPrice
                });
                _context.SaveChanges();
                 return true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Update Order failed!");
                return false;
            }
        }

        //Product Methods
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