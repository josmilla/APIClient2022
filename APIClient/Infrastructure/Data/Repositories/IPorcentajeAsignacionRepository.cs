using APIClient.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIClient.Infrastructure.Data.Repositories
{
    public interface IPorcentajeAsignacionRepository
    {
        Task<PorcentajeAsignacion> DeleteAsync(int id);
        Task<PorcentajeAsignacion> GetPorcentajeAsignacionByIdAsync(int id);
                    
        Task<List<PorcentajeAsignacion>> GetPorcentajeAsignacionAsync();
        Task<PorcentajeAsignacion> InsertAsync(PorcentajeAsignacion porcentajeasignacion);
        Task<PorcentajeAsignacion> UpdateAsync(int id, PorcentajeAsignacion porcentajeasignacion);
    }
}