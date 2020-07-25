using HybridChat.Entities;
using HybridChat.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace HybridChat.Services
{
    public class UserService : IUserService
    {
        public async Task<User> GetUserById(Guid userId) {
            return new User();
        }

        public Guid CreateNewUser(string username) {
            return Guid.NewGuid();
        }
    }
}
