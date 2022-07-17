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
    public class TransportRepository : ITransportRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Transport> _dbSet;
        private readonly IMapper _mapper;

        public TransportRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<Transport>();
            _mapper = mapper;
        }

        public async Task<Transport> GetByNameWithTrackingAsync(string name)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Name == name);

            return result;
        }

        public async Task<TransportDto> GetByIdWithTrackingAsync(int id)
        {
            var transport = await _dbSet.FindAsync(id);
            var result = _mapper.Map<TransportDto>(transport);

            return result;
        }

        public async Task<IEnumerable<TransportDto>> GetQueueAsync(int offset, int size)
        {
            var queue = await _dbSet.AsNoTracking().Skip(offset * size).Take(size).Select(c => _mapper.Map<TransportDto>(c)).ToListAsync();

            return queue;
        }
        public async Task AddAsync(Transport transport)
        {

            await _dbSet.AddAsync(transport);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            var transport = await _dbSet.FindAsync(id);
            if (transport != null)
            {
                _dbSet.Remove(transport);
                await _context.SaveChangesAsync();
            }

        }

        public async Task UpdateAsync(Transport transport)
        {
            var toUpdateTransportIsNotNull = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == transport.Id) != null;
            if (toUpdateTransportIsNotNull)
            {
                _dbSet.Update(transport);
                await _context.SaveChangesAsync();
            }
        }

        Task<Transport> ITransportRepository.GetByIdWithTrackingAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}