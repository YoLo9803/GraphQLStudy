using GraphQL;

namespace GraphStudy.Api.GraphQLServer.Schema
{
    public class GraphStudySchema : GraphQL.Types.Schema
    {
        public GraphStudySchema(IDependencyResolver dependencyResolver, QueryType queryType)
        {
            DependencyResolver = dependencyResolver;
            Query = queryType;
        }
    }
}
