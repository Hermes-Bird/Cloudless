using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.DTOs;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Interfaces;

namespace Services.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ContactsRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private async Task<User> GetUserAsync(string username) => await _context.Users
            .Include(u => u.Contacts)
            .ThenInclude(uc => uc.Contact)
            .FirstAsync(u => u.Username == username);

        public async Task<bool> ContactExists(string username, string contactUsername) => await _context.Contacts
            .AnyAsync(uc => uc.Contact.Username == contactUsername && uc.User.Username == username);
        
        public async Task<IEnumerable<UserDetailDto>> GetContactsAsync(string username)
        {
            var user = await GetUserAsync(username);
            return _mapper.Map<IEnumerable<UserDetailDto>>(user.Contacts.Select(u => u.Contact));
        }

        public async Task<User> AddToContactsAsync(string username, string contactUsername)
        {
            var user = await GetUserAsync(username);
            var contact = await GetUserAsync(contactUsername);

            await _context.AddAsync(new UserContact()
            {
                User = user,
                UserId = user.Id,
                Contact = contact,
                ContactId = contact.Id
            });

            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<bool> RemoveFromContactsAsync(string username, string contactUsername)
        {
            var user = await GetUserAsync(username);
            var contact = await GetUserAsync(contactUsername);

            _context.Contacts.Remove(
                await _context.Contacts.FirstAsync(uc => uc.UserId == user.Id && uc.ContactId == contact.Id)
            );

            var chages = await _context.SaveChangesAsync();

            return chages >= 1;
        }
    }
}