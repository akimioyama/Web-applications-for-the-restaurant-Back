using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebApplication.Application.DTO;
using RestaurantWebApplication.Application.Serviсes.Interfaces;
using RestaurantWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITablesService _tablesService;
        public TablesController(ITablesService tablesService)
        {
            _tablesService = tablesService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllTable()
        {
            return Ok(_tablesService.GetAllTables());
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> ChangeTable(TableChangeDTO table)
        {
            if (_tablesService.ChangeTable(table)) return Ok();
            else return NotFound();
        }
    }
}
