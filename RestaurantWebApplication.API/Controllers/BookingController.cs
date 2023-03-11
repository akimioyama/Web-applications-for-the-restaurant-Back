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
        [HttpGet]
        public async Task<IActionResult> GetActualByTableId(int TableId)
        {
            return Ok(_bookingService.GetActualByTableId(TableId));
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(BookingDTO bookingDTO)
        {
            if(_bookingService.AddBooking(bookingDTO)) return Ok();
            else return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> ChangeBooking(BookingDTO bookingDTO)
        {
            if (_bookingService.ChangeBooking(bookingDTO)) return Ok();
            else return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            if (_bookingService.DeleteBooking(id)) return Ok();
            else return NotFound();
        }
    }
}
