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
    public class TourTypeRepository : ITourTypeRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TourType> _dbSet; 
        private readonly IMapper _mapper;

        public TourTypeRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<TourType>();
            _mapper = mapper;
        }

        public async Task<TourType> GetByNameWithTrackingAsync(string name)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Name == name);

            return result;
        }

        public async Task<TourTypeDto> GetByIdWithTrackingAsync(int id)
        {
            var tourType = await _dbSet.FindAsync(id);
            var result = _mapper.Map<TourTypeDto>(tourType);

            return result;
        }

        public async Task<IEnumerable<TourTypeDto>> GetQueueAsync(int offset, int size)
        {
            var queue = await _dbSet.AsNoTracking().Skip(offset * size).Take(size).Select(c => _mapper.Map<TourTypeDto>(c)).ToListAsync();

            return queue;
        }
        public async Task AddAsync(TourType tourType)
        {

            await _dbSet.AddAsync(tourType);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            var tourType = await _dbSet.FindAsync(id);
            if (tourType != null)
            {
                _dbSet.Remove(tourType);
                await _context.SaveChangesAsync();
            }

        }

        public async Task UpdateAsync(TourType tourType)
        {
            var toUpdateTourTypeIsNotNull = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == tourType.Id) != null;
            if (toUpdateTourTypeIsNotNull)
            {
                _dbSet.Update(tourType);
                await _context.SaveChangesAsync();
            }
        }
    }
}