using Fantasy2.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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

        

    }
}