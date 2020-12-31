using ABCTask.Core;
using ABCTask.Data;
using ABCTask.DTO;
using ABCTask.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCTask.Services.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        private readonly ABCTaskDbContext _context;
        private readonly IMapper _mapper;

        public LocationRepository(ABCTaskDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this._context = dbContext;
            this._mapper = mapper;
        }

        public async Task<LocationDTOPost> CreateLocation(LocationDTOPost model)
        {
            try
            {
                var location = _mapper.Map<Location>(model);
                await _context.AddAsync(location);
                var success = await _context.SaveChangesAsync() > 0; // kjo e kthen ni bool nese u kry me sukses ose jo
                if (success) return model;
                else
                    return null;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                if (ex.InnerException != null)
                    error = ex.InnerException.Message;
                return null;
            }
        }
        public async Task<IList<LocationDTO>> GetAllLocation()
        {
            var locations = await _context.Location.Include(x => x.City).ToListAsync();
            return _mapper.Map<IList<LocationDTO>>(locations);
        }
        public async Task<LocationDTO> GetLocationById(int id)
        {
            var locations = await _context.Location.Include(d => d.City).AsNoTracking().FirstOrDefaultAsync(x=> x.Id==id);
            return _mapper.Map<LocationDTO>(locations);
        }
        public async Task<LocationDTOPUT> GetLocation(int id)
        {
            var locations = await _context.Location.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<LocationDTOPUT>(locations);
        }
        public async Task<bool> LocationExists(int id)
        {
            return await _context.Location.AnyAsync(u => u.Id == id);
        }

        public async Task<bool> ModifyEntity(LocationDTOPUT model)
        {
            var entity = _mapper.Map<Location>(model);
            _context.Entry(entity).State = EntityState.Modified; //modified state of the entity
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
