using FallDetectionIoT.Shared.ModelDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FallDetectionIoT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FallDetectionController : ControllerBase
    {
        private static List<SensorDataModelDto> sensorDataStore = new List<SensorDataModelDto>();
        // GET api/sensor
        [HttpGet]
        public IActionResult GetSensorData()
        {
            return Ok(sensorDataStore);
        }

        // POST api/sensor
        [HttpPost]
        public IActionResult ReceiveSensorData([FromBody] SensorDataModelDto sensorData)
        {
            if (sensorData == null)
            {
                return BadRequest("ASP.NET Core WebAPI: Sensor data is null");
            }

            sensorData.Id = Guid.NewGuid();
            sensorData.FallDate = DateTime.Now;

            sensorDataStore.Add(sensorData);

            return Ok(new { message = "Data received successfully", data = sensorData });
        }

    }
}
