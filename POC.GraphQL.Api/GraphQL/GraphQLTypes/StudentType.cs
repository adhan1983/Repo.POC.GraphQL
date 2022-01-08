using GraphQL.Types;
using POC.GraphQL.Service.Dtos;

namespace POC.GraphQL.Api.GraphQL.GraphQLTypes
{
    public class StudentType : ObjectGraphType<StudentDto>
    {
        public StudentType()
        {
            Field(x => x.ID, type: typeof(IdGraphType)).Description("Id property from the student object.");
            Field(x => x.FirstMidName).Description("FirstMidName property from the student object.");
            Field(x => x.LastName).Description("LastName property from the student object.");
        }
    }
}
