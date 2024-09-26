using FallDetectionIoT.Shared.ModelDtos;
using FallDetectionIoT.WebApi.Repositories.Interfaces;

namespace FallDetectionIoT.WebApi.Repositories
{
    public class SensorDataRepository : ISensorDataRepository
    {
        public async Task<IEnumerable<SensorDataModelDto>> GetAll()
        {
            return default!;
        }
    }
}
