﻿using AutoMapper;
using Digitall.Warehouse.Api.Contracts.Requests.Products;
using Digitall.Warehouse.Api.Infrastructure.ExceptionHandling.Models;
using Digitall.Warehouse.Application.Features.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Digitall.Warehouse.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public ProductsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IAsyncResult> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync()
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType((int)HttpStatusCode.FailedDependency, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest createProductRequest, CancellationToken cancellationToken)
        {
            var createProductCommand = _mapper.Map<CreateProductCommand>(createProductRequest);
            var result = await _sender.Send(createProductCommand, cancellationToken);

            if (result.IsFailure)
            {
                return StatusCode((int)HttpStatusCode.FailedDependency, new ValidationErrorResponse(result.Error));
            }

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
