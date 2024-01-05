using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieTheater.Repository
{
    public class ProjectionTypeRepository : IProjectionTypeRepository

    {
        private readonly AppDbContext dbContext;

        public ProjectionTypeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ProjectionType> CreateAsync(ProjectionType projectionType)
        {
            await dbContext.ProjectionTypes.AddAsync(projectionType);
            await dbContext.SaveChangesAsync();
            return projectionType;
        }

  

        public async Task<List<ProjectionType>> GetAllAsync()
        {
            return await dbContext.ProjectionTypes.Include(p=>p.ProjectionHall).OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<ProjectionType> GetByIdAsync(int id)
        {
            return await dbContext.ProjectionTypes.FirstOrDefaultAsync(x => x.Id==id);
        }

    
    }
}
