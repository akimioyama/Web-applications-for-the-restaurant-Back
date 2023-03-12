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
    public class BookingController : ControllerBase
    {
        IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetActualByTableId(int TableId)
        {
            return Ok(_bookingService.GetActualByTableId(TableId));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddBooking(BookingDTO bookingDTO)
        {
            int result = _bookingService.AddBooking(bookingDTO);
            if (result != 0) return Ok(result);
            else return BadRequest();
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> ChangeBooking(BookingDTO bookingDTO)
        {
            if (_bookingService.ChangeBooking(bookingDTO)) return Ok();
            else return NotFound();
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            if (_bookingService.DeleteBooking(id)) return Ok();
            else return NotFound();
        }
    }
}
