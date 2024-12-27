using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarRental.Models
{
    [Table("Car")]
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

        [Range(2, 7)]
        public int? Seats { get; set; }
        public string? FuelType { get; set; }
        public string? ImageUrl { get; set; }
    }
}
