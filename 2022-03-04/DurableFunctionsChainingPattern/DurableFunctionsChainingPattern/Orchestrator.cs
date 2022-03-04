using System.Collections.Generic;
using System.Threading.Tasks;
using DurableFunctionsChainingPattern.Model;
using DurableFunctionsChainingPattern.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace DurableFunctionsChainingPattern
{
    public class Orchestrator
    {
        [FunctionName(nameof(Orchestrator))]
        public async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var input = context.GetInput<Order>(); // sku and quantity

            var outputs = new List<string>
            {
                await context.CallActivityAsync<string>(nameof(IOrderService.InitializeOrder), input),
                await context.CallActivityAsync<string>(nameof(IOrderService.ValidateOrder), input),
                await context.CallActivityAsync<string>(nameof(IOrderService.ProcessOrder), input),
                await context.CallActivityAsync<string>(nameof(IOrderService.SaveOrder), input),
            };

            return outputs;
        }
    }
}
