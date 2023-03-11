using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Domain
{
    public class Table
    {
        public int Id { get; set; }
        public bool IsFree { get; set; }

        public List<Booking> BookingList { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
