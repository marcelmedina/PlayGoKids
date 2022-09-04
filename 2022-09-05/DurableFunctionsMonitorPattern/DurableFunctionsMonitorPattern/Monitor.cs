using System.Net.Http;
using System.Threading.Tasks;
using DurableFunctionsMonitorPattern.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace DurableFunctionsMonitorPattern
{
    public class Monitor
    {
        [FunctionName($"{nameof(Monitor)}_HttpStart")]
        public async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            var imageDto = await req.Content.ReadAsAsync<ImageDto>();

            var instanceId = await starter.StartNewAsync(nameof(Constants.RunOrchestrator), imageDto);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}
