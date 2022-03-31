using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WMI_Api.Services.Broker;

namespace WMI_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WMIController : ControllerBase
    {
        private readonly IDataAccessServices _accessServices;

        public WMIController(IDataAccessServices accessServices)
        {
            _accessServices = accessServices ?? throw new ArgumentNullException(nameof(IDataAccessServices));
        }

        [HttpGet("Vehicles")]
        public async Task<IActionResult> GetListVehicle(string country, string searchByName, string searchByWMI, string searchByVehicleType)
        {
            return Ok(await _accessServices.GetAllVehicle(country, searchByName, searchByWMI, searchByVehicleType));
        }

        [HttpGet("Country")]
        public async Task<IActionResult> GetCountry()
        {
            return Ok(await _accessServices.GetCountry());
        }

    }
}
