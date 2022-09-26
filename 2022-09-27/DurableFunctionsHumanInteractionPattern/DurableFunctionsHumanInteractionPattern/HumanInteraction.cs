using System.Net.Http;
using System.Threading.Tasks;
using DurableFunctionsHumanInteractionPattern.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace DurableFunctionsHumanInteractionPattern
{
    public class HumanInteraction
    {
        [FunctionName($"{nameof(HumanInteraction)}_HttpStart")]
        public async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            var expenseClaim = await req.Content.ReadAsAsync<ExpenseClaim>();

            var instanceId = await starter.StartNewAsync<ExpenseClaim>(nameof(Constants.RunOrchestrator), expenseClaim);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}