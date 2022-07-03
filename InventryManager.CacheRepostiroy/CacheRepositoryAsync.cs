using InventryManager.Service.Enums;
using InventryManager.Service.Helpers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;

namespace InventryManager.CacheRepostiroy
{
    public class CacheRepositoryAsync : ICacheRepositoryAsync
    {
        private IMemoryCache _cache;
        private ConcurrentDictionary<object, SemaphoreSlim> _locks = new ConcurrentDictionary<object, SemaphoreSlim>();
        private CacheSettings _cacheSettings { get; }

        public CacheRepositoryAsync(IMemoryCache cache, IOptions<CacheSettings> cacheSettings)
        {
            _cache = cache;
            _cacheSettings = cacheSettings.Value;
        }

        private async Task<T> GetOrCreate<T>(string key, ExpirationType expiration, Func<T> getData = null, Func<Task<T>> getTaskData = null) where T : class
        {
            string cacheEntry = string.Empty;
            T result = default;

            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));

                await mylock.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        // Key not in cache, so get data.
                        result = (getData != null) ? getData() : (getTaskData != null) ? await getTaskData() : default;
                        _cache.Set(key, result.ToJsonString(), expiration.GetTimeSpan());
                    }
                }
                finally
                {
                    mylock.Release();
                }
            }
            if (!string.IsNullOrEmpty(cacheEntry))
            {
                result = cacheEntry.ConvertToModel<T>();
            }
            return result;
        }

        private async Task<T> GetOrCreateWithOutSerilization<T>(string key, ExpirationType expiration, Func<T> getData = null, Func<Task<T>> getTaskData = null) where T : class
        {
            T cacheEntry = default;

            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));

                await mylock.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        // Key not in cache, so get data.
                        cacheEntry = (getData != null) ? getData() : (getTaskData != null) ? await getTaskData() : default;
                        _cache.Set(key, cacheEntry, expiration.GetTimeSpan());
                    }
                }
                finally
                {
                    mylock.Release();
                }
            }
            return cacheEntry;
        }

        public async Task<T> GetOrCreate<T>(string key, Func<Task<T>> getData, ExpirationType expiration = ExpirationType.OneDay, bool noSerilazation = false) where T : class
        {
            return await GetOrCreate<T>(key, expiration, null, getData);
        }

        public async Task<T> GetOrCreate<T>(string key, Func<T> getData, ExpirationType expiration = ExpirationType.OneDay, bool noSerilazation = false) where T : class
        {
            if (noSerilazation)
            {
                return await GetOrCreateWithOutSerilization<T>(key, expiration, getData, null);
            }
            return await GetOrCreate<T>(key, expiration, getData, null);
        }
    }
}