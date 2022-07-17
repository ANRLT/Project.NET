using Microsoft.AspNetCore.Mvc;
using Modsen.App.Core.Models.Dto;
using Modsen.App.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modsen.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourTypeController : ControllerBase
    {
        private readonly ITourTypeService _tourTypeService;

        public TourTypeController(ITourTypeService tourTypeService)
        {
            _tourTypeService = tourTypeService;
        }

        [HttpGet("id")]
        public async Task<TourTypeDto> GetByIdAsync(int id)
        {
            return await _tourTypeService.GetAsync(id);
        }

        [HttpGet("page")]
        public async Task<IEnumerable<TourTypeDto>> GetPageAsync(int pageNumber = 0, int size = 0)
        {
            return await _tourTypeService.GetQueueAsync(pageNumber, size);
        }

        //[Authorize(Roles = "admin")]
        [HttpPost("add")]
        public async Task AddTourTypeAsync(TourTypeDto tourTypeDto)
        {
            await _tourTypeService.AddAsync(tourTypeDto);
        }

        [HttpPut("edit")]
        public async Task EditTourTypeAsync(TourTypeDto tourTypeDto)
        {
            await _tourTypeService.UpdateAsync(tourTypeDto);
        }

        [HttpDelete("id")]
        public async Task DeleteTourTypeAsync(int id)
        {
            await _tourTypeService.DeleteAsync(id);
        }
    }
}
