using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.GraphQL.Service.Dtos;
using POC.GraphQL.Service.Interfaces.Repositories;
using POC.GraphQL.Service.Interfaces.Services;
using POC.GraphQL.Service.Models;

namespace POC.GraphQL.Service.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository) => _enrollmentRepository = enrollmentRepository;
        
        public async Task<ILookup<int, EnrollmentDto>> GetEnrollmentByStudentIdAsync(IEnumerable<int> studentsId)
        {
            var models = await _enrollmentRepository.GetEnrollmentByStudentIdAsync(studentsId);

            var dtos = models.Select(MapToEnrollmentDto()).ToList();

            return dtos.ToLookup(x => x.StudentId);
        }

        private static Func<Enrollment, EnrollmentDto> MapToEnrollmentDto()
        {
            return modelEnrollment => new EnrollmentDto()
            {
                Id = modelEnrollment.EnrollmentID,
                CourseId = modelEnrollment.CourseID,
                StudentId = modelEnrollment.StudentID,
                Course = new CourseDto()
                {
                    Id = modelEnrollment.Course.CourseID,
                    Title = modelEnrollment.Course.Title
                }
            };
        }
    }
}
