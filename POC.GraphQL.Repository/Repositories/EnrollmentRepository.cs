using Microsoft.EntityFrameworkCore;
using POC.GraphQL.Repository.Data.Context;
using POC.GraphQL.Service.Interfaces.Repositories;
using POC.GraphQL.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.GraphQL.Repository.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        protected SchoolContext _schollContext;

        public EnrollmentRepository(SchoolContext schollContext) => _schollContext = schollContext;

        public async Task<List<Enrollment>> GetEnrollmentByStudentIdAsync(IEnumerable<int> studentsId)
        {
            var enrollments = await _schollContext.
                                    Enrollments.
                                    Include(a => a.Course).
                                    Where(x => studentsId.Contains(x.StudentID)).
                                    ToListAsync();

            return enrollments;
        }
    }
}
