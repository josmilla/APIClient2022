using Microsoft.EntityFrameworkCore;
using APIClient.Infrastructure.Data.Contexts;
using APIClient.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace APIClient.Infrastructure.Data.Repositories
{
    public class RolRepository : IRolRepository
    {
        private AsignacionContext _context;
        private DbSet<Rol> _dbSet;
         
        public RolRepository(AsignacionContext context)
        {
            _context = context;
            _dbSet = context.Set<Rol>();
        }

        public async Task<List<Rol>> GetRolAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<Rol> GetRolByIdAsync(int id)
        {
            return await _dbSet.Where(p => p.IdRol == id).FirstOrDefaultAsync();
        }

        

        public async Task<Rol> InsertAsync(Rol rol)
        {
            _dbSet.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }
        public async Task<Rol> UpdateAsync(int id, Rol rol)
        {
            Rol rolactualizarToUpdate = await GetRolByIdAsync(id);
            rolactualizarToUpdate.SqRol = rol.SqRol;
            rolactualizarToUpdate.UsuarioRegistro = rol.UsuarioRegistro;
            rolactualizarToUpdate.FechaRegistro = rol.FechaRegistro;
            rolactualizarToUpdate.FechaModificacion = rol.FechaModificacion;
            rolactualizarToUpdate.UsuarioModificacion = rol.UsuarioModificacion;
            rolactualizarToUpdate.Estado = rol.Estado;
          


            _dbSet.Update(rolactualizarToUpdate);
            await _context.SaveChangesAsync();

            return rolactualizarToUpdate;
        }

        public async Task<Rol> DeleteAsync(int id)
        {
            Rol roleliminarToDelete = await GetRolByIdAsync(id);

            _dbSet.Remove(roleliminarToDelete);
            await _context.SaveChangesAsync();
            return roleliminarToDelete;
        }
    }
}
