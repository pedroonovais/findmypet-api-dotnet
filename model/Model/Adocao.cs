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

        public int idPessoa { get; set; }

        [ForeignKey("idPessoa")]
        public Pessoa pessoa { get; set; }

        public int idAnimal { get; set; }

        [ForeignKey("idAnimal")]
        public Animal animal { get; set; }

        public DateTime dataAdocao { get; set; }

        [MaxLength(15)]
        public string tipoAdocao { get; set; }


    }
}
