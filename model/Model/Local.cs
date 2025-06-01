using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Model
{
    public class Local
    {
        [Key]
        public Guid idLocal { get; set; }

        public required string cidade { get; set; }

        public required string estado { get; set; }

        public required string tipoDesastre { get; set; }

        public required DateTime dataOcorrencia { get; set; }
    }
}
