using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.DTO
{
    public class OrderAddDTO
    {
        public int SessionId { get; set; } 
        public int MenuItemId { get; set; }
    }
}
