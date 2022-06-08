using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
 using APIClient.Infrastructure.Data.Entities;
using System;


namespace APIClient.Infrastructure.Data.Contexts.Configurations
{
    public partial class AplicativoConfiguration : IEntityTypeConfiguration<Aplicativo>
    {
        public void Configure(EntityTypeBuilder<Aplicativo> entity)
        {


                entity.ToTable("APLICATIVO");

                entity.Property(e => e.IdAplicativo).HasColumnName("ID_APLICATIVO");

                entity.Property(e => e.BiddingblockAplicativo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BIDDINGBLOCK_APLICATIVO");

                entity.Property(e => e.CodAplicativo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COD_APLICATIVO");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.EstadoAplicativo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO_APLICATIVO");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_MODIFICACION");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_REGISTRO");

                //entity.Property(e => e.IdPeriodo).HasColumnName("ID_PERIODO");

                entity.Property(e => e.NombreAplicativo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_APLICATIVO");

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

        partial void OnConfigurePartial(EntityTypeBuilder<Aplicativo> entity);
    }
}
