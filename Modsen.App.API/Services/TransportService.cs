using Modsen.App.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Modsen.App.Core.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modsen.App.API.Services
{
    public class TransportService : ITransportService

    {
        public Task<IEnumerable<TransportDto>> GetQueueAsync(int pageNumber, int pageSize)
        {
            return default;
        }

        public Task<TransportDto> GetAsync(int id)
        {
            return default;
        }

        public Task AddAsync(TransportDto transportDto)
        {
            return default;
        }

        public Task UpdateAsync(TransportDto transportDto)
        {
            return default;
        }

        public Task DeleteAsync(int id)
        {
            return default;
        }
    }
}