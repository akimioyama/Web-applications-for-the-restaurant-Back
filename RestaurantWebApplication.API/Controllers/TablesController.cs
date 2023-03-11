using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebApplication.Application.Serviсes.Interfaces;
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
        [HttpGet]
        public async Task<IActionResult> GetAllTable()
        {
            return Ok(_tablesService.GetAllTables());
        }
    }
}
