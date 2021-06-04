using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hangar.HangarContracts;
using Hangar.Models.Hangar;
using Hangar.Orchestrators.Hangar;
using Microsoft.AspNetCore.Mvc;

namespace Hangar.Controllers
{
    [ApiController]
    [Route("api/[controllers]")]
    public class HangarController : ControllerBase
    {
        private readonly IHangarService _hangarService;
        private readonly IMapper _mapper;
        public HangarController(IMapper mapper, IHangarService hangarService)
        {
            _mapper = mapper;
            _hangarService = hangarService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var hangars = await _hangarService.GetAsync();
            return Ok(_mapper.Map<List<HangarContracts.Hangar>>(hangars));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(HangarContracts.Hangar hangar)
        {
            var hangarModel = _mapper.Map<Models.Hangar.Hangar>(hangar);
            var createdModel = await _hangarService.AddAsync(hangarModel);
            return Ok(_mapper.Map<HangarContracts.Hangar>(createdModel));


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var hangar = await _hangarService.GetByIdAsync(id);
            return Ok(_mapper.Map<HangarContracts.Hangar>(hangar));

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, UpdateLocation location)
        {
            var hangar = await _hangarService.Update(id, location.Location);
            return Ok(_mapper.Map<HangarContracts.Hangar>(hangar));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _hangarService.RemoveById(id);
            return Ok();

        }
    }
}