using SOLID_ISP_GOOD.Interfaces;

namespace SOLID_ISP_GOOD
{
    public class OrderProcessor
    {
        private readonly IOrderValidator _orderValidator;
        private readonly IOrderSaver _orderSaver;
        private readonly IOrderNotifier _orderNotifier;

        public OrderProcessor(IOrderValidator orderValidator, IOrderSaver orderSaver, IOrderNotifier orderNotifier)
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