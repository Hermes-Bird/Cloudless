using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.DTOs;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Interfaces;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DatabaseContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DatabaseContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Email))
            {
                return BadRequest("Email is already taken");
            }

            using var hmac = new HMACSHA512();

            var user = new User
            {
                Username = registerDto.Username,
                Email =  registerDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null) return Unauthorized("Invalid email");

            var hmac = new HMACSHA512(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDto
            {
                Token = _tokenService.CreateToken(user),
                Username = user.Username
            };
        }

        private async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}