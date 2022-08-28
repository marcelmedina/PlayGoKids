using SOLID_OCP.Models;

namespace SOLID_OCP
{
    public class SqlDbOrderSaver : IOrderSaver
    {
        private readonly Order _order;

        public SqlDbOrderSaver(Order order)
        {
            _order = order;
        }

        public void Save()
        {
            //TODO: save order
            Console.WriteLine($"save order to sql db: {_order.OrderNumber}");
        }
    }
}