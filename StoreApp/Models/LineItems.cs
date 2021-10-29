using System.Collections.Generic;

namespace Models
{
    public class LineItems
    {
        private int _lineItemId;
        private int _orderNumber;
        private int _productID;
        private Product _product;
        private int _quantity;
        public LineItems()
        {
            
        }
        public LineItems(Product p_product, int p_productId, int p_quantity)
        {
            _product = p_product;
            _quantity = p_quantity;
            _productID = p_productId;
        }

        public Product Product { get => _product; set => _product = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public int OrderNumber { get => _orderNumber; set => _orderNumber = value; }
        public int ProductID { get => _productID; set => _productID = value; }
        public int LineItemId { get => _lineItemId; set => _lineItemId = value; }
    }
}