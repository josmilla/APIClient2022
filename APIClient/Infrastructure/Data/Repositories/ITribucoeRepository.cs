using APIClient.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIClient.Infrastructure.Data.Repositories
{
    public interface ITribucoeRepository
    {
        Task<Tribucoe> DeleteAsync(int id);
        Task<Tribucoe> GetTribucoeByIdAsync(int id);
                    
        Task<List<Tribucoe>> GetTribucoeAsync();
        Task<Tribucoe> InsertAsync(Tribucoe tribucoe);
        Task<Tribucoe> UpdateAsync(int id, Tribucoe tribucoe);
    }
}