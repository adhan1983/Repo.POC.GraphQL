using GraphQL.Types;
using POC.GraphQL.Service.Dtos;

namespace POC.GraphQL.Api.GraphQL.GraphQLTypes
{
    public class EnrollmentType : ObjectGraphType<EnrollmentDto>
    {
        public EnrollmentType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the account object.");
            Field(x => x.CourseId).Description("Description property from the account object.");
            Field(x => x.StudentId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
        }
    }
}
