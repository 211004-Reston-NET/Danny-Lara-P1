using System;
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
        public Store GetStore(int p_storeId)
        {
            List<Store> stores = _data.GetAllStores();
            Store result = new Store();
            foreach (Store s in stores)
            {
                if (s.StoreID == p_storeId)
                    result = s;
            }
            return result;
        }
        public void UpdateStore(Store p_store, int p_orderNum)
        {
            foreach (Order o in p_store.Orders)
            {
                if (o.OrderNumber == p_orderNum)
                {
                    foreach (LineItems item in o.Items)
                    {
                        _data.UpdateLineItem(item);
                        _data.UpdateProduct(item.Product, -item.Quantity);
                    }
                }
            }
        }
        public bool UpdateProduct(Product p_product, int p_quantity)
        {
            _data.UpdateProduct(p_product, p_quantity);
            return true;
        }
        public List<Product> GetStoreProducts(int p_storeId)
        {
            return _data.GetProductsByStoreId(p_storeId);
        }
        public List<LineItems> GetOrderProducts(int orderNumber)
        {
            return _data.GetLineItemsByOrderNum(orderNumber);
        }
        public Product GetProduct(int p_id)
        {
            return _data.GetProductByProductId(p_id);
        }
        public int AddOrder(Order p_order)
        {
            int orderNumber = _data.AddOrder(p_order);
            foreach (LineItems li in p_order.Items)
            {
                li.OrderNumber = orderNumber;
                _data.AddLineItem(li);
            }
            return orderNumber;
        }
        public List<Order> GetOrdersByStoreID(int p_storeId)
        {
            return _data.GetOrdersByStoreId(p_storeId);
        }
        public bool CustExists(int p_custId)
        {
            if (_data.GetCustomerByCustId(p_custId) != null)
                return true;
            else
                return false;
        }
    }
}