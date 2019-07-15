using System.Collections.Generic;
using System.Linq;
using FantasyServer.Context;
using FantasyServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fantasy_Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Devedores")]
    public class DevedoresController : ControllerBase
    {
        readonly private FantasyContext _context;

        public DevedoresController(FantasyContext context)
        {
            this._context = context;
        }

        [HttpGet, Route("devedores/{page}/{qtdItem}")]
        public IEnumerable<Devedores> getDevedores(int page, int qtdItem)
        {
            var devedores = _context.Devedores.
            Include(g => g.participante_ganhador).
            Include(p => p.participante_perdedor).
            Include(e => e.etapa).
            ToList().Take(page * qtdItem).Skip((page * qtdItem) - qtdItem);
            return devedores;
        }

        [HttpPost, Route("pagamento/{idDevedores}")]
        public IActionResult postDevedores(int idDevedores)
        {
            var devedor = this._context.Devedores.Find(idDevedores);
            devedor.pago = "T";
            this._context.Update(devedor);
            this._context.SaveChanges();
            return Ok();
        }
    }
}