using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
     
        [NotMapped]
        public List<string> Roles { get; set; }

      
        public List<UserRole> UserRoles { get; set; }
    }
}
