using System.Collections.Generic;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class StoreBL //: IBL
    {
        private CloudRepo _data;
        public StoreBL(CloudRepo p_data)
        {
            _data = p_data;
        }
        public List<Store> GetAll()
        {
            return _data.GetAllStores();
        }
        public void Update(Store p_store)
        {
            _data.UpdateStore(p_store);
        }
    }
}