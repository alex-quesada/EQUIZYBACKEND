using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Address> CreateAddress(Address newAddress)
        {
            await _unitOfWork.Addresses.AddAsync(newAddress);
            await _unitOfWork.CommitAsync();
            return newAddress;
        }

        public async Task DeleteAddress(Address address)
        {
            var addressDelete = await GetAddressById(address.Id);
            addressDelete.Status = 2;
            await _unitOfWork.CommitAsync();
        }

        public async Task<Address> GetAddressById(int id)
        {
            return await _unitOfWork.Addresses.GetWithCityByIdAsync(id);
        }

        public async Task<IEnumerable<Address>> GetAllWithCity(Guid id)
        {
            var result = new List<Address>();
            var addresses = await _unitOfWork.Addresses.GetAllWithCityAsync(id);
            foreach (var address in addresses)
            {
                if (address.Status < 2)
                {
                    result.Add(address);
                }
            }
            return result;
        }

        public async Task UpdateAddress(Address addressToBeUpdated, Address address)
        {
            addressToBeUpdated.TypeAddressId = address.TypeAddressId;
            addressToBeUpdated.AddressOne = address.AddressOne;
            addressToBeUpdated.AddressTwo = address.AddressTwo;
            addressToBeUpdated.OtherSigns = address.OtherSigns;
            addressToBeUpdated.ZipCode = address.ZipCode;
            addressToBeUpdated.CityId = address.CityId;
            await _unitOfWork.CommitAsync();
        }
    }
}
