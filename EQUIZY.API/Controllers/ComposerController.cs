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
    public class ComposerController : ControllerBase
    {
        private readonly IComposerService _composerService;
        private readonly IMapper _mapper;
        public ComposerController(IComposerService composerService, IMapper mapper)
        {
            _composerService = composerService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ComposerResource>>> GetAllComposers()
        {
            var composers = await _composerService.GetAllComposers();
            var composerResources = _mapper.Map<IEnumerable<Composer>, IEnumerable<ComposerResource>>(composers);
            return Ok(composerResources);

        }

        [HttpPost("")]
        public async Task<ActionResult<ComposerResource>> CreateComposer([FromBody] SaveComposerResource saveComposerResource)
        {
            var composer = _mapper.Map<SaveComposerResource, Composer>(saveComposerResource);
            var composerCreated = await _composerService.Create(composer);
            var composerResource = _mapper.Map<Composer, ComposerResource>(composerCreated);
            return Ok(composerResource);


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryResource>> GetComposerById(string id)
        {
            var composer = await _composerService.GetComposerById(id);
            if (composer == null)
            {
                return NotFound();
            }
            var composerResource = _mapper.Map<Composer, ComposerResource>(composer);
            return Ok(composerResource);
        }
    }
}
