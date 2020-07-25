using HybridChat.Entities;
using System;
using System.Threading.Tasks;

namespace HybridChat.Services.Interfaces
{
    public partial interface IUserService
    {
        Task<User> GetUserById(Guid userId);

        Guid CreateNewUser(string username);
    }
}
