using App.Application.Contracts.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace App.Caching;

public class CacheService(IMemoryCache memoryCache) : ICacheService
{
    public Task AddAsync<T>(string cacheKey, T value, TimeSpan exportTimeSpan)
    {
        var cacheOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = exportTimeSpan,
        };

        memoryCache.Set(cacheKey, value, cacheOptions);

        return Task.CompletedTask;
    }

    public Task<T?> GetAsync<T>(string cacheKey) => memoryCache.TryGetValue(cacheKey,
        out T? result) ? Task.FromResult(result) : Task.FromResult(default(T));

    public Task RemoveAsync(string cacheKey)
    {
        memoryCache.Remove(cacheKey);
        return Task.CompletedTask;
    }
}
