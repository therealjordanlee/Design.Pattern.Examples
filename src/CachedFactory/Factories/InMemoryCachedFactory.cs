using GenericFactory.Factories;
using Microsoft.Extensions.Caching.Memory;

namespace CachedFactory.Factories
{
    public class InMemoryCachedFactory<TModelArgs, TModel> : IGenericFactory<TModelArgs, TModel>
    {
        private IMemoryCache _cache;
        private IGenericFactory<TModelArgs, TModel> _factory;

        public InMemoryCachedFactory(IMemoryCache cache, IGenericFactory<TModelArgs, TModel> factory)
        {
            _cache = cache;
            _factory = factory;
        }

        public async Task<TModel> CreateAsync(TModelArgs args, CancellationToken cancellationToken = default)
        {
            var argValues = string.Join(",", args.GetType().GetProperties().Select(prop => prop.GetValue(args)));
            var key = $"{typeof(TModelArgs).Name}_{argValues}";

            TModel cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1));
                cacheEntry = await _factory.CreateAsync(args, cancellationToken);
                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }
    }
}