using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.DTO
{
    public class SessionStateChangeDTO
    {
        public int Id { get; set; }
        public bool PaymentState { get; set; }
    }
}
