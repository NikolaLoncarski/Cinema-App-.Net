using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface IMovieTicketRepository
    {
        Task<MovieTicket> CreateAsync(MovieTicket movieTicket);
        Task<List<MovieTicket>> GetAllAsync();
        Task<MovieTicket?> GetByIdAsync(int id);
        Task<MovieTicket?> UpdateAsync(int id, MovieTicket movieTicket);
        Task<MovieTicket?> DeleteAsync(int id);
    }
}
