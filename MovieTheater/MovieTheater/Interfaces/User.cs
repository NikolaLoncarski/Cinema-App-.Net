using MovieTheater.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.Interfaces
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public List<string> Roles { get; set; }


        public List<UserRole> UserRoles { get; set; }
    }
}
