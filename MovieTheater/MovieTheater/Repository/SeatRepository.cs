using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;

namespace MovieTheater.Repository
{
    public class SeatRepository : ISeatRepository
    {
        private readonly AppDbContext dbContext;

        public SeatRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Seat> CreateAsync(Seat seat)
        {
            await dbContext.Seats.AddAsync(seat);
            await dbContext.SaveChangesAsync();
            return seat;
        }

        public async Task<Seat> DeleteAsync(int id)
        {
            var seat = await dbContext.Seats.FirstOrDefaultAsync(x => x.Id == id);

            if (seat== null)
            {
                return null;
            }

            dbContext.Seats.Remove(seat);
            await dbContext.SaveChangesAsync();
            return seat;
        }

        public async Task<List<Seat>> GetAllAsync()
        {
            return await dbContext.Seats.Include(s => s.AvailableSeats)
                .Include(s => s.Projection).ThenInclude(m=>m.Movie)
                .Include(p=>p.Projection).ThenInclude(ph=>ph.ProjectionHall)
                .Include(p => p.Projection).ThenInclude(pt => pt.ProjectionType)
                .OrderBy(p => p.Id).ToListAsync();
        }

      

        public async Task<Seat> GetByIdAsync(int id)
        {
            return await dbContext.Seats.Include(s => s.AvailableSeats)
                .Include(s => s.Projection).ThenInclude(m => m.Movie)
                .Include(p => p.Projection).ThenInclude(ph => ph.ProjectionHall)
                 .Include(p => p.Projection).ThenInclude(pt => pt.ProjectionType)
                .OrderBy(p => p.Id)

                   .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Seat> UpdateAsync(int id, Seat seat)
        {
            var seats = await dbContext.Seats.FirstOrDefaultAsync(x => x.Id == id);

            if (seats == null)
            {
                return null;
            }


        

            await dbContext.SaveChangesAsync();

            return seat;
        }
    }
}
