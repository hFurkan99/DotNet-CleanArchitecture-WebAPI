namespace App.Application.Contracts.Caching;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string cacheKey);
    Task AddAsync<T>(string cacheKey, T value, TimeSpan exportTimeSpan);
    Task RemoveAsync(string cacheKey);
}
