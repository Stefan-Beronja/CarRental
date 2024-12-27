using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental
{
    public class CarRentalContext : DbContext
    {
        public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });    

        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviwes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
