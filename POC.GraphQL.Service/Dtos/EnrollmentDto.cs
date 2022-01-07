namespace POC.GraphQL.Service.Dtos
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public CourseDto Course { get; set; }
    }
}
