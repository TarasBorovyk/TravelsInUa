using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<Category>>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
        {
            private readonly IApplicationDbContext _context;

            public GetCategoriesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
            {
                return await _context.Categories.ToListAsync();
            }
        }
    }
}
