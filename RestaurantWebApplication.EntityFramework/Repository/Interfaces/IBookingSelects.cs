using RestaurantWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.EntityFramework.Repository.Interfaces
{
    public interface IBookingSelects
    {
        public Booking GetFirstActualDateTimeByTableId(int id);
        public List<Booking> GetActualByTableId(int id);
        public int AddBooking(Booking booking);
        public bool ChangeBooking(Booking booking);
        public bool DeleteBookingById(int id);
    }
}
