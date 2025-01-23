using CarRental.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CarRental.Models
{
    [Table("Booking")]
    public class Booking
    {
        [Required]
        public int BookingId { get; set; }

        [Required]
        public int CarId { get; set; }

        
        public string? UserId { get; set; }

        [Required]
        public Car? Car { get; set; }

        //public string Make { get; set; }

        //public string Model { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateGreaterThan(nameof(StartDate), ErrorMessage = "End date must be after the sart date")]
        public DateTime EndDate { get; set; }
        
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Total price must be greater than 0.")]
        public decimal TotalPrice { get; set; }
    }
}
