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
    public class SessionsController : ControllerBase
    {
        ISessionsService _sessionsService;
        public SessionsController(ISessionsService sessionsService)
        {
            _sessionsService = sessionsService;
        }
        [HttpPost]
        public async Task<IActionResult> AddSession(int tableId)
        {
            SessionDTO result = _sessionsService.AddSession(tableId);
            if (result != null) return Ok(result);
            else return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetSessionByTableId(int tableId)
        {
            SessionDTO result = _sessionsService.GetSessionByTableId(tableId);
            if (result != null) return Ok(result);
            else return NotFound();
        }
        [HttpGet("GetCheck")]
        public async Task<IActionResult> FormPayableCheck(int id)
        {
            decimal result = _sessionsService.FormPayableCheck(id);
            if (result != -1) return Ok(result);
            else return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> ChangePaymentState(SessionStateChangeDTO sessionStateChangeDTO)
        {
            bool result = _sessionsService.ChangePaymentState(sessionStateChangeDTO);
            if (result) return Ok();
            else return NotFound();
        }
    }
}
