using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using GraphStudy.Models;
using GraphStudy.SearchFriendsWebServer.Models;
using Microsoft.Extensions.Configuration;

namespace GraphStudy.SearchFriendsWebServer.Controllers
{
    public class UserController : Controller
    {
        private IHttpClientFactory httpClientFactory;

        private IConfiguration config;

        public UserController(IHttpClientFactory httpClientFactory,IConfiguration config)
        {
            this.httpClientFactory = httpClientFactory;
            this.config = config;
        }

        [HttpGet]
        public async Task<JsonResult> UserAndHisFriends(int userId)
        {
            string GET_USER_URL = config["RequestURL:GetUserById"];
            string GET_RELATIONSHIP_URL = config["RequestURL:GetRelationShipById"];
            var httpClient = httpClientFactory.CreateClient();
            //GetUserById
            var response = await httpClient.GetAsync(GET_USER_URL + userId.ToString());
            User userModel = await response.Content.ReadAsAsync<User>();
            //Initialize result model
            UserAndHisFriend userAndHisFriends = new UserAndHisFriend 
                {
                    user = userModel,
                    friends = new List<FriendInformation>()
                };
            //GetRelationshipById
            response = await httpClient.GetAsync(GET_RELATIONSHIP_URL + userId.ToString());
            List<Relationship> relationships = await response.Content.ReadAsAsync<List<Relationship>>();
            //SearchFriendsByRelationship
            foreach (Relationship relationship in relationships)
            {
                if (relationship.FirstUserId == userId)
                {
                    response = await httpClient.GetAsync(GET_USER_URL + relationship.SecondUserId.ToString()); 
                }
                else
                { 
                    response = await httpClient.GetAsync(GET_USER_URL + relationship.FirstUserId.ToString());
                }
                userModel = await response.Content.ReadAsAsync<User>();
                userAndHisFriends.friends.Add
                (
                    new FriendInformation
                    {
                        relationship = relationship,
                        FriendModel = userModel
                    }
                );
            }
            return Json(userAndHisFriends);
        }
    }
}