using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy2.Models
{
    [Table("participante", Schema = "fantasy")]
    public class Participante
    {
        [Key]
        public int id { get; set; }

        public string nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Email do Participante")]
        public string email { get; set; }
    }
}
