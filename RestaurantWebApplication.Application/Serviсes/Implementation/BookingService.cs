using RestaurantWebApplication.Application.DTO;
using RestaurantWebApplication.Application.Serviсes.Interfaces;
using RestaurantWebApplication.Domain;
using RestaurantWebApplication.EntityFramework.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.Serviсes.Implementation
{
    public class BookingService : IBookingService
    {
        BookingSelects bookingSelects;
        public BookingService()
        {
            bookingSelects = new BookingSelects();
        }
        public List<BookingDTO> GetActualByTableId(int id)
        {
            return bookingSelects.GetActualByTableId(id).Select(b=>new BookingDTO() {Id = b.Id, TableId = b.TableId, DateTime = b.DateTime, FIO = b.FIO, Phone = b.Phone }).ToList();
        }
        public int AddBooking(BookingDTO booking)
        {
            return bookingSelects.AddBooking(new Booking() { Id = booking.Id, TableId = booking.TableId, DateTime = booking.DateTime, FIO = booking.FIO, Phone = booking.Phone });
        }
        public bool ChangeBooking(BookingDTO booking)
        {
            return bookingSelects.ChangeBooking(new Booking() { Id = booking.Id, TableId = booking.TableId, DateTime = booking.DateTime, FIO = booking.FIO, Phone = booking.Phone });
        }
        public bool DeleteBooking(int id)
        {
            return bookingSelects.DeleteBookingById(id);
        }
    }
}
