using Microsoft.EntityFrameworkCore;
using APIClient.Infrastructure.Data.Contexts;
using APIClient.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace APIClient.Infrastructure.Data.Repositories
{
    public class PorcentajeAsignacionRepository : IPorcentajeAsignacionRepository
    {
        private AsignacionContext _context;
        private DbSet<PorcentajeAsignacion> _dbSet;
        public PorcentajeAsignacionRepository(AsignacionContext context)
        {
            _context = context;
            _dbSet = context.Set<PorcentajeAsignacion>();
        }

        public async Task<List<PorcentajeAsignacion>> GetPorcentajeAsignacionAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<PorcentajeAsignacion> GetPorcentajeAsignacionByIdAsync(int id)
        {
            return await _dbSet.Where(p => p.IdRol == id).FirstOrDefaultAsync();
        }

        

        public async Task<PorcentajeAsignacion> InsertAsync(PorcentajeAsignacion rol)
        {
            _dbSet.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }
        public async Task<PorcentajeAsignacion> UpdateAsync(int id, PorcentajeAsignacion porcentajeasignacion)
        {
            PorcentajeAsignacion actualizarToUpdate = await GetPorcentajeAsignacionByIdAsync(id);
            actualizarToUpdate.IdCarga = porcentajeasignacion.IdCarga;
            actualizarToUpdate.IdPeriodo = porcentajeasignacion.IdPeriodo;
            actualizarToUpdate.IdRol = porcentajeasignacion.IdRol;
            actualizarToUpdate.IdAplicativo = porcentajeasignacion.IdAplicativo;
            actualizarToUpdate.Porcentaje = porcentajeasignacion.Porcentaje;
            actualizarToUpdate.UsuarioRegistro = porcentajeasignacion.UsuarioRegistro;
            actualizarToUpdate.FechaModificacion = porcentajeasignacion.FechaModificacion;
            actualizarToUpdate.UsuarioModificacion = porcentajeasignacion.UsuarioModificacion;
            actualizarToUpdate.Estado = porcentajeasignacion.Estado;
          


            _dbSet.Update(actualizarToUpdate);
            await _context.SaveChangesAsync();

            return actualizarToUpdate;
        }

        public async Task<PorcentajeAsignacion> DeleteAsync(int id)
        {
            PorcentajeAsignacion eliminarToDelete = await GetPorcentajeAsignacionByIdAsync(id);

            _dbSet.Remove(eliminarToDelete);
            await _context.SaveChangesAsync();
            return eliminarToDelete;
        }
    }
}
