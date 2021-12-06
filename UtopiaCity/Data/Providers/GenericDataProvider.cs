using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using UtopiaCity.Common;
using UtopiaCity.Models.Common;

namespace UtopiaCity.Data.Providers
{
    public class GenericDataProvider<T> where T: BaseObject
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheExpiration;

        public GenericDataProvider(AppDbContext context, IMemoryCache cache, IOptions<AppConfig> options)
        {
            _context = context;
            _cache = cache;
            _cacheExpiration = TimeSpan.FromSeconds(options.Value.CacheExpiration);
        }

        public virtual async Task<T> Get(string id, bool cacheResult = true)
        {
            if (cacheResult && _cache.TryGetValue(GetKey(id), out T item))
            {
                return item;
            }

            item = await _context.FindAsync(typeof(T), id) as T;
            if (item == null)
            {
                return null;
            }

            if (cacheResult)
            {
                _cache.Set(GetKey(id), item, _cacheExpiration);
            }

            return item;
        }

        public virtual async Task<T> Add(T item, bool cacheResult = true)
        {
            await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();

            if (cacheResult)
            {
                _cache.Set(GetKey(item.Id), item, _cacheExpiration);
            }

            return item;
        }

        public virtual async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            if (_cache.TryGetValue(GetKey(entity.Id), out _))
            {
                _cache.Set(GetKey(entity.Id), entity, _cacheExpiration);
            }

            return entity;
        }

        public virtual async Task<T> Delete(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                // throw exception
                return entity;
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            if (_cache.TryGetValue(GetKey(id), out _))
            {
                _cache.Remove(GetKey(entity.Id));
            }

            return entity;
        }

        private string GetKey(string id)
        {
            return $"{typeof(T).Name}-{id}";
        }
    }
}
