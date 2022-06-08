using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
 using APIClient.Infrastructure.Data.Entities;
using System;

namespace APIClient.Infrastructure.Data.Contexts.Configurations
{
    public partial class CargaConfiguration : IEntityTypeConfiguration<Carga>
    {
        public void Configure(EntityTypeBuilder<Carga> entity)
        {


            entity.ToTable("CARGA");

            entity.Property(e => e.IdCarga).HasColumnName("ID_CARGA");
            

            entity.Property(e => e.ApellidomaternoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOMATERNO_USUARIO");

            entity.Property(e => e.ApellidopaternoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOPATERNO_USUARIO");

            entity.Property(e => e.ChapterUo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CHAPTER_UO");

            entity.Property(e => e.Empresa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMPRESA");

            entity.Property(e => e.FechaCarga)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CARGA");

            

            entity.Property(e => e.IdPeriodo).HasColumnName("ID_PERIODO");

            entity.Property(e => e.MatriculaCal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MATRICULA_CAL");
            entity.Property(e => e.MatriculaChapter)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MATRICULA_CHAPTER");

            entity.Property(e => e.MatriculaUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MATRICULA_USUARIO");

            entity.Property(e => e.NombreCal)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CAL");

            entity.Property(e => e.NombreChapter)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CHAPTER");

            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_USUARIO");

            entity.Property(e => e.TipoPreper)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO_PREPER");



            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Carga> entity);
    }
}
