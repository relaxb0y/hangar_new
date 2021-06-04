using System.Threading.Tasks;
using AutoMapper;
using Hangar.Models.Plane;
using Hangar.Orchestrators.Plane;
using Hangar.PlaneContracts;
using Microsoft.AspNetCore.Mvc;
using AirCraft = Hangar.PlaneContracts.AirCraft;


namespace Hangar.Controllers
{   [ApiController]
    [Route("[controllers]")]
    public class AirCraftController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlaneService _airCraftService;
        public AirCraftController(IMapper mapper, IPlaneService airCraftService)
        {
            _mapper = mapper;
            _airCraftService = airCraftService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var airPlanes = await _airCraftService.GetAsync();
            return Ok(_mapper.Map<Models.Plane.AirCraft>(airPlanes));
        }
        [HttpPost("hangars/{hangarId}/planes/")]
        public async Task<IActionResult> PostAsync(int hangarId, AirCraft airCraft)
        {
            var airCraftModel = _mapper.Map<Models.Plane.AirCraft>(airCraft);
            airCraftModel.HangarId = hangarId
                ;
            var createdModel = await _airCraftService.AddAsync(airCraftModel);
            return Ok(_mapper.Map<Models.Plane.AirCraft>(createdModel));
        }
        [HttpGet("hangars/{hangarId}/planes/")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var airCraft = await _airCraftService.GetByIdAsync(id);
            return Ok(_mapper.Map<Models.Plane.AirCraft>(airCraft));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]UpdateDescription description)
        {
            await _airCraftService.Update(id, description.Description);
            return Ok(_mapper.Map<AirCraft>(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            await _airCraftService.RemoveById(id);
            return Ok();
        }
    }
}