using System.Collections.Generic;
using Fantasy2.Context;
using Fantasy2.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Fantasy2.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class EtapaParticipanteController : ControllerBase
    {
        private readonly FantasyContext _context;

        public EtapaParticipanteController(FantasyContext context)
        {
            _context = context;
        }
        [HttpGet("{idEtapa}"), Route("NotasEtapas")]
        public EtapaParticipanteVM getNota(int idEtapa)
        {
            try
            {
                var NotasEtapas = from nota in _context.EtapaParticipantes
                                  where (nota.Id == idEtapa)
                                  select new EtapaParticipante
                                  {
                                      Pontuacao = nota.Pontuacao,
                                      Ano = nota.Ano,
                                      Etapas = (from e in _context.Etapas
                                                where e.Id == nota.FKEtapa
                                                select new Etapa
                                                {
                                                    Id = e.Id,
                                                    Nome = e.Nome
                                                }
                                     ),
                                      Participantes = (from p in _context.Participantes
                                                       where p.id == nota.FKParticipante
                                                       select new Participante
                                                       {
                                                           nome = p.nome,
                                                       }
                                     )
                                  };
                if (idEtapa != null)
                    NotasEtapas = NotasEtapas.Where(n => n.FKEtapa == idEtapa);

                var etapa = new EtapaParticipanteVM
                {
                    etapasParticipantes = NotasEtapas
                };
                return etapa;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


    }
}