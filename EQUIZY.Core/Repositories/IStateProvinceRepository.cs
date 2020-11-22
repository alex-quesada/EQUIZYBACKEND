using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface IStateProvinceRepository : IRepository<StateProvince>
    {
        Task<IEnumerable<StateProvince>> GetAllWithCountryAsync();
        Task<StateProvince> GetWithCountryByIdAsync(int id);
        Task<IEnumerable<StateProvince>> GetAllWithCountryByCountryIdAsync(int countryId);
    }
}
