﻿using System.Collections.Generic;
using System.Linq;
using FantasyServer.Comum;
using FantasyServer.Context;
using FantasyServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace FantasyServer.Controllers
{
    [Produces ("application/json")]
    [Route ("api/Participantes")]
    public class ParticipantesController : ControllerBase {
        private readonly FantasyContext _context;

        public ParticipantesController (FantasyContext context) {
            _context = context;
        }

        // GET: api/Participantes
        [HttpGet]
        public IEnumerable<Participante> Get () {
            return _context.Participantes.ToList ();
        }

        // GET: api/Participantes/5
        [HttpGet ("{id}")]
        public Participante Get (int id) {
            var participante = _context.Participantes.Find (id);
            if (participante == null)
                return new Participante ();
            else
                return participante;
        }

        // POST: api/Participantes
        [HttpPost]
        public IActionResult Post ([FromBody] Participante participante) {
            if (participante.nome == null)
                return NotFound ();

            _context.Participantes.Add (participante);
            _context.SaveChanges ();
            return NoContent ();
        }

        // PUT: api/Participantes/5
        [HttpPut ("{id}")]
        public IActionResult Put (int id, [FromBody] Participante participante) {
            var _participante = _context.Participantes.Find (id);
            if (_participante == null)
                return NotFound ();

            _participante.nome = participante.nome;
            _participante.email = participante.email;

            _context.Participantes.Update (_participante);
            _context.SaveChanges ();
            return NoContent ();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete ("{id}")]
        public IActionResult Delete (int id) {
            var _participante = _context.Participantes.Find (id);
            if (_participante == null)
                return NotFound ();
            _context.Participantes.Remove (_participante);
            _context.SaveChanges ();
            return NoContent ();
        }

        [HttpGet, Route ("SendEmail")]
        public IActionResult EnvioEmail () {
            try {
                SendEmail.Mail ();
                return Ok();
            } catch (System.Exception) {
                return NoContent();
                throw;
            }            
        }
    }
}