using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using System.Globalization;

namespace MovieTheater.Repository
{
    public class ProjectionRepository : IProjectionRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper _mapper;

        public ProjectionRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Projection> CreateAsync(Projection projection)
        {
            await dbContext.Projections.AddAsync(projection);
            await dbContext.SaveChangesAsync();
            return projection;
        }

        public async Task<Projection?> DeleteAsync(int id)
        {
            var existingProjection = await dbContext.Projections.FirstOrDefaultAsync(x => x.Id == id);

            if (existingProjection == null)
            {
                return null;
            }

            dbContext.Projections.Remove(existingProjection);
            await dbContext.SaveChangesAsync();
            return existingProjection;
        }

        public async Task<List<Projection>> GetAllAsync()
        {
            var projections = dbContext.Projections.Include(i => i.Movie).ThenInclude(i=>i.Image).Include(p=>p.ProjectionHall).Include(p=>p.ProjectionType).AsQueryable();


       

            return await projections.ToListAsync();
        }

        public async Task<Projection?> GetByIdAsync(int id)
        {
            return await dbContext.Projections.Include(i => i.Movie).ThenInclude(i => i.Image).Include(p => p.ProjectionHall).Include(p => p.ProjectionType).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Projection?> UpdateAsync(int id, Projection projection)
        {
            throw new NotImplementedException();
        }
    }
}
