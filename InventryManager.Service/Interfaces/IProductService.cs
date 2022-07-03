using InventryManager.Service.Criteria;
using InventryManager.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManager.Service.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> FindAsync(SearchCriteria searchCriteria);
        Task<bool> CreateOrUpdateAsync(ProductDto productDto);
        Task<bool> RemoveAsync(int[] Ids);
    }
}
