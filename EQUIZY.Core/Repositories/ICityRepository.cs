using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface ICityRepository : IRepository<City>
    {
        Task<IEnumerable<City>> GetAllWithStateProvinceAsync();
        Task<City> GetWithStateProvinceByIdAsync(int id);
        Task<City> GetWithStateProvinceByNameAsync(string name);
        Task<IEnumerable<City>> GetAllWithStateProvinceByStateProvinceIdAsync(int countryId);
    }
}
