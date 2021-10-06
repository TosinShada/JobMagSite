using JobMagSite.Domain.Common;
using JobMagSite.Domain.Entities;
using JobMagSite.Service.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobMagSite.Service.Contract
{
    public interface IRepository
    {
        Task<Response<IEnumerable<PersonQueryResponse>>> GetPersons();
        Task<Response<PersonQueryResponse>> GetPersonById(long id);
        Task<Response<List<Student>>> GetStudents();

    }
}
