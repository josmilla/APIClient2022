using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
 using APIClient.Infrastructure.Data.Entities;
using System;

namespace APIClient.Infrastructure.Data.Contexts.Configurations
{
    public partial class SquadConfiguration : IEntityTypeConfiguration<Squad>
    {
        public void Configure(EntityTypeBuilder<Squad> entity)
        {


            entity.ToTable("SQUAD");

            entity.Property(e => e.IdSquad).HasColumnName("ID_SQUAD");

            entity.Property(e => e.CodSquad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COD_SQUAD");

            entity.Property(e => e.NombreSquad)
              .HasMaxLength(50)
              .IsUnicode(false)
              .HasColumnName("NOMBRE_SQUAD");

            entity.Property(e => e.IdTribucoe).IsUnicode(false).HasColumnName("ID_TRIBUCOE");

            
        
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
            //modelBuilder.Entity<PrimaryClass>().HasMany(p => p.DependentClasses);
          //  entity.HasMany(e => e.Tribucoe);


            entity.HasOne(e => e.Tribucoe)
                                .WithMany(p => p.Squad)
                                .HasForeignKey(e => e.IdTribucoe)
                                .HasConstraintName("FK_squadTribucoe");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Squad> entity);
    }
}
