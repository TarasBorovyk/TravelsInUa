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
    public class LogoutUserCommand : IRequest<AuthenticationResult>
    {
        public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand, AuthenticationResult>
        {
            private readonly IUserManager _userManager;

            public LogoutUserCommandHandler(IUserManager userManager)
            {
                _userManager = userManager;
            }

            public async Task<AuthenticationResult> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
            {
                return await _userManager.LogoutUserAsync().ConfigureAwait(true);
            }
        }
    }
}
