using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Domain
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Composition { get; set; }
        public string PictureName { get; set; }
        public decimal Price { get; set; }

        public List<Order> Orders { get; set; }
    }
}
