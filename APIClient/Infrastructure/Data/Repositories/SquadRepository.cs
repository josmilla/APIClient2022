using Microsoft.EntityFrameworkCore;
using APIClient.Infrastructure.Data.Contexts;
using APIClient.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace APIClient.Infrastructure.Data.Repositories
{
    public class SquadRepository : ISquadRepository
    {
        private AsignacionContext _context;
        private DbSet<Squad> _dbSet;
        public SquadRepository(AsignacionContext context)
        {
            _context = context;
            _dbSet = context.Set<Squad>();
        }

        public async Task<List<Squad>> GetSquadAsync()
        {

            var query = await _dbSet
              .Include(p => p.Tribucoe)
             // .ThenInclude(p => p.NombreTribucoe)
              //.ThenInclude(p => p.NombreTribucoe)
              .ToListAsync();
            return query;
            //  return await _dbSet.ToListAsync();
        }
        public async Task<Squad> GetSquadByIdAsync(int id)
        {
            var query = await _dbSet
              .Include(p => p.Tribucoe)
              .Where(p => p.IdSquad == id).FirstOrDefaultAsync();
            return query;
          //  return await _dbSet.Where(p => p.IdSquad == id).FirstOrDefaultAsync();
        }
         
        public async Task<Squad> InsertAsync(Squad squad)
        {
            _dbSet.Add(squad);
           

            await _context.SaveChangesAsync();
            return squad;
        }
        public async Task<Squad> UpdateAsync(int id, Squad squad)
        {

            Squad actualizarToUpdate = await GetSquadByIdAsync(id);
          
            actualizarToUpdate.CodSquad = squad.CodSquad;
            actualizarToUpdate.NombreSquad = squad.NombreSquad;
            actualizarToUpdate.IdTribucoe = squad.IdTribucoe;
            actualizarToUpdate.FechaRegistro = squad.FechaRegistro;
            actualizarToUpdate.UsuarioRegistro = squad.UsuarioRegistro;
            actualizarToUpdate.FechaModificacion = squad.FechaModificacion;
            actualizarToUpdate.UsuarioModificacion = squad.UsuarioModificacion;
            actualizarToUpdate.Estado = squad.Estado;
          


            _dbSet.Update(actualizarToUpdate);
            await _context.SaveChangesAsync();

            return actualizarToUpdate;
        }

        public async Task<Squad> DeleteAsync(int id)
        {
            Squad eliminarToDelete = await GetSquadByIdAsync(id);

            _dbSet.Remove(eliminarToDelete);
            await _context.SaveChangesAsync();
            return eliminarToDelete;
        }
    }
}
