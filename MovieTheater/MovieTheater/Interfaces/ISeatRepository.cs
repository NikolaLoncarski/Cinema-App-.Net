using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface ISeatRepository
    {
        Task<Seat> CreateAsync(Seat seat);
        Task<List<Seat>> GetAllAsync();
        Task<Seat> GetByIdAsync(Guid id);
        Task<Seat> UpdateAsync(Guid id, Seat seat);
        Task<Seat> DeleteAsync(Guid id);
        Task<List<Seat>> GetSeatsByProjectionId(int id);
        Task<List<Seat>> CreateSeatByProjectionCapacity(int hallId);

        Task<Seat> CheckIfSeatIsReserved(Guid seatId, bool action);
        Task<Seat> ClearSeatReservation(Guid seatId, bool action);

    }
}
