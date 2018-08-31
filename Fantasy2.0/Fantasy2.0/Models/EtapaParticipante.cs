using Fantasy2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy2.Models
{
    [Table("ETAPAPARTICIPANTE", Schema = "FANTASY")]
    public class EtapaParticipante
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Participante")]
        public int FKParticipante { get; set; }
        public virtual Participante Participante { get; set; }

        [ForeignKey("Etapa")]
        public int FKEtapa { get; set; }
        public virtual Etapa Etapa { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a pontuacao do participante")]
        public double Pontuacao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Ano da Etapa")]
        public int Ano { get; set; }

        [NotMapped]
        public IEnumerable<Etapa> Etapas { get; set; }
         
         [NotMapped]
        public IEnumerable<Participante> Participantes { get; set; }
    }
}
