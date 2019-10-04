using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using GraphStudy.Api.GraphQLServer.BusinessModels;
using GraphStudy.Api.GraphQLServer.Services;

namespace GraphStudy.Api.GraphQLServer.Schema
{
    /// <summary>
    /// Query ObjectType
    /// </summary>
    public class QueryType : ObjectGraphType
    {
        public QueryType(IConfiguration config, HttpOperation httpOperation)
        {
            string GET_USER_URL_BASE = config["RequestURL:GetUserById"];
            //尋找對應編號的使用者
            FieldAsync<UserType>(
                "user",
                arguments: new QueryArguments(
                        new QueryArgument<IdGraphType> { Name = "id" }
                    ),
                resolve: async context =>
                {
                    int id = context.GetArgument<int>("id");
                    string GET_USER_URL = String.Format(GET_USER_URL_BASE,id);
                    string response = await httpOperation.GetResponseContent(GET_USER_URL);
                    User user = JsonConvert.DeserializeObject<User>(response);
                    return user;
                }
            );
        }
    }
}
