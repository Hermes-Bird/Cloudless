using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Interfaces;

namespace Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        { 
            _context = context;
        }
        
        
        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }   

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToArrayAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}