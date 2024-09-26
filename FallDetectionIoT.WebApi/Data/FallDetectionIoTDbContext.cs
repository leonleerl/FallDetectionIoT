using FallDetectionIoT.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FallDetectionIoT.WebApi.Data
{
    public class FallDetectionIoTDbContext : DbContext
    {
        public FallDetectionIoTDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SensorDataModel> SensorData { get; set; }
    }
}

