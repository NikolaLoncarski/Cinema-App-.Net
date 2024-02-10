namespace MovieTheater.Interfaces
{
    public interface IUserRepository
    {
        Task<Models.User> AuthenticateAsync(string username, string password);
    }
}
