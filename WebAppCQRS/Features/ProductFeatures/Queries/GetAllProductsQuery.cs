using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAppCQRS.Context;
using WebAppCQRS.Models;

namespace WebAppCQRS.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IReadOnlyList<Product>>, IRequest<Product>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyList<Product>>
        {
            private readonly IApplicationContext _context;

            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IReadOnlyList<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync(cancellationToken);
                if (productList == null)
                {
                    return null;
                }

                return productList;
            }
        }
    }
}
