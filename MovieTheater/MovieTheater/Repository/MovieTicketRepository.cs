using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;

namespace MovieTheater.Repository
{
    public class MovieTicketRepository : IMovieTicketRepository
    {
        private readonly AppDbContext dbContext;

        public MovieTicketRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }




        public async Task<MovieTicket> CreateAsync(MovieTicket movieTicket)
        {
            await dbContext.MovieTickets.AddAsync(movieTicket);
            await dbContext.SaveChangesAsync();
            return movieTicket;
        }

        public async Task<MovieTicket?> DeleteAsync(int id)
        {
            var existingTicket = await dbContext.MovieTickets.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTicket == null)
            {
                return null;
            }

            dbContext.MovieTickets.Remove(existingTicket);
            await dbContext.SaveChangesAsync();
            return existingTicket;
        }

        public async Task<List<MovieTicket>> GetAllAsync()
        {
            var movieTicket = dbContext.MovieTickets
                .Include(i => i.Projection).ThenInclude(p => p.ProjectionHall)
                .Include(i => i.Projection).ThenInclude(p => p.ProjectionType)
                .Include(i => i.Projection).ThenInclude(p => p.Movie).ThenInclude(p => p.Image)
                .Include(s => s.Seat).AsQueryable();




            return await movieTicket.ToListAsync();
        }

        public async Task<MovieTicket?> GetByIdAsync(int id)
        {
            return await dbContext.MovieTickets
                .Include(i => i.Projection).ThenInclude(p => p.ProjectionHall)
                .Include(i => i.Projection).ThenInclude(p => p.ProjectionType)
                .Include(i => i.Projection).ThenInclude(p => p.Movie).ThenInclude(p => p.Image)

                .Include(s => s.Seat).FirstOrDefaultAsync(x => x.Id == id);

        }



        public async Task<List<MovieTicket>> GetTicketByUserId(Guid userId)
        {
            return await dbContext.MovieTickets.Where(u => u.UserId == userId)
                    .Include(i => i.Projection).ThenInclude(p => p.ProjectionHall)
                    .Include(i => i.Projection).ThenInclude(p => p.ProjectionType)
                    .Include(i => i.Projection).ThenInclude(p => p.Movie).ThenInclude(p => p.Image)

                    .Include(s => s.Seat).AsQueryable().ToListAsync();
        }

        public async Task<MovieTicket?> UpdateAsync(int id, MovieTicket movieTicket)
        {
            throw new NotImplementedException();
        }
    }
}
