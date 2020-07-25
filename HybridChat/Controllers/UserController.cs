using HybridChat.Entities;
using HybridChat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HybridChat.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet]
        public JsonResult GetUserById(Guid userId) {
            Task<User> user = _userService.GetUserById(userId);
            return new JsonResult(user);
        }

        [HttpPut]
        public JsonResult CreateNewUser(string username)
        {
            return new JsonResult(_userService.CreateNewUser(username));
        }
    }
}
