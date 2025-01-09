using CarRental.Models;
using CarRental.Services;
using CarRental.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarRental.Controllers
{
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // UnitOfWorks nam menja CarService i BookingService

        //private readonly ICarService _carService;
        //public BookingController(ICarService carService)
        //{
        //    _carService = carService;
        //}

        //private readonly IBookingService _bookingService;
        //public BookingController(IBookingService bookingService)
        //{
        //    _bookingService = bookingService;
        //}

        [HttpGet]
        public IActionResult Create(int carId, int userId, DateTime startDate, DateTime endDate)
        {
            //IEnumerable<Car> cars = Storage.InitCars();
            //Car car = cars.Single(x => x.CarId == carId);

            //IEnumerable<Booking> bookings = Storage.InitBooking();
            //Booking booking = bookings.SingleOrDefault(x => x.CarId == carId);

            var cars = _unitOfWork.CarService.GetCarById(carId);

            Booking bookings = new Booking();

            bookings.StartDate = DateTime.Now.AddDays(1);
            bookings.EndDate = DateTime.Now.AddDays(3);
            bookings.TotalPrice = _unitOfWork.BookingService.CalculateTotalPrice(bookings.StartDate, bookings.EndDate, cars.PricePerDay);
            bookings.Car = cars;

            if (bookings == null || !cars.IsAvailable)
            {
                return NotFound("The car is not avilable for booking.");
            }

            return View(bookings);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( int carId, DateTime startDate, DateTime endDate, string action)
        {
            //IEnumerable<Car> cars = Storage.InitCars();
            //Car car = cars.SingleOrDefault(x => x.CarId == booking.CarId);

            var cars = _unitOfWork.CarService.GetCarById(carId);
            var bookings = _unitOfWork.BookingService.GetBookingByCarId(carId);

            bookings.StartDate = startDate;
            bookings.EndDate = endDate;
            bookings.TotalPrice = _unitOfWork.BookingService.CalculateTotalPrice(startDate, endDate, cars.PricePerDay);
            bookings.Car = cars;

            if (action == "refresh") 
            {
                return View(bookings);
            }

            if (cars == null || !cars.IsAvailable) // cars.IsAvailable == false 
            {
                return NotFound("The car is not avilable for booking.");
            }

            //ModelState:
            //To je objekat koji se koristi za praćenje stanja modela tokom HTTP zahteva.
            //ModelState čuva informacije o validaciji modela, kao što su greške koje mogu nastati tokom procesa bindovanja podataka sa formom, na primer.

            //IsValid

            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirmation", new { bookingId = bookings.BookingId, carId = bookings.CarId, totalPrice = bookings.TotalPrice, startDate = bookings.StartDate, endDate = bookings.EndDate });
            }

            return View(bookings);

        }

        public IActionResult Confirmation(int bookingId, int carId, DateTime startDate, DateTime endDate, decimal totalPrice)
        {
            //IEnumerable<Booking> bookings = Storage.InitBooking();
            //Booking booking = bookings.SingleOrDefault(x => x.BookingId == bookingId);

            //IEnumerable<Car> cars = Storage.InitCars();
            //Car car = cars.Single(x => x.CarId == carId);

            Booking bookings = new Booking();

            var cars = _unitOfWork.CarService.GetCarById(carId);
            bookings = _unitOfWork.BookingService.GetBookingByCarId(carId);

            bookings.StartDate = startDate;
            bookings.EndDate = endDate;
            bookings.TotalPrice = _unitOfWork.BookingService.CalculateTotalPrice(startDate, endDate, cars.PricePerDay);
            bookings.Car = cars;

            if (bookings == null)
            {
                return NotFound("Booking not found");
            }

            return View(bookings);
        }

        public IActionResult History(int userId)
        {
            //IEnumerable<Booking> bookings = Storage.InitBooking().Where(x => x.UserId == userId);

            //Booking booking = bookings.Where(x => x.UserId == userId);

            var bookings = _unitOfWork.BookingService.GetBookingById(userId);

            return View(bookings);
        }
    }
}