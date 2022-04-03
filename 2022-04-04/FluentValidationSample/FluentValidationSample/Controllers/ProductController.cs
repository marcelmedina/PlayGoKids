using FluentValidation;
using FluentValidationSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IValidator<ProductViewModel> _validator;

        public ProductController(IValidator<ProductViewModel> validator)
        {
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductViewModel model)
        {
            var validation = await _validator.ValidateAsync(model);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors?.Select(e => new ValidationResult()
                {
                    Code = e.ErrorCode,
                    PropertyName = e.PropertyName,
                    Message = e.ErrorMessage
                }));
            }

            return Ok();
        }
    }
}
