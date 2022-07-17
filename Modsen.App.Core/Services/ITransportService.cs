using System.Collections.Generic;
using System.Threading.Tasks;
using Modsen.App.Core.Models.Dto;

namespace Modsen.App.Core.Services
{
    public interface ITransportService
    {
        public Task<IEnumerable<TransportDto>> GetQueueAsync(int pageNumber, int pageSize);
        public Task<TransportDto> GetAsync(int id);
        public Task AddAsync(TransportDto transportDto);
        public Task UpdateAsync(TransportDto transportDto);
        public Task DeleteAsync(int id);
    }
}