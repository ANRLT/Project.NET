using System.Collections.Generic;
using System.Threading.Tasks;
using Modsen.App.Core.Models.Dto;

namespace Modsen.App.Core.Services
{
    public interface IBookingService
    {
        public Task<IEnumerable<BookingDto>> GetQueueAsync(int pageNumber, int pageSize);
        public Task<BookingDto> GetAsync(int id);
        public Task AddAsync(BookingDto bookingDto);
        public Task UpdateAsync(BookingDto bookingDto);
        public Task DeleteAsync(int id);
    }
}