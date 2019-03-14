using Fantasy_server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy_server.Context
{
    public class FantasyContext : DbContext
    {
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<EtapaParticipante> EtapaParticipantes { get; set; }
        public DbSet<User> Users { get; set; }

        public FantasyContext(DbContextOptions<FantasyContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participante>().HasKey(c => c.id);            
            modelBuilder.Entity<Etapa>().HasKey(c => c.id);
            modelBuilder.Entity<EtapaParticipante>().HasKey(c => c.id);
            modelBuilder.Entity<User>().HasKey(c => c.id);
        }
    }
}
