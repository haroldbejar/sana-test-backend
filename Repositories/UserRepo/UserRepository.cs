using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.UserRepo
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }

        public async Task<User> GetUserByUsername(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            return user;
        }
    }
}
