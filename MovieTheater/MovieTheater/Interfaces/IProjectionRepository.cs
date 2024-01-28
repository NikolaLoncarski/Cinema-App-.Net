using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface IProjectionRepository
    {
        Task<Projection> CreateAsync(Projection projection);
        Task<List<Projection>> GetAllAsync();
        Task<Projection?> GetByIdAsync(int id);
        Task<Projection?> UpdateAsync(int id, Projection projection);
        Task<Projection?> DeleteAsync(int id);
        Task<List<Projection?>> GetByMovieIdAsync(int id);

        Task<Projection?> CheckProjectionForDateAndHall(int projectionHallId, DateTime dateTime);
    }
}
