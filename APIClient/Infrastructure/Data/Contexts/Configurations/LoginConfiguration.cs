using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
 using APIClient.Infrastructure.Data.Entities;
using System;


namespace APIClient.Infrastructure.Data.Contexts.Configurations
{
    public partial class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> entity)
        {


                entity.ToTable("LOGIN");

                entity.Property(e => e.IdLogin).HasColumnName("ID_LOGIN");


                entity.Property(e => e.Matricula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MATRICULA");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");

            entity.Property(e => e.UsuarioRegistro)
    .HasMaxLength(50)
    .IsUnicode(false)
    .HasColumnName("USUARIO_REGISTRO");


            entity.Property(e => e.FechaModificacion)
    .HasColumnType("datetime")
    .HasColumnName("FECHA_MODIFICACION");

            entity.Property(e => e.UsuarioModificacion)
    .HasMaxLength(50)
    .IsUnicode(false)
    .HasColumnName("USUARIO_MODIFICACION");


            entity.Property(e => e.Estado).HasColumnName("ESTADO");


            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Login> entity);
    }
}
