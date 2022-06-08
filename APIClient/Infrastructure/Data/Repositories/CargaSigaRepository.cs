using Microsoft.EntityFrameworkCore;
using APIClient.Infrastructure.Data.Contexts;
using APIClient.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace APIClient.Infrastructure.Data.Repositories
{
    public class CargaSigaRepository : ICargaSigaRepository
    {
        private AsignacionContext _context;
        private DbSet<CargaSiga> _dbSet;
        public CargaSigaRepository(AsignacionContext context)
        {
            _context = context;
            _dbSet = context.Set<CargaSiga>();
        }

        public async Task<List<CargaSiga>> GetCargaSigaAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<CargaSiga> GetCargaSigaByIdAsync(int id )
        {
            return await _dbSet.Where(p => p.IdCarga == id).FirstOrDefaultAsync();
        }

        public async Task<CargaSiga> GetCargaMatriculaUsuario(string matricula)
        {
            return await _dbSet.Where(p => p.MatriculaUsuario == matricula).FirstOrDefaultAsync();
        }
        public async Task<CargaSiga> InsertAsync(CargaSiga cargasiga)
        {
            _dbSet.Add(cargasiga);
            await _context.SaveChangesAsync();
            return cargasiga;
        }
        public async Task<CargaSiga> UpdateAsync(int id, CargaSiga cargasiga)
        {
            CargaSiga cargaSigaToUpdate = await GetCargaSigaByIdAsync(id);
            cargaSigaToUpdate.NombreCal = cargasiga.NombreCal;
            cargaSigaToUpdate.MatriculaCal = cargasiga.MatriculaCal;
            cargaSigaToUpdate.NombreChapter = cargasiga.NombreChapter;
            cargaSigaToUpdate.MatriculaChapter = cargasiga.MatriculaChapter;
            cargaSigaToUpdate.TipoPreper = cargasiga.TipoPreper;
            cargaSigaToUpdate.Empresa = cargasiga.Empresa;
            cargaSigaToUpdate.MatriculaUsuario = cargasiga.MatriculaUsuario;
            cargaSigaToUpdate.ApellidopaternoUsuario = cargasiga.ApellidopaternoUsuario;
            cargaSigaToUpdate.ApellidomaternoUsuario = cargasiga.ApellidomaternoUsuario;
            cargaSigaToUpdate.NombreUsuario = cargasiga.NombreUsuario;
            cargaSigaToUpdate.RolInsourcing = cargasiga.RolInsourcing;
            cargaSigaToUpdate.Especialidad = cargasiga.Especialidad;
            cargaSigaToUpdate.ChapterUo = cargasiga.ChapterUo;
            cargaSigaToUpdate.Asignacion= cargasiga.Asignacion;
            cargaSigaToUpdate.UsuarioRegistro = cargasiga.UsuarioRegistro;
            cargaSigaToUpdate.FechaModificacion = cargasiga.FechaModificacion;
            cargaSigaToUpdate.UsuarioModificacion = cargasiga.UsuarioModificacion;
            cargaSigaToUpdate.Estado = cargasiga.Estado;
            cargaSigaToUpdate.FechaCarga = cargasiga.FechaCarga;
            cargaSigaToUpdate.FechaPeriodo = cargasiga.FechaPeriodo;
    
            _dbSet.Update(cargaSigaToUpdate);
            await _context.SaveChangesAsync();

            return cargaSigaToUpdate;
        }

        public async Task<CargaSiga> DeleteAsync(int id)
        {
            CargaSiga cargaSigaToDelete = await GetCargaSigaByIdAsync(id);

            _dbSet.Remove(cargaSigaToDelete);
            await _context.SaveChangesAsync();
            return cargaSigaToDelete;
        }
    }
}
