using AutoMapper;
using FallDetectionIoT.Shared.ModelDtos;
using FallDetectionIoT.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDetectionIoT.WPF.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SensorDataModel, SensorDataModelDto>();
        }
    }
}
