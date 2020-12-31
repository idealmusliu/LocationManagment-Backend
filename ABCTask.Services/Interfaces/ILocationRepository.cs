using ABCTask.Core;
using ABCTask.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABCTask.Services.Interfaces
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        Task<LocationDTOPost> CreateLocation(LocationDTOPost model);
        Task<bool> LocationExists(int id);
        Task<IList<LocationDTO>> GetAllLocation();
        Task<LocationDTO> GetLocationById(int id);
        Task<bool> ModifyEntity(LocationDTOPUT model);
        Task<LocationDTOPUT> GetLocation(int id);
    }
}
