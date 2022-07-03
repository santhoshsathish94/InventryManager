using InventryManager.Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManager.CacheRepostiroy
{
    public interface ICacheRepositoryAsync
    {
        Task<T> GetOrCreate<T>(string key, Func<Task<T>> getData, ExpirationType expiration = ExpirationType.OneDay, bool noSerilazation = false) where T : class;

        Task<T> GetOrCreate<T>(string key, Func<T> getData, ExpirationType expiration = ExpirationType.OneDay, bool noSerilazation = false) where T : class;
    }
}
