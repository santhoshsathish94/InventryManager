using InventryManager.Service.Criteria;
using InventryManager.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManager.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> FindAsync(SearchCriteria searchCriteria);
        Task<bool> CreateOrUpdateAsync(OrderDto orderDto);
        Task<bool> CreateOrUpdateAsync(OrderItemDto orderItemDto);
        Task<bool> RemoveAsync(int[] Ids);
        Task<bool> CompleteOrderAsync(OrderDto orderDto);
    }
}
