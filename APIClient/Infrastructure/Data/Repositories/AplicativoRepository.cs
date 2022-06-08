using Microsoft.EntityFrameworkCore;
using APIClient.Infrastructure.Data.Contexts;
using APIClient.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace APIClient.Infrastructure.Data.Repositories
{
    public class AplicativoRepository : IAplicativoRepository
    {
        private AsignacionContext _context;
        private DbSet<Aplicativo> _dbSet;

        public AplicativoRepository(AsignacionContext context)
        {
            _context = context;
            _dbSet = context.Set<Aplicativo>();
        }

        public async Task<List<Aplicativo>> GetAplicativoAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<Aplicativo> GetAplicativoByIdAsync(int id)
        {
            return await _dbSet.Where(p => p.IdAplicativo == id).FirstOrDefaultAsync();
        }

        

        public async Task<Aplicativo> InsertAsync(Aplicativo aplicativo)
        {
            _dbSet.Add(aplicativo);
            await _context.SaveChangesAsync();
            return aplicativo;
        }
        public async Task<Aplicativo> UpdateAsync(int id, Aplicativo aplicativo)
        {
            Aplicativo aplicativoActualizarToUpdate = await GetAplicativoByIdAsync(id);
            aplicativoActualizarToUpdate.CodAplicativo = aplicativo.CodAplicativo;
            aplicativoActualizarToUpdate.NombreAplicativo = aplicativo.NombreAplicativo;
            aplicativoActualizarToUpdate.BiddingblockAplicativo = aplicativo.BiddingblockAplicativo;
            aplicativoActualizarToUpdate.EstadoAplicativo = aplicativo.EstadoAplicativo;
            aplicativoActualizarToUpdate.FechaRegistro = aplicativo.FechaRegistro;
            aplicativoActualizarToUpdate.UsuarioRegistro = aplicativo.UsuarioRegistro;
            aplicativoActualizarToUpdate.FechaModificacion = aplicativo.FechaModificacion;
            aplicativoActualizarToUpdate.UsuarioModificacion = aplicativo.UsuarioModificacion;
            aplicativoActualizarToUpdate.Estado = aplicativo.Estado;
            //actualizarToUpdate.IdPeriodo = aplicativo.IdPeriodo;



            _dbSet.Update(aplicativoActualizarToUpdate);
            await _context.SaveChangesAsync();

            return aplicativoActualizarToUpdate;
        }

        public async Task<Aplicativo> DeleteAsync(int id)
        {
            Aplicativo aplicativoEliminarToDelete = await GetAplicativoByIdAsync(id);

            _dbSet.Remove(aplicativoEliminarToDelete);
            await _context.SaveChangesAsync();
            return aplicativoEliminarToDelete;
        }
    }
}
