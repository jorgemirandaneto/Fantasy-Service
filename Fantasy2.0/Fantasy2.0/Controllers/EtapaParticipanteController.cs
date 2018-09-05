using System.Collections.Generic;
using Fantasy2.Context;
using Fantasy2.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Fantasy2.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]   
    [Authorize()] 
    public class EtapaParticipanteController : ControllerBase
    {
        private readonly FantasyContext _context;

        public EtapaParticipanteController(FantasyContext context)
        {
            _context = context;
        }
        [HttpGet("{idEtapa}"), Route("NotasEtapas")]
        public IEnumerable<EtapaParticipante> getNota(int idEtapa)
        {       
            try
            {
                var NotasEtapas = (from nota in _context.EtapaParticipantes
                                  where (nota.fk_etapa == idEtapa)
                                  select new EtapaParticipante
                                  {
                                      id = nota.id,
                                      nota = nota.nota,
                                      ano = nota.ano,
                                      fk_etapa =nota.fk_etapa,
                                      fk_participante = nota.fk_participante,
                                      Etapas = (from e in _context.Etapas
                                                where e.id == nota.fk_etapa
                                                select new Etapa
                                                {
                                                    id = e.id,
                                                    nome = e.nome
                                                }
                                     ),
                                      Participantes = (from p in _context.Participantes
                                                       where p.id == nota.fk_participante
                                                       select new Participante
                                                       {
                                                           id =p.id,
                                                           nome = p.nome,
                                                           email = p.email
                                                       }
                                     )
                                  }).OrderByDescending(o => o.nota).ToList();
                return NotasEtapas;                      
            }
            catch (System.Exception)
            {                
                throw;
            }                 
        }        
    }
}