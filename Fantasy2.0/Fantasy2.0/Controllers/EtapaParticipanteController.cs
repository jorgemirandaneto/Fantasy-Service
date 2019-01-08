using System.Collections.Generic;
using Fantasy2.Context;
using Fantasy2.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Fantasy2.Dao;

namespace Fantasy2.Controllers
{
    [Route("api/EtapaParticipante")]
    [EnableCors("AllowSpecificOrigin")]   
    public class EtapaParticipanteController : ControllerBase
    {
        private readonly FantasyContext _context;
        private EtapaParticipanteDao _etapa;
        public EtapaParticipanteController(FantasyContext context, EtapaParticipanteDao etapa)
        {
            _context = context;
            _etapa = etapa;
        }

        [EnableCors("AllowSpecificOrigin")]  
        [HttpPost, Route("SalvarNota")]
        public IActionResult Post([FromBody] EtapaParticipante etapaParticipante){
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
        [HttpGet(),Route("Etapa")]
        public IEnumerable<Etapa> getEtapa(){
            var etapa = (from e in _context.Etapas
            select new Etapa{
                id = e.id,
                nome = e.nome
            }   
            ).OrderBy(o => o.id).ToList();
            return etapa;                      
        }         
    }    
}