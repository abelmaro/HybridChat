using HybridChat.Entities.DTO;
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
            UserDto user = _userService.GetUserById(userId);
            return new JsonResult(user);
        }

        [HttpPost]
        public async Task<JsonResult> CreateNewUser(string username)
        {
            return new JsonResult(await _userService.CreateNewUser(username));
        }
    }
}
