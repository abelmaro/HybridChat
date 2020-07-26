using HybridChat.Entities.DTO;
using System;
using System.Threading.Tasks;

namespace HybridChat.Services.Interfaces
{
    public partial interface IUserService
    {
        UserDto GetUserById(Guid userId);

        Task<Guid> CreateNewUser(string username);
    }
}
