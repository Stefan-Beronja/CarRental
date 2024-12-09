using CarRental.Models;
using CarRental.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace CarRental.Controllers
{
    
    public class CarController : Controller
    {
        public readonly CarRentalContext _context;
        public CarController(CarRentalContext context)
        {
            _context = context;
        }

        public IActionResult Index(string make, string model, decimal? minPrice, decimal? maxPrice, int pageCount, int pageSize = 10)
        {
            //IEnumerable<Car> cars = Storage.InitCars();
            var cars = _context.Cars.AsQueryable();


            if (!string.IsNullOrEmpty(make))
            {
                cars = cars.Where(c => c.Make.ToLower().Contains(make.ToLower()));
            }

            if (!string.IsNullOrEmpty(model))
            {
                cars = cars.Where(c => c.Model.ToLower().Contains(model.ToLower()));
            }

            // 'Has.Value' ispituje da li uoste imamo vrednost, dok '.Value' pristupa zadatoj vrednosti

            if (minPrice.HasValue)
            {
                cars = cars.Where(c => c.PricePerDay >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                cars = cars.Where(c => c.PricePerDay <= maxPrice.Value);
            }
            return View(cars);
        }

        public async Task<IActionResult> Details(int id)
        {
            //IEnumerable<Car> cars = Storage.InitCars();
            //var car = cars.FirstOrDefault(c => c.CarId == id);

            var car = await _context.Cars.FindAsync(id);

            if (car == null) return NotFound();
            
            return View(car);
        }
    }
}