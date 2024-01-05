using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(Models.User user);
    }
}
