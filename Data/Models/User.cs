using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string PublicUsername { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }
        
        public byte[] PasswordSalt { get; set; }

        public ICollection<UserContact> Contacts { get; set; }

        public ICollection<UserContact> InContacts { get; set; }
    }
}