namespace MovieTheater.Models.DTO
{
    public class MovieStatisticsDTO
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public decimal TotalEarned { get; set; }
        public int NumberOfProjections { get; set; }

        public int NumberOfTicketsSold { get; set; }

        public int TotalNumberOfSeats { get; set; }
        public decimal AverageTicketPrice { get; set; }

        public double PercentageOfSeatsOcupied { get; set; }

    }
}
