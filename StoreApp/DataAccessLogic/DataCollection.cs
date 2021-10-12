using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Models;

namespace DataAccessLogic
{
    public class DataCollection
    {
        private const string _storeFilepath = "./../DataAccessLogic/Database/StoreData.json";
        private const string _customerFilepath = "./../DataAccessLogic/Database/CustomerData.json";
        private string _jsonString;

        public StoreFront AddStore(StoreFront p_store)
        {
            List<StoreFront> storeList = GetAllStores();
            storeList.Add(p_store);

            _jsonString = JsonSerializer.Serialize(storeList);
            File.WriteAllText(_storeFilepath,_jsonString);
            return p_store;
        }
        public List<StoreFront> GetAllStores()
        {
            _jsonString = File.ReadAllText(_storeFilepath);
            return JsonSerializer.Deserialize<List<StoreFront>>(_jsonString);
        }

        public Customer AddCustomer(Customer p_customer)
        {
            List<Customer> customerList = GetAllCustomers();
            customerList.Add(p_customer);

            _jsonString = JsonSerializer.Serialize(customerList);
            File.WriteAllText(_customerFilepath,_jsonString);
            return p_customer;
        }
        public List<Customer> GetAllCustomers()
        {
            _jsonString = File.ReadAllText(_customerFilepath);
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }
        
    }
}