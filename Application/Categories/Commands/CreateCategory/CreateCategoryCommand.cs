using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.Commands.CreateCategory
{
    public partial class CreateCategoryCommand : IRequest<int>
    {
        public string CategoryName { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateCategoryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var entity = new Category()
                {
                    CategoryName = request.CategoryName
                };

                _context.Categories.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.CategoryId;
            }
        }
    }
}
