namespace SOLID_SRP.Models
{
    public class Order
    {
        private int _orderNumber;

        public Order(int orderNumber)
        {
            _orderNumber = orderNumber;
        }

        //TODO: properties
        public int OrderNumber
        {
            get => _orderNumber;
            private set => _orderNumber = value;
        }
        
        //TODO: methods
    }
}