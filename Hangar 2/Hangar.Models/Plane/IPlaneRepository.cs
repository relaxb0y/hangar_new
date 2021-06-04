using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hangar.Models.Plane
{
    public interface IPlaneRepository
    {
        Task<List<AirCraft>> GetAsync();
        Task<AirCraft> GetByIdAsync(int id);
        Task<AirCraft> Update(int id, string description);
        Task RemoveById(int id);
        Task<AirCraft> AddAsync(AirCraft airCraft);
    }
}