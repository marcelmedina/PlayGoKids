using SOLID_OCP.Models;

namespace SOLID_OCP
{
    public class OrderValidator
    {
        private readonly Order _order;

        public OrderValidator(Order order)
        {
            _order = order;
        }

        public void Validate()
        {
            //TODO: validate order
            Console.WriteLine($"validate order: {_order.OrderNumber}");
        }
    }
}