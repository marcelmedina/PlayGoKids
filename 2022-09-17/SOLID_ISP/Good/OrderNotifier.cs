using SOLID_ISP_GOOD.Interfaces;
using SOLID_ISP_GOOD.Models;

namespace SOLID_ISP_GOOD
{
    public class OrderNotifier : IOrderNotifier
    {
        private readonly Order _order;

        public OrderNotifier(Order order)
        {
            _order = order;
        }

        public void Notify()
        {
            //TODO: send notification
            Console.WriteLine($"send notification: {_order.OrderNumber}");
        }
    }
}