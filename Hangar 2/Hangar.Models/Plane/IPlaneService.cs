using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hangar.Models.Plane
{
    public interface IPlaneService
    {
        Task<List<AirCraft>> GetAsync();
        Task<AirCraft> GetByIdAsync(int id);
        Task<AirCraft> Update(int id, string location);
        Task RemoveById(int id);
        Task<AirCraft> AddAsync(AirCraft airCraft);
    }
}