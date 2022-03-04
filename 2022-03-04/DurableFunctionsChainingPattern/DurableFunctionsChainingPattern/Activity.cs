using DurableFunctionsChainingPattern.Model;
using DurableFunctionsChainingPattern.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace DurableFunctionsChainingPattern
{
    public class Activity
    {
        private readonly IOrderService _orderService;

        public Activity(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [FunctionName(nameof(IOrderService.InitializeOrder))]
        public string Initialize([ActivityTrigger] Order order, ILogger log)
        {
            log.LogInformation($"Initializing order.");
            var initializedOrder = _orderService.InitializeOrder(order);
            return initializedOrder.OrderNumber;
        }

        [FunctionName(nameof(IOrderService.ValidateOrder))]
        public string ValidateOrder([ActivityTrigger] Order order, ILogger log)
        {
            log.LogInformation($"Validating order.");
            var validatedOrder = _orderService.ValidateOrder(order);
            return validatedOrder.Quantity.ToString();
        }

        [FunctionName(nameof(IOrderService.ProcessOrder))]
        public string ProcessOrder([ActivityTrigger] Order order, ILogger log)
        {
            log.LogInformation($"Processing order.");
            var processedOrder = _orderService.ProcessOrder(order);
            return processedOrder.OrderDate.ToString("o");
        }

        [FunctionName(nameof(IOrderService.SaveOrder))]
        public string SaveOrder([ActivityTrigger] Order order, ILogger log)
        {
            log.LogInformation($"Saving order.");
            var savedOrder = _orderService.SaveOrder(order);
            return savedOrder.OrderId.ToString();
        }
    }
}
