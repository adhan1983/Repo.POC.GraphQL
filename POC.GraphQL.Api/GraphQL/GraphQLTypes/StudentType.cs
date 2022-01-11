using GraphQL.DataLoader;
using GraphQL.Types;
using POC.GraphQL.Service.Dtos;
using POC.GraphQL.Service.Interfaces.Services;

namespace POC.GraphQL.Api.GraphQL.GraphQLTypes
{
    public class StudentType : ObjectGraphType<StudentDto>
    {
        public StudentType(IEnrollmentService enrollmentService, IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.ID, type: typeof(IdGraphType)).Description("Id property from the student object.");
            Field(x => x.FirstMidName).Description("FirstMidName property from the student object.");
            Field(x => x.LastName).Description("LastName property from the student object.");
            Field<ListGraphType<EnrollmentType>>(
                "enrollments",
                resolve: context =>
                {
                    var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<int, EnrollmentDto>(
                        "GetEnrollmentByStudentIdAsync", enrollmentService.GetEnrollmentByStudentIdAsync);

                    return loader.LoadAsync(context.Source.ID);

                }

            );
        }
    }
}
