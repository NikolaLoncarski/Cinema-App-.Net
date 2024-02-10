using System.Text.Json.Serialization;

namespace MovieTheater.Models.DTO
{
    public class SeatDetailsDTO
    {
        public Guid Id { get; set; }


        public bool Reserved { get; set; }

        public int Location { get; set; }
        public int ProjectionId { get; set; }
        [JsonPropertyName("MovieId")]
        public int ProjectionMovieId { get; set; }
        [JsonPropertyName("MovieName")]
        public string ProjectionMovieName { get; set; }
        [JsonPropertyName("Duration")]
        public int ProjectionMovieDuration { get; set; }

        public int ProjectionProjectionTypeId { get; set; }
        [JsonPropertyName("ProjectionType")]
        public string ProjectionProjectionTypeType { get; set; }
        [JsonPropertyName("ProjectionHallId")]
        public int ProjectionProjectionHallId { get; set; }
        [JsonPropertyName("ProjectionHall")]
        public string ProjectionProjectionHallName { get; set; }

        public int ProjectionHallCapacity { get; set; }

        [JsonPropertyName("DateAndTimeOfProjecton")]
        public DateTime ProjectionDateAndTimeOfProjecton { get; set; }
        [JsonPropertyName("Price")]
        public decimal ProjectionPrice { get; set; }

    }
}
