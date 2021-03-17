using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DatabaseContext Context;

        public AccountController(DatabaseContext context)
        {
            Context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody]RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username))
            {
                return BadRequest("Username is taken");
            }

            using var hmac = new HMACSHA512();

            var user = new User 
            {
                Username = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();
            
            return user;
        }

        private async Task<bool> UserExists(string username)
        {
            return await Context.Users.AnyAsync(u => u.Username == username.ToLower());
        }
    }
}