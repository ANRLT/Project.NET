using Modsen.App.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Modsen.App.Core.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modsen.App.API.Services
{
    public class TourTypeService : ITourTypeService

    {
        public Task<IEnumerable<TourTypeDto>> GetQueueAsync(int pageNumber, int pageSize)
        {
            return default;
        }

        public Task<TourTypeDto> GetAsync(int id)
        {
            return default;
        }

        public Task AddAsync(TourTypeDto tourDto)
        {
            return default;
        }

        public Task UpdateAsync(TourTypeDto tourDto)
        {
            return default;
        }

        public Task DeleteAsync(int id)
        {
            return default;
        }
    }
}