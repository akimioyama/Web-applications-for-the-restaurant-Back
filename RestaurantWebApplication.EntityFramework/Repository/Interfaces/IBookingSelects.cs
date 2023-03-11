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
        public DateTime? GetFirstActualDateTimeByTableId(int id);
    }
}
