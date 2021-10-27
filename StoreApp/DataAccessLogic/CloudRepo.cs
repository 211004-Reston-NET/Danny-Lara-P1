using System.Collections.Generic;
using Model = Models;
using Entity = DataAccessLogic.Entities;
using System.Linq;

namespace DataAccessLogic
{
    public class CloudRepo //: IRepository
    {
        private Entity.DataContext _context;
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
            List<Model.Order> allOrders = _context.Orders.Select(o => 
                new Model.Order()
                {
                }
            ).ToList();
            return _context.Stores.Select(s =>
                new Model.Store()
                {
                    Name = s.StoreName,
                    Address = s.StoreAddress,
                    StoreID = s.StoreId,
                    //Products = 
                    //Orders =
                }
            ).ToList();
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
        public List<Model.Customer> GetAllCustomers()
        {
            return null;
        }

        //Order Methods
        public Model.Order AddOrder(Model.Order p_order)
        {
            return p_order;
        }
        public List<Model.Order> GetOrders()
        {
            return _context.Orders.Select(o =>
                new Model.Order()
                {
                    OrderNumber = o.OrderNumber,
                    CustID = (int)o.CustId,
                    StoreID = (int)o.StoreId,
                    //Store = (Model.Store)o.Store,
                    //Customer = o.Cust,
                    //Items = 
                    TotalPrice = (double)o.OrderTotalPrice
                }
            ).ToList();
        }

        //LineItem Methods
        public List<Model.LineItems> GetLineItems()
        {
            return _context.LineItems.Select(l =>
                new Model.LineItems()
                {
                    //insert mapping here
                }
            ).ToList();
        }
        /*public object Add(object p_newObject)
        {
            throw new System.NotImplementedException();
        }

        public List<object> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(List<object> p_newList)
        {
            throw new System.NotImplementedException();
        }*/
    }
}