﻿using CQRSAndMediatrWithFluentValidationSampleApplication.Product.Command;
using CQRSAndMediatrWithFluentValidationSampleApplication.Product.Dto;
using CQRSAndMediatrWithFluentValidationSampleApplication.Product.Notify;
using CQRSAndMediatrWithFluentValidationSampleApplication.Product.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatrWithFluentValidationSampleApi.Controllers
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
        public async Task<IActionResult> Create([FromBody] ProductRequestDto product)
        {
            // Create product
            var result = await _mediator.Send(new AddOrUpdateProductCommand() {ProductRequestDto = product});

            // Notify consumers
            await _mediator.Publish(new PublishProductNotify() {Message = $"Product {product.Sku} created"});

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductRequestDto product)
        {
            // Update product
            var result = await _mediator.Send(new AddOrUpdateProductCommand() { ProductRequestDto = product });

            // Notify consumers
            await _mediator.Publish(new PublishProductNotify() { Message = $"Product {product.Sku} updated" });

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string productSku)
        {
            // Remove product
            var result = await _mediator.Send(new DeleteProductCommand() {Sku = productSku});

            // Notify consumers
            await _mediator.Publish(new PublishProductNotify() { Message = $"Product {productSku} removed" });

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
