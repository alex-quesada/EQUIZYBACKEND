using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllWithCity(Guid id);
        Task<Address> GetAddressById(int id);
        Task<Address> CreateAddress(Address newAddress);
        Task UpdateAddress(Address addressToBeUpdated, Address address);
        Task DeleteAddress(Address address);
    }
}
