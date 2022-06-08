using APIClient.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIClient.Infrastructure.Data.Repositories
{
    public interface ISquadRepository
    {

        Task<List<Squad>> GetSquadAsync();
        Task<Squad> GetSquadByIdAsync(int id);
        Task<Squad> InsertAsync(Squad squad);
        Task<Squad> UpdateAsync(int id, Squad squad);
        Task<Squad> DeleteAsync(int id);
    }
}