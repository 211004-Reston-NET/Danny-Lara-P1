using Models;
using System.Collections.Generic;

namespace DataAccessLogic
{
    public interface IRepository
    {
        //Store Methods
        /// <summary>
        /// Adds a store to the database. Specifically the Store table
        /// </summary>
        /// <param name="p_store">The store object to be added</param>
        /// <returns>Returns the store that was added</returns>
        Store AddStore(Store p_store);
        /// <summary>
        /// Gets all the stores in the table
        /// </summary>
        /// <returns>A list of all the stores in the database</returns>
        List<Store> GetAllStores();

        //Customer Methods
        /// <summary>
        /// Adds a customer to the customer table
        /// </summary>
        /// <param name="p_cust">The customer that is being added</param>
        /// <returns>The customer ID of the newly added customer</returns>
        int AddCustomer(Customer p_cust);
        /// <summary>
        /// Gets a customer from the customer table using the primary key (Customer_ID)
        /// </summary>
        /// <param name="p_custID">The ID of the customer to find</param>
        /// <returns>The customer being requested</returns>
        Customer GetCustomerByCustId(int p_custID);
        /// <summary>
        /// Gets all the customers in the customer table
        /// </summary>
        /// <returns>A list of all the customers in the database</returns>
        List<Customer> GetAllCustomers();
        /// <summary>
        /// Although not implemented, will be able to change/update a customer's info.
        /// </summary>
        /// <param name="p_cust">The customer that will be updated</param>
        /// <returns>True if the update was successful or false if it failed</returns>
        bool UpdateCustomer(Customer p_cust);

        //Order Methods
        /// <summary>
        /// Adds an order to the order table in the database
        /// </summary>
        /// <param name="p_order">The order being added to the database</param>
        /// <returns>The order number of the order being added (The primary key)</returns>
        int AddOrder(Order p_order);
        /// <summary>
        /// Gets all the orders from a specific store using 
        /// the store ID (primary key)
        /// </summary>
        /// <param name="p_storeId">The store ID</param>
        /// <returns>A list of all the orders at the specified store</returns>
        List<Order> GetOrdersByStoreId(int p_storeId);
        /// <summary>
        /// Gets all the orders currently in the database
        /// </summary>
        /// <returns>A list of all the orders in the database</returns>
        List<Order> GetAllOrders();
        /// <summary>
        /// Gets all the orders from the order table made by the 
        /// specified customer using the customer's ID
        /// </summary>
        /// <param name="p_custId">The customer's ID</param>
        /// <returns>A list of all the orders made by the customer</returns>
        List<Order> GetOrdersByCustId(int p_custId);

        //Product Methods
        /// <summary>
        /// Gets all the products from a specified store 
        /// using the store's ID
        /// </summary>
        /// <param name="p_storeId">The ID of the store</param>
        /// <returns>A list of all the products the store has</returns>
        List<Product> GetProductsByStoreId(int p_storeId);
        /// <summary>
        /// Gets a specific product using the product's ID
        /// </summary>
        /// <param name="p_id">The ID of the product</param>
        /// <returns>The product from the product table in the database</returns>
        Product GetProductByProductId(int p_id);
        /// <summary>
        /// Adds a product to the database in the product table
        /// </summary>
        /// <param name="p_product">The product to be added</param>
        /// <returns>The product that was added</returns>
        Product AddProduct(Product p_product);
        /// <summary>
        /// Updates the specified product in the product table 
        /// in the database
        /// </summary>
        /// <param name="p_product">The product to update</param>
        /// <returns>True if the update was successful or false otherwise</returns>
        bool UpdateProduct(Product p_product);

        //LineItems Methods
        /// <summary>
        /// Gets all the line items associated with the 
        /// specified order number
        /// </summary>
        /// <param name="p_orderNum">The order number</param>
        /// <returns>A list of all the line items in the specified order</returns>
        List<LineItems> GetLineItemsByOrderNum(int p_orderNumb);
        /// <summary>
        /// Adds a line item to the line item table in the database
        /// </summary>
        /// <param name="p_lineItem">The line item to be added</param>
        /// <returns>The line item that was added</returns>
        LineItems AddLineItem(LineItems p_lineItem);
        /// <summary>
        /// Updates the specified line item in the database
        /// </summary>
        /// <param name="p_lineItem">The line item to be updated</param>
        /// <returns>True if the update was successful or false otherwise</returns>
        bool UpdateLineItem(LineItems p_lineItem);
    }
}