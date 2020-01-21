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
    public class CreateUserCommand: IRequest<AuthenticationResult>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class Handler : IRequestHandler<CreateUserCommand, AuthenticationResult>
        {
            private readonly IUserManager _userManagerService;

            public Handler(IUserManager userManagerService)
            {
                _userManagerService = userManagerService;
            }

            public async Task<AuthenticationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                return await _userManagerService.CreateUserAsync(request.UserName, request.Email, request.Password).ConfigureAwait(true);
            }
        }
    }
}
