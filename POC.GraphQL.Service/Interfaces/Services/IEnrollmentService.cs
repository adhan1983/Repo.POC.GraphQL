using System.Collections.Generic;
using POC.GraphQL.Service.Dtos;
using System.Linq;
using System.Threading.Tasks;

namespace POC.GraphQL.Service.Interfaces.Services
{
    public interface IEnrollmentService
    {
        Task<ILookup<int, EnrollmentDto>> GetEnrollmentByStudentIdAsync(IEnumerable<int> studentsId);
    }
}
