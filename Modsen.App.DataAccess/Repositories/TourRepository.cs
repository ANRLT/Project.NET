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
    public class TourRepository : ITourRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Tour> _dbSet;
        private readonly IMapper _mapper;
        public TourRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<Tour>();
            _mapper = mapper;
        }

        public async Task<TourDto> GetByIdWithTrackingAsync(int id)
        {
            var tour = await _dbSet.FindAsync(id);
            var result = _mapper.Map<TourDto>(tour);

            return result;
        }
        public async Task<IEnumerable<TourShortDto>> GetQueueAsync(int offset, int size)
        {
            var queue = await _dbSet.AsNoTracking().Skip(offset * size).Take(size).Select(c => _mapper.Map<TourShortDto>(c)).ToListAsync();

            return queue;
        }
        public async Task AddAsync(Tour tour)
        {

            await _dbSet.AddAsync(tour);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            var tour = await _dbSet.FindAsync(id);
            if (tour != null)
            {
                _dbSet.Remove(tour);
                await _context.SaveChangesAsync();
            }

        }

        public async Task UpdateAsync(Tour tour)
        {
            var toUpdateTourIsNotNull = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == tour.Id) != null;
            if (toUpdateTourIsNotNull)
            {
                _dbSet.Update(tour);
                await _context.SaveChangesAsync();
            }
        }
    }
}