using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface IProjectionTypeRepository
    {
        Task<ProjectionType> CreateAsync(ProjectionType projectionType);
        Task<List<ProjectionType>> GetAllAsync();
        Task<ProjectionType> GetByIdAsync(int id);

    }
}
