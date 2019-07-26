using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraphStudy.Models;
using GraphStudy.SearchFriendsWebServer.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GraphStudy.SearchFriendsWebServer.Services;
using System;

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
            string GET_USER_URL_BASE = config["RequestURL:GetUserById"];
            string GET_USER_URL = String.Format(GET_USER_URL_BASE,userId);
            string GET_RELATIONSHIP_URL = String.Format(config["RequestURL:GetRelationShipById"],userId);
            //GetUserById
            string response = await this.httpOperation.GetResponseContent(GET_USER_URL);
            JObject result = JObject.Parse(response);
            //GetFriendsIds
            response = await this.httpOperation.GetResponseContent(GET_RELATIONSHIP_URL);
            List<int> friendsIds = JsonConvert.DeserializeObject<List<int>>(response);
            JArray friends= new JArray();
            //GetFriends
            foreach (int friendId in friendsIds)
            {
                GET_USER_URL = String.Format(GET_USER_URL_BASE,friendId);
                response = await this.httpOperation.GetResponseContent(GET_USER_URL);
                friends.Add(JObject.Parse(response));
            }
            result["friends"] = friends;
            return Json(result);
        }
    }
}