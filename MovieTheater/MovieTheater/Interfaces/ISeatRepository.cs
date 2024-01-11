using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface ISeatRepository
    {
        Task<Seat> CreateAsync(Seat seat);
        Task<List<Seat>> GetAllAsync();
        Task<Seat> GetByIdAsync(int id);
        Task<Seat> UpdateAsync(int id, Seat seat);
        Task<Seat> DeleteAsync(int id);
        Task<List<Seat>> GetSeatsByProjectionId(int id);

    }
}
