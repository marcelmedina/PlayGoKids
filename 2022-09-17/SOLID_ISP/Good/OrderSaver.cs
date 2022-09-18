using SOLID_ISP_GOOD.Interfaces;
using SOLID_ISP_GOOD.Models;

namespace SOLID_ISP_GOOD
{
    public class OrderSaver : IOrderSaver
    {
        private readonly Order _order;

        public OrderSaver(Order order)
        {
            _order = order;
        }

        public void Save()
        {
            //TODO: save order
            Console.WriteLine($"save order: {_order.OrderNumber}");
        }
    }
}