using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Model
{
    public class Adocao
    {
        [Key]
        public Guid idAdocao { get; set; }

        public Guid idPessoa { get; set; }

        public Guid idAnimal { get; set; }

        public DateTime dataAdocao { get; set; }

        [MaxLength(15)]
        public string tipoAdocao { get; set; }

    }
}
