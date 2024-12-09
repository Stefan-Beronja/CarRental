using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarRental.Models
{
    public class Car
    {
        [Required]
        public int CarId { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public decimal PricePerDay { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public int Year { get; set; }
        public int Seats { get; set; }
        public string FuelType { get; set; }
        public string ImageUrl { get; set; }
    }
}
