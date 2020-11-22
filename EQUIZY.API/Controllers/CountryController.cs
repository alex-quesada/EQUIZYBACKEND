using AutoMapper;
using EQUIZY.API.Resources;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;
        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CountryResource>>> GetAllCountries()
        {
            var countries = await _countryService.GetAllCountries();
            var countryResource = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(countries);
            return Ok(countryResource);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryResource>> GetCountryById(int id)
        {
            var country = await _countryService.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            var countryResource = _mapper.Map<Country, CountryResource>(country);
            return Ok(countryResource);
        }
        [HttpPost("")]
        public async Task<ActionResult<CountryResource>> CreateCountry([FromBody] SaveCountryResource saveCountryResource)
        {
            var country = _mapper.Map<SaveCountryResource, Country>(saveCountryResource);
            var newCountry = await _countryService.CreateCountry(country);
            var countryCreated = await _countryService.GetCountryById(newCountry.Id);
            var countryResource = _mapper.Map<Country, CountryResource>(countryCreated);
            return Ok(countryResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CountryResource>> UpdateCountry(int id, [FromBody] SaveCountryResource saveCountryResource)
        {
            var countryToUpdate = await _countryService.GetCountryById(id);
            if (countryToUpdate == null)
            {
                return NotFound();
            }
            var country = _mapper.Map<SaveCountryResource, Country>(saveCountryResource);
            await _countryService.UpdateCountry(countryToUpdate, country);
            var countryUpdated = await _countryService.GetCountryById(id);
            var countryResource = _mapper.Map<Country, CountryResource>(countryUpdated);
            return Ok(countryResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countryService.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            await _countryService.DeleteCountry(country);
            return NoContent();
        }
    }

}
