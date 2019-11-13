using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.API.Data.Generic
{
     public class DbRepository<T> : IDbRepository<T> where T : class
    {
        private readonly DbContext _context;
        public DbRepository(DbContext context)
        {
            _context = context;
        }
        public IQueryable<T> AllItems => _context.Set<T>();

        public DbContext Context => _context;

        async public Task<bool> AddItemAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            return await SaveChangesAsync() > 0;
        }

        async public Task<int> AddItemsAsync(IEnumerable<T> items)
        {
            await _context.Set<T>().AddRangeAsync(items);
            return await SaveChangesAsync();
        }

        async public Task<bool> ChangeItemAsync(T item)
        {
            _context.Set<T>().Update(item);
            return await SaveChangesAsync() > 0;
        }

        async public Task<bool> DeleteItemAsync(int id)
        {
            T item = await _context.Set<T>().FindAsync(id);
            if (item == null)
                return false;
            _context.Set<T>().Remove(item);
            return await SaveChangesAsync() > 0;
        }

        async public Task<T> GetItemAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        async public Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
#pragma warning disable 0168
            catch(Exception e)
#pragma warning restore 0168
            {
                return -1;
            }
        }

        async public Task<List<T>> ToListAsync()
        {
            return await AllItems.ToAsyncEnumerable<T>().ToList();
        }
    }
}