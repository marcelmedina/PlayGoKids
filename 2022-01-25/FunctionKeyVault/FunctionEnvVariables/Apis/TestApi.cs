using System.ComponentModel;
using System.Threading.Tasks;
using FunctionEnvVariables.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FunctionEnvVariables.Apis
{
    public class TestApi
    {
        private readonly IOptions<SecretSettings> _settings;

        public TestApi(IOptions<SecretSettings> settings)
        {
            _settings = settings;
        }

        [Description("Test endpoint")]
        [FunctionName(nameof(Secret))]
        public async Task<IActionResult> Secret(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "test/secret")]
            HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(new
            {
                SqlConnString = _settings.Value.SqlConnectionString,
                BlobConnString = _settings.Value.BlobConnectionString
            });
        }
    }
}
