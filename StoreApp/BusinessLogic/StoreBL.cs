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
            List<Store> stores = _data.GetAllStores();
            foreach (Store s in stores)
            {
                s.Products = _data.GetProductsByStoreId(s.StoreID);
                s.Orders = _data.GetOrdersByStoreId(s.StoreID);
            }
            return stores;
        }
        public void Update(Store p_store)
        {
            _data.UpdateStore(p_store);
        }
    }
}