using System.Linq;
using Fantasy_server.Context;

namespace Fantasy_server.Dao {
    public class EtapaParticipanteDao {
        private readonly FantasyContext _fantasyContext;

        public EtapaParticipanteDao (FantasyContext fantasyContext) {
            _fantasyContext = fantasyContext;
        }

        public bool validarNotaExistente (int fk_etapa, int fk_participante, int ano) {
            var nota = _fantasyContext.EtapaParticipantes.Where (x => x.fk_etapa == fk_etapa && x.fk_participante == fk_participante && x.ano == ano);
            if (nota == null)
                return true;
            else
                return false;
        }
    }
}