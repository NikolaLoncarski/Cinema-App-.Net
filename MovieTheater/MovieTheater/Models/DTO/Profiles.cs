using AutoMapper;
using MovieTheater.Models.DTO.RequestDTOs;

namespace MovieTheater.Models.DTO
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<ProjectionType, ProjectionTypeDTO>();
            CreateMap<Seat, SeatDetailsDTO>();
            CreateMap<Movie, MovieDetailsDTO>();
            CreateMap<Projection, ProjectionDetailsDTO>();
            CreateMap<MovieTicket, MovieTicketDetailsDTO>();
            CreateMap<MovieTicketRequestDTO, MovieTicket>().ReverseMap();
            CreateMap<CreateMovieDTO, Movie>().ReverseMap();
            CreateMap<CreateProjectionDTO, Projection>().ReverseMap();
            CreateMap<CreateProjectionTypeDTO, ProjectionType>().ReverseMap();
        }
    }
}
