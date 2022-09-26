using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using DurableFunctionsHumanInteractionPattern.Services;
using DurableFunctionsHumanInteractionPattern.Models;

namespace DurableFunctionsHumanInteractionPattern
{
    public class Activity
    {
        private readonly INotifier _notifier;
        private readonly ILogger<Activity> _logger;

        public Activity(INotifier notifier, ILogger<Activity> logger)
        {
            _notifier = notifier;
            _logger = logger;
        }

        [FunctionName(nameof(Constants.RunRequestApproval))]
        public void RunRequestApproval([ActivityTrigger] ExpenseClaim expenseClaim)
        {
            _logger.LogInformation($"{nameof(RunRequestApproval)}");

            // TODO: send notification
            _notifier.Notify($"{expenseClaim.Description}, ${expenseClaim.Cost}");
        }

        [FunctionName(nameof(Constants.RunProcessApproval))]
        public void RunProcessApproval([ActivityTrigger] bool approved)
        {
            _logger.LogInformation($"{nameof(RunProcessApproval)} - Approved:{approved}");

            // TODO: process approval
        }

        [FunctionName(nameof(Constants.RunEscalation))]
        public void RunEscalation([ActivityTrigger] IDurableActivityContext context)
        {
            _logger.LogInformation($"{nameof(RunEscalation)}");

            // TODO: escalate
            _notifier.Notify("escalated");
        }
    }
}
