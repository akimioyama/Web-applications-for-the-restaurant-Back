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
        public Booking GetFirstActualDateTimeByTableId(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return db.Booking.Where(b=>b.TableId==id && DateTime.Compare(b.DateTime,DateTime.Now)>=0).OrderBy(p=>p.DateTime)?.FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }
        public List<Booking> GetActualByTableId(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return db.Booking.Where(b=>b.TableId==id && DateTime.Compare(b.DateTime,DateTime.Now)>=0).OrderBy(p=>p.DateTime).ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        public bool AddBooking(Booking booking)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.Booking.Add(booking);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ChangeBooking(Booking booking)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Booking bookingMain = db.Booking.FirstOrDefault(b=>b.Id == booking.Id);
                    if(bookingMain != null)
                    {
                        bookingMain.Id = booking.Id;
                        bookingMain.TableId = booking.TableId;
                        bookingMain.DateTime = booking.DateTime;
                        bookingMain.FIO = booking.FIO;
                        bookingMain.Phone = booking.Phone;
                        db.SaveChanges();
                        return true;
                    }
                    else return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteBookingById(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Booking bookingMain = db.Booking.FirstOrDefault(b => b.Id == id);
                    if (bookingMain != null)
                    {
                        db.Booking.Remove(bookingMain);
                        db.SaveChanges();
                        return true;
                    }
                    else return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
