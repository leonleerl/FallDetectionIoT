using FallDetectionIoT.Shared.ModelDtos;
using FallDetectionIoT.Shared.Models;
using FallDetectionIoT.WebApi.Data;
using FallDetectionIoT.WebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FallDetectionIoT.WebApi.Repositories
{
    public class SensorDataRepository : ISensorDataRepository
    {
        private readonly FallDetectionIoTDbContext _context;

        public SensorDataRepository(FallDetectionIoTDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SensorDataModel>> GetAll()
        {
            var results = await _context.SensorData.ToListAsync();
            return results;
        }

        public async Task<int> Add(SensorDataModel sensorDataModel)
        {
            await _context.SensorData.AddAsync(sensorDataModel);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SensorDataModel>> GetAllByName(string name)
        {
            var results = await _context.SensorData.Where(p => p.Name.Contains(name)).ToListAsync();
            return results;
        }
    }
}
