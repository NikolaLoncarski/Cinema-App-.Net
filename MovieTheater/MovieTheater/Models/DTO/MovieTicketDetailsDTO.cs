using System.Text.Json.Serialization;

namespace MovieTheater.Models.DTO
{
    public class MovieTicketDetailsDTO
    {
        public int Id { get; set; }
       
        public int ProjectionId { get; set; }
        [JsonPropertyName("movie_id")]
        public int ProjectionMovieId { get; set; }

        [JsonPropertyName("movie_name")]
        public string ProjectionMovieName { get; set; }

        [JsonPropertyName("duration")]
        public int ProjectionMovieDuration { get; set; }

        [JsonPropertyName("image_id")]
        public int ProjectionMovieImageId { get; set; }
        [JsonPropertyName("image_Name")]
        public string ProjectionMovieImageFileName { get; set; }
        [JsonPropertyName("image_Src")]
        public string ProjectionMovieImageFilePath { get; set; }
        [JsonPropertyName("projectionType_id")]
        public int ProjectionProjectionTypeId { get; set; }
        [JsonPropertyName("projection_Type")]
        public string ProjectionProjectionTypeType { get; set; }
        [JsonPropertyName("projectionHall_id")]
        public int ProjectionProjectionHallId { get; set; }
        [JsonPropertyName("projectionHall_Name")]
        public string ProjectionProjectionHallName { get; set; }
        [JsonPropertyName("starts")]
        public string ProjectionDateAndTimeOfProjecton { get; set; }

        [JsonPropertyName("price")]
        public decimal ProjectionPrice { get; set; }
        [JsonPropertyName("seat_Id")]
        public Guid SeatId { get; set; }
        [JsonPropertyName("seat_Location")]
        public string SeatLocation { get; set; }
        [JsonPropertyName("Reserved")]
        public bool SeatReserved { get; set; }
        [JsonPropertyName("Purchase_Date")]
        public DateTime DateAndTimeOfPurchase { get; set; }

    }
}
