using CarProject.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CarProject.Core.Models;
using CarProject.Core.Enums;
using System.Collections.Generic;

namespace CarProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IVehicleService _vehicleService;
        public VehicleController(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
            _vehicleService = serviceProvider.GetService<IVehicleService>();
        }

        [HttpPost("create-car")]
        [ProducesResponseType(typeof(CarModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostCarAsync([FromBody] CarPostModel request)
        {
            return Ok(await _vehicleService.PostCarAsync(request));
        }

        [HttpPost("create-bus")]
        [ProducesResponseType(typeof(BusModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostBusAsync([FromBody] BusPostModel request)
        {
            return Ok(await _vehicleService.PostBusAsync(request));
        }

        [HttpPost("create-boat")]
        [ProducesResponseType(typeof(BoatModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostBoatAsync([FromBody] BoatPostModel request)
        {
            return Ok(await _vehicleService.PostBoatAsync(request));
        }

        [HttpGet("get-cars")]
        [ProducesResponseType(typeof(List<CarModel>), StatusCodes.Status200OK)]
        public IActionResult GetCarsAsync([FromQuery] VehicleColor color)
        {
            return Ok(_vehicleService.GetCarsByColorAsync(color));
        }

        [HttpGet("get-boats")]
        [ProducesResponseType(typeof(List<BoatModel>), StatusCodes.Status200OK)]
        public IActionResult GetBoatsAsync([FromQuery] VehicleColor color)
        {
            return Ok(_vehicleService.GetBoatsByColorAsync(color));
        }

        [HttpGet("get-busses")]
        [ProducesResponseType(typeof(List<BusModel>), StatusCodes.Status200OK)]
        public IActionResult GetBussesAsync([FromQuery] VehicleColor color)
        {
            return Ok(_vehicleService.GetBussesByColorAsync(color));
        }

        [HttpDelete("delete-car")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteCarAsync([FromQuery] int carId)
        {
            return Ok(await _vehicleService.DeleteCarAsync(carId));
        }

        [HttpPost("switch-headlights")]
        [ProducesResponseType(typeof(CarModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> SwitchCarHeadlightsByIdAsync([FromQuery] int carId)
        {
            return Ok(await _vehicleService.SwitchCarHeadlightsByIdAsync(carId));
        }
    }
}
