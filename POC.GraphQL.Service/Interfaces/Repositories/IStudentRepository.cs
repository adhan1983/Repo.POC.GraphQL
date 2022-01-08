using POC.GraphQL.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.GraphQL.Service.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentAsync();

        Task<Student> GetStudentByIdAsync(int id);
    }
}
