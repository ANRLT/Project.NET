using System.Collections.Generic;
using System.Threading.Tasks;
using Dal.Entities;
using Modsen.App.Core.Models.Dto;

namespace Modsen.App.DataAccess.Abstractions;

internal interface IBookingRepository
{
    Task<Booking> GetByIdWithTrackingAsync(int id);
    Task<IEnumerable<BookingDto>> GetQueueAsync(int offset, int size);
    Task DeleteByIdAsync(int id);
    Task UpdateAsync(Booking booking);
    Task AddAsync(Booking bransport);
}
