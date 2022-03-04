using System.Net.Http;
using System.Threading.Tasks;
using DurableFunctionsChainingPattern.Model;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace DurableFunctionsChainingPattern
{
    public class Chaining
    {
        [FunctionName($"{nameof(Chaining)}_HttpStart")]
        public async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            var order = await req.Content.ReadAsAsync<Order>();

            var instanceId = await starter.StartNewAsync(nameof(Orchestrator), order);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}