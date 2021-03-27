using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Data.DTOs;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    public class ContactsController : BaseApiController
    {
        private readonly IContactsRepository _contactsRepo;
        private readonly IMapper _mapper;

        public ContactsController(
            IContactsRepository contactsRepo,
            IMapper mapper
            )
        {
            _contactsRepo = contactsRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDetailDto>> GetContacts()
        {
            var username = User.FindFirstValue(ClaimTypes.Name);
            return await _contactsRepo.GetContactsAsync(username);
        }

        [HttpPost("{contactUsername}")]
        public async Task<ActionResult<UserDetailDto>> AddToContact(string contactUsername)
        {
            var username = User.FindFirstValue(ClaimTypes.Name);
            
            if (await _contactsRepo.ContactExists(username, contactUsername))
                return BadRequest("This user already in contacts");
            
            var contactsUser = await _contactsRepo.AddToContactsAsync(username, contactUsername);
            return _mapper.Map<UserDetailDto>(contactsUser);
        }

        [HttpDelete("{contactUsername}")]
        public async Task<ActionResult<bool>> DeleteFromContacts(string contactUsername)
        {
            var username = User.FindFirstValue(ClaimTypes.Name);

            if (!await _contactsRepo.ContactExists(username, contactUsername))
                return BadRequest("This user not in contacts");

            return await _contactsRepo.RemoveFromContactsAsync(username, contactUsername);
        }

    }
}