﻿using GraphQL.Types;
using GraphStudy.Models;
using GraphStudy.Services;
using System.Collections.Generic;

namespace GraphStudy.Api.GraphQLServer.Schema
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(IUserService userService,IRelationshipService relationshipService)
        {
            //使用者編號
            Field(context => context.Id);
            //使用者名稱
            Field(context => context.Name);
            //朋友
            Field<ListGraphType<UserType>>(
                "friends",
                resolve: context => 
                {
                    List<int> friendsIds = relationshipService.GetFriendsIdsByUserId(context.Source.Id);
                    List<User> friends = new List<User>();
                    foreach (int friendId in friendsIds)
                    {
                        friends.Add(userService.GetUserById(friendId));
                    }
                    return friends;
                });
        }
    }
}
