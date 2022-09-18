using SOLID_ISP_BAD.Interfaces;
using SOLID_ISP_BAD.Models;

namespace SOLID_ISP_BAD
{
    public class OrderValidator : IOrderProcessor
    {
        private readonly Order _order;

        public OrderValidator(Order order)
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
            throw new NotImplementedException();
        }

        // Notify
        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}