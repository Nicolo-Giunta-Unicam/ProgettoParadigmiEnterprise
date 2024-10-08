﻿using Microsoft.EntityFrameworkCore;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Context
{
    public class DatabaseRistorante : DbContext
    {
        public DbSet<Utente> utenti { get; set; }
        public DbSet<Ordine> ordini { get; set; }
        public DbSet<Portata> portate { get; set; }

        public DatabaseRistorante(DbContextOptions<DatabaseRistorante> config) : base(config)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
