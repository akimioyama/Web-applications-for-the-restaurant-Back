using RestaurantWebApplication.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.Serviсes.Interfaces
{
    public interface IMenuService
    {
        public IEnumerable<MenuItemDTO> GetMenu();
        public int AddMenuItem(MenuItemDTO menuItemsDTO);
        public bool ChangeMenuItem(MenuItemDTO menuItemsDTO);
        public bool DeleteMenuItem(int id);
    }
}
