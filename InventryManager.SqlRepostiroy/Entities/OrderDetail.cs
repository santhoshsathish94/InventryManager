using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManager.SqlRepostiroy.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
    }
}
