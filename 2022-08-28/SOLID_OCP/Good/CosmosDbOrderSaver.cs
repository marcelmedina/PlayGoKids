using SOLID_OCP.Models;

namespace SOLID_OCP
{
    public class CosmosDbOrderSaver : IOrderSaver
    {
        private readonly Order _order;

        public CosmosDbOrderSaver(Order order)
        {
            _order = order;
        }

        public void Save()
        {
            //TODO: save order
            Console.WriteLine($"save order to cosmos db: {_order.OrderNumber}");
        }
    }
}