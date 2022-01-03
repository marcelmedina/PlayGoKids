using System.IO;
using System.Threading.Tasks;
using DependencyInjectionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DependencyInjectionFunctionSample
{
    public class Email
    {
        private readonly IEmailService _emailService;

        public Email(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [FunctionName("SendEmail")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Send Email function processed a request.");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string email = data?.email;

            _emailService.SendEmail(email, "Subject", "Body");

            return new OkObjectResult("OK");
        }
    }
}
