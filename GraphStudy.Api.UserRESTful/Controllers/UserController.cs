using Microsoft.AspNetCore.Mvc;
using GraphStudy.Services;
using GraphStudy.Models;

namespace GraphStudy.Api.UserRESTful.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            //DI
            this.userService = userService;
        }

        [HttpGet]
        [Route("api/[Controller]/{userId}")]
        public User GetUserById(int userId)
        {
            return userService.GetUserById(userId);
        }
    }
}