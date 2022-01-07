using Microsoft.EntityFrameworkCore;
using POC.GraphQL.Repository.Data.Context;
using POC.GraphQL.Service.Interfaces.Repositories;
using POC.GraphQL.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.GraphQL.Repository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        protected SchoolContext _schollContext;

        public StudentRepository(SchoolContext schollContext) => _schollContext = schollContext;

        public async Task<List<Student>> GetAllAsync()
        {
            var students = await _schollContext.
                                    Students.
                                    Include(x => x.Enrollments).
                                    ThenInclude((y => y.Course)).
                                    ToListAsync();

            return students;
        }
    }
}
