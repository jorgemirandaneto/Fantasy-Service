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
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome da Etapa")]
        [StringLength(255, ErrorMessage = "O tamanho máximo do Nome da Etapa é de 255 caracteres")]
        public string nome { get; set; }        
    }
}
