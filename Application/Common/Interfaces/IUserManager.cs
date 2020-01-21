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
        Task<AuthenticationResult> UpdateUserAsync(string id, UserVm userVm);
        Task<AuthenticationResult> LoginUserAsync(string UserName, string Password);
    }
}
