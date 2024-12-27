using CarRental.Models;

namespace CarRental.Services
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetFilteredCars(string make, string model, decimal? minPrice, decimal? maxPrice);
        Car GetCarById(int id);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
    }
}
