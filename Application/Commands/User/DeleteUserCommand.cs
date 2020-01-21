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
    public class DeleteUserCommand : IRequest<AuthenticationResult>
    {
        public string Id { get; set; }

        public class Handler : IRequestHandler<DeleteUserCommand, AuthenticationResult>
        {
            private readonly IUserManager _userManagerService;

            public Handler(IUserManager userManagerService)
            {
                _userManagerService = userManagerService;
            }

            public async Task<AuthenticationResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                return await _userManagerService.DeleteUserAsync(request.Id).ConfigureAwait(true);
            }
        }
    }
}
