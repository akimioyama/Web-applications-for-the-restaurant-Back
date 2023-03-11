using RestaurantWebApplication.Application.DTO;
using RestaurantWebApplication.Application.Serviсes.Interfaces;
using RestaurantWebApplication.Domain;
using RestaurantWebApplication.EntityFramework.Repository.Implementation;
using RestaurantWebApplication.EntityFramework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApplication.Application.Serviсes.Implementation
{
    public class MenuService : IMenuService
    {
        IMenuSelects menuSelects;
        public MenuService()
        {
            menuSelects = new MenuSelects();
        }
        public IEnumerable<MenuItemDTO> GetMenu()
        {
            return menuSelects.GetAllMenuItems().Select(m => new MenuItemDTO() { Id = m.Id, Name = m.Name, Composition = m.Composition, PictureName = m.PictureName, Price = m.Price });
        }
        public int AddMenuItem(MenuItemDTO menuItemsDTO)
        {
            return menuSelects.AddMenuItem(new MenuItem() {Id = menuItemsDTO.Id, Name = menuItemsDTO.Name, Composition = menuItemsDTO.Composition, PictureName = menuItemsDTO.PictureName, Price = menuItemsDTO.Price });
        }
        public bool ChangeMenuItem(MenuItemDTO menuItemsDTO)
        {
            return menuSelects.ChangeMenuItem(new MenuItem() { Id = menuItemsDTO.Id, Name = menuItemsDTO.Name, Composition = menuItemsDTO.Composition, PictureName = menuItemsDTO.PictureName, Price = menuItemsDTO.Price });
        }
        public bool DeleteMenuItem(int id)
        {
            return menuSelects.DeleteMenuItem(id);
        }
    }
}
