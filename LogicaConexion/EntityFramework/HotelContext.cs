﻿using Microsoft.EntityFrameworkCore;
using LogicaNegocio.Entidades;
using LogicaConexion.EntityFramework.Config;


namespace LogicaConexion.EntityFramework
{
    public class HotelContext : DbContext
    {
        public DbSet<Cabana> Cabanas { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }


        public HotelContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CabanaConfig());
            modelBuilder.ApplyConfiguration(new MantenimientoConfig());
            modelBuilder.ApplyConfiguration(new TipoConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
           

            base.OnModelCreating(modelBuilder);
        }

    }
}
