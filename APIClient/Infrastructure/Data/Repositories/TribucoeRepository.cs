using Microsoft.EntityFrameworkCore;
using APIClient.Infrastructure.Data.Contexts;
using APIClient.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace APIClient.Infrastructure.Data.Repositories
{
    public class TribucoeRepository : ITribucoeRepository
    {
        private AsignacionContext _context;
        private DbSet<Tribucoe> _dbSet;
        public TribucoeRepository(AsignacionContext context)
        {
            _context = context;
         _dbSet = context.Set<Tribucoe>();
        }

        public async Task<List<Tribucoe>> GetTribucoeAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<Tribucoe> GetTribucoeByIdAsync(int id)
        {
            return await _dbSet.Where(p => p.IdTribucoe == id).FirstOrDefaultAsync();
        }

        

        public async Task<Tribucoe> InsertAsync(Tribucoe tribucoe)
        {
            _dbSet.Add(tribucoe);
            await _context.SaveChangesAsync();
            return tribucoe;
        }
        public async Task<Tribucoe> UpdateAsync(int id, Tribucoe tribucoe)
        {
            
            Tribucoe actualizarToUpdate = await GetTribucoeByIdAsync(id);
          
            actualizarToUpdate.NombreTribucoe = tribucoe.NombreTribucoe;
            actualizarToUpdate.CategoriaTribucoe = tribucoe.CategoriaTribucoe;
            actualizarToUpdate.IdTribucoe = tribucoe.IdTribucoe;
            actualizarToUpdate.FechaRegistro = tribucoe.FechaRegistro;
            actualizarToUpdate.UsuarioRegistro = tribucoe.UsuarioRegistro;
            actualizarToUpdate.FechaModificacion = tribucoe.FechaModificacion;
            actualizarToUpdate.UsuarioModificacion = tribucoe.UsuarioModificacion;
            actualizarToUpdate.Estado = tribucoe.Estado;
          


            _dbSet.Update(actualizarToUpdate);
            await _context.SaveChangesAsync();

            return actualizarToUpdate;
        }

        public async Task<Tribucoe> DeleteAsync(int id)
        {
            Tribucoe eliminarToDelete = await GetTribucoeByIdAsync(id);

            _dbSet.Remove(eliminarToDelete);
            await _context.SaveChangesAsync();
            return eliminarToDelete;
        }
    }
}
