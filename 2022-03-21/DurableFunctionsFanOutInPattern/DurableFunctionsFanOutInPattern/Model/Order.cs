using System;

namespace DurableFunctionsFanOutInPattern.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string ProductSKu { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
