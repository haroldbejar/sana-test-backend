using Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        public BaseRepository(ApplicationDbContext contex)
        {
            this.context = contex;
        }

        protected DbSet<T> EntitySet
        {
            get
            {
                return context.Set<T>();
            }
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
           return await EntitySet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            EntitySet.Add(entity);
            await Save();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await Save();
        }

        public async Task DeleteByIdAsync(int id)
        {
            T entity = await EntitySet.FindAsync(id);
            EntitySet.Remove(entity);
            await Save();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> PaginatedItems(int pageNumber, int pageSize) 
        {
            return await EntitySet
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize)
                     .ToListAsync();
        }

        public async Task<int> Count()
        {
            return await EntitySet.CountAsync();
        }
    }
}
