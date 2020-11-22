using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface ITypeAddressService
    {
        Task<IEnumerable<TypeAddress>> GetAllTypeAddress();
        Task<TypeAddress> GetTypeAddressById(int id);
        Task<TypeAddress> CreateTypeAddress(TypeAddress newTypeAddress);
        Task UpdateTypeAddress(TypeAddress typeAddressToUpdate, TypeAddress typeAddress);
        Task DeleteTypeAddress(TypeAddress typeAddress);
    }
}
