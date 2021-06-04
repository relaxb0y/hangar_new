using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hangar.Models.Hangar;

namespace Hangar.Orchestrators.Hangar
{
    public class HangarService : IHangarService
    {
        private readonly IHangarRepository _hangarRepository;
        public HangarService(IHangarRepository hangarRepository)
        {
            _hangarRepository = hangarRepository ;
        }
        public async Task<Models.Hangar.Hangar> AddAsync(Models.Hangar.Hangar hangar)
        {
            return await _hangarRepository.AddAsync(hangar); 
        }
        public  async Task<List<Models.Hangar.Hangar>> GetAsync()
        {
            return await _hangarRepository.GetAsync();
        }
        public async Task<Models.Hangar.Hangar> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException();
            return await _hangarRepository.GetByIdAsync(id);
        }
        public async Task<Models.Hangar.Hangar> Update(int id, string location)
        {
            var hangar = await _hangarRepository.GetByIdAsync(id);
            if (hangar == null)
                throw new ArgumentNullException();
            
            hangar.Location = location;
            var updateHangar = await _hangarRepository.Update(id, location);
            return updateHangar;
        }
        public async Task RemoveById(int id)
        {
            var hangar = await _hangarRepository.GetByIdAsync(id);
            if (hangar == null)
                throw new ArgumentOutOfRangeException();
            await _hangarRepository.RemoveById(id);
        }
    }
}