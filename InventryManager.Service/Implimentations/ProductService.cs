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
    public class ProductService : IProductService
    {
        public Task<bool> CreateOrUpdateAsync(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> FindAsync(SearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int[] Ids)
        {
            throw new NotImplementedException();
        }
    }
}
