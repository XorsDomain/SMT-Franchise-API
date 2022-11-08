﻿using AutoMapper;
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Shin.Megami.Tensei.DTOs.Products;
using Shin.Megami.Tensei.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shin.Megami.Tensei.Data.Model;

namespace Shin.Megami.Tensei.API.Controllers
{
    /// <summary>
    /// The ProductsController exposes endpoints for product related actions.
    /// </summary>
    [ApiController]
    [Route("/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductProvider _productProvider;
        private readonly IMapper _mapper;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductProvider productProvider,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _productProvider = productProvider;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetProductByIdAsync for id: {id}");

            var product = await _productProvider.GetProductByIdAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(product);

            return Ok(productDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsAsync()
        {
            var result = await _productProvider.GetAllProductsAsync();

            IEnumerable<ProductDTO> productDTO = _mapper.Map<IEnumerable<ProductDTO>>(result);
            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProductAsync([FromBody]ProductDTO productToCreate)
        {
            _logger.LogInformation("Request recieved for CreateProductAsync");

            var product = _mapper.Map<Product>(productToCreate);
            var newProduct = await _productProvider.CreateProductAsync(product);
            var productDTO = _mapper.Map<ProductDTO>(newProduct);
            return Created("/products", productDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProductAsync(int id, [FromBody] ProductDTO productToUpdate)
        {
            _logger.LogInformation("Request received for UpdateProductAsync");

            var product = _mapper.Map<Product>(productToUpdate);
            var updatedProduct = await _productProvider.UpdateProductAsync(id, product);
            var productDTO = _mapper.Map<ProductDTO>(updatedProduct);

            return Ok(productDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductById(int id)
        {
            await _productProvider.DeleteProductByIdAsync(id);
            return NoContent();
        }

    }
}
