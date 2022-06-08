using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
 using APIClient.Infrastructure.Data.Entities;
using System;

namespace APIClient.Infrastructure.Data.Contexts.Configurations
{
    public partial class PorcentajeAsignacionConfiguration : IEntityTypeConfiguration<PorcentajeAsignacion>
    {
        public void Configure(EntityTypeBuilder<PorcentajeAsignacion> entity)
        {


             

            entity.ToTable("PORCENTAJE_ASIGNACION");

            entity.Property(e => e.IdPorcentajeAsignacion).HasColumnName("ID_PORCENTAJE_ASIGNACION");

            entity.Property(e => e.Estado).HasColumnName("ESTADO");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");

            entity.Property(e => e.IdAplicativo).HasColumnName("ID_APLICATIVO");

            entity.Property(e => e.IdCarga).HasColumnName("ID_CARGA");

            entity.Property(e => e.IdPeriodo).HasColumnName("ID_PERIODO");

            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

            entity.Property(e => e.Porcentaje).HasColumnName("PORCENTAJE");

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

        partial void OnConfigurePartial(EntityTypeBuilder<PorcentajeAsignacion> entity);
    }
}
