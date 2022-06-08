using Microsoft.EntityFrameworkCore;
using APIClient.Infrastructure.Data.Contexts;
using APIClient.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace APIClient.Infrastructure.Data.Repositories
{
    public class CargaRepository : ICargaRepository
    {
        private AsignacionContext _context;
        private DbSet<Carga> _dbSet;
        public CargaRepository(AsignacionContext context)
        {
            _context = context;
            _dbSet = context.Set<Carga>();
        }

        public async Task<List<Carga>> GetCargaAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<Carga> GetCargaByIdAsync(int id)
        {
            return await _dbSet.Where(p => p.IdCarga == id).FirstOrDefaultAsync();
        }

        

        public async Task<Carga> InsertAsync(Carga carga)
        {
            _dbSet.Add(carga);
            await _context.SaveChangesAsync();
            return carga;
        }
        public async Task<Carga> UpdateAsync(int id, Carga carga)
        {
            Carga cargaToUpdate = await GetCargaByIdAsync(id);
            cargaToUpdate.NombreCal = carga.NombreCal;
            cargaToUpdate.MatriculaCal = carga.MatriculaCal;
            cargaToUpdate.NombreChapter = carga.NombreChapter;
            cargaToUpdate.MatriculaChapter = carga.MatriculaChapter;
            cargaToUpdate.TipoPreper = carga.TipoPreper;
            cargaToUpdate.Empresa = carga.Empresa;
            cargaToUpdate.MatriculaUsuario = carga.MatriculaUsuario;
            cargaToUpdate.ApellidopaternoUsuario = carga.ApellidopaternoUsuario;
            cargaToUpdate.ApellidomaternoUsuario = carga.ApellidomaternoUsuario;
            cargaToUpdate.NombreUsuario = carga.NombreUsuario;
            cargaToUpdate.ChapterUo = carga.ChapterUo;
            cargaToUpdate.FechaCarga = carga.FechaCarga;


            _dbSet.Update(cargaToUpdate);
            await _context.SaveChangesAsync();

            return cargaToUpdate;
        }

        public async Task<Carga> DeleteAsync(int id)
        {
            Carga cargaToDelete = await GetCargaByIdAsync(id);

            _dbSet.Remove(cargaToDelete);
            await _context.SaveChangesAsync();
            return cargaToDelete;
        }
    }
}
