using AutoMapper;
using InventryManager.API.Models;
using InventryManager.Service.Criteria;
using InventryManager.Service.Dto;
using InventryManager.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventryManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(ILogger<ProductController> logger, IProductService productService,
            IMapper mapper)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> SearchAsync(SearchRequestModel searchRequest)
        {
            var results = await _productService.FindAsync(_mapper.Map<SearchCriteria>(searchRequest));
            return Ok(results);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync(ProductModel productModel)
        {
            var status = await _productService.CreateOrUpdateAsync(_mapper.Map<ProductDto>(productModel));
            return Ok(status);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAsync(ProductModel productModel)
        {
            var status = await _productService.CreateOrUpdateAsync(_mapper.Map<ProductDto>(productModel));
            return Ok(status);
        }

        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> RemoveAsync(int productId)
        {
            var status = await _productService.RemoveAsync(new int[] { productId });
            return Ok(status);
        }

        [HttpDelete]
        [Route("RemoveBatch")]
        public async Task<IActionResult> RemoveBatchAsync(int[] productIds)
        {
            var status = await _productService.RemoveAsync(productIds);
            return Ok(status);
        }
    }
}
