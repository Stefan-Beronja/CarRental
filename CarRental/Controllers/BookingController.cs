using CarRental.Models;
using CarRental.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarRental.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Create(int carId, int userId)
        {
            IEnumerable<Car> cars = Storage.InitCars();
            Car car = cars.Single(x => x.CarId == carId);
            
            IEnumerable<Booking> bookings = Storage.InitBooking();
            Booking booking = bookings.SingleOrDefault(x => x.CarId == carId);

            booking.TotalPrice = CalculateTotalPrice(booking.StartDate, booking.EndDate, car.PricePerDay);
            booking.Car = car;

            if (booking == null || !car.IsAvailable)
            {
                return NotFound("The car is not avilable for booking.");
            }
            

            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            IEnumerable<Car> cars = Storage.InitCars();
            Car car = cars.SingleOrDefault(x => x.CarId == booking.CarId);

            if (car == null || !car.IsAvailable)
            {
                return NotFound("The car is not avilable for booking.");
            }

            booking.TotalPrice = CalculateTotalPrice(booking.StartDate, booking.EndDate, car.PricePerDay);
            booking.Car = car;

            //ModelState:
            //To je objekat koji se koristi za praćenje stanja modela tokom HTTP zahteva.
            //ModelState čuva informacije o validaciji modela, kao što su greške koje mogu nastati tokom procesa bindovanja podataka sa formom, na primer.

            //IsValid


            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirmation", new { bookingId = booking.BookingId, carId = booking.CarId });
            }

            return View(booking);

        }

        public IActionResult Confirmation(int bookingId, int carId)
        {
            IEnumerable<Booking> bookings = Storage.InitBooking();
            Booking booking = bookings.SingleOrDefault(x => x.BookingId == bookingId);

            IEnumerable<Car> cars = Storage.InitCars();
            Car car = cars.Single(x => x.CarId == carId);

            booking.TotalPrice = CalculateTotalPrice(booking.StartDate, booking.EndDate, car.PricePerDay);
            booking.Car = car;

            if (booking == null)
            {
                return NotFound("Booking not found");
            }

            return View(booking);
        }

        public IActionResult History(int userId)
        {
            IEnumerable<Booking> bookings = Storage.InitBooking().Where(x => x.UserId == userId);
            
            //Booking booking = bookings.Where(x => x.UserId == userId);
            // Zasto ne moze kao u gore navedenim primerima
            
            return View(bookings);
        }

        public decimal CalculateTotalPrice(DateTime startDate, DateTime endDate, decimal pricePerDay)
        {
            var rentalDays = (endDate - startDate).Days;
            var totalPrice = pricePerDay * rentalDays;

            return totalPrice;
        }
    }
}
