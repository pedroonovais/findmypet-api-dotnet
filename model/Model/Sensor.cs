using System;
using System.ComponentModel.DataAnnotations;

namespace library.Model
{
    public class Sensor
    {
        [Key]
        public Guid idSensor { get; set; }

        [MaxLength(15)]
        public required string tipoSensor { get; set; }

        public required decimal latitude { get; set; }

        public required decimal longitude { get; set; }

        public required bool ativo { get; set; }
    }
}
