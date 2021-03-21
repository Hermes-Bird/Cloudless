using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Interfaces;

namespace API.Controllers
{
    public class UsersController: BaseApiController
    {
        private readonly IUserRepository _userRepository;
       
        
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _userRepository.GetUsersAsync());
        }

        [Authorize]
        [HttpGet("{id}")] 
        public async Task<ActionResult<User>> GetUser(int id)
        {
           return await _userRepository.GetUserByIdAsync(id);
        } 
    }
}