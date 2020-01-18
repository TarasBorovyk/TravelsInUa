using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<Product>>
    {
        public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
        {
            private readonly IApplicationDbContext _context;

            public GetProductsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                return await _context.Products.ToListAsync();
            }
        }
    }
}
