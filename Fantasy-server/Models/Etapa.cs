using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy_server.Models
{
    [Table("etapa", Schema = "develop")]
    public class Etapa
    {
        public int id { get; set; }
        public string nome { get; set; }        
    }
}
