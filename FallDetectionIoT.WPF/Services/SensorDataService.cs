using System.Net.Http;
using System.Text.Json;
using FallDetectionIoT.Shared.Models;
using FallDetectionIoT.WPF.Services.Interfaces;

namespace FallDetectionIoT.WPF.Services
{
    public class SensorDataService : ISensorDataService
    {
        private readonly HttpClient _httpClient;

        public SensorDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SensorDataModel>> GetAll()
        {
            var response = await _httpClient.GetAsync("http://localhost:5278/api/FallDetection");
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();

            var sensorData = JsonSerializer.Deserialize<IEnumerable<SensorDataModel>>(responseData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return sensorData ?? Enumerable.Empty<SensorDataModel>();
        }

        public async Task<IEnumerable<SensorDataModel>> GetAll(string name)
        {
            var response = await _httpClient.GetAsync("http://localhost:5278/api/FallDetection/"+name);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();

            var sensorData = JsonSerializer.Deserialize<IEnumerable<SensorDataModel>>(responseData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return sensorData ?? Enumerable.Empty<SensorDataModel>();
        }
    }
}
