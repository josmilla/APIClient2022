using APIClient.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIClient.Infrastructure.Data.Repositories
{
    public interface IAplicativoRepository
    {
        Task<Aplicativo> DeleteAsync(int id);
        Task<Aplicativo> GetAplicativoByIdAsync(int id);
                    
        Task<List<Aplicativo>> GetAplicativoAsync();
        Task<Aplicativo> InsertAsync(Aplicativo aplicativo);
        Task<Aplicativo> UpdateAsync(int id, Aplicativo aplicativo);
    }
}