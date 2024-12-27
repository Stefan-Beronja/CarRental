using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAllBooking();
        Booking GetBookingById(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int id);
        public decimal CalculateTotalPrice(DateTime startDate, DateTime endDate, decimal pricePerDay);

        public Booking GetBookingByCarId(int carId);
    }
}
