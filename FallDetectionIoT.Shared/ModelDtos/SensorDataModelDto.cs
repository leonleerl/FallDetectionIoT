﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FallDetectionIoT.Shared.ModelDtos
{
    public partial class SensorDataModelDto : ObservableObject
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime FallDate { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? accelX { get; set; }
        public string? accelY { get; set; }
        public string? accelZ { get; set; }
        [ObservableProperty]
        private bool _isChecked;
    }
}
