using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
 using APIClient.Infrastructure.Data.Entities;
using System;

namespace APIClient.Infrastructure.Data.Contexts.Configurations
{
    public partial class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> entity)
        {

            entity.ToTable("ROL");
            
            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
          //  entity.Property(e => e.IdRol).HasColumnName("ID_ROL").HasKey(s => s.;

            entity.Property(e => e.SqRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SQ_ROL");

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

              entity.Property(e => e.Estado)
               .HasMaxLength(1)
               .IsUnicode(false)
               .HasColumnName("ESTADO");

           


            //entity.HasOne(e => e.Asignars)
            //    .WithMany(p => p)
            //    .HasForeignKey(d => d.idRol)
            //    .HasConstraintName("FK_AsignarRol");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Rol> entity);
    }
}
