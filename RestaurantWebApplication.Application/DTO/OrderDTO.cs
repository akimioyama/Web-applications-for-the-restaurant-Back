using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string NameMenuItem { get; set; }
        public decimal ActualPrice { get; set; }
    }
}
