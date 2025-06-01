using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Model
{
    public class Pessoa
    {
        [Key]
        public Guid idPessoa { get; set; }
        public required string nomePessoa { get; set; }
        
        public required string telefone { get; set; }

        public required string tipoPessoa { get; set; }

        public required string cpf { get; set; }
        
        public required string email { get; set; }

        public required string senha { get; set; }
    }
}
