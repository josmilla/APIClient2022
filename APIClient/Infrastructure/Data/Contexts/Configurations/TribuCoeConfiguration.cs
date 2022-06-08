using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
 using APIClient.Infrastructure.Data.Entities;
using System;

namespace APIClient.Infrastructure.Data.Contexts.Configurations
{
    public partial class TribuCoeConfiguration : IEntityTypeConfiguration<Tribucoe>
    {
        public void Configure(EntityTypeBuilder<Tribucoe> entity)
        {


            entity.ToTable("TRIBUCOE");

            entity.Property(e => e.IdTribucoe).HasColumnName("ID_TRIBUCOE");

            entity.Property(e => e.CodTribucoe)
               .HasMaxLength(50)
               .IsUnicode(false)
               .HasColumnName("COD_TRIBUCOE");



            entity.Property(e => e.NombreTribucoe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_TRIBUCOE");



            entity.Property(e => e.CategoriaTribucoe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CATEGORIA_TRIBUCOE");

            entity.Property(e => e.FechaRegistro)
               .HasColumnType("datetime")
               .HasColumnName("FECHA_REGISTRO");


            entity.Property(e => e.Estado).HasColumnName("ESTADO");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");

            entity.Property(e => e.UsuarioRegistro)
               .HasMaxLength(50)
               .IsUnicode(false)
               .HasColumnName("USUARIO_REGISTRO");


            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USUARIO_MODIFICACION");


            //entity
            //    .HasMany(b => b.Squads)
            //    .WithOne();
                


            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Tribucoe> entity);
    }
}
