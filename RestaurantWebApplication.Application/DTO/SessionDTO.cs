using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.DTO
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public decimal? PayableCheck { get; set; }
        public bool PaymentState { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}
