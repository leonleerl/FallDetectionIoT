using FallDetectionIoT.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDetectionIoT.WPF.Services.Interfaces
{
    public interface ISensorDataService
    {
        Task<IEnumerable<SensorDataModel>> GetAll();
        Task<IEnumerable<SensorDataModel>> GetAllByName(string name);
    }
}
