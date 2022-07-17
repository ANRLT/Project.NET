using System.Collections.Generic;
using System.Threading.Tasks;
using Modsen.App.Core.Models.Dto;

namespace Modsen.App.Core.Services
{
    public interface ITourTypeService
    {
        public Task<IEnumerable<TourTypeDto>> GetQueueAsync(int pageNumber, int pageSize);
        public Task<TourTypeDto> GetAsync(int id);
        public Task AddAsync(TourTypeDto tourTypeDto);
        public Task UpdateAsync(TourTypeDto tourTypeDto);
        public Task DeleteAsync(int id);
    }
}