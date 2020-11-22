using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface IStateProvinceService
    {
        Task<IEnumerable<StateProvince>> GetAllWithCountry();
        Task<StateProvince> GetStateProvinceById(int id);
        Task<IEnumerable<StateProvince>> GetStatesProvincesByCountrytId(int countryId);
        Task<StateProvince> CreateStateProvince(StateProvince newStateProvince);
        Task UpdateStateProvince(StateProvince stateProvinceToBeUpdated, StateProvince stateProvince);
        Task DeleteStateProvince(StateProvince stateProvince);
    }
}
