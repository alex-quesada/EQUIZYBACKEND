using EQUIZY.Core.Models;
using EQUIZY.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public CityRepository(MyEquizyDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<City>> GetAllWithStateProvinceAsync()
        {
            return await MyEquizyDbContext.Cities.Include(m => m.StateProvince).ToListAsync();
        }

        public async Task<IEnumerable<City>> GetAllWithStateProvinceByStateProvinceIdAsync(int stateProvinceId)
        {
            return await MyEquizyDbContext.Cities.Include(m => m.StateProvince).Where(m => m.StateProvinceId == stateProvinceId).ToListAsync();
        }

        public async Task<City> GetWithStateProvinceByIdAsync(int id)
        {
            return await MyEquizyDbContext.Cities.Include(m => m.StateProvince).SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<City> GetWithStateProvinceByNameAsync(string name)
        {
            return await MyEquizyDbContext.Cities.Include(m => m.StateProvince).SingleOrDefaultAsync(mbox => mbox.Name.ToLower().Trim() == name.ToLower().Trim());
        }
    }
}
