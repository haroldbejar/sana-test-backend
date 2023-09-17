using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.OrderRepo
{
    public interface IOrderRepository
    {
        Task<IReadOnlyCollection<Order>> GetByClientIdAsync(int customerId);
    }
}
