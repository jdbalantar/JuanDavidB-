using JuanDavidB.Domain;
using Microsoft.EntityFrameworkCore;

namespace JuanDavidB.Persistence
{
    public class JuanDavidBContext : DbContext
    {
        public JuanDavidBContext(DbContextOptions<JuanDavidBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tablero>().HasData(
                new Tablero
                {
                    Id = 1,
                    Pais = "AUS",
                    Deportista = "Carlos Alviz",
                    Arranque = 134,
                    Envion = 177,
                    TotalPeso = 311
                }, new Tablero
                {
                    Id = 2,
                    Pais = "CHN",
                    Deportista = "Andrés Sabogal",
                    Arranque = 130,
                    Envion = 180,
                    TotalPeso = 310
                }, new Tablero
                {
                    Id = 3,
                    Pais = "FRA",
                    Deportista = "Jorge Ortega",
                    Arranque = 125,
                    Envion = 184,
                    TotalPeso = 309
                }, new Tablero
                {
                    Id = 4,
                    Pais = "AUS",
                    Deportista = "Pablo Velasco",
                    Arranque = 0,
                    Envion = 150,
                    TotalPeso = 150
                }
            );
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Tablero> Tableros { get; set; }
    }
}