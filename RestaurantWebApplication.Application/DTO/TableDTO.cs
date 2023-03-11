using RestaurantWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.DTO
{
    public class TableDTO
    {
        public TableDTO() { }
        public TableDTO(int id, bool isFree, Booking NextBoking)
        {
            Id = id;
            IsFree = isFree;
            DateTime = NextBoking?.DateTime;
            FIO = NextBoking?.FIO;
        }
        public int Id { get; set; }
        public bool IsFree { get; set; }
        public DateTime? DateTime { get; set; }
        public string FIO { get; set; }
    }
}
