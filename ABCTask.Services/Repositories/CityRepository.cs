using ABCTask.Core;
using ABCTask.Data;
using ABCTask.DTO;
using ABCTask.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABCTask.Services.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly ABCTaskDbContext _context;
        private readonly IMapper _mapper;

        public CityRepository(ABCTaskDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this._context = dbContext;
            this._mapper = mapper;
        }
        public async Task<IList<CityDTO>> GetAllCities()
        {
            var cities = await _context.City.AsNoTracking().ToListAsync();
            return _mapper.Map<IList<CityDTO>>(cities);
        }
    }
}
