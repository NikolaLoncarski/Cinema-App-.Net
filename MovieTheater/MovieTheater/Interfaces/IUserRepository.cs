using MovieTheater.Models;
using MovieTheater.Models.DTO;

namespace MovieTheater.Interfaces
{
    public interface IUserRepository
    {
        Task<(int, string)> Registration(RegisterRequestDTO model, string role);
        Task<TokenViewModel> Login(LoginRequestDTO model);
        Task<TokenViewModel> GetRefreshToken(GetRefreshTokenViewModel model);
    }
}
