using MovieTheater.Models;


namespace MovieTheater.Interfaces
{
    public interface ISeatPositionRepository
    {
        Task<List<AvailableSeats>> GetAllAsync();
 
    }
}
