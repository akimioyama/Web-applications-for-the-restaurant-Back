using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.DTO
{
    public class MenuItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Composition { get; set; }
        public string PictureName { get; set; }
        public decimal Price { get; set; }
    }
}
