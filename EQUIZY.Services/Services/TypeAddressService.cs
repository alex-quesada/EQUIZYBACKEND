using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class TypeAddressService : ITypeAddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeAddressService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<TypeAddress> CreateTypeAddress(TypeAddress newTypeAddress)
        {
            await _unitOfWork.TypesAddress
                .AddAsync(newTypeAddress);
            await _unitOfWork.CommitAsync();
            return newTypeAddress;
        }

        public async Task DeleteTypeAddress(TypeAddress typeAddress)
        {
            _unitOfWork.TypesAddress.Remove(typeAddress);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TypeAddress>> GetAllTypeAddress()
        {
            return await _unitOfWork.TypesAddress.GetAllAsync();
        }

        public async Task<TypeAddress> GetTypeAddressById(int id)
        {
            return await _unitOfWork.TypesAddress.GetByIdAsync(id);
        }

        public async Task UpdateTypeAddress(TypeAddress typeAddressToUpdate, TypeAddress typeAddress)
        {
            typeAddressToUpdate.Type = typeAddress.Type;
            await _unitOfWork.CommitAsync();
        }
    }
}
