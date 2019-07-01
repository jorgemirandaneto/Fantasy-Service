using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyServer.Models
{
    [Table("participante", Schema = "develop")]
    public class Participante
    {
        public int id { get; set; }

        public string nome { get; set; }
        public string email { get; set; }
    }
}
