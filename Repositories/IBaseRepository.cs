namespace Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);        
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task<IReadOnlyList<T>> PaginatedItems(int pageNumber, int pageSize);
        Task<int> Count();
    }
}
