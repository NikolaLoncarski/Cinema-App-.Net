﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieTheater.Data;

#nullable disable

namespace MovieTheater.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "1",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "2",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MovieTheater.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FileExtension = ".jpg",
                            FileName = "ForestGump",
                            FilePath = "http://localhost:5139/Images/ForestGump.jpg",
                            FileSizeInBytes = 98802L
                        },
                        new
                        {
                            Id = 2,
                            FileExtension = ".jpg",
                            FileName = "ShawShankRedemption",
                            FilePath = "http://localhost:5139/Images/ShawShankRedemption.jpg",
                            FileSizeInBytes = 104330L
                        },
                        new
                        {
                            Id = 3,
                            FileExtension = ".jpg",
                            FileName = "TheReturnOfTheKing",
                            FilePath = "http://localhost:5139/Images/TheReturnOfTheKing.jpg",
                            FileSizeInBytes = 572930L
                        });
                });

            modelBuilder.Entity("MovieTheater.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Distributer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("LeadActor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfRelease")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryOfOrigin = "USA",
                            Description = "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.",
                            Director = "Frank Darabont",
                            Distributer = "Universal Studios",
                            Duration = 164,
                            Genre = "Drama",
                            ImageId = 2,
                            LeadActor = "Morgan Freeman",
                            Name = "The Shawshank Redemption",
                            YearOfRelease = 1994
                        },
                        new
                        {
                            Id = 2,
                            CountryOfOrigin = "USA",
                            Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                            Director = "Peter Jackson",
                            Distributer = "WB Entertainment",
                            Duration = 201,
                            Genre = "Fantasy",
                            ImageId = 3,
                            LeadActor = "Ian McKellen",
                            Name = "The Lord of the Rings: The Return of the King",
                            YearOfRelease = 2003
                        },
                        new
                        {
                            Id = 3,
                            CountryOfOrigin = "USA",
                            Description = "The history of the United States from the 1950s to the '70s unfolds from the perspective of an Alabama man with an IQ of 75, who yearns to be reunited with his childhood sweetheart.",
                            Director = "Peter Jackson",
                            Distributer = "Universal Studios",
                            Duration = 146,
                            Genre = "Drama",
                            ImageId = 1,
                            LeadActor = "Tom Hanks",
                            Name = "Forest Gump",
                            YearOfRelease = 1994
                        });
                });

            modelBuilder.Entity("MovieTheater.Models.MovieTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAndTimeOfPurchase")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectionId")
                        .HasColumnType("int");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectionId");

                    b.HasIndex("SeatId");

                    b.ToTable("MovieTickets");
                });

            modelBuilder.Entity("MovieTheater.Models.Projection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAndTimeOfProjecton")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("ProjectionHallId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("ProjectionHallId");

                    b.HasIndex("ProjectionTypeId");

                    b.ToTable("Projections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateAndTimeOfProjecton = new DateTime(2024, 1, 11, 18, 26, 51, 179, DateTimeKind.Local).AddTicks(8939),
                            MovieId = 1,
                            Price = 6.63m,
                            ProjectionHallId = 1,
                            ProjectionTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            DateAndTimeOfProjecton = new DateTime(2024, 1, 13, 18, 26, 51, 179, DateTimeKind.Local).AddTicks(8994),
                            MovieId = 1,
                            Price = 7.53m,
                            ProjectionHallId = 2,
                            ProjectionTypeId = 2
                        },
                        new
                        {
                            Id = 3,
                            DateAndTimeOfProjecton = new DateTime(2024, 1, 9, 18, 26, 51, 179, DateTimeKind.Local).AddTicks(8997),
                            MovieId = 2,
                            Price = 3.53m,
                            ProjectionHallId = 2,
                            ProjectionTypeId = 3
                        },
                        new
                        {
                            Id = 4,
                            DateAndTimeOfProjecton = new DateTime(2024, 1, 12, 18, 26, 51, 179, DateTimeKind.Local).AddTicks(8999),
                            MovieId = 3,
                            Price = 13.53m,
                            ProjectionHallId = 1,
                            ProjectionTypeId = 2
                        },
                        new
                        {
                            Id = 5,
                            DateAndTimeOfProjecton = new DateTime(2024, 1, 15, 18, 26, 51, 179, DateTimeKind.Local).AddTicks(9002),
                            MovieId = 3,
                            Price = 3.53m,
                            ProjectionHallId = 2,
                            ProjectionTypeId = 3
                        });
                });

            modelBuilder.Entity("MovieTheater.Models.ProjectionHall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectionHalls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hall 14 XXL"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hall 1 Crystal"
                        });
                });

            modelBuilder.Entity("MovieTheater.Models.ProjectionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProjectionHallId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectionHallId");

                    b.ToTable("ProjectionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProjectionHallId = 1,
                            Type = "2D"
                        },
                        new
                        {
                            Id = 2,
                            ProjectionHallId = 1,
                            Type = "3D"
                        },
                        new
                        {
                            Id = 3,
                            ProjectionHallId = 2,
                            Type = "4D"
                        });
                });

            modelBuilder.Entity("MovieTheater.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MovieTheater.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProjectionHallId")
                        .HasColumnType("int");

                    b.Property<bool>("Reserved")
                        .HasColumnType("bit");

                    b.Property<string>("SeatLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectionHallId");

                    b.ToTable("Seats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProjectionHallId = 1,
                            Reserved = false,
                            SeatLocation = "A1"
                        },
                        new
                        {
                            Id = 2,
                            ProjectionHallId = 1,
                            Reserved = false,
                            SeatLocation = "B13"
                        },
                        new
                        {
                            Id = 3,
                            ProjectionHallId = 1,
                            Reserved = false,
                            SeatLocation = "D7"
                        },
                        new
                        {
                            Id = 4,
                            ProjectionHallId = 1,
                            Reserved = false,
                            SeatLocation = "F17"
                        },
                        new
                        {
                            Id = 5,
                            ProjectionHallId = 1,
                            Reserved = false,
                            SeatLocation = "O8"
                        },
                        new
                        {
                            Id = 6,
                            ProjectionHallId = 2,
                            Reserved = false,
                            SeatLocation = "A7"
                        },
                        new
                        {
                            Id = 7,
                            ProjectionHallId = 2,
                            Reserved = false,
                            SeatLocation = "B4"
                        },
                        new
                        {
                            Id = 8,
                            ProjectionHallId = 2,
                            Reserved = false,
                            SeatLocation = "I5"
                        },
                        new
                        {
                            Id = 9,
                            ProjectionHallId = 1,
                            Reserved = false,
                            SeatLocation = "K18"
                        },
                        new
                        {
                            Id = 10,
                            ProjectionHallId = 2,
                            Reserved = false,
                            SeatLocation = "M3"
                        });
                });

            modelBuilder.Entity("MovieTheater.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MovieTheater.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieTheater.Models.Movie", b =>
                {
                    b.HasOne("MovieTheater.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("MovieTheater.Models.MovieTicket", b =>
                {
                    b.HasOne("MovieTheater.Models.Projection", "Projection")
                        .WithMany()
                        .HasForeignKey("ProjectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieTheater.Models.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projection");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("MovieTheater.Models.Projection", b =>
                {
                    b.HasOne("MovieTheater.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MovieTheater.Models.ProjectionHall", "ProjectionHall")
                        .WithMany()
                        .HasForeignKey("ProjectionHallId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MovieTheater.Models.ProjectionType", "ProjectionType")
                        .WithMany()
                        .HasForeignKey("ProjectionTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("ProjectionHall");

                    b.Navigation("ProjectionType");
                });

            modelBuilder.Entity("MovieTheater.Models.ProjectionType", b =>
                {
                    b.HasOne("MovieTheater.Models.ProjectionHall", "ProjectionHall")
                        .WithMany("ProjectionTypes")
                        .HasForeignKey("ProjectionHallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectionHall");
                });

            modelBuilder.Entity("MovieTheater.Models.Seat", b =>
                {
                    b.HasOne("MovieTheater.Models.ProjectionHall", "ProjectionHall")
                        .WithMany()
                        .HasForeignKey("ProjectionHallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectionHall");
                });

            modelBuilder.Entity("MovieTheater.Models.UserRole", b =>
                {
                    b.HasOne("MovieTheater.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieTheater.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieTheater.Models.ProjectionHall", b =>
                {
                    b.Navigation("ProjectionTypes");
                });

            modelBuilder.Entity("MovieTheater.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("MovieTheater.Models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
