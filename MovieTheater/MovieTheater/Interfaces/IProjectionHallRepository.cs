using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface IProjectionHallRepository
    {
        Task<List<ProjectionHall>> GetAllAsync();
    }
}
