using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Domain
{
    public class Session
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public decimal PayableCheck { get; set; }
        public bool PaymentState { get; set; }

        public List<Order> Orders { get; set; }
    }
}
