using RestaurantWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.EntityFramework.Repository.Interfaces
{
    public interface IMenuSelects
    {
        public List<MenuItem> GetAllMenuItems();
        public int AddMenuItem(MenuItem menuItem);
        public bool ChangeMenuItem(MenuItem menuItem);
        public bool DeleteMenuItem(int id);
    }
}
