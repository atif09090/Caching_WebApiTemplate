using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace Caching_WebApiTemplate.Services
{
    public class CacheService
    {
        private readonly IMemoryCache _memory;
        private readonly IDistributedCache _redis;

        public CacheService(IMemoryCache memory, IDistributedCache redis)
        {
            _memory = memory;
            _redis = redis;
        }

        public T? Get<T>(string key)
        {
            if (_memory.TryGetValue(key, out T value))
                return value;

            var redisData = _redis.GetString(key);
            return redisData is not null ? JsonSerializer.Deserialize<T>(redisData) : default;
        }

        public void Set<T>(string key, T data, TimeSpan ttl)
        {
            _memory.Set(key, data, ttl);
            _redis.SetString(key, JsonSerializer.Serialize(data), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = ttl
            });
        }
    }

}
