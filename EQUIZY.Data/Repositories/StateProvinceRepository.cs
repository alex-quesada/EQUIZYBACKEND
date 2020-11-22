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
    public class StateProvinceRepository : Repository<StateProvince>, IStateProvinceRepository
    {
        private MyEquizyDbContext MyEquizyDbContext
        {
            get { return Context as MyEquizyDbContext; }
        }
        public StateProvinceRepository(MyEquizyDbContext context)
            : base(context)
        { }

        async Task<IEnumerable<StateProvince>> IStateProvinceRepository.GetAllWithCountryAsync()
        {
            return await MyEquizyDbContext.StatesProvinces.Include(m => m.Country).ToListAsync();
        }

        async Task<StateProvince> IStateProvinceRepository.GetWithCountryByIdAsync(int id)
        {
            return await MyEquizyDbContext.StatesProvinces.Include(m => m.Country).SingleOrDefaultAsync(m => m.Id == id);
        }

        async Task<IEnumerable<StateProvince>> IStateProvinceRepository.GetAllWithCountryByCountryIdAsync(int countryId)
        {
            return await MyEquizyDbContext.StatesProvinces.Include(m => m.Country).Where(m => m.CountryId == countryId).ToListAsync();
        }
    }
}
