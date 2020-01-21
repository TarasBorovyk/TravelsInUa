using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthenticationResult> CreateUserAsync(string userName, string email, string password)
        {
            /*var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this email address already exists" },
                    Success = false
                };
            }*/

            //var newUserId = Guid.NewGuid();
            var newUser = new ApplicationUser
            {
                //Id = newUserId.ToString(),
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

        public async Task<AuthenticationResult> UpdateUserAsync(string id, UserVm userVm)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exists" }
                };
            }
            user.UserName = userVm.UserName;
            user.Email = userVm.Email;

            var newPassword = _userManager.PasswordHasher.HashPassword(user, userVm.Password);
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
            // TODO SignIn
            var authResult = _signInManager.SignInAsync(user, false);

            return new AuthenticationResult { Success = true };
        }
    }
}
