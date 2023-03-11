using RestaurantWebApplication.Domain;
using RestaurantWebApplication.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.EntityFramework.Repository.Implementation
{
    public class BookingSelects : IBookingSelects
    {
        public DateTime? GetFirstActualDateTimeByTableId(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return db.Booking.Where(b=>b.TableId==id && DateTime.Compare(b.DateTime,DateTime.Now)>=0).OrderBy(p=>p.DateTime)?.FirstOrDefault()?.DateTime;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
