using GraphQL.Types;
using GraphStudy.Api.GraphQLServer.BusinessModels;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;

namespace GraphStudy.Api.GraphQLServer.Schema
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(IConfiguration config, HttpOperation httpOperation)
        {
            string GET_USER_URL_BASE = config["RequestURL:GetUserById"];
            //使用者編號
            Field(context => context.id);
            //使用者名稱
            Field(context => context.name);
            //朋友
            FieldAsync<ListGraphType<UserType>>(
                "friends",
                resolve: async context => 
                {
                    string GET_RELATIONSHIP_URL = String.Format(config["RequestURL:GetRelationShipById"],context.Source.id);
                    string response = await httpOperation.GetResponseContent(GET_RELATIONSHIP_URL);
                    string GET_USER_URL;
                    List<int> friendsIds = JsonConvert.DeserializeObject<List<int>>(response);
                    List<User> friends = new List<User>();
                    foreach (int friendId in friendsIds)
                    {
                        GET_USER_URL = String.Format(GET_USER_URL_BASE, friendId);
                        response = await httpOperation.GetResponseContent(GET_USER_URL);
                        User friend = JsonConvert.DeserializeObject<User>(response);
                        friends.Add(friend);
                    }
                    return friends;
                });
        }
    }
}
