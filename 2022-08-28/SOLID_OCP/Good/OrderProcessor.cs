using SOLID_OCP.Models;

namespace SOLID_OCP
{
    public class OrderProcessor
    {
        private readonly OrderValidator _orderValidator;
        private readonly IOrderSaver _orderSaver;
        private readonly OrderNotifier _orderNotifier;

        public OrderProcessor(OrderValidator orderValidator, IOrderSaver orderSaver, OrderNotifier orderNotifier)
        {
            _orderValidator = orderValidator;
            _orderSaver = orderSaver;
            _orderNotifier = orderNotifier;
        }
        
        public void Process()
        {
            _orderValidator.Validate();
            _orderSaver.Save();
            _orderNotifier.Notify();
        }
    }
}