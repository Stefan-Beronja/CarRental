using CarRental.Models;

namespace CarRental.Services
{
    public class BookingService : IBookingService
    {
        private readonly CarRentalContext _context;

        public BookingService(CarRentalContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAllBooking()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetBookingById(int id)
        {
            return _context.Bookings.Find(id);
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
        }
        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
        }

        public void DeleteBooking(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
        }

        public decimal CalculateTotalPrice(DateTime startDate, DateTime endDate, decimal pricePerDay)
        {
            var rentalDays = (endDate - startDate).Days;
            var totalPrice = pricePerDay * rentalDays;
            
            return totalPrice;
        }

        public Booking GetBookingByCarId(int carId)
        {
            return _context.Bookings.FirstOrDefault(b => b.CarId == carId);
        }
    }
}
