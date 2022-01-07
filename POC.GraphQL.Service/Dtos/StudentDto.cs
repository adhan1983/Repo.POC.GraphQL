using System;
using System.Collections.Generic;

namespace POC.GraphQL.Service.Dtos
{
    public class StudentDto
    {
        public int ID { get; set; }

        public string LastName { get; set; }
        
        public string FirstMidName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public  List<EnrollmentDto> Enrollments { get; set; }
    }
}
