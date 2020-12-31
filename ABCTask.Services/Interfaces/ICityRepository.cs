using ABCTask.Core;
using ABCTask.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABCTask.Services.Interfaces
{
    public interface ICityRepository: IGenericRepository<City>
    {
        Task<IList<CityDTO>> GetAllCities();
    }
}
