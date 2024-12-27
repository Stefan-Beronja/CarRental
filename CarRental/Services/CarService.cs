using CarRental.Models;
using System.Linq;

namespace CarRental.Services
{
    public class CarService : ICarService
    {
        private readonly CarRentalContext _context;

        public CarService(CarRentalContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.Find(id);
        }

        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
        }

        public void UpdateCar(Car car)
        {
            _context.Cars.Update(car);
        }

        public void DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }
        }

        public IEnumerable<Car> GetFilteredCars(string make, string model, decimal? minPrice, decimal? maxPrice)
        {
            var cars = _context.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(make))
            {
                cars = cars.Where(c => c.Make.ToLower().Contains(make.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(model))
            {
                cars = cars.Where(c => c.Model.ToLower().Contains(model.Trim().ToLower()));
            }

            if (minPrice.HasValue)  // 'Has.Value' ispituje da li uoste imamo vrednost
            {
                cars = cars.Where(c => c.PricePerDay >= minPrice.Value); // '.Value' pristupa zadatoj vrednosti
            }

            if (maxPrice.HasValue) // 'Has.Value' ispituje da li uoste imamo vrednost
            {
                cars = cars.Where(c => c.PricePerDay <= maxPrice.Value); // '.Value' pristupa zadatoj vrednosti
            }
            return cars;
        }
    }      
}
