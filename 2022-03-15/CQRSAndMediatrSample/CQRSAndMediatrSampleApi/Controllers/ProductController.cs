using CQRSAndMediatrSampleApplication.Product.Command;
using CQRSAndMediatrSampleApplication.Product.Dto;
using CQRSAndMediatrSampleApplication.Product.Notify;
using CQRSAndMediatrSampleApplication.Product.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatrSampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("product")]
        public async Task<IActionResult> Get(string productSKu)
        {
            var result = await _mediator.Send(new GetProductQuery() {Sku = productSKu});
            return Ok(result);
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetProductsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto product)
        {
            var result = await _mediator.Send(new AddOrUpdateProductCommand() {ProductDto = product});
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductDto product)
        {
            var result = await _mediator.Send(new AddOrUpdateProductCommand() { ProductDto = product });
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string productSku)
        {
            var result = await _mediator.Send(new DeleteProductCommand() {Sku = productSku});
            return Ok(result);
        }

        [HttpPost("notify")]
        public async Task<IActionResult> NotifyAsync(string message)
        {
            await _mediator.Publish(new PublishProductNotify() {Message = message});
            return Ok();
        }
    }
}
