using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraphStudy.Models;
using GraphStudy.SearchFriendsWebServer.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            //RequestString
            string GET_USER_URL = config["RequestURL:GetUserById"];
            string GET_RELATIONSHIP_URL = config["RequestURL:GetRelationShipById"];
            string FRIENDIDS = config["RequestURL:FriendsIds"];
            //GetUserById
            string response = await this.httpOperation.GetResponseContent(GET_USER_URL + userId.ToString());
            JObject result = JObject.Parse(response);
            //GetFriendsIds
            response = await this.httpOperation.GetResponseContent(GET_RELATIONSHIP_URL + userId + FRIENDIDS);
            List<int> friendsIds = JsonConvert.DeserializeObject<List<int>>(response);
            JArray friends= new JArray();
            //GetFriends
            foreach (int friendId in friendsIds)
            {
                response = await this.httpOperation.GetResponseContent(GET_USER_URL + friendId.ToString());
                friends.Add(JObject.Parse(response));
            }
            result["friends"] = friends;
            return Json(result);
        }
    }
}