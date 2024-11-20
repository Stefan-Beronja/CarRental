using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace CarRental.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index(string make, string model, decimal? minPrice, decimal? maxPrice)
        {
            var cars = InitCars();
            
            return View(cars);
        }

        public IActionResult Details(int id)
        {
            var cars = InitCars();
            var car = cars.FirstOrDefault(c => c.CarId == id);

            if (car == null) return NotFound();
            return View(car);
        }

        private IEnumerable<Car> InitCars()
        {
            var cars = new List<Car>();

            Car audiA3 = new Car()
            {
                CarId = 1,
                Make = "Audi",
                Model = "A3",
                PricePerDay = 30.5m,
                IsAvailable = true,
                Year = 2021,
                FuelType = "Disel",
                Seats = 5,
                ImageUrl = "AUDI_A3L.webp"
            };

            Car bmwM5 = new Car()
            {
                CarId = 2,
                Make = "BMW",
                Model = "M5",
                PricePerDay = 33.3m,
                IsAvailable = true,
                Year = 2023,
                FuelType = "Petrol",
                Seats = 5,
                ImageUrl = "BMW_M5.png"
            };

            Car renaultSenic = new Car()
            {
                CarId = 3,
                Make = "Renault",
                Model = "Senic",
                PricePerDay = 96.3m,
                IsAvailable = true,
                Year = 2024,
                FuelType = "Electric",
                Seats = 5,
                ImageUrl = "Renault_Senic.webp"
            };

            cars.Add(audiA3);
            cars.Add(bmwM5);
            cars.Add(renaultSenic);

            return cars;
        }
    }
}