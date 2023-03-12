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
    public class UsersController : ControllerBase
    {
        IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            List<UserDTO> result = _usersService.GetAllUsers();
            if (result != null) return Ok(result);
            else return NotFound();
        }
    
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddDTO userAddDTO)
        {
            int result = _usersService.AddUser(userAddDTO);
            if (result != 0) return Ok(result);
            else return BadRequest();
        }
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> ChangeUser(UserDTO userDTO)
        {
            if (_usersService.ChangeUser(userDTO)) return Ok();
            else return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_usersService.DeleteUser(id)) return Ok();
            else return NotFound();
        }
    }
}
