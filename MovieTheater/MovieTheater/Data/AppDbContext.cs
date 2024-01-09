using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MovieTheater.Models;
using System.Reflection.Metadata;
using static MovieTheater.Models.AvailableSeats;

namespace MovieTheater.Data
{
    public class AppDbContext:IdentityDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<ProjectionType> ProjectionTypes { get; set; }
        public DbSet<ProjectionHall> ProjectionHalls { get; set; }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<AvailableSeats> AvailableSeats { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Image> Images { get; set; }

         public DbSet<MovieTicket> MovieTickets { get; set; }


        public DbSet<User> Users { get; set; }
          public DbSet<Role> Roles { get; set; }
          public DbSet<UserRole> UsersRoles { get; set; }
          public DbSet<Projection>Projections { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

      



            var userRoleId = "1";
            var adminRoleId = "2";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=userRoleId,
                    ConcurrencyStamp=userRoleId,
                    Name="User",
                    NormalizedName="User".ToUpper()
                },
                     new IdentityRole
                {
                    Id=adminRoleId,
                    ConcurrencyStamp=adminRoleId,
                    Name="Admin",
                    NormalizedName="Admin".ToUpper()
                }

            };


            modelBuilder.Entity<IdentityRole>().HasData(roles);

       

            modelBuilder.Entity<UserRole>()
                  .HasOne(x => x.Role)
                  .WithMany(y => y.UserRoles)
                  .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ProjectionHall>()
                  .HasMany(e => e.ProjectionTypes)
                  .WithOne(e => e.ProjectionHall)
                  .HasForeignKey(e => e.ProjectionHallId)
                  .IsRequired();


            modelBuilder.Entity<Projection>()
                 .HasOne(p => p.Movie)
                 .WithMany()
                 .HasForeignKey(p => p.MovieId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Projection>()
                .HasOne(p => p.ProjectionType)
                .WithMany()
                .HasForeignKey(p => p.ProjectionTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Projection>()
                .HasOne(p => p.ProjectionHall)
                .WithMany()
                .HasForeignKey(p => p.ProjectionHallId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Seat>()
             .HasOne(p => p.AvailableSeats)
              .WithMany()
             .HasForeignKey(p => p.AvailableSeatsId)
             .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<Seat>()
             .HasOne(p => p.Projection)
             .WithMany()
             .HasForeignKey(p => p.ProjectionId)
             .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ProjectionHall>().HasData(
                new ProjectionHall() { Id = 1, Name = "Hall 14 XXL", },
                new ProjectionHall() { Id = 2, Name = "Hall 1 Crystal" }

            );
            modelBuilder.Entity<ProjectionType>().HasData(
            new ProjectionType() { Id = 1, Type = "2D", ProjectionHallId = 1 },
            new ProjectionType() { Id = 2, Type = "3D", ProjectionHallId = 1 },
            new ProjectionType() { Id = 3, Type = "4D", ProjectionHallId = 2 }
            );




            modelBuilder.Entity<Image>().HasData(
            new Image
            {
                Id = 1,
                FileName = "ForestGump",
                FileExtension = ".jpg",
                FileSizeInBytes = 98802,
                FilePath = "http://localhost:5139/Images/ForestGump.jpg"
            },
              new Image
              {
                  Id = 2,
                  FileName = "ShawShankRedemption",
                  FileExtension = ".jpg",
                  FileSizeInBytes = 104330,
                  FilePath = "http://localhost:5139/Images/ShawShankRedemption.jpg"
              },
                new Image
                {
                    Id = 3,
                    FileName = "TheReturnOfTheKing",
                    FileExtension = ".jpg",
                    FileSizeInBytes = 572930,
                    FilePath = "http://localhost:5139/Images/TheReturnOfTheKing.jpg"
                }

             
  
           );

            var seatPositions = Enum.GetNames(typeof(SeatPosition));
            int id = 1;
            foreach (var position in seatPositions)
            {
                modelBuilder.Entity<AvailableSeats>().HasData(
                   new AvailableSeats { Id = id++, Seat = position}
                );
            }

      
           



      



            
            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = 1,
                    Name = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    LeadActor = "Morgan Freeman",
                    Genre = "Drama",
                    Duration = 164,
                    Distributer = "Universal Studios",
                    CountryOfOrigin = "USA",
                    YearOfRelease = 1994,
                    Description = "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.",
                    ImageId=2
             
             
                },
                  new Movie()
                  {
                      Id = 2,
                      Name = "The Lord of the Rings: The Return of the King",
                      Director = "Peter Jackson",
                      LeadActor = "Ian McKellen",
                      Genre = "Fantasy",
                      Duration = 201,
                      Distributer = "WB Entertainment",
                      CountryOfOrigin = "USA",
                      YearOfRelease = 2003,
                      Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                      ImageId=3
                

                  },
                      new Movie()
                      {
                          Id = 3,
                          Name = "Forest Gump",
                          Director = "Peter Jackson",
                          LeadActor = "Tom Hanks",
                          Genre = "Drama",
                          Duration = 146,
                          Distributer = "Universal Studios",
                          CountryOfOrigin = "USA",
                          YearOfRelease = 1994,
                          Description = "The history of the United States from the 1950s to the '70s unfolds from the perspective of an Alabama man with an IQ of 75, who yearns to be reunited with his childhood sweetheart.",
                          ImageId=1

                 

                      }


                );

            modelBuilder.Entity<Projection>().HasData(
        new Projection()
        {
            Id = 1,
            MovieId = 1,
            ProjectionTypeId = 1,
            ProjectionHallId = 1,
            DateAndTimeOfProjecton = DateTime.Now.AddDays(3),
            Price = 6.63M


        },
                new Projection()
                {
                    Id = 2,
                    MovieId = 1,
                    ProjectionTypeId = 2,
                    ProjectionHallId = 2,
                    DateAndTimeOfProjecton = DateTime.Now.AddDays(5),
                    Price = 7.53M


                },
                new Projection()
                {
                    Id = 3,
                    MovieId = 2,
                    ProjectionTypeId = 3,
                    ProjectionHallId = 2,
                    DateAndTimeOfProjecton = DateTime.Now.AddDays(1),
                    Price = 3.53M


                },
                new Projection()
                {
                    Id = 4,
                    MovieId = 3,
                    ProjectionTypeId = 2,
                    ProjectionHallId = 1,
                    DateAndTimeOfProjecton = DateTime.Now.AddDays(4),
                    Price = 13.53M


                },
                new Projection()
                {
                    Id = 5,
                    MovieId = 3,
                    ProjectionTypeId = 3,
                    ProjectionHallId = 2,
                    DateAndTimeOfProjecton = DateTime.Now.AddDays(7),
                    Price = 3.53M


                }




        );



            modelBuilder.Entity<Seat>().HasData(
                new Seat() { Id = 1, Reserved = true, AvailableSeatsId = 1, ProjectionId = 1 },
                new Seat() { Id = 2, Reserved = true, AvailableSeatsId = 2, ProjectionId = 1 },
                new Seat() { Id = 3, Reserved = false, AvailableSeatsId = 3, ProjectionId = 1 },
                new Seat() { Id = 4, Reserved = false, AvailableSeatsId = 4, ProjectionId = 1 },
                new Seat() { Id = 5, Reserved = false, AvailableSeatsId = 5, ProjectionId = 1 },
                new Seat() { Id = 6, Reserved = true, AvailableSeatsId = 6, ProjectionId = 1 },
                new Seat() { Id = 7, Reserved = true, AvailableSeatsId = 7, ProjectionId = 1 },
                new Seat() { Id = 8, Reserved = true, AvailableSeatsId = 8, ProjectionId = 1 },
                new Seat() { Id = 9, Reserved = false, AvailableSeatsId = 9, ProjectionId = 1 },
                new Seat() { Id = 10, Reserved = false, AvailableSeatsId = 10, ProjectionId = 1 }
                );


            modelBuilder.Entity<Projection>().Property(o => o.Price).HasPrecision(18, 4);

          
         
    base.OnModelCreating(modelBuilder);
        }
    }
}
