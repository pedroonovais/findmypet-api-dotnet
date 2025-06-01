using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Model
{
    public class Report
    {
        [Key]
        public Guid idReport { get; set; }

        public Guid idPessoa { get; set; }

        public Guid idAnimal { get; set; }

        public Guid idLocal { get; set; }

        public Guid idSensor { get; set; }

        public DateTime dataReport { get; set; }

        [MaxLength(255)]
        public required string descricaoLocal { get; set; }

        [MaxLength(15)]
        public required string statusReport { get; set; }
    }
}
