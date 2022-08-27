using SOLID_SRP.Models;

namespace SOLID_SRP
{
    public class OrderProcessor
    {
        private readonly OrderValidator _orderValidator;
        private readonly OrderSaver _orderSaver;
        private readonly OrderNotifier _orderNotifier;

        public OrderProcessor(OrderValidator orderValidator, OrderSaver orderSaver, OrderNotifier orderNotifier)
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