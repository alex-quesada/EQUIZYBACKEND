using EQUIZY.Core.Models;
using EQUIZY.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public CountryRepository(MyEquizyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Country>> GetAllWithStatesProvincesAsync()
        {
            return await MyEquizyDbContext.Countries.Include(a => a.StatesProvinces).ToListAsync();
        }

        public Task<Country> GetWithStatesProvincesByIdAsync(int id)
        {
            return MyEquizyDbContext.Countries.Include(a => a.StatesProvinces).SingleOrDefaultAsync(a => a.Id == id);
        }

        async Task<IEnumerable<Country>> ICountryRepository.GetAllWithStatesProvincesAsync()
        {
            return await MyEquizyDbContext.Countries.Include(a => a.StatesProvinces).ToListAsync();
        }

        async Task<Country> ICountryRepository.GetWithStatesProvincesByIdAsync(int id)
        {
            return await MyEquizyDbContext.Countries.Include(a => a.StatesProvinces).SingleOrDefaultAsync(a => a.Id == id);
        }

    }
}
