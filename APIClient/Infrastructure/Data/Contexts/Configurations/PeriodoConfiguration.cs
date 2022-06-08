using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
 using APIClient.Infrastructure.Data.Entities;
using System;

namespace APIClient.Infrastructure.Data.Contexts.Configurations
{
    public partial class PeriodoConfiguration : IEntityTypeConfiguration<Periodo>
    {
        public void Configure(EntityTypeBuilder<Periodo> entity)
        {


            

            entity.ToTable("PERIODO");

            entity.Property(e => e.IdPeriodo).HasColumnName("ID_PERIODO");

            entity.Property(e => e.Anio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ANIO");

            entity.Property(e => e.Estado).HasColumnName("ESTADO");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");

            entity.Property(e => e.Mes)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MES");

            entity.Property(e => e.Periodo1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PERIODO");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USUARIO_MODIFICACION");

            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USUARIO_REGISTRO");

           
           


            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Periodo> entity);
    }
}
