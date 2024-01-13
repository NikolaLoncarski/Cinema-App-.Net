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

        public async Task<Seat> CheckIfSeatIsReserved(Guid seatId)
        {
            var seat = await dbContext.Seats.Where(s => s.Reserved == false).FirstOrDefaultAsync(x => x.Id == seatId);
            seat.Reserved = true;

            return seat;
        }

        public async Task<Seat> CreateAsync(Seat seat)
        {
            await dbContext.Seats.AddAsync(seat);
            await dbContext.SaveChangesAsync();
            return seat;
        }

        public async Task<List<Seat>> CreateSeatByProjectionCapacity(int hallId)
        {
          var projection = await dbContext.Projections.Include(i => i.Movie).ThenInclude(i => i.Image).Include(p => p.ProjectionHall).Include(p => p.ProjectionType).FirstOrDefaultAsync(x => x.Id == hallId);

            int hallCapacity = projection.ProjectionHall.Capacity;



            for (var i = 0; i <hallCapacity;i++)
            {
            Seat seat = new Seat(  );
                seat.Id = Guid.NewGuid();
                seat.Reserved = false;
                seat.ProjectionId = projection.Id;
                seat.Location = i;
            await dbContext.Seats.AddAsync(seat);
            await dbContext.SaveChangesAsync();

            }

            return await dbContext.Seats
               .Include(s => s.Projection).ThenInclude(m => m.Movie)
               .Include(p => p.Projection).ThenInclude(ph => ph.ProjectionHall)
               .Include(p => p.Projection).ThenInclude(pt => pt.ProjectionType)
               .OrderBy(p => p.Id).ToListAsync();

        }

        public async Task<Seat> DeleteAsync(Guid id)
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
            return await dbContext.Seats
                .Include(s => s.Projection).ThenInclude(m=>m.Movie)
                .Include(p=>p.Projection).ThenInclude(ph=>ph.ProjectionHall)
                .Include(p => p.Projection).ThenInclude(pt => pt.ProjectionType)
                .OrderBy(p => p.Id).ToListAsync();
        }

      

        public async Task<Seat> GetByIdAsync(Guid id)
        {
            return await dbContext.Seats
                .Include(s => s.Projection).ThenInclude(m => m.Movie)
                .Include(p => p.Projection).ThenInclude(ph => ph.ProjectionHall)
                 .Include(p => p.Projection).ThenInclude(pt => pt.ProjectionType)
                .OrderBy(p => p.Location).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Seat>> GetSeatsByProjectionId(int id)
        {
            return await dbContext.Seats.Where(p => p.ProjectionId == id)
              .Include(s => s.Projection).ThenInclude(m => m.Movie)
              .Include(p => p.Projection).ThenInclude(ph => ph.ProjectionHall)
               .Include(p => p.Projection).ThenInclude(pt => pt.ProjectionType)
              .OrderBy(p => p.Location).ToListAsync();

               
        }

        public async Task<Seat> UpdateAsync(Guid id, Seat seat)
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
