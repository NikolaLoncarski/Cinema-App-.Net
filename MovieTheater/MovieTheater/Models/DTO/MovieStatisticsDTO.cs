namespace MovieTheater.Models.DTO
{
    public class MovieStatisticsDTO
    {
       
        public decimal AverageTicketPrice { get; set; }

        public int NumberOfTicketsSold { get; set; }
        public decimal Income {  get; set; }    
        public double PercentageOfSeatsOcupied { get; set; }

    }
}
