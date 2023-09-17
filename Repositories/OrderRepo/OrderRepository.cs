using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.OrderRepo
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
       
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Order>> GetByClientIdAsync(int customerId)
        {
            return await _context.Orders.Where(c => c.CustomerId == customerId).ToListAsync();
        }
    }
}
