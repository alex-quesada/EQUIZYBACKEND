using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class StateProvinceService : IStateProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StateProvinceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<StateProvince> CreateStateProvince(StateProvince newStateProvince)
        {
            await _unitOfWork.StatesProvinces.AddAsync(newStateProvince);
            await _unitOfWork.CommitAsync();
            return newStateProvince;
        }

        public async Task DeleteStateProvince(StateProvince stateProvince)
        {
            _unitOfWork.StatesProvinces.Remove(stateProvince);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<StateProvince>> GetAllWithCountry()
        {
            return await _unitOfWork.StatesProvinces.GetAllWithCountryAsync();
        }

        public async Task<StateProvince> GetStateProvinceById(int id)
        {
            return await _unitOfWork.StatesProvinces.GetByIdAsync(id);
        }

        public async Task<IEnumerable<StateProvince>> GetStatesProvincesByCountrytId(int countryId)
        {
            return await _unitOfWork.StatesProvinces.GetAllWithCountryByCountryIdAsync(countryId);
        }

        public async Task UpdateStateProvince(StateProvince stateProvinceToBeUpdated, StateProvince stateProvince)
        {
            stateProvinceToBeUpdated.Name = stateProvince.Name;
            stateProvinceToBeUpdated.CountryId = stateProvince.CountryId;
            await _unitOfWork.CommitAsync();
        }
    }
}
