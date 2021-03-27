using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data.DTOs;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Interfaces;

namespace API.Controllers
{
    [AllowAnonymous]
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
            if (await UserExists(registerDto.Email, registerDto.Username))
            {
                return BadRequest("Email or Username is already taken");
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
        public async Task<ActionResult<UserTokenDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null) return Unauthorized("Invalid email");

            var hmac = new HMACSHA512(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserTokenDto
            {
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            };
        }

        private async Task<bool> UserExists(string email, string username)
        {
            return await _context.Users.AnyAsync(u => u.Email == email) 
                   || await _context.Users.AnyAsync(u => u.Username == username);
        }
    }
}