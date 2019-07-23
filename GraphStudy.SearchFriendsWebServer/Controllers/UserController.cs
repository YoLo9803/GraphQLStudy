using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraphStudy.Models;
using GraphStudy.SearchFriendsWebServer.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using GraphStudy.SearchFriendsWebServer.Services;

namespace GraphStudy.SearchFriendsWebServer.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration config;

        private readonly HttpOperation httpOperation;

        public UserController(IConfiguration config, HttpOperation httpOperation)
        {
            this.config = config;
            this.httpOperation = httpOperation;
        }

        [HttpGet]
        public async Task<JsonResult> UserAndHisFriends(int userId)
        {
            string GET_USER_URL = config["RequestURL:GetUserById"];
            string GET_RELATIONSHIP_URL = config["RequestURL:GetRelationShipById"];
            //GetUserById
            string response = await httpOperation.GetResponseContent(GET_USER_URL + userId.ToString());
            User userModel = JsonConvert.DeserializeObject<User>(response);
            //Initialize result model
            UserAndHisFriends userAndHisFriends = new UserAndHisFriends
                {
                    user = userModel,
                    friends = new List<FriendInformation>()
                };
            //GetRelationshipById
            string relationshipResponse = await httpOperation.GetResponseContent(GET_RELATIONSHIP_URL + userId);
            List<Relationship> relationships = JsonConvert.DeserializeObject<List<Relationship>>(relationshipResponse);
            //SearchFriendsByRelationship
            foreach (Relationship relationship in relationships)
            {
                if (relationship.FirstUserId == userId)
                    response = await httpOperation.GetResponseContent(
                        GET_USER_URL + relationship.SecondUserId.ToString()); 
                else
                    response = await httpOperation.GetResponseContent(
                        GET_USER_URL + relationship.FirstUserId.ToString());
                userModel = JsonConvert.DeserializeObject<User>(response);
                userAndHisFriends.friends.Add(new FriendInformation
                                                {
                                                    relationship = relationship,
                                                    FriendModel = userModel
                                                });
            }
            return Json(userAndHisFriends);
        }
    }
}