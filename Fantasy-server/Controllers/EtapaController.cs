using System;
using System.Collections.Generic;
using System.Linq;
using Fantasy_server.Context;
using Fantasy_server.Dao;
using Fantasy_server.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy_server.Controllers
{   
    [Produces ("application/json")]
    [Route ("api/Etapa")]
    [EnableCors ("AllowSpecificOrigin")]
    public class EtapaController : ControllerBase
    {
        private readonly FantasyContext _context;
        private readonly EtapaParticipanteDao _etapa;
        public EtapaController(FantasyContext context, EtapaParticipanteDao etapa)
        {
            this._context = context;
            this._etapa = etapa;
        }

         [HttpPost, Route("SalvarNota")]
        public IActionResult Post(
            [FromBody] EtapaParticipante etapaParticipante)
            {
            if(etapaParticipante.fk_participante.ToString() == null)
                return NotFound();

            
            bool notaExistente = _etapa.validarNotaExistente(etapaParticipante.fk_etapa, etapaParticipante.fk_participante, DateTime.Now.Year);
            if(!notaExistente)
                return NotFound("A nota desse participante já foi preenchida!");

            EtapaParticipante e = new EtapaParticipante();
            e.fk_etapa = etapaParticipante.fk_etapa;
            e.fk_participante = etapaParticipante.fk_participante;
            e.nota = etapaParticipante.nota;
            e.ano = DateTime.Now.Year;                
            _context.Add(etapaParticipante);
            _context.SaveChanges();
            return NoContent();
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

        [HttpGet,Route("etapas")]
         public List<Etapa> getEtapa(){
            var etapa = _context.Etapas.ToList();
            return etapa;                      
        }       
    }
}