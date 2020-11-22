using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Repositories
{
    public interface ITypeAddressRepository : IRepository<TypeAddress>
    {
        Task<IEnumerable<TypeAddress>> GetAllTypeAddressAsync();
        Task<TypeAddress> GetTypesAddressByIdAsync(int id);
    }
}
