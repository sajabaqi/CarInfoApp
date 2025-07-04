using CarInfoApiApp.DTOs;
using CarInfoApiApp.Models;
using CarInfoApiApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarInfoApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly IMakeService _makeService;

        public MakesController(IMakeService makeService)
        {
            _makeService = makeService;
        }

        [HttpGet("allMakes")]
        public async Task<ActionResult<List<Makes>>> GetAllMakes()
        {
            try
            {
                var makes = await _makeService.GetAllMakesAsync();

                return Ok(makes);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while fetching makes");
            }
        }

        [HttpGet("{makeId}/vehicle-types")]
        public async Task<ActionResult<List<VehicleType>>> GetVehicleTypesForMake(int makeId)
        {
            try
            {
                if (makeId > 0)
                {
                    var vehicleTypes = await _makeService.GetVehicleTypesForMakeAsync(makeId);
                    return Ok(vehicleTypes);
                }
                else
                {
                    return BadRequest("Error Make ID");
                }
                

                
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while fetching vehicle types");
            }
        }
        
        [HttpGet("{makeId}/make-model/{modelyear}")]
        public async Task<ActionResult<List<MakeModel>>> GetMakeModels(int makeId, int modelyear)
        {
            try
            {
                if (makeId > 0)
                {
                    var makeModels = await _makeService.GetModelsForMakeAndYearAsync(makeId, modelyear);
                    return Ok(makeModels);
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while fetching makes model");
            }
        }

    }
}
