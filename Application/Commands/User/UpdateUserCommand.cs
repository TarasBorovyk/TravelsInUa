using Infrastructure.Common.Interfaces;
using Infrastructure.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.User
{
    public class UpdateUserCommand : IRequest<AuthenticationResult>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, AuthenticationResult>
        {
            private readonly IUserManager _userManagerService;

            public UpdateUserCommandHandler(IUserManager userManagerService)
            {
                _userManagerService = userManagerService;
            }

            public async Task<AuthenticationResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                return await _userManagerService.UpdateUserAsync(request.Id, request.UserName, request.Email, request.Password).ConfigureAwait(true);
            }
        }
    }
}
