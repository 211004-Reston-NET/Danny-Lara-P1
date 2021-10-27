using System.Collections.Generic;
using Model = Models;
using Entity = DataAccessLogic.Entities;
using System.Linq;

namespace DataAccessLogic
{
    public class OrderCloudRepo : IRepository
    {
        private Entity.DataContext _context;
        public OrderCloudRepo(Entity.DataContext p_context)
        {
            _context = p_context;
        }
        public Model.Order AddOrder(Model.Order p_order)
        {
            return p_order;
        }
        public List<Model.Order> GetOrders()
        {
            return null;
        }
        public object Add(object p_newObject)
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
        }
    }
}