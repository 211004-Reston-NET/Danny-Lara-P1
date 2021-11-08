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

        /// <summary>
        /// Gets all the stores from the data layer
        /// </summary>
        /// <returns>A list of all the stores in the database</returns>
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
        /// <summary>
        /// Gets a specific store from the data layer 
        /// using the store's ID
        /// </summary>
        /// <param name="p_storeId">The ID of the store</param>
        /// <returns>The store being requested</returns>
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
        /// <summary>
        /// Updates the specified product in the data layer
        /// </summary>
        /// <param name="p_product">The product to be updated</param>
        /// <returns>True if the update was successful or false otherwise</returns>
        public bool UpdateProduct(Product p_product)
        {
            return _data.UpdateProduct(p_product);
        }
        /// <summary>
        /// Gets the products for the specified store 
        /// using the store's ID
        /// </summary>
        /// <param name="p_storeId">The ID of the store</param>
        /// <returns>A list of the store's products</returns>
        public List<Product> GetStoreProducts(int p_storeId)
        {
            return _data.GetProductsByStoreId(p_storeId);
        }
        /// <summary>
        /// Gets the products (in line item form) from the specified 
        /// order using the order number
        /// </summary>
        /// <param name="orderNumber">The order number</param>
        /// <returns>A list of line items containing the products in the order</returns>
        public List<LineItems> GetOrderProducts(int orderNumber)
        {
            return _data.GetLineItemsByOrderNum(orderNumber);
        }
        /// <summary>
        /// Gets the specified product using the product's ID
        /// </summary>
        /// <param name="p_id">The product ID</param>
        /// <returns>The specified product</returns>
        public Product GetProduct(int p_id)
        {
            return _data.GetProductByProductId(p_id);
        }
        /// <summary>
        /// Adds an order to the database
        /// </summary>
        /// <param name="p_order">The order to be added</param>
        /// <returns>The order's ID number from the database</returns>
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
        /// <summary>
        /// Gets the orders from the specified store using 
        /// the store's ID number
        /// </summary>
        /// <param name="p_storeId">The store's ID</param>
        /// <returns>A list of the orders at the specified store</returns>
        public List<Order> GetOrdersByStoreID(int p_storeId)
        {
            return _data.GetOrdersByStoreId(p_storeId);
        }
        /// <summary>
        /// Checks to see if the specified customer exists 
        /// in the current database
        /// </summary>
        /// <param name="p_custId">The ID of the customer</param>
        /// <returns>True if the customer exists or false otherwise</returns>
        public bool CustExists(int p_custId)
        {
            if (_data.GetCustomerByCustId(p_custId) != null)
                return true;
            else
                return false;
        }
    }
}