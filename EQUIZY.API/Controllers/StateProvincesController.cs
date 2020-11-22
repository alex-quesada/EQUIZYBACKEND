using AutoMapper;
using EQUIZY.API.Resources;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateProvincesController :ControllerBase
    {
        private readonly IStateProvinceService _stateProvinceService;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public StateProvincesController(IStateProvinceService stateProvinceService, IMapper mapper, ICountryService countryService)
        {
            _stateProvinceService = stateProvinceService;
            _mapper = mapper;
            _countryService = countryService;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<StateProvinceResource>>> GetAllStatesProvinces()
        {
            var statesProvinces = await _stateProvinceService.GetAllWithCountry();
            var stateProvinceResources = _mapper.Map<IEnumerable<StateProvince>, IEnumerable<StateProvinceResource>>(statesProvinces);
            return Ok(stateProvinceResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StateProvinceResource>> GetMusicById(int id)
        {
            var stateProvince = await _stateProvinceService.GetStateProvinceById(id);
            if (stateProvince == null)
            {
                return NotFound();
            }
            var stateProvinceResource = _mapper.Map<StateProvince, StateProvinceResource>(stateProvince);
            return Ok(stateProvinceResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<StateProvinceResource>> CreateMusic([FromBody] SaveStateProvinceResource saveStateProvinceResource)
        {
            var stateProvince = _mapper.Map<SaveStateProvinceResource, StateProvince>(saveStateProvinceResource);
            var newStateProvince = await _stateProvinceService.CreateStateProvince(stateProvince);
            return Ok(newStateProvince);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<StateProvinceResource>> UpdateMusic(int id, [FromBody] SaveStateProvinceResource updateStaProRes)
        {
            var stProToUpdate = await _stateProvinceService.GetStateProvinceById(id);

            if (stProToUpdate == null)
            {
                return NotFound();
            }

            var stProUpdate = _mapper.Map<SaveStateProvinceResource, StateProvince>(updateStaProRes);
            await _stateProvinceService.UpdateStateProvince(stProToUpdate, stProUpdate);

            var stProNewUpdate = await _stateProvinceService.GetStateProvinceById(id);
            var stProUpdateResource = _mapper.Map<StateProvince, StateProvinceResource>(stProNewUpdate);
            return Ok(stProUpdateResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStateProvince(int id)
        {
            var stateProvince = await _stateProvinceService.GetStateProvinceById(id);
            if (stateProvince == null)
            {
                return NotFound();
            }
            await _stateProvinceService.DeleteStateProvince(stateProvince);

            return NoContent();

        }

        [HttpGet("Country/id")]
        public async Task<ActionResult<IEnumerable<StateProvinceResource>>> GetAllMusicsByArtistID(int id)
        {
            var country = await _countryService.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            var statesProvinces = await _stateProvinceService.GetStatesProvincesByCountrytId(id);
            var staProResource = _mapper.Map<IEnumerable<StateProvince>, IEnumerable<StateProvinceResource>>(statesProvinces);
            return Ok(staProResource);

        }
    }
}
