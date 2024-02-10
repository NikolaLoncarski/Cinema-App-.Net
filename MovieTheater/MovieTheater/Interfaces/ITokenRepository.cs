using Microsoft.AspNetCore.Identity;

namespace MovieTheater.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
