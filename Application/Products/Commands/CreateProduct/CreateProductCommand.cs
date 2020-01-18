using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Commands.CreateProduct
{
    public partial class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var entity = new Product()
                {
                    Name = request.Name,
                    Price = request.Price,
                    Description = request.Description,
                    Category = _context.Categories.Where(c => c.CategoryId == request.CategoryId).FirstOrDefault()
                };
                
                _context.Products.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }
        }
    }
}
