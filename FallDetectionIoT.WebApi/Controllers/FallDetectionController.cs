using FallDetectionIoT.Shared.ModelDtos;
using FallDetectionIoT.Shared.Models;
using FallDetectionIoT.WebApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FallDetectionIoT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FallDetectionController : ControllerBase
    {
        private readonly ISensorDataRepository _sensorDataRepository;

        public FallDetectionController(ISensorDataRepository sensorDataRepository)
        {
            _sensorDataRepository = sensorDataRepository;
        }

        // GET api/sensor
        [HttpGet]
        public async Task<IActionResult> GetSensorData()
        {
            var results = await _sensorDataRepository.GetAll();

            return Ok(results);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetSensorData(string name)
        {
            var results = await _sensorDataRepository.GetAllByName(name);
            return Ok(results);
        }

        // POST api/sensor
        [HttpPost]
        public async Task<IActionResult> ReceiveSensorData([FromBody] SensorDataModelDto sensorDataDto)
        {
            if (sensorDataDto == null)
            {
                return BadRequest("ASP.NET Core WebAPI: Sensor data is null");
            }

            var sensorDataModel = new SensorDataModel
            {
                Id = Guid.NewGuid(),
                Name = sensorDataDto.Name,
                FallDate = DateTime.Now,
                Longitude = sensorDataDto.Longitude,
                Latitude = sensorDataDto.Latitude,
                accelX = sensorDataDto.accelX,
                accelY = sensorDataDto.accelY,
                accelZ = sensorDataDto.accelZ
            };

            await _sensorDataRepository.Add(sensorDataModel);

            return Ok(new { message = "Data received and saved successfully", data = sensorDataDto });
        }
    }
}
