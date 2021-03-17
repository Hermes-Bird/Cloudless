using System.ComponentModel.DataAnnotations;

namespace Data.DTOs
{
    public class LoginDto
    {
        [Required] 
        public string Username { get; set; }

        public string Password { get; set; }
    }
}