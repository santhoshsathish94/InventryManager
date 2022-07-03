using InventryManager.Service.Criteria;
using InventryManager.Service.Dto;
using InventryManager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManager.Service.Implimentations
{
    public class OrderService : IOrderService
    {
        public Task<bool> CompleteOrderAsync(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateOrUpdateAsync(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateOrUpdateAsync(OrderItemDto orderItemDto)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> FindAsync(SearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int[] Ids)
        {
            throw new NotImplementedException();
        }
    }
}
