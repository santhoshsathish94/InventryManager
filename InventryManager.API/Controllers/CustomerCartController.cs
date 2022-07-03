using AutoMapper;
using InventryManager.API.Models;
using InventryManager.Service.Criteria;
using InventryManager.Service.Dto;
using InventryManager.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventryManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public class CustomerCartController : ControllerBase
    {

        private readonly ILogger<CustomerCartController> _logger;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public CustomerCartController(ILogger<CustomerCartController> logger, IOrderService orderService,
            IMapper mapper)
        {
            _logger = logger;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("SearchOrder")]
        public async Task<IActionResult> SearchAsync(SearchRequestModel searchRequest)
        {
            var results = await _orderService.FindAsync(_mapper.Map<SearchCriteria>(searchRequest));
            return Ok(results);
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrderAsync(OrderModel orderModel)
        {
            var status = await _orderService.CreateOrUpdateAsync(_mapper.Map<OrderDto>(orderModel));
            return Ok(status);
        }

        [HttpPost]
        [Route("AddItem")]
        public async Task<IActionResult> AddOrderItemAsync(OrderItemModel orderItem)
        {
            var status = await _orderService.CreateOrUpdateAsync(_mapper.Map<OrderItemDto>(orderItem));
            return Ok(status);
        }

        [HttpPut]
        [Route("UpdateItem")]
        public async Task<IActionResult> UpdateOrderItemAsync(OrderItemModel orderItem)
        {
            var status = await _orderService.CreateOrUpdateAsync(_mapper.Map<OrderItemDto>(orderItem));
            return Ok(status);
        }

        [HttpDelete]
        [Route("RemoveItem")]
        public async Task<IActionResult> DeleteOrderItemAsync(int ItemId)
        {
            var status = await _orderService.RemoveAsync(new int[] { ItemId });
            return Ok(status);
        }

        [HttpDelete]
        [Route("RemoveItems")]
        public async Task<IActionResult> DeleteOrderItemsAsync(int[] ItemIds)
        {
            var status = await _orderService.RemoveAsync(ItemIds);
            return Ok(status);
        }

        [HttpPost]
        [Route("CompleteOrder")]
        public async Task<IActionResult> CompleteOrderAsync(OrderModel orderModel)
        {
            var status = await _orderService.CompleteOrderAsync(_mapper.Map<OrderDto>(orderModel));
            return Ok(status);
        }
    }
}
