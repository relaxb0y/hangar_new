using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hangar.Models.Hangar;
using Microsoft.EntityFrameworkCore;

namespace Hangar.Dao.Hangar
{
    public class HangarRepository : IHangarRepository
    {
        private readonly IMapper _mapper;
        private readonly  HangarContext _context;
        public HangarRepository(IMapper mapper,
            HangarContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Models.Hangar.Hangar> AddAsync(Models.Hangar.Hangar hangar)
        {
            var entity = _mapper.Map<HangarDto>(hangar);
            var result = await _context.AddAsync(entity);
            return _mapper.Map<Models.Hangar.Hangar>(result.Entity);
        }

        public async Task<List<Models.Hangar.Hangar>> GetAsync()
        {
            var entities = await _context.Hangars
                .Include(b => b.AirCrafts)
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<Models.Hangar.Hangar>>(entities);
        }
        public async Task<Models.Hangar.Hangar> GetByIdAsync(int id)
        {
            var entity = await _context.Hangars.FirstAsync(x => x.Id == id);
            return _mapper.Map<Models.Hangar.Hangar>(entity);
        }
        public async Task RemoveById(int id)
        {
            var entity = await _context.Hangars.FirstAsync(x => x.Id == id);
            _context.Hangars.Remove(entity);

        }
        public async Task<Models.Hangar.Hangar> Update(int id, string location)
        {
            var hangarEntitiy = _mapper.Map<HangarDto>(location);
            var result = _context.Hangars.Update(hangarEntitiy);
            await _context.SaveChangesAsync();
            return _mapper.Map<Models.Hangar.Hangar>(result.Entity);
        }
    }
}