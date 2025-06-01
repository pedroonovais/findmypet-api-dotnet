using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library.Model
{
    public class Sensor
    {
        [Key]
        public Guid idSensor { get; set; }

        [MaxLength(15)]
        public required string tipoSensor { get; set; }

        [Column(TypeName = "decimal(18,15)")]
        public required decimal latitude { get; set; }

        [Column(TypeName = "decimal(18,15)")]
        public required decimal longitude { get; set; }

        public required bool ativo { get; set; }
    }
}
