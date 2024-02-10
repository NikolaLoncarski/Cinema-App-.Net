using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Models.DTO;

namespace MovieTheater.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper _mapper;

        public MovieRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Movie> CreateAsync(Movie movie)
        {
            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> DeleteAsync(int id)
        {
            var existingMovie = await dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (existingMovie == null)
            {
                return null;
            }

            dbContext.Movies.Remove(existingMovie);
            await dbContext.SaveChangesAsync();
            return existingMovie;
        }

        public async Task<List<Movie>> GetAllAsync(string? name = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 10)
        {
            var movies = dbContext.Movies.Include(i => i.Image).AsQueryable();


            if (string.IsNullOrWhiteSpace(name) == false)
            {


                movies = movies.Where(x => x.Name.Contains(name));

            }


            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    movies = isAscending ? movies.OrderBy(x => x.Name) : movies.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Duration", StringComparison.OrdinalIgnoreCase))
                {
                    movies = isAscending ? movies.OrderBy(x => x.Duration) : movies.OrderByDescending(x => x.Duration);
                }
                else if (sortBy.Equals("YearOfRelease", StringComparison.OrdinalIgnoreCase))
                {
                    movies = isAscending ? movies.OrderBy(x => x.YearOfRelease) : movies.OrderByDescending(x => x.YearOfRelease);
                }

            }


            var skipResults = (pageNumber - 1) * pageSize;

            return await movies.Skip(skipResults).Take(pageSize).ToListAsync();

        }

        public async Task<List<MovieStatisticsDTO>> GetAllStatisticsAsync(string? name = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 10)



        {

            var stats = dbContext.Movies
                .Select(s =>
                    new MovieStatisticsDTO
                    {
                        MovieId = s.Id,
                        MovieName = s.Name,
                        TotalNumberOfSeats = dbContext.Seats.Where(m => m.Projection.MovieId == s.Id && m.Reserved == false).Count(),
                        NumberOfTicketsSold = dbContext.Seats.Where(m => m.Projection.MovieId == s.Id && m.Reserved).Count(),

                        PercentageOfSeatsOcupied = Math.Round(dbContext.Seats
                       .Where(m => m.Projection.MovieId == s.Id && m.Reserved == false)
                       .Count() > 0
                       ? 100 / (double)dbContext.Seats
                       .Where(m => m.Projection.MovieId == s.Id && m.Reserved == false)
                       .Count() * dbContext.Seats
                       .Where(m => m.Projection.MovieId == s.Id && m.Reserved)
                       .Count()
                        : 0, 2),

                        NumberOfProjections = dbContext.Projections.Where(p => p.MovieId == s.Id).Count(),
                        AverageTicketPrice = Math.Round(dbContext.Projections.Where(pr => pr.MovieId == s.Id).Select(price => price.Price).Average() > 0 ?
                       dbContext.Projections.Where(pr => pr.MovieId == s.Id).Select(price => price.Price).Average() : 0, 2),
                        TotalEarned = dbContext.Projections.Where(pr => pr.MovieId == s.Id).Select(price => price.Price).Sum()
                    }
                ).AsQueryable();


            if (string.IsNullOrWhiteSpace(name) == false)
            {


                stats = stats.Where(x => x.MovieName.Contains(name));
            }


            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    stats = isAscending ? stats.OrderBy(x => x.MovieName) : stats.OrderByDescending(x => x.MovieName);
                }
                else if (sortBy.Equals("TotalEarned", StringComparison.OrdinalIgnoreCase))
                {
                    stats = isAscending ? stats.OrderBy(x => x.TotalEarned) : stats.OrderByDescending(x => x.TotalEarned);
                }
                else if (sortBy.Equals("NumberOdProjections", StringComparison.OrdinalIgnoreCase))
                {
                    stats = isAscending ? stats.OrderBy(x => x.NumberOfProjections) : stats.OrderByDescending(x => x.NumberOfProjections);
                }

            }


            var skipResults = (pageNumber - 1) * pageSize;

            return await stats.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);



        }

        public async Task<int> OcupiedSeatsById(int id)
        {
            return await dbContext.Seats.CountAsync(m => m.Projection.MovieId == id && m.Reserved == false);
        }

        public async Task<Movie?> UpdateAsync(int id, Movie movie)
        {
            var existingMovie = await dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (existingMovie == null)
            {
                return null;
            }


            existingMovie.Name = movie.Name;
            existingMovie.Director = movie.Director;
            existingMovie.LeadActor = movie.LeadActor;
            existingMovie.Genre = movie.Genre;
            existingMovie.Duration = movie.Duration;
            existingMovie.Distributer = movie.Distributer;
            existingMovie.CountryOfOrigin = movie.CountryOfOrigin;
            existingMovie.YearOfRelease = movie.YearOfRelease;
            existingMovie.Description = movie.Description;
            existingMovie.ImageId = movie.ImageId;

            await dbContext.SaveChangesAsync();

            return existingMovie;
        }
    }
}
