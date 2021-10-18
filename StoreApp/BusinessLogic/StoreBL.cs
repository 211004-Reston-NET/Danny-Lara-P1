using System.Collections.Generic;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class StoreBL //: IBL
    {
        private Repository _data;
        public StoreBL(Repository p_data)
        {
            _data = p_data;
        }
        public List<Store> GetAll()
        {
            return _data.GetAllStores();
        }
        public Store Add(Store p_store)
        {
            _data.AddStore(p_store);
            return p_store;
        }
        public void Update(List<Store> p_stores)
        {
            _data.UpdateStores(p_stores);
        }
    }
}
