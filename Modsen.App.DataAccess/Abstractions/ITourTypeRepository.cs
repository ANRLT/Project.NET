using System.Collections.Generic;
using System.Threading.Tasks;
using Dal.Entities;
using Modsen.App.Core.Models.Dto;

namespace Modsen.App.DataAccess.Abstractions;

public interface ITourTypeRepository
{
    Task<TourType> GetByNameWithTrackingAsync(string name);

    Task<TourTypeDto> GetByIdWithTrackingAsync(int id);
    Task<IEnumerable<TourTypeDto>> GetQueueAsync(int offset, int size);
    Task DeleteByIdAsync(int id);
    Task UpdateAsync(TourType tourType);
    Task AddAsync(TourType tourType);
}