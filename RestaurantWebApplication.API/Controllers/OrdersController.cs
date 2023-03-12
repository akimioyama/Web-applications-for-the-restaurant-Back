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
    public class OrdersController : ControllerBase
    {
        IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderAddDTO orderAddDTO)
        {
            int result = _ordersService.AddOrder(orderAddDTO);
            if (result != 0) return Ok(result);
            else return BadRequest();
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            if (_ordersService.DeleteOrder(orderId)) return Ok();
            else return NotFound();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrderBySessionId(int sessionId)
        {
            List<OrderDTO> result = _ordersService.GetOrderBySessionId(sessionId);
            if (result != null) return Ok(result);
            else return NotFound();
        }
    }
}
