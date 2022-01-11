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

        public async Task<List<Student>> GetAllStudentAsync()
        {
            var students = await _schollContext.
                                            Students.ToListAsync();
            
            return students;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _schollContext.
                                Students.
                                FirstAsync(x => x.ID == id);

            return student;
        }
    }
}
