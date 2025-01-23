namespace CarRental.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
