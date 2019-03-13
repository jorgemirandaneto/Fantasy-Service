using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy_server.Models
{
    [Table("etapaparticipante", Schema = "develop")]
    public class EtapaParticipante
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Participante")]
        public int fk_participante { get; set; }
        [JsonIgnore]
        public virtual Participante Participante { get; set; }

        [ForeignKey("Etapa")]
        public int fk_etapa { get; set; }
        [JsonIgnore]
        public virtual Etapa Etapa { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a pontuacao do participante")]
        public double nota { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Ano da Etapa")]
        public int ano { get; set; }

        [NotMapped]
        public IEnumerable<Etapa> Etapas { get; set; }
         
        [NotMapped]
        public IEnumerable<Participante> Participantes { get; set; }
    }
}
