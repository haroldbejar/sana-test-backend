﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.UserRepo
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string userName);
    }
}
