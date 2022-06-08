using Microsoft.EntityFrameworkCore;
using APIClient.Infrastructure.Data.Contexts;
using APIClient.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace APIClient.Infrastructure.Data.Repositories
{
    public class PeriodoRepository : IPeriodoRepository
    {
        private AsignacionContext _context;
        private DbSet<Periodo> _dbSet;
        public PeriodoRepository(AsignacionContext context)
        {
            _context = context;
            _dbSet = context.Set<Periodo>();
        }

        public async Task<List<Periodo>> GetPeriodoAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<Periodo> GetPeriodoByIdAsync(int id)
        {
            return await _dbSet.Where(p => p.IdPeriodo == id).FirstOrDefaultAsync();
        }

        

        public async Task<Periodo> InsertAsync(Periodo periodo)
        {
            _dbSet.Add(periodo);
            await _context.SaveChangesAsync();
            return periodo;
        }
        public async Task<Periodo> UpdateAsync(int id, Periodo periodo)
        {
            Periodo actualizarToUpdate = await GetPeriodoByIdAsync(id);
            actualizarToUpdate.Periodo1 = periodo.Periodo1;
            actualizarToUpdate.Mes = periodo.Mes;
            actualizarToUpdate.Anio = periodo.Anio;
            actualizarToUpdate.FechaRegistro = periodo.FechaRegistro;
            actualizarToUpdate.UsuarioRegistro = periodo.UsuarioRegistro;
            actualizarToUpdate.FechaModificacion = periodo.FechaModificacion;
            actualizarToUpdate.UsuarioModificacion = periodo.UsuarioModificacion;
            actualizarToUpdate.Estado = periodo.Estado;
          


            _dbSet.Update(actualizarToUpdate);
            await _context.SaveChangesAsync();

            return actualizarToUpdate;
        }

        public async Task<Periodo> DeleteAsync(int id)
        {
            Periodo eliminarToDelete = await GetPeriodoByIdAsync(id);

            _dbSet.Remove(eliminarToDelete);
            await _context.SaveChangesAsync();
            return eliminarToDelete;
        }
    }
}
