using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidationFunction.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace FluentValidationFunction.Apis
{
    public class ProductApi
    {
        private readonly ILogger<ProductApi> _logger;
        private readonly IValidator<ProductViewModel> _validator;

        public ProductApi(ILogger<ProductApi> log, IValidator<ProductViewModel> validator)
        {
            _logger = log;
            _validator = validator;
        }

        [FunctionName(nameof(AddProductAsync))]
        [OpenApiOperation(operationId: nameof(AddProductAsync), tags: new[] {"name"})]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(ProductViewModel), Description = nameof(ProductViewModel), Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json ", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> AddProductAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
            HttpRequest req)
        {
            _logger.LogInformation($"{nameof(AddProductAsync)} has been triggered");

            // Deserialize object
            var productJson = await req.ReadAsStringAsync();
            var productViewModel = JsonConvert.DeserializeObject<ProductViewModel>(productJson);

            // Validating
            var productValidationResult = await _validator.ValidateAsync(productViewModel);

            if (!productValidationResult.IsValid)
            {
                return new BadRequestObjectResult(productValidationResult.Errors.Select(e => new
                {
                    e.ErrorCode, e.PropertyName, e.ErrorMessage
                }));
            }

            // TODO: Perform add product

            return new OkResult();
        }
    }
}
