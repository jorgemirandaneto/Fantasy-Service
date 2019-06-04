using System;
using System.Collections.Generic;
using System.Linq;
using Fantasy_server.Context;
using Fantasy_server.Dao;
using Fantasy_server.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fantasy_server.Controllers
{
    [Produces("application/json")]
    [Route("api/Etapa")]
    [EnableCors("AllowSpecificOrigin")]
    public class EtapaController : ControllerBase
    {
        private readonly FantasyContext _context;
        public EtapaController(FantasyContext context)
        {
            this._context = context;
        }

        [HttpPost, Route("SalvarNota")]
        public IActionResult Post(
           [FromBody] EtapaParticipante etapaParticipante)
        {
            if (etapaParticipante.fk_participante.ToString() == null)
                return NotFound();

            var etapa = new EtapaParticipanteDao(_context);
            bool notaExistente = etapa.validarNotaExistente(etapaParticipante.fk_etapa, etapaParticipante.fk_participante, DateTime.Now.Year);
            if (notaExistente)
                return NotFound("A nota desse participante já foi preenchida!");

            EtapaParticipante e = new EtapaParticipante();

            e.fk_etapa = etapaParticipante.fk_etapa;
            e.fk_participante = etapaParticipante.fk_participante;
            e.nota = etapaParticipante.nota;
            e.ano = DateTime.Now.Year;
            _context.EtapaParticipantes.Add(e);
            _context.SaveChanges();
            return NoContent();
        }

        //teste
        [HttpGet, Route("NotasEtapas/{idEtapa}")]
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
                                       fk_etapa = nota.fk_etapa,
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
                                                            id = p.id,
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

        [HttpGet, Route("etapas")]
        public List<Etapa> getEtapa()
        {
            var etapa = _context.Etapas.ToList();
            return etapa;
        }

        [HttpPost, Route("FinalizarEtapa/{idEtapa}")]
        public IActionResult FanalizarEtapa(int idEtapa)
        {
            var etapaParticipanteDao = new EtapaParticipanteDao(_context);
            if (!etapaParticipanteDao.ValidarParticipanteNota(idEtapa))
                return NotFound("Alguns participantes não tem nota ainda");
            else if (etapaParticipanteDao.EtapaFinalizada(idEtapa))
                return NotFound("Essa etapa já foi finalizada");

            var Vencedores = etapaParticipanteDao.Vencedores(idEtapa);
            var Perdedores = etapaParticipanteDao.Perdedores(idEtapa);

            for (int i = 0; i < Vencedores.Count(); i++)
            {
                Devedores d = new Devedores();
                d.fk_participante_ganhardor = Vencedores.ElementAt(i).fk_participante;
                d.fk_participante_perdedor = Perdedores.ElementAt(i).fk_participante;
                d.fk_etapa_devedores = idEtapa;
                _context.Devedores.Add(d);
                _context.SaveChanges();
            }
            return Ok();
        }

        [HttpGet, Route("Devedores/{page}/{qtdItem}")]
        public IEnumerable<Devedores> getDevedores(int page, int qtdItem)
        {
            var x = _context.Devedores.
            Include(g => g.participante_ganhador).
            Include(p => p.participante_perdedor).
            ToList().Take(page * qtdItem).Skip((page * qtdItem) - qtdItem);                                
            return x;
        }
    }
}