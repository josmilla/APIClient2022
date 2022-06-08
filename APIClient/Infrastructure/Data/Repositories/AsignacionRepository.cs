 
using Microsoft.EntityFrameworkCore;
using APIClient.Infrastructure.Data.Contexts;
using APIClient.Infrastructure.Data.Entities;
using APIClient.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using APIClient.Infrastructure.Specification;

namespace APIClient.Infrastructure.Data.Repositories
{
    public class AsignacionRepository : IAsignacionRepository<Asignacion>
    {
        private AsignacionContext _context;
        private DbSet<Asignacion> _dbSet;
        //private DbSet<Rol> _dbSetRol;
        public AsignacionRepository(AsignacionContext context)
        {
            _context = context;
            _dbSet = context.Set<Asignacion>();
          //_dbSetRol = context.Set<Rol>();
        }

        public IEnumerable<Asignacion> FindWithSpecificationPattern(ISpecification<Asignacion> specification = null)
        {
            return SpecificationEvaluator<Asignacion>.GetQuery(_context.Set<Asignacion>().AsQueryable(), specification);
        }

        public async Task<List<Asignacion>> GetAsignacionAsync()
        {

            var query = await _dbSet
             .Include(p => p.Rol)
             .Include(p => p.Squad)
             .Include(p => p.Aplicativo)
             //.ThenInclude(p => p.NombreTribucoe)
             .ToListAsync();
            return query;
            
 
       
        }
        public async Task<Asignacion> GetAsignacionByIdAsync(int id)
        {

            var query = await _dbSet
            .Include(p => p.Rol)
            .Include(p => p.Squad)
            .Include(p => p.Aplicativo)
            .Where(p => p.IdPorcentajeAsignacion == id).FirstOrDefaultAsync();
            return query;
           // return await _dbSet.Where(p => p.IdPorcentajeAsignacion == id).FirstOrDefaultAsync();
        }

        public async Task<List<Asignacion>> GetAsignacionMatriculaChapterByIdAsync(string matricula)
        {

            var query = await _dbSet
             .Include(p => p.Rol)
             .Include(p => p.Squad)
             .Include(p => p.Aplicativo)
             .Where(p => p.MatriculaChapter == matricula)
             //.ThenInclude(p => p.NombreTribucoe)
             .ToListAsync();
            return query;
           // return await _dbSet.Where(p => p.MatriculaChapter == matricula).ToListAsync();
        }

        public async Task<Asignacion> GetSumaParticipacion(string matriculasuma)
        {

            var query = await _dbSet
                  .Where(p => p.MatriculaUsuario == matriculasuma)
                  //.Include(q => q.Rol)
                  //.Include(z => z.Squad)
                  //.Include(r => r.Aplicativo)
                  .GroupBy(x => new { x.MatriculaUsuario })
                  .Select(y => new Asignacion
                  {

                      MatriculaUsuario = y.Max(x => x.MatriculaUsuario),
                      NombreUsuario = y.Max(x => x.NombreUsuario),
                      ApellidopaternoUsuario = y.Max(x => x.ApellidopaternoUsuario),
                      ApellidomaternoUsuario = y.Max(x => x.ApellidomaternoUsuario),
                      Porcentaje = y.Sum(x => x.Porcentaje),
                      NombreChapter = y.Max(x => x.NombreChapter)

                  }
                     )
           
               .FirstOrDefaultAsync();
            return query;

        }

        public async Task<List<Asignacion>> GetAsignacionMatriculausuarioByIdAsync(string usuario)
        {

            var query = await _dbSet
            .Include(p => p.Rol)
            .Include(p => p.Squad)
            .Include(p => p.Aplicativo)
            .Where(x => x.MatriculaUsuario == usuario).ToListAsync();
            return query;
           // return await _dbSet.Where(x => x.MatriculaUsuario == usuario).ToListAsync();
        }

        public async Task<Asignacion> InsertAsync(Asignacion asignacion)
        {
            _dbSet.Add(asignacion);
            await _context.SaveChangesAsync();
            return asignacion;
        }
        public async Task<Asignacion> UpdateAsync(int id, Asignacion asignacion)
        {
            Asignacion asignacionToUpdate = await GetAsignacionByIdAsync(id);
            asignacionToUpdate.MatriculaUsuario = asignacion.MatriculaUsuario;
            asignacionToUpdate.ApellidopaternoUsuario = asignacion.ApellidomaternoUsuario;
            asignacionToUpdate.ApellidomaternoUsuario = asignacion.ApellidomaternoUsuario;
            asignacionToUpdate.NombreUsuario = asignacion.NombreUsuario;
            asignacionToUpdate.NombreChapter = asignacion.NombreChapter;
            asignacionToUpdate.MatriculaChapter = asignacion.MatriculaChapter;
            asignacionToUpdate.IdRol = asignacion.IdRol;
            asignacionToUpdate.Especialidad = asignacion.Especialidad;
            asignacionToUpdate.IdSquad = asignacion.IdSquad;
            asignacionToUpdate.IdAplicativo = asignacion.IdAplicativo;
            asignacionToUpdate.Porcentaje = asignacion.Porcentaje;
            asignacionToUpdate.Comentarios = asignacion.Comentarios;
            asignacionToUpdate.FechaPeriodoAprobado = asignacion.FechaPeriodoAprobado;
            asignacionToUpdate.FechaRegistro = asignacion.FechaRegistro;
            asignacionToUpdate.UsuarioRegistro = asignacion.UsuarioRegistro;
            asignacionToUpdate.FechaModificacion = asignacion.FechaModificacion;
            asignacionToUpdate.UsuarioModificacion = asignacion.UsuarioModificacion;
            asignacionToUpdate.Estado = asignacion.Estado;
            asignacionToUpdate.EstadoRegistro = asignacion.EstadoRegistro;

            _dbSet.Update(asignacionToUpdate);
            await _context.SaveChangesAsync();

            return asignacionToUpdate;
        }

        public async Task<Asignacion> DeleteAsync(int id)
        {
            Asignacion asignacionToDelete = await GetAsignacionByIdAsync(id);

            _dbSet.Remove(asignacionToDelete);
            await _context.SaveChangesAsync();
            return asignacionToDelete;
        }
    }
}
