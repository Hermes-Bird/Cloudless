using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DTOs;
using Data.Models;

namespace Services.Interfaces
{
    public interface IContactsRepository
    {
        public Task<IEnumerable<UserDetailDto>> GetContactsAsync(string username);
        public Task<User> AddToContactsAsync(string username, string contactUsername);

        public Task<bool> RemoveFromContactsAsync(string username, string contactUsername);

        public Task<bool> ContactExists(string username, string contactUsername);
    }
}