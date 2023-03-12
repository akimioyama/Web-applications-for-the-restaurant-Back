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
    public class AccountController : ControllerBase
    {
        IAccountService _loginService;
        public AccountController(IAccountService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AccountLoginDTO accountLoginDTO)
        {
            AccountGetDTO result = _loginService.GetJWTToken(accountLoginDTO);
            if (result != null) return Ok(result);
            else return BadRequest();
        }
    }
}
