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
    public class RefreshTokenCommand: IRequest<AuthenticationResult>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthenticationResult>
        {
            public IUserManager _userManager { get; set; }

            public RefreshTokenCommandHandler(IUserManager userManager)
            {
                _userManager = userManager;
            }

            public async Task<AuthenticationResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
            { 
                var authResponse = await _userManager.RefreshTokenAsync(request.Token, request.RefreshToken).ConfigureAwait(false);

                if (!authResponse.Success)
                {
                    return new AuthenticationResult
                    {
                        Errors = authResponse.Errors
                    };
                }

                return new AuthenticationResult
                {
                    Success = true,
                    Token = authResponse.Token,
                    RefreshToken = authResponse.RefreshToken
                };
            }
        }
    }
}
