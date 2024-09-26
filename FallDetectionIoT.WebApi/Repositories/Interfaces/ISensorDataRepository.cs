using FallDetectionIoT.Shared.ModelDtos;

namespace FallDetectionIoT.WebApi.Repositories.Interfaces
{
    public interface ISensorDataRepository
    {
        Task<IEnumerable<SensorDataModelDto>> GetAll();
    }
}
