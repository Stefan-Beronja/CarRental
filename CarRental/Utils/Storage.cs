using CarRental.Models;
using System.Data;

namespace CarRental.Utils
{
    public class Storage
    {
        public static IEnumerable<Car> InitCars()
        {
            List<Car> cars = new List<Car>();

            cars.Add(new Car()
            {
                CarId = 1,
                Make = "Audi",
                Model = "A3",
                PricePerDay = 45.5m,
                IsAvailable = true,
                Year = 2021,
                FuelType = "Disel",
                Seats = 5,
                ImageUrl = "AUDI_A3L.webp"
            });

            cars.Add(new Car()
            {
                CarId = 2,
                Make = "BMW",
                Model = "M5",
                PricePerDay = 56.3m,
                IsAvailable = true,
                Year = 2023,
                FuelType = "Petrol",
                Seats = 5,
                ImageUrl = "BMW_M5.png"
            });


            cars.Add(new Car()
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
            });

            cars.Add(new Car()
            {
                CarId = 4,
                Make = "Honda",
                Model = "Civic",
                PricePerDay = 88.6m,
                IsAvailable = true,
                Year = 2024,
                FuelType = "Petrol",
                Seats = 5,
                ImageUrl = "Honda_Civic_1.png"
            });

            cars.Add(new Car()
            {
                CarId = 5,
                Make = "Toyota",
                Model = "RAV 4",
                PricePerDay = 83.6m,
                IsAvailable = true,
                Year = 2024,
                FuelType = "Hybrid",
                Seats = 5,
                ImageUrl = "Toyota_RAV4.png"
            });

            cars.Add(new Car()
            {
                CarId = 6,
                Make = "Mercedes-Benz",
                Model = "GLA",
                PricePerDay = 112.6m,
                IsAvailable = true,
                Year = 2022,
                FuelType = "Disel",
                Seats = 5,
                ImageUrl = "Mercedes_GLA_1.png"
            });

            cars.Add(new Car()
            {
                CarId = 7,
                Make = "Peugeot",
                Model = "3008",
                PricePerDay = 98.6m,
                IsAvailable = false,
                Year = 2023,
                FuelType = "Petrol",
                Seats = 5,
                ImageUrl = ""
            });

            cars.Add(new Car()
            {
                CarId = 8,
                Make = "Maybach",
                Model = "S-680",
                PricePerDay = 526.6m,
                IsAvailable = true,
                Year = 2024,
                FuelType = "Hybrid",
                Seats = 5,
                ImageUrl = "Mercedes-Maybach-S-680.png"
            });

            return cars;
        }

        public static IEnumerable<Booking> InitBooking()
        {
            List<Booking> bookings = new List<Booking>();

            bookings.Add(new Booking()
            {
                BookingId = 1,
                CarId = 1,
                UserId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                TotalPrice = 0,
                Car = new Car()
                {
                    CarId = 1,
                    Make = "Audi",
                    Model = "A3",
                    PricePerDay = 45.5m,
                    IsAvailable = true,
                    Year = 2021,
                    FuelType = "Disel",
                    Seats = 5,
                    ImageUrl = "AUDI_A3L.webp"
                }

            });

            bookings.Add(new Booking()
            {
                BookingId = 2,
                CarId = 4,
                UserId = 2,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                TotalPrice = 0,
                Car = new Car()
                {
                    CarId = 4,
                    Make = "Honda",
                    Model = "Civic",
                    PricePerDay = 88.6m,
                    IsAvailable = true,
                    Year = 2024,
                    FuelType = "Petrol",
                    Seats = 5,
                    ImageUrl = "Honda_Civic.png"
                }
            });

            bookings.Add(new Booking()
            {
                BookingId = 3,
                CarId = 6,
                UserId = 3,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                TotalPrice = 0,
                Car = new Car()
                {
                    CarId = 6,
                    Make = "Mercedes",
                    Model = "GLA",
                    PricePerDay = 112.6m,
                    IsAvailable = true,
                    Year = 2022,
                    FuelType = "Disel",
                    Seats = 5,
                    ImageUrl = "Mercedes_GLA.webp"
                }
            });

            bookings.Add(new Booking()
            {
                BookingId = 4,
                CarId = 8,
                UserId = 4,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                TotalPrice = 0,
                Car = new Car()
                {
                    CarId = 8,
                    Make = "Maybach",
                    Model = "S-680",
                    PricePerDay = 526.6m,
                    IsAvailable = true,
                    Year = 2024,
                    FuelType = "Hybrid",
                    Seats = 5,
                    ImageUrl = "Mercedes-Maybach-S-680.png"
                }
            });

            bookings.Add(new Booking()
            {
                BookingId = 5,
                CarId = 2,
                UserId = 5,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                TotalPrice = 0,
                Car = new Car()
                {
                    CarId = 2,
                    Make = "BMW",
                    Model = "M5",
                    PricePerDay = 56.3m,
                    IsAvailable = true,
                    Year = 2023,
                    FuelType = "Petrol",
                    Seats = 5,
                    ImageUrl = "BMW_M5.png"
                }
            });

            bookings.Add(new Booking()
            {
                BookingId = 6,
                CarId = 3,
                UserId = 6,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                TotalPrice = 0,
                Car = new Car()
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
                }
            });

            bookings.Add(new Booking()
            {
                BookingId = 7,
                CarId = 5,
                UserId = 7,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                TotalPrice = 0,
                Car = new Car()
                {
                    CarId = 5,
                    Make = "Toyota",
                    Model = "RAV 4",
                    PricePerDay = 83.6m,
                    IsAvailable = true,
                    Year = 2024,
                    FuelType = "Hybrid",
                    Seats = 5,
                    ImageUrl = "Toyota_RAV4.png"
                }
            });

            return bookings;
        }

        
    }
}
