using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDetectionIoT.Shared.Models
{
    [Table("FallDetecionTable")]
    public class SensorDataModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime FallDate { get; set; }
        [Required]
        public string? Longitude { get; set; }
        [Required]
        public string? Latitude { get; set; }
        [Required]
        public string? accelX { get; set; }
        [Required]
        public string? accelY { get; set; }
        [Required]
        public string? accelZ { get; set; }

    }
}
