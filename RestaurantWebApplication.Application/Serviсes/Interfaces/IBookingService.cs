using RestaurantWebApplication.Application.DTO;
using RestaurantWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.Serviсes.Interfaces
{
    public interface IBookingService
    {
        public IEnumerable<BookingDTO> GetActualByTableId(int id);
        public bool AddBooking(BookingDTO booking);
        public bool ChangeBooking(BookingDTO booking);
        public bool DeleteBooking(int id);
    }
}
