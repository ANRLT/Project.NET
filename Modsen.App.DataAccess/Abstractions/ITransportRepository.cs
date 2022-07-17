using System.Collections.Generic;
using System.Threading.Tasks;
using Dal.Entities;
using Modsen.App.Core.Models.Dto;

namespace Modsen.App.DataAccess.Abstractions;

public interface ITransportRepository
{
    Task<Transport> GetByNameWithTrackingAsync(string name);
    Task<Transport> GetByIdWithTrackingAsync(int id);
    Task<IEnumerable<TransportDto>> GetQueueAsync(int offset, int size);
    Task DeleteByIdAsync(int id);
    Task UpdateAsync(Transport transport);
    Task AddAsync(Transport transport);
}