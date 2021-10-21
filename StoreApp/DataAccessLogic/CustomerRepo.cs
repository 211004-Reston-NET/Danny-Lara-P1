using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace DataAccessLogic
{
    public class CustomerRepo : IRepository
    {
        private const string _customerFilepath = "./../DataAccessLogic/Database/CustomerData.json";
        private string _jsonString;
        public CustomerRepo()
        {
            if(!File.Exists(_customerFilepath))
            {
                FileStream f = File.Create(_customerFilepath);
                f.Close();
                File.WriteAllText(_customerFilepath, "[]");
            }
        }

        public object Add(object p_newObject)
        {
            List<object> list = GetAll();
            List<Customer> c_list = new List<Customer>();
            foreach (object item in list)
            {
                c_list.Add((Customer)item);
            }
            c_list.Add((Customer)p_newObject);
            _jsonString = JsonSerializer.Serialize(c_list, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(_customerFilepath,_jsonString);
            return p_newObject;
        }
        public List<object> GetAll()
        {
            _jsonString = File.ReadAllText(_customerFilepath);
            List<Customer> c_list = JsonSerializer.Deserialize<List<Customer>>(_jsonString);
            List<object> list = new List<object>();
            foreach (Customer c in c_list)
            {
                list.Add((object)c);
            }
            return list;
        }
        public bool Update(List<object> p_newList)
        {
            throw new System.NotImplementedException();
        }
    }
}