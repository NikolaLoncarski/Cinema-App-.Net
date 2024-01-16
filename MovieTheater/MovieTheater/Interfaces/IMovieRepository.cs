using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface IMovieRepository
    {
        Task<Movie> CreateAsync(Movie movie);
        Task<List<Movie>> GetAllAsync(string? name = null, 
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);
        Task<Movie?> GetByIdAsync( int id);
        Task<Movie?> UpdateAsync( int id, Movie movie);
        Task<Movie?> DeleteAsync(int id);
    }
}
