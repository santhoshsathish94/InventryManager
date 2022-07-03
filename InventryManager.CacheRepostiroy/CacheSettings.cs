using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManager.CacheRepostiroy
{
    public class CacheSettings
    {
        public int AbsoluteExpiration { get; set; }
        public int SlidingExpiration { get; set; }
    }
}
