using SOLID_ISP_GOOD.Interfaces;
using SOLID_ISP_GOOD.Models;

namespace SOLID_ISP_GOOD
{
    public class OrderValidator : IOrderValidator
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