using Microsoft.AspNetCore.Mvc;
using Modsen.App.Core.Models.Dto;
using Modsen.App.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modsen.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService _transportService;

        public TransportController(ITransportService transportService)
        {
            _transportService = transportService;
        }

        [HttpGet("id")]
        public async Task<TransportDto> GetByIdAsync(int id)
        {
            return await _transportService.GetAsync(id);
        }

        [HttpGet("page")]
        public async Task<IEnumerable<TransportDto>> GetPageAsync(int pageNumber = 0, int size = 0)
        {
            return await _transportService.GetQueueAsync(pageNumber, size);
        }

        //[Authorize(Roles = "admin")]
        [HttpPost("add")]
        public async Task AddTransportAsync(TransportDto transportDto)
        {
            await _transportService.AddAsync(transportDto);
        }

        [HttpPut("edit")]
        public async Task EditTransporAsync(TransportDto transportDto)
        {
            await _transportService.UpdateAsync(transportDto);
        }

        [HttpDelete("id")]
        public async Task DeleteTransporAsync(int id)
        {
            await _transportService.DeleteAsync(id);
        }

    }
}
