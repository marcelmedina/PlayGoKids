using System;
using System.Collections.Generic;
using DurableFunctionsFanOutInPattern.Model;
using DurableFunctionsFanOutInPattern.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace DurableFunctionsFanOutInPattern
{
    public class Activity
    {
        private readonly IOrderService _orderService;

        public Activity(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [FunctionName(nameof(IOrderService.GetOrders))]
        public List<Order> GetOrders([ActivityTrigger] DateTime dateTime, ILogger log)
        {
            log.LogInformation($"Getting orders.");
            var orders = _orderService.GetOrders(dateTime);
            return orders;
        }

        [FunctionName(nameof(IOrderService.ProcessOrder))]
        public string ProcessOrder([ActivityTrigger] Order order, ILogger log)
        {
            log.LogInformation($"Processing order {order.OrderNumber}");
            var orderNumber = _orderService.ProcessOrder(order);
            return orderNumber;
        }

        [FunctionName(nameof(IOrderService.SendNotification))]
        public void SendNotification([ActivityTrigger] string[] orderNumbers, ILogger log)
        {
            log.LogInformation($"Send notification.");
            _orderService.SendNotification(orderNumbers);
        }
    }
}
