using APIClient.Infrastructure.Data.Entities;
using APIClient.Infrastructure.Specification;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIClient.Infrastructure.Data.Repositories
{
    public interface IAsignacionRepository<Asignacion> where Asignacion : class
    {
        Task<Asignacion> DeleteAsync(int id);
        
       Task<Asignacion> GetAsignacionByIdAsync(int id);

        //IEnumerable<Asignacion> FindWithSpecificationPattern(ISpecification<Asignacion> specification = null);
        IEnumerable<Asignacion> FindWithSpecificationPattern(ISpecification<Asignacion> specification = null);
        //Task<List<Asignacion>> FindWithSpecificationPattern(ISpecification<Asignacion> specification = null);

        Task<List<Asignacion>> GetAsignacionMatriculaChapterByIdAsync(string matricula);

        Task<Asignacion> GetSumaParticipacion(string matriculasuma);

        Task<List<Asignacion>> GetAsignacionMatriculausuarioByIdAsync(string usuario);
        Task<List<Asignacion>> GetAsignacionAsync();
        Task<Asignacion> InsertAsync(Asignacion asignacion);
        Task<Asignacion> UpdateAsync(int id, Asignacion asignacion);
    }
}