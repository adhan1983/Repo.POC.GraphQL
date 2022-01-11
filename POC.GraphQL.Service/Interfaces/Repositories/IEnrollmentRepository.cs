using POC.GraphQL.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.GraphQL.Service.Interfaces.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<List<Enrollment>> GetEnrollmentByStudentIdAsync(IEnumerable<int> studentsId);
    }
}
