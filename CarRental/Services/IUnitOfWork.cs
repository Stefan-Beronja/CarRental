namespace CarRental.Services
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        ICarService CarService { get; }
        IBookingService BookingService { get; }
    }
}
