using GraphQL.Types;
using GraphQL.Utilities;
using POC.GraphQL.Api.GraphQL.GraphQLQueries;
using System;

namespace POC.GraphQL.Api.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
        }
    }
}
