namespace MovieTheater.Models.DTO
{
    public class LoginResponseDTO
    {
        public string JwtToken { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
    }
}
