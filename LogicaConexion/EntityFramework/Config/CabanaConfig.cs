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
    internal class CabanaConfig : IEntityTypeConfiguration<Cabana>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cabana> entityTypeBuilder)
        {
            entityTypeBuilder.OwnsOne(cabana => cabana.Nombre).Property(Nombre => Nombre.Data).HasColumnName("Nombre");
            entityTypeBuilder.OwnsOne(cabana => cabana.Descripcion).Property(Descripcion => Descripcion.Data).HasColumnName("Descripcion");
            entityTypeBuilder.OwnsOne(cabana => cabana.NombreTipo).Property(Nombre => Nombre.Data).HasColumnName("NombreTipo");
            entityTypeBuilder.OwnsOne(cabana => cabana.Jacuzzi).Property(Jacuzzi => Jacuzzi.Data).HasColumnName("Jacuzzi");
            entityTypeBuilder.OwnsOne(cabana => cabana.HabilitadoAReservas).Property(HabilitadaReserva => HabilitadaReserva.Data).HasColumnName("HabilitadoAReservas");
            entityTypeBuilder.OwnsOne(cabana => cabana.CapacidadHabitacion).Property(CapacidadHabitacion => CapacidadHabitacion.Data).HasColumnName("CapacidadHabitacion");
            entityTypeBuilder.OwnsOne(cabana => cabana.Fotografia).Property(Fotografia => Fotografia.Data).HasColumnName("Fotografia");

            entityTypeBuilder.HasKey("NumeroHabitacion");
            entityTypeBuilder.HasIndex(e => e.NumeroHabitacion).IsUnique();
            
        }



    }
}
