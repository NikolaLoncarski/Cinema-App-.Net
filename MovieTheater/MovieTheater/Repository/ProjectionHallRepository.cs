using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;

using MovieTheater.Models.DTO;
using System;

namespace MovieTheater.Repository
{
    public class ProjectionHallRepository : IProjectionHallRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper _mapper;

        public ProjectionHallRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ProjectionHall>> GetAllAsync()
        {
            return await dbContext.ProjectionHalls.Include(p=>p.ProjectionTypes).ToListAsync();
        }
    }
    
}
