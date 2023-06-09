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
    internal class TipoConfig : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tipo> entityTypeBuilder)
        {
            entityTypeBuilder.OwnsOne(Tipo => Tipo.Descripcion).Property(Descripcion => Descripcion.Data).HasColumnName("Descripcion");
            entityTypeBuilder.OwnsOne(Tipo => Tipo.CostoHuesped).Property(Costo => Costo.Data).HasColumnName("CostoHuesped");

            entityTypeBuilder.HasKey("Nombre");
            entityTypeBuilder.HasIndex("Nombre").IsUnique();
            
        }
    }
}
