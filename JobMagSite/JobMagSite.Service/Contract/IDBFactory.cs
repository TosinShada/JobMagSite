using JobMagSite.Domain.Common;
using JobMagSite.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobMagSite.Service.Contract
{
    public interface IDBFactory
    {
        Task<IEnumerable<Person>> GetAllPersonAsync();
        Task<Person> GetByIdAsync(object id);
        Task<long> CreateAsync(Person entity);
        Task<bool> UpdateAsync(Person entity);
        Task<bool> DeleteAsync(object id);
        Task<bool> ExistAsync(object id);
    }
}
