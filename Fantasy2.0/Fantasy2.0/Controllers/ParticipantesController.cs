using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Fantasy2.Context;
using Fantasy2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy2.Controllers
{
    [Produces("application/json")]
    [Route("api/Participantes")]    
    public class ParticipantesController : ControllerBase
    {
        private readonly FantasyContext _context;

        public ParticipantesController(FantasyContext context)
        {
            _context = context;
        }

        // GET: api/Participantes
        [Authorize("Bearer")]
        [HttpGet]
        public IEnumerable<Participante> Get()
        {
            return _context.Participantes.ToList();
        }

        // GET: api/Participantes/5
        [HttpGet("{id}")]
        public Participante Get(int id)
        {
            var participante = _context.Participantes.Find(id);
            if (participante == null)
                return new Participante();
            else
                return participante;
        }

        // POST: api/Participantes
        [HttpPost]
        public IActionResult Post([FromBody]Participante participante)
        {
            if (participante.nome == null)            
                return NotFound();
            
            _context.Participantes.Add(participante);
            _context.SaveChanges();
            return NoContent();
        }

        // PUT: api/Participantes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Participante participante)
        {
            var _participante = _context.Participantes.Find(id);
            if (_participante == null)
                return NotFound();

            _participante.nome = participante.nome;
            _participante.email = participante.email;
            _participante.senha = participante.senha;

            _context.Participantes.Update(_participante);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _participante = _context.Participantes.Find(id);
            if (_participante == null)
                return NotFound();
            _context.Participantes.Remove(_participante);
            _context.SaveChanges();
            return NoContent();            
        }
    }
}
