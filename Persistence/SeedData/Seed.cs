using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.SeedData
{
    public static class Seed
    {
        public static async Task SeedUsers(DatabaseContext context)
        {
            if (!await context.Users.AnyAsync())
            {
                var usersData = await System.IO.File.ReadAllTextAsync("../Persistence/SeedData/UserSeedData.json");
                var users = JsonSerializer.Deserialize<List<User>>(usersData);

                if (users != null)
                {
                    foreach (var user in users)
                    {
                        using var hmac = new HMACSHA512();
                        user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Passw0rd"));
                        user.PasswordSalt = hmac.Key;
                    }

                    await context.Users.AddRangeAsync(users);
                }

                await context.SaveChangesAsync();
            }
            
            
        }
    }
}