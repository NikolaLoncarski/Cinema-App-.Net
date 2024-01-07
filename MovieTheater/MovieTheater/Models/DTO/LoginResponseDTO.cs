namespace MovieTheater.Models.DTO
{
    public class LoginResponseDTO
    {
        public Guid id { get; set; }
        public string JwtToken { get; set; }
        public string Username { get; set; }
        public string Roles { get; set; }
    }
}
