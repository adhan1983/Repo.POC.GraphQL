using POC.GraphQL.Service.Dtos;
using POC.GraphQL.Service.Interfaces.Repositories;
using POC.GraphQL.Service.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POC.GraphQL.Service.Models;

namespace POC.GraphQL.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository) => _studentRepository = studentRepository;

        public async Task<List<StudentDto>> GetStudentAllAsync()
        {
            var models = await _studentRepository.GetAllStudentAsync();

            var studentsDtos = models.
                Select(model =>
                    mappingToStudentDto(model)).
                OrderBy(x => x.FirstMidName).
                ToList();

            return studentsDtos;
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var model = await _studentRepository.GetStudentByIdAsync(id);

            var studentDto = mappingToStudentDto(model);

            return studentDto;
        }

        private static StudentDto mappingToStudentDto(Student model)
        {
            return new StudentDto()
            {
                ID = model.ID,
                FirstMidName = model.FirstMidName,
                LastName = model.LastName,
                EnrollmentDate = model.EnrollmentDate,
                Enrollments =
                    model.
                        Enrollments.
                        Select(
                            (
                                modelEnrollment => new EnrollmentDto()
                                {
                                    Id = modelEnrollment.EnrollmentID,
                                    CourseId = modelEnrollment.CourseID,
                                    StudentId = modelEnrollment.StudentID,
                                    Course = new CourseDto()
                                    {
                                        Id = modelEnrollment.Course.CourseID,
                                        Title = modelEnrollment.Course.Title
                                    }
                                }
                            )).ToList()


            };
        }

    }
}
