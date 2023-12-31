using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Data.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonModel>> GetAllAsync();
        Task<PersonModel> GetByIdAsync(int id);
        Task AddAsync(PersonModel person);
        Task UpdateAsync(PersonModel person);
        Task DeleteAsync(int id);
    }
}
