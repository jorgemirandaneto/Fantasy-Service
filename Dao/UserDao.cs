using FantasyServer.Context;
using FantasyServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyServer.Dao
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
