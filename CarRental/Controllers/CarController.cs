using CarRental.Services;
using CarRental.Utils;
using CarRental.ViewModels;
using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.IO;

namespace CarRental.Controllers
{

    public class CarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //private readonly ICarService _carService;

        //public CarController(ICarService carService)
        //{
        //    _carService = carService;
        //}


        public async Task<IActionResult> Index(string make, string model, decimal? minPrice, decimal? maxPrice, int page = 1)
        {
            //var cars = _carService.GetFilteredCars(make, model, minPrice, maxPrice);
            
            var cars = _unitOfWork.CarService.GetFilteredCars(make, model, minPrice, maxPrice);

            var pageSize = 8;

            PaginatedCarsViewModel pcvm = new PaginatedCarsViewModel();

            pcvm.PageSize = pageSize;
            pcvm.TotalPages = (int)Math.Ceiling((double)cars.Count() / pageSize);
            pcvm.CurrentPage = page < 1 ? 1 : (page > pcvm.TotalPages ? pcvm.TotalPages : page);
            pcvm.HasNextPage = pcvm.CurrentPage < pcvm.TotalPages;
            pcvm.HasPreviousPage = pcvm.CurrentPage > 1;

            cars = cars.Skip(pageSize * (page - 1)).Take(pageSize );

            pcvm.Cars = cars;

            return View(pcvm);
        }

        public async Task<IActionResult> Details(int id)
        {
            //var cars = _carService.GetCarById(id);

            var cars = _unitOfWork.CarService.GetCarById(id);

            if (cars == null) return NotFound();
            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string make, string model, decimal? minPrice, decimal? maxPrice, int page = 1)
        {
            var cars = _unitOfWork.CarService.GetFilteredCars(make, model, minPrice, maxPrice);

            var pageSize = 8;

            PaginatedCarsViewModel pcvm = new PaginatedCarsViewModel();

            pcvm.PageSize = pageSize;
            pcvm.TotalPages = cars.Count() % pageSize;
            pcvm.CurrentPage = page;
            pcvm.HasNextPage = pcvm.CurrentPage < pcvm.TotalPages;
            pcvm.HasPreviousPage = pcvm.CurrentPage > 1;

            cars = cars.Skip(pageSize * (page - 1)).Take(pageSize);

            pcvm.Cars = cars;

            return View(pcvm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car car, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Cars");
                    path = $"{path}\\{car.Make}_{car.Model}_{car.Year}.jpg";

                    FileStream filestream = new FileStream(path, FileMode.Create);
                    file.CopyTo(filestream);
                    car.ImageUrl = path;
                }

                _unitOfWork.CarService.AddCar(car);
                _unitOfWork.SaveChanges();

                IEnumerable<Car> cars = _unitOfWork.CarService.GetAllCars();

                return View("Index", cars);
            }

            return View(car);
        }
    }
}