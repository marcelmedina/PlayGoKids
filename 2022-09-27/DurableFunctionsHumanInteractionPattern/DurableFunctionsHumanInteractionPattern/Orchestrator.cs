using System.Threading;
using System.Threading.Tasks;
using DurableFunctionsHumanInteractionPattern.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace DurableFunctionsHumanInteractionPattern
{
    public class Orchestrator
    {
        [FunctionName(nameof(Constants.RunOrchestrator))]
        public async Task RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context, ILogger log)
        {
            var expense = context.GetInput<ExpenseClaim>();

            await context.CallActivityAsync<ExpenseClaim>(nameof(Constants.RunRequestApproval), expense);

            using var timeoutCts = new CancellationTokenSource();
            var dueTime = context.CurrentUtcDateTime.AddHours(Constants.Timeout);
            var durableTimeout = context.CreateTimer(dueTime, timeoutCts.Token);

            var approvalEvent = context.WaitForExternalEvent<bool>(Constants.WaitForExternalApprovalEvent);
            if (approvalEvent == await Task.WhenAny(approvalEvent, durableTimeout))
            {
                timeoutCts.Cancel();
                await context.CallActivityAsync<bool>(Constants.RunProcessApproval, approvalEvent.Result);
            }
            else
            {
                await context.CallActivityAsync(Constants.RunEscalation, null);
            }
        }
    }
}
