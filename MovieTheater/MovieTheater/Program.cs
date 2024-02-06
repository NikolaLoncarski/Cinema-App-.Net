using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using MovieTheater.Data;
using MovieTheater.Interfaces;

using MovieTheater.Models;
using MovieTheater.Models.DTO;
using MovieTheater.Repository;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .MinimumLevel.Error()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnectionString"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                ;
        });
});
builder.Services.AddAutoMapper(typeof(Profiles));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IProjectionTypeRepository, ProjectionTypeRepository>();
builder.Services.AddScoped<IProjectionHallRepository, ProjectionHallRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<IImageRepository, LocalImageRepository>();
builder.Services.AddScoped<IMovieTicketRepository,MovieTicketRepository>();
builder.Services.AddScoped<IProjectionRepository, ProjectionRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();

builder.Services.AddScoped<ITokenRepository, TokenRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit= false;
    options.Password.RequireLowercase= false;
    options.Password.RequireUppercase= false;
    options.Password.RequireNonAlphanumeric= false;
    options.Password.RequiredLength= 6;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidAudience = builder.Configuration["JWTKey:ValidAudience"],
                   ValidIssuer = builder.Configuration["JWTKey:ValidIssuer"],
                   ClockSkew = TimeSpan.Zero,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTKey:Secret"]))
               };
           });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");
//app.UseSaveFilePathMiddleware();
app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
