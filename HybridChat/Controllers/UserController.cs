using HybridChat.Entities;
using HybridChat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HybridChat.Controllers
{
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public JsonResult GetUserById(Guid userId) {
            Task<User> user = _userService.GetUserById(userId);
            return new JsonResult(user);
        }

        [HttpPut]
        [Route("api/[controller]/[action]")]
        public JsonResult CreateNewUser(string username)
        {
            return new JsonResult(_userService.CreateNewUser(username));
        }
    }
}
