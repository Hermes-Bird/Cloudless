using System.Collections.Generic;
using Data.Models;

namespace Data.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }

        public string PublicUsername { get; set; }

        public string Email { get; set; }

        public ICollection<UserDetailDto> Contacts { get; set; }
    }
}