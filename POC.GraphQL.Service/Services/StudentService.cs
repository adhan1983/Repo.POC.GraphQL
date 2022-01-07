using POC.GraphQL.Service.Dtos;
using POC.GraphQL.Service.Interfaces.Repositories;
using POC.GraphQL.Service.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.GraphQL.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository) => _studentRepository = studentRepository;

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var models = await _studentRepository.GetAllAsync();

            var studentsDtos = models.
                Select(model =>
                    new StudentDto()
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


                    }).
                OrderBy(x => x.FirstMidName).
                ToList();

            return studentsDtos;
        }
    }
}
