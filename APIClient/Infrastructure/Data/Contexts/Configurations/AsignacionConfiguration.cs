using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
 using APIClient.Infrastructure.Data.Entities;
using System;

namespace APIClient.Infrastructure.Data.Contexts.Configurations
{
    public partial class AsignacionConfiguration : IEntityTypeConfiguration<Asignacion>
    {
        public void Configure(EntityTypeBuilder<Asignacion> entity)
        {
            entity.ToTable("ASIGNACION_ACTIVOS");

            // entity.Property(e => e.Id).IsRequired();
            //entity.Property(e => e.ProductId).HasDefaultValueSql("(newid())");
            //  entity.Property(e => e.IdPorcentajeAsignacion).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IdPorcentajeAsignacion)
                .IsUnicode(false)
                .HasColumnType("int")
                 
                .HasColumnName("ID_PORCENTAJE_ASIGNACION");

            entity.Property(e => e.MatriculaUsuario) 
                .IsUnicode(false)
                .HasColumnName("MATRICULA_USUARIO");  

            entity.Property(e => e.ApellidopaternoUsuario)
                .IsUnicode(false)
                .HasColumnName("APELLIDOPATERNO_USUARIO");  
            entity.Property(e => e.ApellidomaternoUsuario)
                .IsUnicode(false)
                .HasColumnName("APELLIDOMATERNO_USUARIO");  
            entity.Property(e => e.NombreUsuario)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_USUARIO");  
            entity.Property(e => e.NombreChapter)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CHAPTER");  
            entity.Property(e => e.MatriculaChapter)
                .IsUnicode(false)
                .HasColumnName("MATRICULA_CHAPTER");  
            entity.Property(e => e.IdRol).IsUnicode(false).HasColumnName("ID_ROL");  

            entity.Property(e => e.Especialidad).IsUnicode(false).HasColumnName("ESPECIALIDAD");  
            entity.Property(e => e.IdSquad).IsUnicode(false).HasColumnName("ID_SQUAD");  
            entity.Property(e => e.IdAplicativo).IsUnicode(false).HasColumnName("ID_APLICATIVO");  

            entity.Property(e => e.Porcentaje).HasColumnName("PORCENTAJE"); 

            entity.Property(e => e.Comentarios).IsUnicode(false).HasColumnName("COMENTARIOS");  

            entity.Property(e => e.FechaPeriodoAprobado).IsUnicode(false).HasColumnName("FECHA_PERIODO_APROBADO");  

            entity.Property(e => e.FechaRegistro).IsUnicode(false).HasColumnName("FECHA_REGISTRO");  
            entity.Property(e => e.UsuarioRegistro).IsUnicode(false).HasColumnName("USUARIO_REGISTRO");  
            entity.Property(e => e.FechaModificacion).IsUnicode(false).HasColumnName("FECHA_MODIFICACION");  

            entity.Property(e => e.UsuarioModificacion).IsUnicode(false).HasColumnName("USUARIO_MODIFICACION");  
            entity.Property(e => e.Estado).IsUnicode(false).HasColumnName("ESTADO");  
            entity.Property(e => e.EstadoRegistro).IsUnicode(false).HasColumnName("ESTADO_REGISTRO");

            entity.HasOne(e => e.Rol)
                             .WithMany(p => p.Asignacion)
                             
                             .HasForeignKey(e => e.IdRol)
                             .HasConstraintName("FK_AsignarRol");

            entity.HasOne(e => e.Squad)
                            .WithMany(p => p.Asignacion)

                            .HasForeignKey(e => e.IdSquad)
                            .HasConstraintName("FK_AsignarSquad");
            entity.HasOne(e => e.Aplicativo)
                           .WithMany(p => p.Asignacion)
                           .HasForeignKey(e => e.IdAplicativo)
                           .HasConstraintName("FK_AsignarAplicativo");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Asignacion> entity);
    }
}
