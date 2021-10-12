using System.Collections.Generic;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class StoreBL //: IBL
    {
        private DataCollection _data;
        public StoreBL(DataCollection p_data)
        {
            _data = p_data;
        }
        public List<StoreFront> GetAll()
        {
            return _data.GetAllStores();
        }
        public StoreFront Add(StoreFront p_store)
        {
            _data.AddStore(p_store);
            return p_store;
        }
    }
}
