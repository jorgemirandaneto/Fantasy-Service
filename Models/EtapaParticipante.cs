using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyServer.Models
{
    [Table("etapaparticipante", Schema = "develop")]
    public class EtapaParticipante
    {
        public int id { get; set; }

        public int fk_participante { get; set; }
        [JsonIgnore]

        [ForeignKey("fk_participante")]
        public virtual Participante Participante { get; set; }

        public int fk_etapa { get; set; }
        [JsonIgnore]

        [ForeignKey("fk_etapa")]
        public virtual Etapa Etapa { get; set; }


        public double nota { get; set; }

        public int ano { get; set; }

        [NotMapped]
        public IEnumerable<Etapa> Etapas { get; set; }
         
        [NotMapped]
        public IEnumerable<Participante> Participantes { get; set; }
    }
}
