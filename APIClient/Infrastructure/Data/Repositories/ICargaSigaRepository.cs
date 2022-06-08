using APIClient.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIClient.Infrastructure.Data.Repositories
{
    public interface ICargaSigaRepository
    {
        Task<CargaSiga> DeleteAsync(int id);
        Task<CargaSiga> GetCargaSigaByIdAsync(int id);

        Task <CargaSiga> GetCargaMatriculaUsuario(string matricula);
        Task<List<CargaSiga>> GetCargaSigaAsync();
        Task<CargaSiga> InsertAsync(CargaSiga cargasiga);
        Task<CargaSiga> UpdateAsync(int id, CargaSiga cargasiga);
    }
}