using Microsoft.AspNetCore.Mvc;
using Modsen.App.Core.Models.Dto;
using Modsen.App.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modsen.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet("id")]
        public async Task<BookingDto> GetByIdAsync(int id)
        {
            return await _bookingService.GetAsync(id);
        }

        [HttpGet("page")]
        public async Task<IEnumerable<BookingDto>> GetPageAsync(int pageNumber = 0, int size = 0)
        {
            return await _bookingService.GetQueueAsync(pageNumber, size);
        }
        //[Authorize(Roles = "admin")]
        [HttpPost("add")]
        public async Task AddTourAsync(BookingDto bookingDto)
        {
            await _bookingService.AddAsync(bookingDto);
        }
        [HttpPut("edit")]
        public async Task EditTourAsync(BookingDto bookingDto)
        {
            await _bookingService.UpdateAsync(bookingDto);
        }
        [HttpDelete("id")]
        public async Task DeleteTourAsync(int id)
        {
            await _bookingService.DeleteAsync(id);
        }
    }
}
