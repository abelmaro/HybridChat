using HybridChat.Data;
using HybridChat.Entities;
using HybridChat.Entities.DTO;
using HybridChat.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HybridChat.Services
{
    public class UserService : IUserService
    {
        private readonly ChatContext _context;

        public UserService( ChatContext chatContext) {
            _context = chatContext;
        }

        public UserDto GetUserById(Guid userId) {

            User user = _context.Users.FirstOrDefault(x => x.UserId == userId);

            UserDto response = new UserDto()
            {
                Username = user.Username
            };

            return response;
        }

        public async Task<Guid> CreateNewUser(string username) {

            User newUser = new User() { 
                Username = username,
                UserId = Guid.NewGuid()
            };

            await _context.AddAsync(newUser);
            _context.SaveChanges();
            return newUser.UserId;
        }
    }
}
