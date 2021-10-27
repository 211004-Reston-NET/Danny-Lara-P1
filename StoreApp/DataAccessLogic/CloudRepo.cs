using System.Collections.Generic;
using Model = Models;
using Entity = DataAccessLogic.Entities;
using System.Linq;

namespace DataAccessLogic
{
    public class CloudRepo //: IRepository
    {
        private static Entity.DataContext _context;
        public CloudRepo(Entity.DataContext p_context)
        {
            _context = p_context;
        }

        //Store Methods
        public Model.Store AddStore(Model.Store p_store)
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
                    Name = s.StoreName,
                    Address = s.StoreAddress,
                    StoreID = s.StoreId,
                    Products = new CloudRepo(_context).GetProductsByStoreId(s.StoreId),
                    Orders = (List<Model.Order>)(from o in _context.Orders where o.StoreId == s.StoreId select o)
                }
            ).ToList();
        }
        public void UpdateStore(Model.Store p_store)
        {
            
        }

        //Customer Methods
        public Model.Customer AddCustomer(Model.Customer p_cust)
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
            return p_cust;
        }
        public Model.Customer GetCustomerByCustId(int p_custID)
        {
            Entity.Customer cust = _context.Customers.Find(p_custID);
            return new Model.Customer(){
                CustID = cust.CustId,
                Name = cust.CustName,
                Address = cust.CustAddress,
                Email = cust.CustEmail,
                PhoneNumber = cust.CustPhoneNumber,
                Orders = GetOrdersByCustId(cust.CustId)
            };
        }
        public List<Model.Customer> GetAllCustomers()
        {
            var result = (from cust in _context.Customers select cust);
            List<Model.Customer> customers = new List<Model.Customer>();
            foreach (var c in result)
            {
                customers.Add(new Model.Customer(){
                    CustID = c.CustId,
                    Name = c.CustName,
                    Address = c.CustAddress,
                    Email = c.CustEmail,
                    PhoneNumber = c.CustPhoneNumber,
                    //Orders = GetOrdersByCustId(c.CustId)
                });
            }
            return customers;
            /*return _context.Customers.Select(c =>
                new Model.Customer(){
                    CustID = c.CustId,
                    Name = c.CustName,
                    Address = c.CustAddress,
                    Email = c.CustEmail,
                    PhoneNumber = c.CustPhoneNumber,
                    Orders = GetOrdersByCustId(c.CustId)
                }).ToList();*/
        }
        public void UpdateCustomer(int p_custId)
        {

        }

        //Order Methods
        public Model.Order AddOrder(Model.Order p_order)
        {
            return p_order;
        }
        public List<Model.Order> GetOrdersByStoreId(int p_storeId)
        {

            return null;
        }
        public List<Model.Order> GetOrdersByCustId(int p_custId)
        {
            return _context.Orders.Where(o => o.CustId == p_custId)
                    .Select(o => new Model.Order(){
                        OrderNumber = o.OrderNumber,
                        CustID = o.CustId,
                        StoreID = o.StoreId
                    }).ToList();
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
        public static Model.Product GetProductByProductId(int p_id)
        {
            Entity.Product prodToFind = _context.Products.Find(p_id);
            return new Model.Product(){
                Id = prodToFind.ProductId,
                StoreID = prodToFind.StoreId,
                Name = prodToFind.ProductName,
                Price = (double)prodToFind.ProductPrice,
                Description = prodToFind.ProductDescription,
                Quantity = prodToFind.ProductQuantity
            };
        }

        //LineItem Methods
        public List<Model.LineItems> GetLineItemsByOrderId(int p_orderId)
        {
            return _context.LineItems.Where(l => l.OrderNumber == p_orderId)
                .Select(l =>
                    new Model.LineItems()
                    {
                        OrderNumber = l.OrderNumber,
                        ProductID = l.ProductId,
                        Product = GetProductByProductId(l.ProductId),
                        Quantity = l.LineItemQuantity
                    }
            ).ToList();
        }
    }
}