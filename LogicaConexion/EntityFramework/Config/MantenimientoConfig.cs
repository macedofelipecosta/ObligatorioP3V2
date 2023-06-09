using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaConexion.EntityFramework.Config
{
    internal class MantenimientoConfig : IEntityTypeConfiguration<Mantenimiento>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Mantenimiento> entityTypeBuilder)
        {
            entityTypeBuilder.OwnsOne(Mantenimiento => Mantenimiento.Descripcion).Property(Descripcion => Descripcion.Data).HasColumnName("Descripcion");
            entityTypeBuilder.OwnsOne(Mantenimiento => Mantenimiento.Costo).Property(Costo => Costo.Data).HasColumnName("Costo");
            entityTypeBuilder.OwnsOne(Mantenimiento => Mantenimiento.Operador).Property(Operador => Operador.Data).HasColumnName("Operador");


            entityTypeBuilder.HasKey("Id");
            entityTypeBuilder.HasIndex(e => e.Id);
            
        }

    }
}
