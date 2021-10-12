using System.Collections.Generic;

namespace Models
{
    public class Orders
    {
        private List<LineItems> items;
        private StoreFront storeLocation;
        private double totalPrice;
    }
}