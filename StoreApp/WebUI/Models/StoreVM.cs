using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class StoreVM
    {
        public StoreVM(Store p_store)
        {
            this.StoreId = p_store.StoreID;
            this.Name = p_store.Name;
            this.Address = p_store.Address;
        }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
