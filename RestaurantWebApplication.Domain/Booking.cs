using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public DateTime DateTime { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
    }
}
