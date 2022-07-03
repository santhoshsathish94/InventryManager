using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManager.SqlRepostiroy.Entities
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; }
        public int CustomerId { get; set; }
        public virtual ICollection<OrderDetail> OrderItems { get; set; }
    }
}
