using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fantasy_server.Models
{
    [Table("devedores", Schema = "develop")]
    public class Devedores
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("fk_participante_ganhardor")]
        public virtual Participante participante_ganhador { get; set; }

        public int fk_participante_ganhardor { get; set; }

        [ForeignKey("fk_participante_perdedor")]
        public virtual Participante participante_perdedor { get; set; }

        public int fk_participante_perdedor { get; set; }
        
        [MaxLength(1)]
        public string pago { get; set; }
    }
}