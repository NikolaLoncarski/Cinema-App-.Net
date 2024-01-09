using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;

namespace MovieTheater.Repository
{
    public class SeatPositionRepository : ISeatPositionRepository
    {
        private readonly AppDbContext dbContext;

        public SeatPositionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<AvailableSeats>> GetAllAsync()
        {
            return await dbContext.AvailableSeats.OrderBy(p => p.Id).ToListAsync();
        }
    }
}
