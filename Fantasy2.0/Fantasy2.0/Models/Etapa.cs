using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy2.Models
{
    [Table("ETAPA", Schema = "FANTASY")]
    public class Etapa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome da Etapa")]
        [StringLength(255, ErrorMessage = "O tamanho máximo do Nome da Etapa é de 255 caracteres")]
        public string Nome { get; set; }        
    }
}
