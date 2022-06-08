using APIClient.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIClient.Infrastructure.Data.Repositories
{
    public interface IPeriodoRepository
    {
        Task<Periodo> DeleteAsync(int id);
        Task<Periodo> GetPeriodoByIdAsync(int id);
                    
        Task<List<Periodo>> GetPeriodoAsync();
        Task<Periodo> InsertAsync(Periodo periodo);
        Task<Periodo> UpdateAsync(int id, Periodo periodo);
    }
}