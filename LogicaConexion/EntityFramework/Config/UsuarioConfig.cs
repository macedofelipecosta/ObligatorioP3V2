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
    internal class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> entityTypeBuilder)
        {
            entityTypeBuilder.OwnsOne(Usuario => Usuario.PassWord).Property(Password => Password.Data).HasColumnName("PassWord");

            entityTypeBuilder.HasKey("Email");
        }

    }
}
