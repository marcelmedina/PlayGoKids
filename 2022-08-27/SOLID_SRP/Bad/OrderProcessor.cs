using SOLID_SRP.Models;

namespace SOLID_SRP
{
    public class OrderProcessor
    {
        private readonly Order _order;

        public OrderProcessor(Order order)
        {
            _order = order;
        }

        // Validate
        public void Validate()
        {
            //TODO: validate order
            Console.WriteLine($"validate order: {_order.OrderNumber}");
        }

        // Save
        public void Save()
        {
            //TODO: save order
            Console.WriteLine($"save order: {_order.OrderNumber}");
        }

        // Notify
        public void Notify()
        {
            //TODO: send notification
            Console.WriteLine($"send notification: {_order.OrderNumber}");
        }
    }
}