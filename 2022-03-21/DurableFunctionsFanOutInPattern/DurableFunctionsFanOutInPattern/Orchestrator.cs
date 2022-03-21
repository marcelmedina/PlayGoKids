using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DurableFunctionsFanOutInPattern.Model;
using DurableFunctionsFanOutInPattern.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace DurableFunctionsFanOutInPattern
{
    public class Orchestrator
    {
        [FunctionName(nameof(Orchestrator))]
        public async Task RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var orderProcessingTasks = new List<Task<string>>();

            // Get a list of orders
            var orders = await context.CallActivityAsync<List<Order>>(nameof(IOrderService.GetOrders), DateTime.Now);

            foreach (var order in orders)
            {
                // Process orders in parallel
                Task<string> task = context.CallActivityAsync<string>(nameof(IOrderService.ProcessOrder), order);
                orderProcessingTasks.Add(task);
            }

            // Wait for all orders to process
            var orderNumbers = await Task.WhenAll(orderProcessingTasks);

            // Send notification
            await context.CallActivityAsync(nameof(IOrderService.SendNotification), orderNumbers);
        }
    }
}
