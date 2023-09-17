using Domain.Data;
using Domain.Entities;

namespace Repositories.CustomerRepo
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context):base(context)
        {
        }
    }
}
