using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Modsen.App.Core.Models.Dto;

namespace Modsen.App.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Booking> _dbSet;
        private readonly IMapper _mapper;

        public BookingRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<Booking>();
            _mapper = mapper;
        }


        public async Task<BookingDto> GetByIdWithTrackingAsync(int id)
        {
            var transport = await _dbSet.FindAsync(id);
            var result = _mapper.Map<BookingDto>(transport);

            return result;
        }

        public async Task<IEnumerable<BookingDto>> GetQueueAsync(int offset, int size)
        {
            var queue = await _dbSet.AsNoTracking().Skip(offset * size).Take(size).Select(c => _mapper.Map<BookingDto>(c)).ToListAsync();

            return queue;
        }
        public async Task AddAsync(Booking booking)
        {

            await _dbSet.AddAsync(booking);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            var booking = await _dbSet.FindAsync(id);
            if (booking != null)
            {
                _dbSet.Remove(booking);
                await _context.SaveChangesAsync();
            }

        }

        public async Task UpdateAsync(Booking booking)
        {
            var toUpdateBookingIsNotNull = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == booking.Id) != null;
            if (toUpdateBookingIsNotNull)
            {
                _dbSet.Update(booking);
                await _context.SaveChangesAsync();
            }
        }

        Task<Booking> IBookingRepository.GetByIdWithTrackingAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}