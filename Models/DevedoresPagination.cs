using System.Collections;
using System.Collections.Generic;
using FantasyServer.Models;

namespace Fantasy_Service.Models
{
    public class DevedoresPagination
    {
        public int TotalPaginas { get; set; }

        public IEnumerable<Devedores> devedores { get; set; }
    }
}