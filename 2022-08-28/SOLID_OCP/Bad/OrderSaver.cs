using SOLID_OCP.Models;

namespace SOLID_OCP
{
    public class OrderSaver
    {
        private readonly Order _order;

        public OrderSaver(Order order)
        {
            _order = order;
        }

        public void Save()
        {
            //TODO: save order
            Console.WriteLine($"save order to sql db: {_order.OrderNumber}");
        }

        public void SaveCosmos()
        {
            //TODO: save order
            Console.WriteLine($"save order to cosmos db: {_order.OrderNumber}");
        }
    }
}