using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models.DTO
{
    public class ProjectionDetailsDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
  
        public string MovieName { get; set; }
        public string? MovieDirector { get; set; }
        public string? MovieLeadActor { get; set; }
        public string? MovieGenre { get; set; }
    
        public int MovieDuration { get; set; }
        public string MovieDistributer { get; set; }
        public string MovieCountryOfOrigin { get; set; }
        public int MovieYearOfRelease { get; set; }
        public string? MovieDescription { get; set; }
        public int MovieImageId { get; set; }
     
        public string MovieImageFileName { get; set; }
        public string MovieImageFilePath { get; set; }
        public int ProjectionTypeId { get; set; }
        public string ProjectionTypeType { get; set; }
        public int ProjectionHallId { get; set; }
        public string ProjectionHallName { get; set; }
        public DateTime DateAndTimeOfProjecton { get; set; }
        public decimal Price { get; set; }
    }
}
