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

            if (car == null || !car.IsAvailable)
            {
                return NotFound("The car is not avilable for booking.");
            }

            return View(new Booking {BookingId = 1, CarId = carId, Car = car, StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(2), TotalPrice = car.PricePerDay});
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

            var rentalDays = (booking.EndDate - booking.StartDate).Days;
            booking.TotalPrice = rentalDays * car.PricePerDay;
            booking.Car = car;

            //ModelState:
            //To je objekat koji se koristi za praćenje stanja modela tokom HTTP zahteva.
            //ModelState čuva informacije o validaciji modela, kao što su greške koje mogu nastati tokom procesa bindovanja podataka sa formom, na primer.

            //IsValid


            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirmation", new { bookingId = booking.BookingId });
            }

            return View(booking);

        }

        public IActionResult Confirmation(int bookingId)
        {
            IEnumerable<Booking> bookings = Storage.InitBooking();
            Booking booking = bookings.SingleOrDefault(x => x.BookingId == bookingId);

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
    }
}
