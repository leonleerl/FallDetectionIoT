using FallDetectionIoT.Shared.ModelDtos;
using FallDetectionIoT.Shared.Models;

namespace FallDetectionIoT.WebApi.Repositories.Interfaces
{
    public interface ISensorDataRepository
    {
        Task<IEnumerable<SensorDataModel>> GetAll();
        Task<int> Add(SensorDataModel sensorDataModel);
        Task<IEnumerable<SensorDataModel>> GetAll(string name);
    }
}
