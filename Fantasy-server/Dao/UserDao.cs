using Fantasy_server.Context;
using Fantasy_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy_server.Dao
{
    public class UserDao
    {
        private readonly FantasyContext _fantasyContext;

        public UserDao(FantasyContext fantasyContext)
        {
            _fantasyContext = fantasyContext;
        }

        public User find(User user)
        {
            User u = _fantasyContext.Users.Where(p => p.nome.Equals(user.nome) && p.senha.Equals(user.senha)).FirstOrDefault();
            return u;
        }
     }
}
