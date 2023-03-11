using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.DTO
{
    public class TableDTO
    {
        public int Id { get; set; }
        public bool IsFree { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
