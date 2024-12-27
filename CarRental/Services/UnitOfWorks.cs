namespace CarRental.Services
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly CarRentalContext _context;

        public UnitOfWorks(CarRentalContext context)
        {
            _context = context;
            CarService = new CarService(context);
            BookingService = new BookingService(context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();   
        }
        public ICarService CarService { get; private set; }

        public IBookingService BookingService { get; private set; }
    }
}
