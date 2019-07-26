using GraphQL.Types;
using GraphStudy.Services;

namespace GraphStudy.Api.GraphQLServer.Schema
{
    /// <summary>
    /// Query ObjectType
    /// </summary>
    public class QueryType : ObjectGraphType
    {
        public QueryType(IUserService userService)
        {
            //尋找對應編號的使用者
            Field<UserType>(
                "user",
                arguments: new QueryArguments(
                        new QueryArgument<IdGraphType> { Name = "id" }
                    ),
                resolve: context =>
                {
                    int id = context.GetArgument<int>("id");
                    return userService.GetUserById(id);
                }
            );
        }
    }
}
