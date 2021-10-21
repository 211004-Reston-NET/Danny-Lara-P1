using System.Collections.Generic;

namespace DataAccessLogic
{
    public interface IRepository
    {
        public object Add(object p_newObject);
        public List<object> GetAll();
        public bool Update(List<object> p_newList);
    }
}