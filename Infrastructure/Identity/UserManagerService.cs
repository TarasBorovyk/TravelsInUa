using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserManagerService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResult> CreateUserAsync(string userName, string email, string password)
        {
            var newUser = new ApplicationUser
            {
                Email = email,
                UserName = userName
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description),
                    Success = false
                };
            }

            return new AuthenticationResult { Success = true };
        }

        public async Task<AuthenticationResult> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);
            
            if(user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exists" }
                };
            }

            var deletedUser =  await _userManager.DeleteAsync(user);
            if(!deletedUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = deletedUser.Errors.Select(x => x.Description)
                };
            }

            return new AuthenticationResult { Success = true };
        }

        public async Task<AuthenticationResult> UpdateUserAsync(string id, string UserName, string Email, string Password)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exists" }
                };
            }
            user.UserName = UserName;
            user.Email = Email;

            var newPassword = _userManager.PasswordHasher.HashPassword(user, Password);
            user.PasswordHash = newPassword;

            var result = await _userManager.UpdateAsync(user);
            if(!result.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = result.Errors.Select(x => x.Description)
                };
            }
            return new AuthenticationResult { Success = true };
        }

        public async Task<AuthenticationResult> LoginUserAsync(string UserName, string Password)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exists" }
                };
            }
            var authResult = await _signInManager.CheckPasswordSignInAsync(user, Password, false);
           
            if(!authResult.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Unable to login" }
                };
            }

            await _signInManager.SignInAsync(user, false);

            return new AuthenticationResult { Success = true };
        }

        public async Task<AuthenticationResult> LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();

            return new AuthenticationResult { Success = true };
        }

        public async Task<UserVm> GetUserByNameAsync(string Name)
        {
            var user = await _userManager.FindByNameAsync(Name);
            if (user != null)
                return new UserVm { Id = user.Id, Email = user.Email, UserName = user.UserName, Password = user.PasswordHash };
            return null;
        }
    }
}
