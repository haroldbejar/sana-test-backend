using Appllication.Services.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appllication.Services.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> GetUserByUserName(string userName);
        Task<UserDto> Register(RegisterDto registerDto);
    }
}
