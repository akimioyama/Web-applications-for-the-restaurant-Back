using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebApplication.Application.DTO;
using RestaurantWebApplication.Application.Serviсes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetMenu()
        {
            List<MenuItemDTO> result = _menuService.GetMenu();
            if (result != null) return Ok(result);
            else return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AddMenuItem(MenuItemDTO menuItemDTO)
        {
            int result = _menuService.AddMenuItem(menuItemDTO);
            if (result != 0) return Ok(result);
            else return BadRequest();
        }
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> ChangeMenuItem(MenuItemDTO menuItemDTO)
        {
            if(_menuService.ChangeMenuItem(menuItemDTO)) return Ok();
            else return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            if (_menuService.DeleteMenuItem(id)) return Ok();
            else return NotFound();
        }

    }
}
