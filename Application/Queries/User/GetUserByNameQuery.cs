using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.User
{
    public class GetUserByNameQuery: IRequest<UserVm>
    {
        public string UserName { get; set; }

        public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, UserVm>
        {
            private readonly IUserManager _userManager;

            public GetUserByNameQueryHandler(IUserManager userManager)
            {
                _userManager = userManager;
            }
            public async Task<UserVm> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
            {
                return await _userManager.GetUserByNameAsync(request.UserName).ConfigureAwait(true);
            }
        }
    }
}
