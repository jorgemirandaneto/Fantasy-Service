using System;
using System.Collections.Generic;
using System.Linq;
using Fantasy_server.Context;
using Fantasy_server.Models;

namespace Fantasy_server.Dao
{
    public class EtapaParticipanteDao
    {
        private readonly FantasyContext _fantasyContext;

        public EtapaParticipanteDao(FantasyContext fantasyContext)
        {
            _fantasyContext = fantasyContext;
        }

        public bool validarNotaExistente(int fk_etapa, int fk_participante, int ano)
        {
            var nota = _fantasyContext.EtapaParticipantes.Any(x => x.fk_etapa == fk_etapa && x.fk_participante == fk_participante && x.ano == ano);
            if (nota)
                return true;
            else
                return false;
        }

        public bool ValidarParticipanteNota(int idEtapa)
        {
            var qtdParticipante = _fantasyContext.Participantes.Count();
            var qtdParticipantesEtapaNota = _fantasyContext.EtapaParticipantes.Count(x => x.fk_etapa == idEtapa && x.ano == DateTime.Now.Year);

            if (qtdParticipante == qtdParticipantesEtapaNota)
                return true;
            else
                return false;
        }

        public IEnumerable<EtapaParticipante> Vencedores(int idEtapa)
        {
            return _fantasyContext.EtapaParticipantes.Where(x => x.fk_etapa == idEtapa && x.ano == DateTime.Now.Year).OrderByDescending(x => x.nota).Take(3).ToList();
        }

        public IEnumerable<EtapaParticipante> Perdedores(int idEtapa)
        {
            var qtdParticipante = _fantasyContext.Participantes.Count();
            return _fantasyContext.EtapaParticipantes.Where(x => x.fk_etapa == idEtapa && x.ano == DateTime.Now.Year).OrderBy(x => x.nota).Take(3).OrderByDescending(x => x.nota).ToList();
        }

        public bool EtapaFinalizada(int idEtapa)
        {
            return _fantasyContext.Devedores.Any(x => x.fk_etapa_devedores == idEtapa);
        }
    }
}