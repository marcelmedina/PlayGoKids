using System;
using System.Threading;
using System.Threading.Tasks;
using DurableFunctionsMonitorPattern.Models;
using DurableFunctionsMonitorPattern.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace DurableFunctionsMonitorPattern
{
    public class Orchestrator
    {
        [FunctionName(nameof(Constants.RunOrchestrator))]
        public async Task RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context, ILogger log)
        {
            var imageDto = context.GetInput<ImageDto>();
            var pollingInterval = GetPollingInterval();
            var expiryTime = GetExpiryTime(context);

            await context.CallActivityAsync(nameof(Constants.RunProcessImageActivity), imageDto);

            var isProcessWithinTime = context.CurrentUtcDateTime < expiryTime;

            while (isProcessWithinTime)
            {
                var jobStatus = await context.CallActivityAsync<ImageStatus>(nameof(Constants.RunGetStatusImageActivity), imageDto.FileName);

                if (jobStatus == ImageStatus.Processed)
                {
                    // Perform an action when a condition is met.
                    await context.CallActivityAsync(nameof(Constants.RunSendAlertActivity), imageDto.FileName);
                    break;
                }

                // Orchestration sleeps until this time.
                var nextCheck = context.CurrentUtcDateTime.AddSeconds(pollingInterval);
                await context.CreateTimer(nextCheck, CancellationToken.None);
            }

            if (!isProcessWithinTime)
            {
                // Operation has timed out
                log.LogWarning($"The image process operation for {imageDto.FileName} has timed out.");
            }
        }

        private DateTime GetExpiryTime(IDurableOrchestrationContext context)
        {
            return context.CurrentUtcDateTime.AddMinutes(5); //Define the expiry time
        }

        private int GetPollingInterval()
        {
            return 15; //Define the polling interval
        }
    }
}
