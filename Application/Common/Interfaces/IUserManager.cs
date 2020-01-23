using Application.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<AuthenticationResult> CreateUserAsync(string userName, string email, string password);

        Task<AuthenticationResult> DeleteUserAsync(string userId);
        Task<AuthenticationResult> UpdateUserAsync(string id, string UserName, string Email, string Password);
        Task<AuthenticationResult> LoginUserAsync(string UserName, string Password);
        Task<AuthenticationResult> LogoutUserAsync();
        Task<AuthenticationResult> RefreshTokenAsync(string Toke, string RefreshToken);
        Task<UserDto> GetUserByNameAsync(string Name);
    }
}
