using AircraftService.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AircraftService.Repositories
{
    // Aircraft Repository Interface
    // Aircraft Repository Interface
    public interface IAircraftRepository
    {
        Task<IEnumerable<Aircraft>> GetAllAircraftsAsync();
        Task<Aircraft> GetAircraftByIdAsync(int id);
        Task AddAircraftAsync(Aircraft aircraft);
        Task UpdateAircraftAsync(Aircraft aircraft);
        Task DeleteAircraftAsync(int id);
    }
}
