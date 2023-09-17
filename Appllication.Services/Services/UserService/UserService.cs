using Appllication.Services.Dtos.UserDto;
using Domain.Entities;
using Repositories;
using Repositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> repository;
        private readonly IUserRepository _userRepository;

        public UserService(IBaseRepository<User> repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this._userRepository = userRepository;
        }
        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = registerDto.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            await repository.InsertAsync(user);

            return new UserDto
            {
                UserName = registerDto?.UserName
            };
        }

        public async Task<UserDto> GetUserByUserName(string userName) 
        {
            var user = await _userRepository.GetUserByUsername(userName);
            if (user == null) return null;

            return new UserDto
            {
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,  
                PasswordSalt = user.PasswordSalt
            };
        }
    }
}
