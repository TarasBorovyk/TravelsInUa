using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.User
{
    public class LoginUserCommand : IRequest<AuthenticationResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthenticationResult>
        {
            private readonly IUserManager _userManagerService;

            public LoginUserCommandHandler(IUserManager userManagerService)
            {
                _userManagerService = userManagerService;
            }

            public async Task<AuthenticationResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                return await _userManagerService.LoginUserAsync(request.UserName, request.Password).ConfigureAwait(true);
            }
        }
    }
}
