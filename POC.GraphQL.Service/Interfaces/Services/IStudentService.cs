using POC.GraphQL.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.GraphQL.Service.Interfaces.Services
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
    }
}
