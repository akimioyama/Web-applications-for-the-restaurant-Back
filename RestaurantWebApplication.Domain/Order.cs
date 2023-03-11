using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int MenuId { get; set; }
        public MenuItem Menu { get; set; }
        public decimal ActualPrice { get; set; }
    }
}
