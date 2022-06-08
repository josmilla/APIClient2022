using APIClient.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIClient.Infrastructure.Data.Repositories
{
    public interface ILoginRepository
    {
        Task<Login> DeleteAsync(int id);
        Task<Login> GetLoginByIdAsync(int id);
                    
        Task<List<Login>> GetLoginAsync();
        Task<Login> InsertAsync(Login login);
        Task<Login> UpdateAsync(int id, Login login);
    }
}