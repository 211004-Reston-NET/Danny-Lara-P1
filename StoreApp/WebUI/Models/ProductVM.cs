using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ProductVM
    {
        public ProductVM()
        {

        }
        public ProductVM(Product p_product)
        {
            this.Id = p_product.ProductID;
            this.StoreId = p_product.StoreID;
            this.Name = p_product.Name;
            this.Price = p_product.Price;
            this.Description = p_product.Description;
            this.Quantity = p_product.Quantity;
        }
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
