﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Interfaces
{
    public interface IUserRepository
    {
        void Update(User user);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<User> GetUserByEmailAsync(string email);
    }
}