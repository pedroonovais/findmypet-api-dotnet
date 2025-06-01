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
        public int idReport { get; set; }

        public int idPessoa { get; set; }
        [ForeignKey("PessoaId")]
        public Pessoa pessoa { get; set; }

        public int idAnimal { get; set; }
        [ForeignKey("idAnimal")]
        public Animal animal { get; set; }

        public int idLocal { get; set; }
        [ForeignKey("idLocal")]
        public Local local { get; set; }

        public int idSensor { get; set; }
        [ForeignKey("idSensor")]
        public Sensor sensor { get; set; }

        public DateTime dataReport { get; set; }

        [MaxLength(255)]
        public required string descricaoLocal { get; set; }

        [MaxLength(15)]
        public required string statusReport { get; set; }
    }
}
