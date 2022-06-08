using Microsoft.EntityFrameworkCore;
using APIClient.Infrastructure.Data.Contexts;
using APIClient.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace APIClient.Infrastructure.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private AsignacionContext _context;
        private DbSet<Login> _dbSet;

        public LoginRepository(AsignacionContext context)
        {
            _context = context;
            _dbSet = context.Set<Login>();
        }

        public async Task<List<Login>> GetLoginAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<Login> GetLoginByIdAsync(int id)
        {
            return await _dbSet.Where(p => p.IdLogin == id).FirstOrDefaultAsync();
        }


        public async Task<Login> InsertAsync(Login login)
        {
            _dbSet.Add(login);
            await _context.SaveChangesAsync();
            return login;
        }
        public async Task<Login> UpdateAsync(int id, Login login)
        {
            Login loginActualizarToUpdate = await GetLoginByIdAsync(id);
            loginActualizarToUpdate.Matricula = login.Matricula;
            loginActualizarToUpdate.Correo = login.Correo;
            loginActualizarToUpdate.FechaRegistro = login.FechaRegistro;
            loginActualizarToUpdate.UsuarioRegistro = login.UsuarioRegistro;
            loginActualizarToUpdate.FechaModificacion = login.FechaModificacion;
            loginActualizarToUpdate.UsuarioModificacion = login.UsuarioModificacion;
            loginActualizarToUpdate.Estado = login.Estado;

            _dbSet.Update(loginActualizarToUpdate);
            await _context.SaveChangesAsync();

            return loginActualizarToUpdate;
        }

        public async Task<Login> DeleteAsync(int id)
        {
            Login loginEliminarToDelete = await GetLoginByIdAsync(id);

            _dbSet.Remove(loginEliminarToDelete);
            await _context.SaveChangesAsync();
            return loginEliminarToDelete;
        }
    }
}
