using DeLeeghteAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLeeghteAPI.Domain.Data
{
    public class DeLeeghteContext : DbContext
    {
        public DeLeeghteContext(DbContextOptions<DeLeeghteContext> options) : base(options) { }

        public DbSet<Uuid> uuid { get; set; }
        public DbSet<Wedstrijd> wedstrijd { get; set; }
        public DbSet<Inschrijving> inschrijving { get; set; }
        public DbSet<Weging> weging { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Boekings>().ToTable("boekings");
            modelBuilder.Entity<Inschrijving>().ToTable("inschrijvingens");
            modelBuilder.Entity<Wedstrijd>().ToTable("wedstrijds");
            modelBuilder.Entity<Uuid>().ToTable("uuids");
            modelBuilder.Entity<Weging>().ToTable("wegingens");
            //modelBuilder.Entity<Categories>().ToTable("categories");

        }
    }
}
