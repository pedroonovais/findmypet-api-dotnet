using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Model
{
    public class Animal
    {
        [Key]
        public Guid idAnimal { get; set; }

        public required string nomeAnimal { get; set; }

        public required string especie { get; set; }

        public required string porte { get; set; }

        public required int idadeEstimada { get; set; }

        public required string status { get; set; }
    }
}
