using APIClient.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIClient.Infrastructure.Data.Repositories
{
    public interface ICargaRepository
    {
        Task<Carga> DeleteAsync(int id);
        Task<Carga> GetCargaByIdAsync(int id);
                    
        Task<List<Carga>> GetCargaAsync();
        Task<Carga> InsertAsync(Carga carga);
        Task<Carga> UpdateAsync(int id, Carga carga);
    }
}