using CarRental.Models;

namespace CarRental.ViewModels
{
    public class PaginatedCarsViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}